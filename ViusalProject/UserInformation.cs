using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ViusalProject
{
    public partial class UserInformation : Form

    {
        public UserInformation()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // OpenFileDialog ile resim seçme penceresini açıyoruz
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen resmin yolunu alıyoruz
                string imagePath = openFileDialog.FileName;

                // Resmi PictureBox'ta gösteriyoruz
                pictureBoxProfile.Image = Image.FromFile(imagePath);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Profil resmi seçilmediyse hata mesajı ver
            if (pictureBoxProfile.Image == null)
            {
                MessageBox.Show("Lütfen önce bir resim seçin.");
                return;
            }

            // Giriş yapan kullanıcının e-posta adresini al
            string currentUserEmail = Login.CurrentUser.Username; // Login formundaki CurrentUser sınıfından e-posta adresi alınıyor
            if (string.IsNullOrEmpty(currentUserEmail))
            {
                MessageBox.Show("Kullanıcı e-posta bilgisi alınamadı!");
                return;
            }

            try
            {
                // Resmi byte dizisine dönüştürme
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBoxProfile.Image.Save(ms, pictureBoxProfile.Image.RawFormat);
                    byte[] imageBytes = ms.ToArray();

                    
                    using (MySqlConnection connection = Conn.GetConnection())
                    {
                        connection.Open();

                        string query = "UPDATE emmployees SET profile_picture = @ProfilePicture WHERE email = @Email";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ProfilePicture", imageBytes);
                            command.Parameters.AddWithValue("@Email", currentUserEmail);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Profil resmi başarıyla yüklendi.");
                            }
                            else
                            {
                                MessageBox.Show("Profil resmi yüklenemedi. Lütfen bilgileri kontrol edin.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void UserInformation_Load(object sender, EventArgs e)
        {
            LoadUserData();

            // Giriş yapan kullanıcının e-posta adresini al
            string currentUserEmail = Login.CurrentUser.Username;

            if (string.IsNullOrEmpty(currentUserEmail))
            {
                MessageBox.Show("Kullanıcı e-posta bilgisi alınamadı!");
                return;
            }

            try
            {
                // conn sınıfından bağlantı al
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // Kullanıcının adını, soyadını ve fotoğrafını almak için sorgu
                    string query = "SELECT name, surname, profile_picture FROM emmployees WHERE email = @Email";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", currentUserEmail);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Veritabanından adı ve soyadı al
                                string name = reader["name"].ToString();
                                string surname = reader["surname"].ToString();
                                lblNameSurname.Text = $"{name} {surname}";

                                // Profil fotoğrafını al
                                if (!Convert.IsDBNull(reader["profile_picture"]))
                                {
                                    byte[] imageBytes = (byte[])reader["profile_picture"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        pictureBoxProfile.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    // Eğer kullanıcı fotoğraf yüklememişse varsayılan bir resim göster
                                    string defaultImagePath = Path.Combine(Application.StartupPath, "default_profile.png");
                                    if (File.Exists(defaultImagePath))
                                    {
                                        pictureBoxProfile.Image = Image.FromFile(defaultImagePath);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                            }
                        }
                    }
                    pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void LoadUserData()
        {
            try
            {
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // Veriyi çeken SQL sorgusu
                    string query = @"
                SELECT e.name, e.surname, e.email, e.phone_number, u.password 
                FROM emmployees e 
                JOIN user u ON e.email = u.username 
                WHERE e.email = @Email";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Giriş yapan kullanıcının email adresini ekle
                        command.Parameters.AddWithValue("@Email", Login.CurrentUser.Username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Alanları doldur
                                textName.Text = reader["name"].ToString();
                                textSurname.Text = reader["surname"].ToString();
                                textEmail.Text = reader["email"].ToString();
                                textTel.Text = reader["phone_number"].ToString();
                                textPass.Text = reader["password"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            PanelUser.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // `emmployees` tablosu için güncelleme sorgusu
                    string updateEmployeeQuery = @"
            UPDATE emmployees 
            SET name = @Name, 
                surname = @Surname, 
                phone_number = @PhoneNumber,
                birth_date = @BirthDate
            WHERE email = @OldEmail";

                    // `user` tablosu için güncelleme sorgusu
                    string updateUserQuery = @"
            UPDATE user 
            SET password = @Password 
            WHERE username = @OldEmail";

                    // Kullanıcı bilgilerini al
                    string oldEmail = Login.CurrentUser.Username;
                    string newName = textName.Text.Trim();
                    string newSurname = textSurname.Text.Trim();
                    string newPhone = textTel.Text.Trim();
                    string newPassword = textPass.Text.Trim();
                    DateTime newBirthDate = birth_date.Value.Date; // DateTimePicker kontrolünden tarih alınır

                    // Tüm alanların dolu olup olmadığını kontrol et
                    if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newSurname) ||
                        string.IsNullOrWhiteSpace(newPhone) || string.IsNullOrWhiteSpace(newPassword))
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurun!");
                        return;
                    }

                    // `emmployees` tablosunu güncelle
                    using (MySqlCommand updateEmployeeCommand = new MySqlCommand(updateEmployeeQuery, connection))
                    {
                        updateEmployeeCommand.Parameters.AddWithValue("@Name", newName);
                        updateEmployeeCommand.Parameters.AddWithValue("@Surname", newSurname);
                        updateEmployeeCommand.Parameters.AddWithValue("@PhoneNumber", newPhone);
                        updateEmployeeCommand.Parameters.AddWithValue("@BirthDate", newBirthDate);
                        updateEmployeeCommand.Parameters.AddWithValue("@OldEmail", oldEmail);

                        int employeeRowsAffected = updateEmployeeCommand.ExecuteNonQuery();
                        if (employeeRowsAffected == 0)
                        {
                            MessageBox.Show("Kullanıcı bilgileri güncellenirken bir hata oluştu!");
                            return;
                        }
                    }

                    // `user` tablosunu güncelle
                    using (MySqlCommand updateUserCommand = new MySqlCommand(updateUserQuery, connection))
                    {
                        updateUserCommand.Parameters.AddWithValue("@Password", newPassword);
                        updateUserCommand.Parameters.AddWithValue("@OldEmail", oldEmail);

                        int userRowsAffected = updateUserCommand.ExecuteNonQuery();
                        if (userRowsAffected == 0)
                        {
                            MessageBox.Show("Kullanıcı şifresi güncellenirken bir hata oluştu!");
                            return;
                        }
                    }

                    // Güncelleme işlemi başarılı
                    MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi!");
                    MainPage main = new MainPage();
                    main.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PanelUser.Visible = false;
        }

        private void PanelUser_Paint(object sender, PaintEventArgs e)
        {
            LoadUserData();

            // Giriş yapan kullanıcının e-posta adresini al
            string currentUserEmail = Login.CurrentUser.Username;

            if (string.IsNullOrEmpty(currentUserEmail))
            {
                MessageBox.Show("Kullanıcı e-posta bilgisi alınamadı!");
                return;
            }

            try
            {
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // Kullanıcının adını, soyadını ve fotoğrafını almak için sorgu
                    string query = "SELECT name, surname, profile_picture, birth_date FROM emmployees WHERE email = @Email";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", currentUserEmail);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Veritabanından adı ve soyadı al
                                string name = reader["name"].ToString();
                                string surname = reader["surname"].ToString();
                                labelNameSurname.Text = $"{name} {surname}";

                                // Profil fotoğrafını al
                                if (!Convert.IsDBNull(reader["profile_picture"]))
                                {
                                    byte[] imageBytes = (byte[])reader["profile_picture"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        pictureCircleBox.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    // Eğer kullanıcı fotoğraf yüklememişse varsayılan bir resim göster
                                    string defaultImagePath = Path.Combine(Application.StartupPath, "default_profile.png");
                                    if (File.Exists(defaultImagePath))
                                    {
                                        pictureCircleBox.Image = Image.FromFile(defaultImagePath);
                                    }
                                }

                                if (!Convert.IsDBNull(reader["birth_date"]))
                                {
                                    DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);
                                    int age = DateTime.Now.Year - birthDate.Year;

                                    // Eğer doğum günü yılın ilerleyen bir günündeyse yaşı bir azalt
                                    if (DateTime.Now < birthDate.AddYears(age))
                                    {
                                        age--;
                                    }

                                    textAge.Text = age.ToString();
                                }
                                else
                                {
                                    textAge.Text = "Bilinmiyor";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                            }
                        }
                    }
                    string userInfoQuery = @"SELECT e.name, e.surname, e.email, e.phone_number, u.password 
                                    FROM emmployees e 
                                    JOIN user u ON e.email = u.username 
                                    WHERE e.email = @Email";

                    using (MySqlCommand command = new MySqlCommand(userInfoQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email", currentUserEmail);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Alanları doldur
                                txtName.Text = reader["name"].ToString();
                                txtSurname.Text = reader["surname"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtTel.Text = reader["phone_number"].ToString();
                                txtPass.Text = reader["password"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
      
       