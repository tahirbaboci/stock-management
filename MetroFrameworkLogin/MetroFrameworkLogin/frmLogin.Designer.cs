namespace MetroFrameworkLogin
{
    partial class Login_form
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroBtn_login = new MetroFramework.Controls.MetroButton();
            this.metroTxt_username = new MetroFramework.Controls.MetroTextBox();
            this.metroTxt_password = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(294, 63);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(80, 20);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Username :";
            // 
            // metroBtn_login
            // 
            this.metroBtn_login.Location = new System.Drawing.Point(530, 147);
            this.metroBtn_login.Name = "metroBtn_login";
            this.metroBtn_login.Size = new System.Drawing.Size(94, 23);
            this.metroBtn_login.TabIndex = 2;
            this.metroBtn_login.Text = "&Login >";
            this.metroBtn_login.UseSelectable = true;
            this.metroBtn_login.Click += new System.EventHandler(this.metroBtn_login_Click);
            // 
            // metroTxt_username
            // 
            // 
            // 
            // 
            this.metroTxt_username.CustomButton.Image = null;
            this.metroTxt_username.CustomButton.Location = new System.Drawing.Point(213, 1);
            this.metroTxt_username.CustomButton.Name = "";
            this.metroTxt_username.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTxt_username.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTxt_username.CustomButton.TabIndex = 1;
            this.metroTxt_username.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTxt_username.CustomButton.UseSelectable = true;
            this.metroTxt_username.CustomButton.Visible = false;
            this.metroTxt_username.Lines = new string[0];
            this.metroTxt_username.Location = new System.Drawing.Point(389, 63);
            this.metroTxt_username.MaxLength = 32767;
            this.metroTxt_username.Name = "metroTxt_username";
            this.metroTxt_username.PasswordChar = '\0';
            this.metroTxt_username.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTxt_username.SelectedText = "";
            this.metroTxt_username.SelectionLength = 0;
            this.metroTxt_username.SelectionStart = 0;
            this.metroTxt_username.ShortcutsEnabled = true;
            this.metroTxt_username.Size = new System.Drawing.Size(235, 23);
            this.metroTxt_username.TabIndex = 0;
            this.metroTxt_username.UseSelectable = true;
            this.metroTxt_username.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTxt_username.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTxt_password
            // 
            // 
            // 
            // 
            this.metroTxt_password.CustomButton.Image = null;
            this.metroTxt_password.CustomButton.Location = new System.Drawing.Point(213, 1);
            this.metroTxt_password.CustomButton.Name = "";
            this.metroTxt_password.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTxt_password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTxt_password.CustomButton.TabIndex = 1;
            this.metroTxt_password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTxt_password.CustomButton.UseSelectable = true;
            this.metroTxt_password.CustomButton.Visible = false;
            this.metroTxt_password.Lines = new string[0];
            this.metroTxt_password.Location = new System.Drawing.Point(389, 103);
            this.metroTxt_password.MaxLength = 32767;
            this.metroTxt_password.Name = "metroTxt_password";
            this.metroTxt_password.PasswordChar = '*';
            this.metroTxt_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTxt_password.SelectedText = "";
            this.metroTxt_password.SelectionLength = 0;
            this.metroTxt_password.SelectionStart = 0;
            this.metroTxt_password.ShortcutsEnabled = true;
            this.metroTxt_password.Size = new System.Drawing.Size(235, 23);
            this.metroTxt_password.TabIndex = 1;
            this.metroTxt_password.UseSelectable = true;
            this.metroTxt_password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTxt_password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(301, 103);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(73, 20);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Password :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MetroFrameworkLogin.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(79, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(389, 147);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "remember me";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 217);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroTxt_password);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroTxt_username);
            this.Controls.Add(this.metroBtn_login);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Login_form";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_form_FormClosed);
            this.Load += new System.EventHandler(this.Login_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroBtn_login;
        private MetroFramework.Controls.MetroTextBox metroTxt_username;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox metroTxt_password;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

