using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static ViusalProject.Login;

namespace ViusalProject
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        public static class CurrentAdmin
        {
            public static string Username { get; set; }
        }
        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("The username and password cannot be left blank.");
                return;
            }

            try
            {
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // Admin bilgilerini admins tablosundan alıyoruz
                    string query = "SELECT id, password FROM admins WHERE username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["password"].ToString();
                                int adminId = Convert.ToInt32(reader["id"]);

                                // Şifreyi kontrol et
                                if (password == storedPassword)
                                {
                                    // Admin bilgilerini CurrentUser static sınıfına atıyoruz
                                    CurrentAdmin.Username = username;
                                    // Adminin bilgilerini admininfo tablosundan alalım
                                    reader.Close(); // Önceki reader'ı kapatıyoruz

                                    string adminInfoQuery = "SELECT name, surname, profile_picture FROM admininfo WHERE admin_id = @AdminId";
                                    using (MySqlCommand infoCommand = new MySqlCommand(adminInfoQuery, connection))
                                    {
                                        infoCommand.Parameters.AddWithValue("@AdminId", adminId);

                                        using (MySqlDataReader infoReader = infoCommand.ExecuteReader())
                                        {
                                            if (infoReader.Read())
                                            {
                                                string name = infoReader["name"].ToString();
                                                string surname = infoReader["surname"].ToString();
                                                byte[] imageBytes = infoReader["profile_picture"] as byte[];

                                                // Adminin bilgilerini birleştirip AdminDashboard'a ilet
                                                AdminDashboard adminDashboard = new AdminDashboard(name, surname, imageBytes);
                                                adminDashboard.Show();
                                                this.Hide();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Admin profile not found.");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The password is incorrect.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("User not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }
    }
}
            
