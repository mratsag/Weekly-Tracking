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
    public partial class WeeklyTracking : Form
    {
        public WeeklyTracking()
        {
            InitializeComponent();
        }
        
        private void btnLoadWeekly_Click(object sender, EventArgs e)
        {
            string username = CurrentUser.Username;
            DateTime trackingDate = DateTime.Now;  

            int mondaySteps = (int)numericMondaySteps.Value;
            int mondayPulse = (int)numericMondayPulse.Value;
            decimal mondayKg = numericMondayKg.Value;

            int tuesdaySteps = (int)numericTuesdaySteps.Value;
            int tuesdayPulse = (int)numericTuesdayPulse.Value;
            decimal tuesdayKg = numericTuesdayKg.Value;

            int wednesdaySteps = (int)numericWednesdaySteps.Value;
            int wednesdayPulse = (int)numericWednesdayPulse.Value;
            decimal wednesdayKg = numericWednesdayKg.Value;

            int thursdaySteps = (int)numericThursdaySteps.Value;
            int thursdayPulse = (int)numericThursdayPulse.Value;
            decimal thursdayKg = numericThursdayKg.Value;

            int fridaySteps = (int)numericFridaySteps.Value;
            int fridayPulse = (int)numericFridayPulse.Value;
            decimal fridayKg = numericFridayKg.Value;

            int saturdaySteps = (int)numericSaturdaySteps.Value;
            int saturdayPulse = (int)numericSaturdayPulse.Value;
            decimal saturdayKg = numericSaturdayKg.Value;

            int sundaySteps = (int)numericSundaySteps.Value;
            int sundayPulse = (int)numericSundayPulse.Value;
            decimal sundayKg = numericSundayKg.Value;

            // Veritabanına kaydetme işlemi
            InsertWeeklyTracking(username, trackingDate, mondaySteps, mondayPulse, mondayKg,
                tuesdaySteps, tuesdayPulse, tuesdayKg, wednesdaySteps, wednesdayPulse, wednesdayKg,
                thursdaySteps, thursdayPulse, thursdayKg, fridaySteps, fridayPulse, fridayKg,
                saturdaySteps, saturdayPulse, saturdayKg, sundaySteps, sundayPulse, sundayKg);
        }

        private void InsertWeeklyTracking(string username, DateTime trackingDate, int mondaySteps, int mondayPulse, decimal mondayKg, 
            int tuesdaySteps, int tuesdayPulse, decimal tuesdayKg, 
            int wednesdaySteps, int wednesdayPulse, decimal wednesdayKg, 
            int thursdaySteps, int thursdayPulse, decimal thursdayKg, 
            int fridaySteps, int fridayPulse, decimal fridayKg, 
            int saturdaySteps, int saturdayPulse, decimal saturdayKg, 
            int sundaySteps, int sundayPulse, decimal sundayKg)
        {
            using (MySqlConnection connection = Conn.GetConnection())
            {
                try
                {
                    connection.Open();

                    // SQL sorgusunu yazıyoruz
                    string query = @"INSERT INTO WeeklyTracking (
                                    username, monday_steps, monday_pulse, monday_kg,
                                    tuesday_steps, tuesday_pulse, tuesday_kg,
                                    wednesday_steps, wednesday_pulse, wednesday_kg,
                                    thursday_steps, thursday_pulse, thursday_kg,
                                    friday_steps, friday_pulse, friday_kg,
                                    saturday_steps, saturday_pulse, saturday_kg,
                                    sunday_steps, sunday_pulse, sunday_kg, tracking_date)
                            VALUES (@username, @mondaySteps, @mondayPulse, @mondayKg,
                                    @tuesdaySteps, @tuesdayPulse, @tuesdayKg,
                                    @wednesdaySteps, @wednesdayPulse, @wednesdayKg,
                                    @thursdaySteps, @thursdayPulse, @thursdayKg,
                                    @fridaySteps, @fridayPulse, @fridayKg,
                                    @saturdaySteps, @saturdayPulse, @saturdayKg,
                                    @sundaySteps, @sundayPulse, @sundayKg, @trackingDate)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@mondaySteps", mondaySteps);
                        command.Parameters.AddWithValue("@mondayPulse", mondayPulse);
                        command.Parameters.AddWithValue("@mondayKg", mondayKg);
                        command.Parameters.AddWithValue("@tuesdaySteps", tuesdaySteps);
                        command.Parameters.AddWithValue("@tuesdayPulse", tuesdayPulse);
                        command.Parameters.AddWithValue("@tuesdayKg", tuesdayKg);
                        command.Parameters.AddWithValue("@wednesdaySteps", wednesdaySteps);
                        command.Parameters.AddWithValue("@wednesdayPulse", wednesdayPulse);
                        command.Parameters.AddWithValue("@wednesdayKg", wednesdayKg);
                        command.Parameters.AddWithValue("@thursdaySteps", thursdaySteps);
                        command.Parameters.AddWithValue("@thursdayPulse", thursdayPulse);
                        command.Parameters.AddWithValue("@thursdayKg", thursdayKg);
                        command.Parameters.AddWithValue("@fridaySteps", fridaySteps);
                        command.Parameters.AddWithValue("@fridayPulse", fridayPulse);
                        command.Parameters.AddWithValue("@fridayKg", fridayKg);
                        command.Parameters.AddWithValue("@saturdaySteps", saturdaySteps);
                        command.Parameters.AddWithValue("@saturdayPulse", saturdayPulse);
                        command.Parameters.AddWithValue("@saturdayKg", saturdayKg);
                        command.Parameters.AddWithValue("@sundaySteps", sundaySteps);
                        command.Parameters.AddWithValue("@sundayPulse", sundayPulse);
                        command.Parameters.AddWithValue("@sundayKg", sundayKg);
                        command.Parameters.AddWithValue("@trackingDate", trackingDate);

                        // Veriyi ekle
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} satır başarıyla eklendi.");
                    }
                    
                    MainPage main = new MainPage();
                    main.Show();
                    this.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}");
                }
            }
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            this.Close();
        }

        
    }
    
}
