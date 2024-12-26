using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Guna.UI2.WinForms.Suite;
using MySql.Data.MySqlClient;

namespace ViusalProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
        }

        

        public static class CurrentUser {
            public static string Username { get; set; }
            
        }

        


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string surname = textSurname.Text;
            string phone = textTel.Text;
            string email = textEmail.Text;
            string password = textPass.Text;
            DateTime birthDate = birth_date.Value;

            // Alanların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            try
            {
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // E-posta adresinin daha önce kaydedilip edilmediğini kontrol et
                    string checkEmailQuery = "SELECT COUNT(*) FROM emmployees WHERE email = @email";
                    using (MySqlCommand checkEmailCommand = new MySqlCommand(checkEmailQuery, connection))
                    {
                        checkEmailCommand.Parameters.AddWithValue("@email", email);
                        int emailCount = Convert.ToInt32(checkEmailCommand.ExecuteScalar());

                        if (emailCount > 0)
                        {
                            MessageBox.Show("Bu e-posta adresi zaten kullanılıyor!");
                            return; // Eğer e-posta zaten varsa, işlemi durdur
                        }
                    }

                    // Employees tablosuna ekle
                    string insertEmployeeQuery = "INSERT INTO emmployees (name, surname, phone_number, email, birth_date) VALUES (@name, @surname, @phone, @email, @BirthDate)";
                    using (MySqlCommand cmd = new MySqlCommand(insertEmployeeQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@surname", surname);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@email", email); 
                        cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                        cmd.ExecuteNonQuery();
                    }

                    // Users tablosuna veri ekle
                    string insertUserQuery = "INSERT INTO user (username, password) VALUES (@Username, @Password)";
                    using (MySqlCommand cmd = new MySqlCommand(insertUserQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", email); // Email'i username olarak kullanıyoruz
                        cmd.Parameters.AddWithValue("@Password", password);
                        int rowsAffected = cmd.ExecuteNonQuery();  // Satır sayısını kontrol et
                        MessageBox.Show("User tablosuna " + rowsAffected + " satır eklendi.");
                    }

                    // Formdaki tüm alanları temizle
                    textName.Clear();
                    textSurname.Clear();
                    textTel.Clear();
                    textEmail.Clear();
                    textPass.Clear();
                    birth_date.Value = DateTime.Now;
                    panelLogin.Visible = true;

                    MessageBox.Show("Kayıt başarılı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        

        

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty!");
                return;
            }

            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();

                    //sql sorgusu
                    string query = "SELECT * FROM User WHERE Username = @Username AND Password = @Password";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Giriş başarılı, kullanıcı adı CurrentUser sınıfına kaydedilsin
                                CurrentUser.Username = username;

                                MessageBox.Show("Login successful.");
                                MainPage main = new MainPage();
                                main.Show();
                                this.Hide();
                                MessageBox.Show("Welcome!");
                            }
                            else
                            {
                                MessageBox.Show("Username or password is incorrect!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }

        private void lblForget_Click(object sender, EventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword();
            this.Hide();
            forgetPassword.Show();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
        }
    }
    
}
