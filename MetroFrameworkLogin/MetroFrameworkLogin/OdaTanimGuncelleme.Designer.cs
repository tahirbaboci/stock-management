namespace MetroFrameworkLogin
{
    partial class OdaTanimGuncelleme
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
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.metroButton_odatanimlama_guncelle = new MetroFramework.Controls.MetroButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.metroComboBox_odatanimla_Oda_Adi_Guncelleme = new MetroFramework.Controls.MetroComboBox();
            this.metroComboBox_odatanimla_PersonelAdi_guncelleme = new MetroFramework.Controls.MetroComboBox();
            this.LinkLogOut = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label19.Location = new System.Drawing.Point(92, 342);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(430, 17);
            this.label19.TabIndex = 57;
            this.label19.Text = "Oda Adi seceneklerde sadece sorumlusu olan odalar gozukecektir.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(-7, 342);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 17);
            this.label20.TabIndex = 56;
            this.label20.Text = "*Aciklama : ";
            // 
            // metroButton_odatanimlama_guncelle
            // 
            this.metroButton_odatanimlama_guncelle.Location = new System.Drawing.Point(83, 277);
            this.metroButton_odatanimlama_guncelle.Name = "metroButton_odatanimlama_guncelle";
            this.metroButton_odatanimlama_guncelle.Size = new System.Drawing.Size(317, 30);
            this.metroButton_odatanimlama_guncelle.TabIndex = 55;
            this.metroButton_odatanimlama_guncelle.Text = "Guncelle";
            this.metroButton_odatanimlama_guncelle.UseSelectable = true;
            this.metroButton_odatanimlama_guncelle.Click += new System.EventHandler(this.metroButton_odatanimlama_guncelle_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label16.Location = new System.Drawing.Point(247, 148);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 17);
            this.label16.TabIndex = 53;
            this.label16.Text = "*Personel Adi : ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label17.Location = new System.Drawing.Point(80, 148);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 17);
            this.label17.TabIndex = 52;
            this.label17.Text = "*Oda Adi : ";
            // 
            // metroComboBox_odatanimla_Oda_Adi_Guncelleme
            // 
            this.metroComboBox_odatanimla_Oda_Adi_Guncelleme.FormattingEnabled = true;
            this.metroComboBox_odatanimla_Oda_Adi_Guncelleme.ItemHeight = 24;
            this.metroComboBox_odatanimla_Oda_Adi_Guncelleme.Location = new System.Drawing.Point(83, 188);
            this.metroComboBox_odatanimla_Oda_Adi_Guncelleme.Name = "metroComboBox_odatanimla_Oda_Adi_Guncelleme";
            this.metroComboBox_odatanimla_Oda_Adi_Guncelleme.Size = new System.Drawing.Size(150, 30);
            this.metroComboBox_odatanimla_Oda_Adi_Guncelleme.TabIndex = 51;
            this.metroComboBox_odatanimla_Oda_Adi_Guncelleme.UseSelectable = true;
            // 
            // metroComboBox_odatanimla_PersonelAdi_guncelleme
            // 
            this.metroComboBox_odatanimla_PersonelAdi_guncelleme.FormattingEnabled = true;
            this.metroComboBox_odatanimla_PersonelAdi_guncelleme.ItemHeight = 24;
            this.metroComboBox_odatanimla_PersonelAdi_guncelleme.Location = new System.Drawing.Point(250, 188);
            this.metroComboBox_odatanimla_PersonelAdi_guncelleme.Name = "metroComboBox_odatanimla_PersonelAdi_guncelleme";
            this.metroComboBox_odatanimla_PersonelAdi_guncelleme.Size = new System.Drawing.Size(150, 30);
            this.metroComboBox_odatanimla_PersonelAdi_guncelleme.TabIndex = 50;
            this.metroComboBox_odatanimla_PersonelAdi_guncelleme.UseSelectable = true;
            // 
            // LinkLogOut
            // 
            this.LinkLogOut.Image = global::MetroFrameworkLogin.Properties.Resources.back;
            this.LinkLogOut.ImageSize = 32;
            this.LinkLogOut.Location = new System.Drawing.Point(23, 22);
            this.LinkLogOut.Name = "LinkLogOut";
            this.LinkLogOut.Size = new System.Drawing.Size(55, 45);
            this.LinkLogOut.TabIndex = 58;
            this.LinkLogOut.UseSelectable = true;
            this.LinkLogOut.Click += new System.EventHandler(this.LinkLogOut_Click);
            // 
            // OdaTanimGuncelleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 511);
            this.Controls.Add(this.LinkLogOut);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.metroButton_odatanimlama_guncelle);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.metroComboBox_odatanimla_Oda_Adi_Guncelleme);
            this.Controls.Add(this.metroComboBox_odatanimla_PersonelAdi_guncelleme);
            this.Name = "OdaTanimGuncelleme";
            this.Text = "            OdaTanimGuncelleme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private MetroFramework.Controls.MetroButton metroButton_odatanimlama_guncelle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private MetroFramework.Controls.MetroComboBox metroComboBox_odatanimla_Oda_Adi_Guncelleme;
        private MetroFramework.Controls.MetroComboBox metroComboBox_odatanimla_PersonelAdi_guncelleme;
        private MetroFramework.Controls.MetroLink LinkLogOut;
    }
}