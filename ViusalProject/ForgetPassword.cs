using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ViusalProject
{
    public partial class ForgetPassword : Form
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }
        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string email = textEmail.Text;
            string phone = textPhone.Text;
            string newPassword = textNewPassword.Text;

            // E-posta ve telefon numarası boş olup olmadığı kontrolü
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            try
            {
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // E-posta ve telefon numarasını doğrula
                    string checkUserQuery = "SELECT COUNT(*) FROM emmployees WHERE email = @email AND phone_number = @phone";
                    using (MySqlCommand cmd = new MySqlCommand(checkUserQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone", phone);

                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            // E-posta ve telefon numarası doğruysa şifreyi güncelle
                            string updatePasswordQuery = "UPDATE user SET password = @newPassword WHERE username = @username";
                            using (MySqlCommand updateCmd = new MySqlCommand(updatePasswordQuery, connection))
                            {
                                updateCmd.Parameters.AddWithValue("@username", email);  // E-posta burada kullanıcı adı olarak kullanılıyor
                                updateCmd.Parameters.AddWithValue("@newPassword", newPassword);
                                updateCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Şifre başarıyla güncellendi!");
                            this.Hide();  // Şifre değiştirildikten sonra formu kapat
                            Login login = new Login();
                            login.Show();
                        }
                        else
                        {
                            MessageBox.Show("E-posta veya telefon numarası hatalı!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Login login = new Login(); 
            login.Show();
            this.Hide();
        }
    }
}
