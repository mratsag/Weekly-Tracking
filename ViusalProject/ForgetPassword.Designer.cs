namespace ViusalProject
{
    partial class ForgetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPassword));
            this.textEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnResetPassword = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textEmail
            // 
            this.textEmail.BorderRadius = 10;
            this.textEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textEmail.DefaultText = "";
            this.textEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textEmail.DisabledState.Parent = this.textEmail;
            this.textEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textEmail.FocusedState.Parent = this.textEmail;
            this.textEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textEmail.HoverState.Parent = this.textEmail;
            this.textEmail.Location = new System.Drawing.Point(472, 166);
            this.textEmail.Name = "textEmail";
            this.textEmail.PasswordChar = '\0';
            this.textEmail.PlaceholderText = "";
            this.textEmail.SelectedText = "";
            this.textEmail.ShadowDecoration.Parent = this.textEmail;
            this.textEmail.Size = new System.Drawing.Size(223, 33);
            this.textEmail.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(469, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Please enter Email";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BorderRadius = 15;
            this.btnResetPassword.CheckedState.Parent = this.btnResetPassword;
            this.btnResetPassword.CustomImages.Parent = this.btnResetPassword;
            this.btnResetPassword.FillColor = System.Drawing.Color.MediumPurple;
            this.btnResetPassword.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnResetPassword.ForeColor = System.Drawing.Color.Black;
            this.btnResetPassword.HoverState.Parent = this.btnResetPassword;
            this.btnResetPassword.Location = new System.Drawing.Point(585, 374);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.PressedColor = System.Drawing.Color.BlueViolet;
            this.btnResetPassword.ShadowDecoration.Parent = this.btnResetPassword;
            this.btnResetPassword.Size = new System.Drawing.Size(110, 37);
            this.btnResetPassword.TabIndex = 12;
            this.btnResetPassword.Text = "RESET";
            this.btnResetPassword.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.MediumPurple;
            this.label1.Location = new System.Drawing.Point(515, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Forgot Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.MediumPurple;
            this.label3.Location = new System.Drawing.Point(541, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "New Password";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(394, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(403, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "---------------------------------------------------------------------------------" +
    "-----------------------------------------------------";
            // 
            // textPhone
            // 
            this.textPhone.BorderRadius = 10;
            this.textPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textPhone.DefaultText = "";
            this.textPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textPhone.DisabledState.Parent = this.textPhone;
            this.textPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textPhone.FocusedState.Parent = this.textPhone;
            this.textPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textPhone.HoverState.Parent = this.textPhone;
            this.textPhone.Location = new System.Drawing.Point(472, 231);
            this.textPhone.Name = "textPhone";
            this.textPhone.PasswordChar = '\0';
            this.textPhone.PlaceholderText = "";
            this.textPhone.SelectedText = "";
            this.textPhone.ShadowDecoration.Parent = this.textPhone;
            this.textPhone.Size = new System.Drawing.Size(223, 32);
            this.textPhone.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(469, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Please enter Phone No";
            // 
            // textNewPassword
            // 
            this.textNewPassword.BorderRadius = 10;
            this.textNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textNewPassword.DefaultText = "";
            this.textNewPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textNewPassword.DisabledState.Parent = this.textNewPassword;
            this.textNewPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textNewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textNewPassword.FocusedState.Parent = this.textNewPassword;
            this.textNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textNewPassword.HoverState.Parent = this.textNewPassword;
            this.textNewPassword.Location = new System.Drawing.Point(472, 297);
            this.textNewPassword.Name = "textNewPassword";
            this.textNewPassword.PasswordChar = '\0';
            this.textNewPassword.PlaceholderText = "";
            this.textNewPassword.SelectedText = "";
            this.textNewPassword.ShadowDecoration.Parent = this.textNewPassword;
            this.textNewPassword.Size = new System.Drawing.Size(223, 33);
            this.textNewPassword.TabIndex = 19;
            this.textNewPassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(469, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "New Password";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 15;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.MediumPurple;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(472, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PressedColor = System.Drawing.Color.BlueViolet;
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(107, 37);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textNewPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ForgetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgetPassword";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox textEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnResetPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox textPhone;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox textNewPassword;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}