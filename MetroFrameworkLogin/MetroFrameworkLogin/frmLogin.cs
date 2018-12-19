using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFrameworkLogin.Siniflar;

namespace MetroFrameworkLogin
{
    public partial class Login_form : MetroFramework.Forms.MetroForm
    {
        public string username;
        public string password;
        public bool yetkiAdmin = false;

        ConnectionClass con = new ConnectionClass();

        public Login_form()
        {
            InitializeComponent();
            Init_Data();
        }
        private void Login_form_Load(object sender, EventArgs e)
        {
            //_instance = this;
            Resizable = false;
            this.MaximizeBox = false;
            metroTxt_username.Focus();
            
        }
        private void metroBtn_login_Click(object sender, EventArgs e)
        {
            username = metroTxt_username.Text;
            password = metroTxt_password.Text;
            login(username, password);
            
        }
        private  void login(string username, string password) {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter your username and password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                metroTxt_username.Focus();
                return;
            }
            else if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter your username and password..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                metroTxt_username.Focus();
                return;
            }
            try
            {
                //string q = "select count(*) from tblUsers where UserName = '" + username + "' and Sifre = '" + password + "'";
                //SqlDataAdapter sda = new SqlDataAdapter(q, con.mySqlConnection());
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                using (SqlCommand cmd = new SqlCommand("sp_Login", con.mySqlConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Save_Data();
                        this.Hide();
                        frmMain frm = new frmMain(string.Format("{0}", username));
                        frm.ShowDialog();
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "your username or password was incorrect! please try again.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con.sqlConnectionClose();
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void Init_Data()
        {

            if (Properties.Settings.Default.username != string.Empty)
            {

                if (Properties.Settings.Default.checkremember == "yes")
                {

                    metroTxt_username.Text = Properties.Settings.Default.username;
                    metroTxt_password.Text = Properties.Settings.Default.password;
                    checkBox1.Checked = true;
                }
                else
                {

                    metroTxt_username.Text = Properties.Settings.Default.username;

                }

            }
        }
        private void Save_Data()
        {

            if (checkBox1.Checked)
            {
                Properties.Settings.Default.username = metroTxt_username.Text;
                Properties.Settings.Default.password = metroTxt_password.Text;
                Properties.Settings.Default.checkremember = "yes";
                Properties.Settings.Default.Save();
            }
            else
            {

                Properties.Settings.Default.username = metroTxt_username.Text;
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.checkremember = "no";
                Properties.Settings.Default.Save();

            }
        }
        private void Login_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
