using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static ViusalProject.Login;

namespace ViusalProject
{
    public partial class AdminDashboard : Form
    {
        private string adminName;
        private string adminSurname;
        private byte[] adminProfilePicture;

        public AdminDashboard(string name, string surname, byte[] profilePicture)
        {
            InitializeComponent();
            adminName = name;
            adminSurname = surname;
            adminProfilePicture = profilePicture;
            panelMemberUpdate.Visible = true;
            PanelAdmin.Visible = true;
            panelHealtData.Visible = true;
            LoadTotalUser();
            LoadAverageWeight();
            LoadWeeklyStepAverage();
            LoadWeeklyPulseAverage();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            lblNameSurname.Text = $"{adminName} {adminSurname}";

            if (adminProfilePicture != null)
            {
                using (MemoryStream ms = new MemoryStream(adminProfilePicture))
                {
                    pictureBoxProfile.Image = Image.FromStream(ms);
                }
            }
            else
            {
                string defaultImagePath = Path.Combine(Application.StartupPath, "default_profile.png");
                if (File.Exists(defaultImagePath))
                {
                    pictureBoxProfile.Image = Image.FromFile(defaultImagePath);
                }
            }
        }

        private void PanelAdmin_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1 != null)
            {
                // Profil fotoğrafı yüklenecek
                using (MemoryStream ms = new MemoryStream(adminProfilePicture))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                string defaultImagePath = Path.Combine(Application.StartupPath, "default_profile.png");
                if (File.Exists(defaultImagePath))
                {
                    pictureBox1.Image = Image.FromFile(defaultImagePath);
                }
            }

            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Admin bilgilerini çekmek için SQL sorgusu
                    string queryAdminInfo = @"
            SELECT a.username, a.password, ai.name, ai.surname, ai.profile_picture
            FROM admininfo ai
            JOIN admins a ON ai.admin_id = a.id
            WHERE a.username = @Username";

                    // `CurrentUser` üzerinden giriş yapan adminin bilgilerine erişiyoruz
                    string currentUsername = AdminLogin.CurrentAdmin.Username;

                    if (string.IsNullOrEmpty(currentUsername))
                    {
                        MessageBox.Show("Admin bilgisi alınamadı!");
                        return;
                    }

