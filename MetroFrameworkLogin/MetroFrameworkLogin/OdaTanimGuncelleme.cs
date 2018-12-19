using MetroFrameworkLogin.Siniflar;
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

namespace MetroFrameworkLogin
{
    public partial class OdaTanimGuncelleme : MetroFramework.Forms.MetroForm
    {
        bool _getBack;
        public string UserInfo { get; set; }

        ConnectionClass con = new ConnectionClass();
        Oda OdaEkleme = new Oda();

        public OdaTanimGuncelleme(string username)
        {
            InitializeComponent();

            Resizable = false;
            this.MaximizeBox = false;

            UserInfo = username;

            OdaCombobox();
            PersonelCombobox();
        }

        private void LinkLogOut_Click(object sender, EventArgs e)
        {
            _getBack = true;
            this.Close();
        }
        //tblOdadan veri cekiyoruz combobox
        private void OdaCombobox()
        {
            try
            {
                string query = "select OdaID, OdaAdi, PersonelID, DepartmanID, Aciklama from tblOda where PersonelID != 0";
                SqlDataAdapter da = new SqlDataAdapter(query, con.mySqlConnection());
                DataSet ds = new DataSet();
                da.Fill(ds, "Oda");
                metroComboBox_odatanimla_Oda_Adi_Guncelleme.DisplayMember = "OdaAdi";
                metroComboBox_odatanimla_Oda_Adi_Guncelleme.ValueMember = "OdaID";
                metroComboBox_odatanimla_Oda_Adi_Guncelleme.DataSource = ds.Tables["Oda"];
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //tblpersonelden veri cekiyoruz combobox
        private void PersonelCombobox()
        {
            try
            {
                string query = "select PersonelID, PersonelAdi, PersonelSoyadi from tblPersonel where personelID != 0";
                SqlDataAdapter da = new SqlDataAdapter(query, con.mySqlConnection());
                DataSet ds = new DataSet();
                da.Fill(ds, "Personel");
                da.Fill(ds, "Personel2");
                metroComboBox_odatanimla_PersonelAdi_guncelleme.DisplayMember = "PersonelAdi";
                metroComboBox_odatanimla_PersonelAdi_guncelleme.ValueMember = "PersonelID";
                metroComboBox_odatanimla_PersonelAdi_guncelleme.DataSource = ds.Tables["Personel"];
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton_odatanimlama_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string oda_Adi = metroComboBox_odatanimla_Oda_Adi_Guncelleme.Text;
                string personel_Adi = metroComboBox_odatanimla_PersonelAdi_guncelleme.Text;
                OdaEkleme = new Oda();
                OdaEkleme.OdaTanimla(int.Parse(metroComboBox_odatanimla_Oda_Adi_Guncelleme.SelectedValue.ToString()), int.Parse(metroComboBox_odatanimla_PersonelAdi_guncelleme.SelectedValue.ToString()));
                OdaCombobox();
                MetroFramework.MetroMessageBox.Show(this, personel_Adi + " adli personel " + oda_Adi + " isimli odaya zimetlenmistir", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
