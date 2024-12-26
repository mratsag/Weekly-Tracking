namespace ViusalProject
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnWeeklyTracking = new Guna.UI2.WinForms.Guna2Button();
            this.btnUserInformation = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBoxProfile = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblNameSurname = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBoxStep = new Guna.UI2.WinForms.Guna2GroupBox();
            this.chartSteps = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxKg = new Guna.UI2.WinForms.Guna2GroupBox();
            this.labelKgData = new System.Windows.Forms.Label();
            this.groupBoxSteps = new Guna.UI2.WinForms.Guna2GroupBox();
            this.labelStepsData = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBoxStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSteps)).BeginInit();
            this.groupBoxKg.SuspendLayout();
            this.groupBoxSteps.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWeeklyTracking
            // 
            this.btnWeeklyTracking.BorderRadius = 15;
            this.btnWeeklyTracking.CheckedState.Parent = this.btnWeeklyTracking;
            this.btnWeeklyTracking.CustomImages.Parent = this.btnWeeklyTracking;
            this.btnWeeklyTracking.FillColor = System.Drawing.Color.MediumPurple;
            this.btnWeeklyTracking.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnWeeklyTracking.ForeColor = System.Drawing.Color.White;
            this.btnWeeklyTracking.HoverState.Parent = this.btnWeeklyTracking;
            this.btnWeeklyTracking.Location = new System.Drawing.Point(59, 347);
            this.btnWeeklyTracking.Name = "btnWeeklyTracking";
            this.btnWeeklyTracking.ShadowDecoration.Parent = this.btnWeeklyTracking;
            this.btnWeeklyTracking.Size = new System.Drawing.Size(180, 45);
            this.btnWeeklyTracking.TabIndex = 0;
            this.btnWeeklyTracking.Text = "Weekly Tracking";
            this.btnWeeklyTracking.Click += new System.EventHandler(this.btnWeeklyTracking_Click);
            // 
            // btnUserInformation
            // 
            this.btnUserInformation.BorderRadius = 15;
            this.btnUserInformation.CheckedState.Parent = this.btnUserInformation;
            this.btnUserInformation.CustomImages.Parent = this.btnUserInformation;
            this.btnUserInformation.FillColor = System.Drawing.Color.MediumPurple;
            this.btnUserInformation.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUserInformation.ForeColor = System.Drawing.Color.White;
            this.btnUserInformation.HoverState.Parent = this.btnUserInformation;
            this.btnUserInformation.Location = new System.Drawing.Point(59, 296);
            this.btnUserInformation.Name = "btnUserInformation";
            this.btnUserInformation.ShadowDecoration.Parent = this.btnUserInformation;
            this.btnUserInformation.Size = new System.Drawing.Size(180, 45);
            this.btnUserInformation.TabIndex = 1;
            this.btnUserInformation.Text = "User Information";
            this.btnUserInformation.Click += new System.EventHandler(this.btnUserInformation_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.guna2GroupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 450);
            this.panel1.TabIndex = 2;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.MediumPurple;
            this.guna2GroupBox1.BorderRadius = 15;
            this.guna2GroupBox1.BorderThickness = 3;
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Controls.Add(this.btnExit);
            this.guna2GroupBox1.Controls.Add(this.pictureBoxProfile);
            this.guna2GroupBox1.Controls.Add(this.lblNameSurname);
            this.guna2GroupBox1.Controls.Add(this.btnUserInformation);
            this.guna2GroupBox1.Controls.Add(this.btnWeeklyTracking);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.MediumPurple;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(3, 3);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(300, 447);
            this.guna2GroupBox1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(55, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "WELCOME";
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 15;
            this.btnExit.CheckedState.Parent = this.btnExit;
            this.btnExit.CustomImages.Parent = this.btnExit;
            this.btnExit.FillColor = System.Drawing.Color.Crimson;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.HoverState.Parent = this.btnExit;
            this.btnExit.Location = new System.Drawing.Point(59, 398);
            this.btnExit.Name = "btnExit";
            this.btnExit.ShadowDecoration.Parent = this.btnExit;
            this.btnExit.Size = new System.Drawing.Size(176, 37);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "EXIT";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBoxProfile.Location = new System.Drawing.Point(79, 51);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureBoxProfile.ShadowDecoration.Parent = this.pictureBoxProfile;
            this.pictureBoxProfile.Size = new System.Drawing.Size(138, 123);
            this.pictureBoxProfile.TabIndex = 4;
            this.pictureBoxProfile.TabStop = false;
            // 
            // lblNameSurname
            // 
            this.lblNameSurname.AutoSize = true;
            this.lblNameSurname.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNameSurname.ForeColor = System.Drawing.Color.Black;
            this.lblNameSurname.Location = new System.Drawing.Point(164, 191);
            this.lblNameSurname.Name = "lblNameSurname";
            this.lblNameSurname.Size = new System.Drawing.Size(15, 23);
            this.lblNameSurname.TabIndex = 15;
            this.lblNameSurname.Text = ".";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.groupBoxStep);
            this.panel2.Controls.Add(this.groupBoxKg);
            this.panel2.Controls.Add(this.groupBoxSteps);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(309, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 450);
            this.panel2.TabIndex = 5;
            // 
            // groupBoxStep
            // 
            this.groupBoxStep.BorderColor = System.Drawing.Color.HotPink;
            this.groupBoxStep.BorderRadius = 10;
            this.groupBoxStep.BorderThickness = 3;
            this.groupBoxStep.Controls.Add(this.chartSteps);
            this.groupBoxStep.CustomBorderColor = System.Drawing.Color.HotPink;
            this.groupBoxStep.FillColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxStep.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxStep.ForeColor = System.Drawing.Color.Black;
            this.groupBoxStep.Location = new System.Drawing.Point(13, 12);
            this.groupBoxStep.Name = "groupBoxStep";
            this.groupBoxStep.ShadowDecoration.Parent = this.groupBoxStep;
            this.groupBoxStep.Size = new System.Drawing.Size(466, 229);
            this.groupBoxStep.TabIndex = 2;
            this.groupBoxStep.Text = "Steps per week";
            // 
            // chartSteps
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSteps.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSteps.Legends.Add(legend1);
            this.chartSteps.Location = new System.Drawing.Point(3, 42);
            this.chartSteps.Name = "chartSteps";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSteps.Series.Add(series1);
            this.chartSteps.Size = new System.Drawing.Size(460, 163);
            this.chartSteps.TabIndex = 2;
            this.chartSteps.Text = "chart1";
            // 
            // groupBoxKg
            // 
            this.groupBoxKg.BorderColor = System.Drawing.Color.Olive;
            this.groupBoxKg.BorderRadius = 10;
            this.groupBoxKg.BorderThickness = 3;
            this.groupBoxKg.Controls.Add(this.labelKgData);
            this.groupBoxKg.CustomBorderColor = System.Drawing.Color.Olive;
            this.groupBoxKg.FillColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxKg.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxKg.ForeColor = System.Drawing.Color.Black;
            this.groupBoxKg.Location = new System.Drawing.Point(254, 247);
            this.groupBoxKg.Name = "groupBoxKg";
            this.groupBoxKg.ShadowDecoration.Parent = this.groupBoxKg;
            this.groupBoxKg.Size = new System.Drawing.Size(225, 200);
            this.groupBoxKg.TabIndex = 1;
            this.groupBoxKg.Text = "Weekly weight gain";
            // 
            // labelKgData
            // 
            this.labelKgData.AutoSize = true;
            this.labelKgData.Location = new System.Drawing.Point(17, 66);
            this.labelKgData.Name = "labelKgData";
            this.labelKgData.Size = new System.Drawing.Size(48, 16);
            this.labelKgData.TabIndex = 0;
            this.labelKgData.Text = "label1";
            // 
            // groupBoxSteps
            // 
            this.groupBoxSteps.BorderColor = System.Drawing.Color.Gold;
            this.groupBoxSteps.BorderRadius = 10;
            this.groupBoxSteps.BorderThickness = 3;
            this.groupBoxSteps.Controls.Add(this.labelStepsData);
            this.groupBoxSteps.CustomBorderColor = System.Drawing.Color.Gold;
            this.groupBoxSteps.FillColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxSteps.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxSteps.ForeColor = System.Drawing.Color.Black;
            this.groupBoxSteps.Location = new System.Drawing.Point(13, 247);
            this.groupBoxSteps.Name = "groupBoxSteps";
            this.groupBoxSteps.ShadowDecoration.Parent = this.groupBoxSteps;
            this.groupBoxSteps.Size = new System.Drawing.Size(225, 200);
            this.groupBoxSteps.TabIndex = 0;
            this.groupBoxSteps.Text = "Weekly pulse rate";
            // 
            // labelStepsData
            // 
            this.labelStepsData.AutoSize = true;
            this.labelStepsData.Location = new System.Drawing.Point(12, 64);
            this.labelStepsData.Name = "labelStepsData";
            this.labelStepsData.Size = new System.Drawing.Size(48, 16);
            this.labelStepsData.TabIndex = 0;
            this.labelStepsData.Text = "label1";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.panel1.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBoxStep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSteps)).EndInit();
            this.groupBoxKg.ResumeLayout(false);
            this.groupBoxKg.PerformLayout();
            this.groupBoxSteps.ResumeLayout(false);
            this.groupBoxSteps.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnWeeklyTracking;
        private Guna.UI2.WinForms.Guna2Button btnUserInformation;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureBoxProfile;
        private System.Windows.Forms.Label lblNameSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2GroupBox groupBoxKg;
        private Guna.UI2.WinForms.Guna2GroupBox groupBoxSteps;
        private Guna.UI2.WinForms.Guna2GroupBox groupBoxStep;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSteps;
        private System.Windows.Forms.Label labelStepsData;
        private System.Windows.Forms.Label labelKgData;
    }
}