                    // Sorguyu çalıştırarak admin bilgilerini alıyoruz
                    using (MySqlCommand cmdAdminInfo = new MySqlCommand(queryAdminInfo, connection))
                    {
                        cmdAdminInfo.Parameters.AddWithValue("@Username", currentUsername);

                        using (MySqlDataReader readerAdminInfo = cmdAdminInfo.ExecuteReader())
                        {
                            if (readerAdminInfo.Read())
                            {
                                // Admin adı ve soyadını ekrana yazdır
                                txtName.Text = readerAdminInfo["name"].ToString();
                                txtSurname.Text = readerAdminInfo["surname"].ToString();

                                // Profil fotoğrafını al ve göster
                                if (!Convert.IsDBNull(readerAdminInfo["profile_picture"]))
                                {
                                    byte[] imageBytes = (byte[])readerAdminInfo["profile_picture"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        pictureBoxProfile.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    string defaultImagePath = Path.Combine(Application.StartupPath, "default_profile.png");
                                    if (File.Exists(defaultImagePath))
                                    {
                                        pictureBoxProfile.Image = Image.FromFile(defaultImagePath);
                                    }
                                }

                                // Username ve Password bilgilerini alıp TextBox'lara yazdırıyoruz
                                txtUsername.Text = readerAdminInfo["username"].ToString();
                                txtPass.Text = readerAdminInfo["password"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Admin bilgisi bulunamadı!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            panelHealtData.Visible = false;
            
        }
        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            panelHealtData.Visible=true;
            panelMemberUpdate.Visible = false;
        }
        private void btnMember_Click(object sender, EventArgs e)
        {
            panelMemberUpdate.Visible = true;
            panelGenel.Visible = false;
            
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            panelGenel.Visible = true;
        }

        private void panelHealtData_Paint(object sender, PaintEventArgs e)
        {
            CalculateAgeGroupSteps();
            CustomizeChart();
        }

        
        private void CalculateAgeGroupSteps()
        {
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Haftalık adım sayısı verilerini çekme
                    string query = @"
            SELECT e.name, e.surname, e.email, 
                   wt.monday_steps, wt.tuesday_steps, wt.wednesday_steps, wt.thursday_steps, 
                   wt.friday_steps, wt.saturday_steps, wt.sunday_steps,
                   e.birth_date
            FROM emmployees e
            JOIN WeeklyTracking wt ON e.email = wt.username";

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Gruplar için adım sayıları
                        int childrenSteps = 0;
                        int adultSteps = 0;
                        int middleAgedSteps = 0;
                        int seniorSteps = 0;
                        int childrenCount = 0;
                        int adultCount = 0;
                        int middleAgedCount = 0;
                        int seniorCount = 0;

                        while (reader.Read())
                        {
                            DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);
                            int mondaySteps = Convert.ToInt32(reader["monday_steps"]);
                            int tuesdaySteps = Convert.ToInt32(reader["tuesday_steps"]);
                            int wednesdaySteps = Convert.ToInt32(reader["wednesday_steps"]);
                            int thursdaySteps = Convert.ToInt32(reader["thursday_steps"]);
                            int fridaySteps = Convert.ToInt32(reader["friday_steps"]);
                            int saturdaySteps = Convert.ToInt32(reader["saturday_steps"]);
                            int sundaySteps = Convert.ToInt32(reader["sunday_steps"]);

                            // Yaş hesaplama
                            int age = DateTime.Now.Year - birthDate.Year;
                            if (birthDate > DateTime.Now.AddYears(-age)) age--;

                            // Adım sayısını gruplama
                            int totalSteps = mondaySteps + tuesdaySteps + wednesdaySteps + thursdaySteps +
                                             fridaySteps + saturdaySteps + sundaySteps;

                            if (age >= 0 && age <= 18)  // Çocuk
                            {
                                childrenSteps += totalSteps;
                                childrenCount++;
                            }
                            else if (age >= 19 && age <= 35)  // Yetişkin
                            {
                                adultSteps += totalSteps;
                                adultCount++;
                            }
                            else if (age >= 36 && age <= 50)  // Orta Yaşlı
                            {
                                middleAgedSteps += totalSteps;
                                middleAgedCount++;
                            }
                            else if (age >= 51)  // Yaşlı
                            {
                                seniorSteps += totalSteps;
                                seniorCount++;
                            }
                        }

                        // Günlük ortalama adım sayısı hesaplama
                        int totalDaysInWeek = 7;

                        double childrenAvgSteps = childrenCount > 0 ? childrenSteps / (childrenCount * totalDaysInWeek) : 0;
                        double adultAvgSteps = adultCount > 0 ? adultSteps / (adultCount * totalDaysInWeek) : 0;
                        double middleAgedAvgSteps = middleAgedCount > 0 ? middleAgedSteps / (middleAgedCount * totalDaysInWeek) : 0;
                        double seniorAvgSteps = seniorCount > 0 ? seniorSteps / (seniorCount * totalDaysInWeek) : 0;

                        // Grafiği güncelleme (ortalama adımlar)
                        chartAge.Series[0].Points.Clear();
                        chartAge.Series[0].Points.AddXY("Çocuk", childrenAvgSteps);
                        chartAge.Series[0].Points.AddXY("Yetişkin", adultAvgSteps);
                        chartAge.Series[0].Points.AddXY("Orta Yaşlı", middleAgedAvgSteps);
                        chartAge.Series[0].Points.AddXY("Yaşlı", seniorAvgSteps);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void CustomizeChart()
        {
            // Başlık ve Eksen Ayarları
            chartAge.Titles.Clear();
            chartAge.Titles.Add("Farklı Yaş Gruplarındaki Adım Sayısı");
            chartAge.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);
            // X ve Y Eksenleri Etiketleri
            chartAge.ChartAreas[0].AxisX.Title = "Yaş Grupları";
            chartAge.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Italic);
            chartAge.ChartAreas[0].AxisY.Title = "Adım Sayısı";
            chartAge.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Italic);
            // Grafik Renk ve Stil Özelleştirmeleri
            chartAge.Series[0].BorderWidth = 3;
            chartAge.Series[0].Color = Color.Green;
            // Grid Lines (Izgaralar)
            chartAge.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartAge.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            // Bütün Yazı Tiplerini Düzenleyelim
            chartAge.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            chartAge.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular);
        }

        private void panelMemberUpdate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textUserId.Text))
            {
                MessageBox.Show("Lütfen bir kullanıcı ID'si girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();
                    string emailQuery = "SELECT email FROM emmployees WHERE id = @id";
                    MySqlCommand emailCmd = new MySqlCommand(emailQuery, connection);
                    emailCmd.Parameters.AddWithValue("@id", textUserId.Text);

                    string existingEmail = null;
                    using (MySqlDataReader emailReader = emailCmd.ExecuteReader())
                    {
                        if (emailReader.Read())
                        {
                            existingEmail = emailReader["email"].ToString();
                        }
                    }

                    // SQL sorgusu (email değişmez)
                    string query = @"
                        UPDATE emmployees 
                        SET name = @name, 
                            surname = @surname, 
                            phone_number = @phone_number, 
                            birth_date = @birth_date 
                        WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // Parametreleri ekle
                    cmd.Parameters.AddWithValue("@id", textUserId.Text);
                    cmd.Parameters.AddWithValue("@name", textName.Text);
                    cmd.Parameters.AddWithValue("@surname", textSurname.Text);
                    cmd.Parameters.AddWithValue("@phone_number", textTel.Text);
                    cmd.Parameters.AddWithValue("@birth_date", textBirthDate.Text);

                    // E-posta sabit kalacak şekilde ekle
                    cmd.Parameters.AddWithValue("@email", existingEmail); 
                    // Güncelleme işlemini gerçekleştir
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız. Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu
                    string query = @"
            SELECT name, surname, phone_number, email, profile_picture, birth_date
            FROM emmployees
            WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", textUserId.Text);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Verileri TextBox'lara aktar
                            textName.Text = reader["name"].ToString();
                            textSurname.Text = reader["surname"].ToString();
                            textTel.Text = reader["phone_number"].ToString();
                            textEmail.Text = reader["email"].ToString();

                            // Doğum tarihini çek ve uygun bir kontrol ile göster
                            if (reader["birth_date"] != DBNull.Value)
                            {
                                DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);
                                textBirthDate.Text = birthDate.ToString("yyyy-MM-dd"); 
                            }

                            if (!Convert.IsDBNull(reader["profile_picture"]))
                            {
                                byte[] imageBytes = (byte[])reader["profile_picture"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    profile_picture.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                // Varsayılan fotoğrafı yükle
                                string defaultImagePath = Path.Combine(Application.StartupPath, "default_profile.png");
                                if (File.Exists(defaultImagePath))
                                {
                                    profile_picture.Image = Image.FromFile(defaultImagePath);
                                }
                                else
                                {
                                    // Eğer varsayılan fotoğraf da yoksa boş bırak
                                    profile_picture.Image = null;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Girilen ID'ye ait bir kullanıcı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bu kullanıcıyı silmek istediğinizden emin misiniz?",
            "Kullanıcı Sil",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu
                    string query = "DELETE FROM emmployees WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", textUserId.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Silme işleminden sonra TextBox'ları ve resmi temizle
                        textUserId.Clear();
                        textName.Clear();
                        textSurname.Clear();
                        textTel.Clear();
                        textEmail.Clear();
                        textBirthDate.Clear();
                        profile_picture.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Silme işlemi başarısız. Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textUserId.Clear();
            textName.Clear();
            textSurname.Clear();
            textTel.Clear();
            textEmail.Clear();
            textBirthDate.Clear();
            profile_picture.Image = null;
            string defaultImagePath = Path.Combine(Application.StartupPath, "default_profile.png");
            if (File.Exists(defaultImagePath))
            {
                profile_picture.Image = Image.FromFile(defaultImagePath);
            }
        }
        private void LoadTotalUser()
        {
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM emmployees;";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    int totalUsers = Convert.ToInt32(cmd.ExecuteScalar());
                    labelTotalUser.Text = totalUsers.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadAverageWeight()
        {
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT AVG(monday_kg) FROM WeeklyTracking;";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        double avgWeight = Convert.ToDouble(result);
                        labelAvgWeight.Text = $"{avgWeight:F2} kg";
                    }
                    else
                    {
                        labelAvgWeight.Text = "Pazartesi günü kilo bilgisi yok.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadWeeklyStepAverage()
        {
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT AVG(monday_steps + tuesday_steps + wednesday_steps + thursday_steps +
                           friday_steps + saturday_steps + sunday_steps) / 7 AS weekly_avg_steps
                FROM WeeklyTracking;";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        double avgSteps = Convert.ToDouble(result);
                        labelAvgSteps.Text = $"{avgSteps:F0} step";
                    }
                    else
                    {
                        labelAvgSteps.Text = "Haftalık adım bilgisi yok.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadWeeklyPulseAverage()
        {
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT AVG(monday_pulse + tuesday_pulse + wednesday_pulse + thursday_pulse +
                           friday_pulse + saturday_pulse + sunday_pulse) / 7 AS weekly_avg_pulse
                FROM WeeklyTracking;";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        double avgPulse = Convert.ToDouble(result);
                        labelAvgPulse.Text = $"{avgPulse:F0} bpm";
                    }
                    else
                    {
                        labelAvgPulse.Text = "Haftalık nabız bilgisi yok.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
