using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace ViusalProject
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnWeeklyTracking_Click(object sender, EventArgs e)
        {
            WeeklyTracking weeklyTracking = new WeeklyTracking();
            weeklyTracking.Show();
            this.Hide();
            
        }

        private void btnUserInformation_Click(object sender, EventArgs e)
        {
            UserInformation userInformation = new UserInformation();
            userInformation.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            // Giriş yapan kullanıcının e-posta adresini al
            string currentUserEmail = Login.CurrentUser.Username;
            LoadUserWeeklySteps(currentUserEmail);
            LoadUserWeeklyKg(currentUserEmail);
            LoadWeeklyStepsChart(currentUserEmail);

            if (string.IsNullOrEmpty(currentUserEmail))
            {
                MessageBox.Show("Kullanıcı e-posta bilgisi alınamadı!");
                return;
            }

            // Veritabanı bağlantısını dışa tanımlayın ve sadece bir kez kullanın
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void LoadUserWeeklySteps(string username)
        {
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT monday_steps, tuesday_steps, wednesday_steps, thursday_steps, 
                       friday_steps, saturday_steps, sunday_steps
                FROM WeeklyTracking
                WHERE username = @username;";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string stepsData = $"Monday: {reader["monday_steps"]} step\n" +
                                               $"Tuesday: {reader["tuesday_steps"]} step\n" +
                                               $"Wednesday: {reader["wednesday_steps"]} step\n" +
                                               $"Thursday: {reader["thursday_steps"]} step\n" +
                                               $"Friday: {reader["friday_steps"]} step\n" +
                                               $"Saturday: {reader["saturday_steps"]} step\n" +
                                               $"Sunday: {reader["sunday_steps"]} step";

                            labelStepsData.Text = stepsData;
                        }
                        else
                        {
                            labelStepsData.Text = "Adım verisi bulunamadı.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Veri Getirme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadUserWeeklyKg(string username)
        {
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT monday_kg, tuesday_kg, wednesday_kg, thursday_kg, 
                       friday_kg, saturday_kg, sunday_kg
                FROM WeeklyTracking
                WHERE username = @username;";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string kgData = $"Monday: {reader["monday_kg"]} kg\n" +
                                            $"Tuesday: {reader["tuesday_kg"]} kg\n" +
                                            $"Wednesday: {reader["wednesday_kg"]} kg\n" +
                                            $"Thursday: {reader["thursday_kg"]} kg\n" +
                                            $"Friday: {reader["friday_kg"]} kg\n" +
                                            $"Saturday: {reader["saturday_kg"]} kg\n" +
                                            $"Sunday: {reader["sunday_kg"]} kg";

                            labelKgData.Text = kgData;
                        }
                        else
                        {
                            labelKgData.Text = "Kilo verisi bulunamadı.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Veri Getirme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadWeeklyStepsChart(string username)
        {
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT monday_steps, tuesday_steps, wednesday_steps, thursday_steps, 
                       friday_steps, saturday_steps, sunday_steps
                FROM WeeklyTracking
                WHERE username = @username;";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            chartSteps.Series.Clear();
                            chartSteps.Series.Add("Step Counts");
                            chartSteps.Series["Step Counts"].Points.AddXY("M", reader["monday_steps"]);
                            chartSteps.Series["Step Counts"].Points.AddXY("T", reader["tuesday_steps"]);
                            chartSteps.Series["Step Counts"].Points.AddXY("W", reader["wednesday_steps"]);
                            chartSteps.Series["Step Counts"].Points.AddXY("T", reader["thursday_steps"]);
                            chartSteps.Series["Step Counts"].Points.AddXY("F", reader["friday_steps"]);
                            chartSteps.Series["Step Counts"].Points.AddXY("S", reader["saturday_steps"]);
                            chartSteps.Series["Step Counts"].Points.AddXY("S", reader["sunday_steps"]);
                            chartSteps.Series["Step Counts"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                            chartSteps.Titles.Clear();
                            chartSteps.Titles.Add("Weekly Step Counts");

                        }
                        else
                        {
                            MessageBox.Show("Adım verisi bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Veri Getirme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }

}
