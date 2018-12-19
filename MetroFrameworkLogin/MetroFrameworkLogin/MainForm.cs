using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFrameworkLogin.Siniflar;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MetroFrameworkLogin
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        bool _logOut = false;

        ConnectionClass con = new ConnectionClass();
        Demirbas dEkleme;
        Oda OdaEkleme;
        TestFunctions tests;

        List<Fakulte> listFakulte = new List<Fakulte>();
        List<Departman> listDepartman = new List<Departman>();

        public string UserInfo { get; set; }
        public frmMain(string userinfo)
        {
            Resizable = false;
            this.MaximizeBox = false;
            InitializeComponent();
            label_userInfo.Text = userinfo;
            kontrol(userinfo);
            UserInfo = userinfo;

            DateTime_Alma_Tarihi.MaxDate = DateTime.Now;

            



        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            AdvancedSearch();
            KategoriCombobox();
            FakulteCombobox();
            PersonelCombobox();
            OdaCombobox();
            OdaCombobox_OD_islemleri();
            fillDataGridView();
        }
        private void LinkLogOut_Click(object sender, EventArgs e)
        {
            _logOut = true;
            this.Close();
            Login_form frmLogin = new Login_form();
            frmLogin.Show();
        }



        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_logOut)
            {
                Application.Exit();
            }
        }

        // admin mi normal kullanici mi kontrol ediyor ona gore ekran gelecek
        private void kontrol(string username)
        {
            if (!username.Equals("admin"))
            {
                metrotabControlAna.HideTab(tabStokKaydi);
                metroTabControl1.HideTab(metroTabPage2);
            }
        }

        private void AdvancedSearch()
        {
            label_D_Fiyati.Visible = false;
            label_D_Turu.Visible = false;
            label_D_Adeti.Visible = false;

            metroTextBox_Demirbas_Adeti_Ara.Visible = false;
            metroTextBox_Demirbas_Turu_Ara.Visible = false;
            metroTextBox_Demirbas_Fiyati_Ara_1.Visible = false;
            metroTextBox_Demirbas_Fiyati_Ara_2.Visible = false;
        }
        private void metroCheckBox_Advanced_Search_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox_Advanced_Search.Checked == true)
            {
                label_D_Fiyati.Visible = true;
                label_D_Turu.Visible = true;
                label_D_Adeti.Visible = true;

                metroTextBox_Demirbas_Adeti_Ara.Visible = true;
                metroTextBox_Demirbas_Turu_Ara.Visible = true;
                metroTextBox_Demirbas_Fiyati_Ara_1.Visible = true;
                metroTextBox_Demirbas_Fiyati_Ara_2.Visible = true;
            }
            else
            {
                label_D_Fiyati.Visible = false;
                label_D_Turu.Visible = false;
                label_D_Adeti.Visible = false;

                metroTextBox_Demirbas_Adeti_Ara.Visible = false;
                metroTextBox_Demirbas_Turu_Ara.Visible = false;
                metroTextBox_Demirbas_Fiyati_Ara_1.Visible = false;
                metroTextBox_Demirbas_Fiyati_Ara_2.Visible = false;
            }

        }

        //tblOdadan veri cekiyoruz combobox
        private void OdaCombobox()
        {
            try
            {
                string query = "select OdaID, OdaAdi, PersonelID, DepartmanID, Aciklama from tblOda where PersonelID = 0";
                SqlDataAdapter da = new SqlDataAdapter(query, con.mySqlConnection());
                DataSet ds = new DataSet();
                da.Fill(ds, "Oda");
                metroComboBox_odatanimla_Oda_Adi.DisplayMember = "OdaAdi";
                metroComboBox_odatanimla_Oda_Adi.ValueMember = "OdaID";
                metroComboBox_odatanimla_Oda_Adi.DataSource = ds.Tables["Oda"];
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OdaCombobox_OD_islemleri()
        {
            try
            {
                string query = "select OdaID, OdaAdi, PersonelID, DepartmanID, Aciklama from tblOda";
                SqlDataAdapter da = new SqlDataAdapter(query, con.mySqlConnection());
                DataSet ds = new DataSet();
                da.Fill(ds, "Oda");
                da.Fill(ds, "Oda2");
                da.Fill(ds, "Oda3");
                da.Fill(ds, "Oda4");
                metroComboBox_StoktanOdaya_Datanacak_Oda_sec.DisplayMember = "OdaAdi";
                metroComboBox_StoktanOdaya_Datanacak_Oda_sec.ValueMember = "OdaID";
                metroComboBox_StoktanOdaya_Datanacak_Oda_sec.DataSource = ds.Tables["Oda"];

                metroComboBox_OdadanOdaya_Datanacak_Oda_Adi.DisplayMember = "OdaAdi";
                metroComboBox_OdadanOdaya_Datanacak_Oda_Adi.ValueMember = "OdaID";
                metroComboBox_OdadanOdaya_Datanacak_Oda_Adi.DataSource = ds.Tables["Oda2"];

                metroComboBox_OdadanOdaya_Dsilinecek_Oda_sec.DisplayMember = "OdaAdi";
                metroComboBox_OdadanOdaya_Dsilinecek_Oda_sec.ValueMember = "OdaID";
                metroComboBox_OdadanOdaya_Dsilinecek_Oda_sec.DataSource = ds.Tables["Oda3"];

                metroComboBox_OdaAdi_Rapor.DisplayMember = "OdaAdi";
                metroComboBox_OdaAdi_Rapor.ValueMember = "OdaID";
                metroComboBox_OdaAdi_Rapor.DataSource = ds.Tables["Oda4"];
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
                metroComboBox_odatanimla_PersonelAdi.DisplayMember = "PersonelAdi";
                metroComboBox_odatanimla_PersonelAdi.ValueMember = "PersonelID";
                metroComboBox_odatanimla_PersonelAdi.DataSource = ds.Tables["Personel"];

                comboBox_PersonelIDArama.DisplayMember = "PersonelAdi";
                comboBox_PersonelIDArama.ValueMember = "PersonelID";
                comboBox_PersonelIDArama.DataSource = ds.Tables["Personel2"];
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // metro datagridview'u veri ile dolduruyor
        public void fillDataGridView()
        {
            SqlDataAdapter d = new SqlDataAdapter("select * from tblDemirbaslar where DemirbasAdet != 0", con.mySqlConnection());
            DataSet ds = new DataSet();
            d.Fill(ds);
            metroGrid_StokKaydi_Demirbaslar.DataSource = ds.Tables[0];
        }
        //tblkategoriden degerleri cekiyoruz
        private void KategoriCombobox()
        {
            try
            {
                string query = "select DemirbasKategoriID, DemirbasKategoriAdi from tblDemirbasKategori";
                SqlDataAdapter da = new SqlDataAdapter(query, con.mySqlConnection());
                DataSet ds = new DataSet();
                da.Fill(ds, "Kategori");
                metroComboBox_kategori.DisplayMember = "DemirbasKategoriAdi";
                metroComboBox_kategori.ValueMember = "DemirbasKategoriID";
                metroComboBox_kategori.DataSource = ds.Tables["Kategori"];
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //tblfakulteden degerleri cekiyoruz
        private void FakulteCombobox()
        {
            try
            {
                string query = "select FakulteID, FakulteAdi from tblFakulte";
                SqlDataAdapter da = new SqlDataAdapter(query, con.mySqlConnection());
                DataSet ds = new DataSet();
                da.Fill(ds, "Fakulte");
                da.Fill(ds, "Fakulte2");
                metroComboBox_Fakulte.DisplayMember = "FakulteAdi";
                metroComboBox_Fakulte.ValueMember = "FakulteID";
                metroComboBox_Fakulte.DataSource = ds.Tables["Fakulte"];
                //oda kaydi icin
                metroComboBox_fakulte_odakaydi.DisplayMember = "FakulteAdi";
                metroComboBox_fakulte_odakaydi.ValueMember = "FakulteID";
                metroComboBox_fakulte_odakaydi.DataSource = ds.Tables["Fakulte2"];

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //tblfakulte ve departman combobox kontrolu
        private void DepartmanCombobox(int value)
        {
            try
            {
                string query = "select DepartmanID, DepartmanAdi from tblDepartman where FakulteID = '" + value + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con.mySqlConnection());
                DataSet ds = new DataSet();
                da.Fill(ds, "Departman");
                metroComboBox_Departman.DisplayMember = "DepartmanAdi";
                metroComboBox_Departman.ValueMember = "DepartmanID";
                metroComboBox_Departman.DataSource = ds.Tables["Departman"];
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DepartmanCombobox_Oda(int value)
        {
            try
            {
                string query = "select DepartmanID, DepartmanAdi from tblDepartman where FakulteID = '" + value + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con.mySqlConnection());
                DataSet ds = new DataSet();
                da.Fill(ds, "Departman");
                metroComboBox_departman_odakaydi.DisplayMember = "DepartmanAdi";
                metroComboBox_departman_odakaydi.ValueMember = "DepartmanID";
                metroComboBox_departman_odakaydi.DataSource = ds.Tables["Departman"];
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void metroComboBox_fakulte_odakaydi_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmanCombobox_Oda(int.Parse(metroComboBox_fakulte_odakaydi.SelectedValue.ToString()));
        }

        private void metroComboBox_Fakulte_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DepartmanCombobox(int.Parse(metroComboBox_Fakulte.SelectedValue.ToString()));
        }
        // stok cell click
        int DemID;
        int fakulte;
        int departman;
        string ad;
        int kategori;
        int adet;
        double fiyat;
        string alimtarihi;
        private void metroGrid_StokKaydi_Demirbaslar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int secilen = metroGrid_StokKaydi_Demirbaslar.SelectedCells[0].RowIndex;
                ad = metroGrid_StokKaydi_Demirbaslar.Rows[secilen].Cells[4].Value.ToString();
                if (ad == "")
                {

                }
                else
                {
                    DemID = int.Parse(metroGrid_StokKaydi_Demirbaslar.Rows[secilen].Cells[0].Value.ToString());
                    txt_Demirbas_Adi.Text = ad;
                    fakulte = int.Parse(metroGrid_StokKaydi_Demirbaslar.Rows[secilen].Cells[1].Value.ToString());
                    metroComboBox_Fakulte.SelectedValue = fakulte;
                    departman = int.Parse(metroGrid_StokKaydi_Demirbaslar.Rows[secilen].Cells[2].Value.ToString());
                    metroComboBox_Departman.SelectedValue = departman;
                    kategori = int.Parse(metroGrid_StokKaydi_Demirbaslar.Rows[secilen].Cells[3].Value.ToString());
                    metroComboBox_kategori.SelectedValue = kategori;
                    adet = int.Parse(metroGrid_StokKaydi_Demirbaslar.Rows[secilen].Cells[6].Value.ToString());
                    txt_Demirbas_Adeti.Text = adet.ToString();
                    fiyat = double.Parse(metroGrid_StokKaydi_Demirbaslar.Rows[secilen].Cells[8].Value.ToString());
                    txt_Demirbas_Fiyat.Text = fiyat.ToString();
                    alimtarihi = metroGrid_StokKaydi_Demirbaslar.Rows[secilen].Cells[7].Value.ToString();
                    DateTime_Alma_Tarihi.Value = Convert.ToDateTime(alimtarihi);

                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //ekle butonu
        string date;
        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                date = Convert.ToDateTime(DateTime_Alma_Tarihi.Value.ToString()).ToString("MM/dd/yyyy");
                dEkleme = new Demirbas();
                dEkleme.insert(DemID, int.Parse(metroComboBox_Fakulte.SelectedValue.ToString()), int.Parse(metroComboBox_Departman.SelectedValue.ToString()), int.Parse(metroComboBox_kategori.SelectedValue.ToString()), txt_Demirbas_Adi.Text, double.Parse(txt_Demirbas_Fiyat.Text), int.Parse(txt_Demirbas_Adeti.Text), date);

                fillDataGridView();
                MetroFramework.MetroMessageBox.Show(this, "Demirbas Ekleme islemi gerceklesmistir.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //btn guncelle
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                date = Convert.ToDateTime(DateTime_Alma_Tarihi.Value.ToString()).ToString("MM/dd/yyyy");
                dEkleme = new Demirbas();
                dEkleme.Update(int.Parse(metroComboBox_Fakulte.SelectedValue.ToString()), int.Parse(metroComboBox_Departman.SelectedValue.ToString()), int.Parse(metroComboBox_kategori.SelectedValue.ToString()), txt_Demirbas_Adi.Text, double.Parse(txt_Demirbas_Fiyat.Text), int.Parse(txt_Demirbas_Adeti.Text), date, DemID);
                fillDataGridView();
                MetroFramework.MetroMessageBox.Show(this, "Demirbas Guncelleme islemi gerceklesmistir.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void metroButton_Oda_Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                OdaEkleme = new Oda();
                OdaEkleme.Ekle(int.Parse(metroComboBox_departman_odakaydi.SelectedValue.ToString()), metroTextBox_OdaAdi_odaekle.Text, textBox_aciklama.Text);
                MetroFramework.MetroMessageBox.Show(this, "Oda Eklenmistir", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OdaCombobox();
                OdaCombobox_OD_islemleri();
                metroTextBox_OdaAdi_odaekle.Clear();
                textBox_aciklama.Clear();

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton_Oda_Tanimla_Click(object sender, EventArgs e)
        {
            try
            {
                string oda_Adi = metroComboBox_odatanimla_Oda_Adi.Text;
                string personel_Adi = metroComboBox_odatanimla_PersonelAdi.Text;
                OdaEkleme = new Oda();
                OdaEkleme.OdaTanimla(int.Parse(metroComboBox_odatanimla_Oda_Adi.SelectedValue.ToString()), int.Parse(metroComboBox_odatanimla_PersonelAdi.SelectedValue.ToString()));
                OdaCombobox();
                MetroFramework.MetroMessageBox.Show(this, personel_Adi + " adli personel " + oda_Adi + " isimli odaya zimetlenmistir", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //aranan demirbasların datagridView'a gozukmesi
        public void arana_demirbaslar()
        {
            string query = "select DemirbasID, DemirbasAdi, DemirbasKodu, DemirbasAdet, DemirbasKategoriAdi from tblDemirbaslar d Inner Join tblDemirbasKategori dk on d.DemirbasKategoriID=dk.DemirbasKategoriID where DemirbasAdi like '%" + metroTextBox_StoktanOdaya_Demirbas_Ara.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(query, con.mySqlConnection());
            DataSet ds = new DataSet();
            da.Fill(ds, "demirbas");
            metroGrid_StoktanOdaya_Demirbaslar.DataSource = ds.Tables[0];
        }
        

        int Odadan_Odaya_secilen_odaninID_atanacak;
        private void metroComboBox_OdadanOdaya_Datanacak_Oda_Adi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Odadan_Odaya_secilen_odaninID_atanacak = int.Parse(metroComboBox_OdadanOdaya_Datanacak_Oda_Adi.SelectedValue.ToString());
            Odadan_Odaya_secilen_Odanin_Demirbaslari_atanacak();
        }
        public void Odadan_Odaya_secilen_Odanin_Demirbaslari_atanacak()
        {
            try
            {
                SqlDataAdapter d = new SqlDataAdapter("select d.DemirbasID, d.DemirbasAdi, od.Adet from tblDemirbaslar d INNER JOIN tblOdaDemirbas od on d.DemirbasID=od.DemirbasID where od.OdaID = '" + Odadan_Odaya_secilen_odaninID_atanacak + "'", con.mySqlConnection());
                DataSet ds = new DataSet();
                d.Fill(ds);
                metroGrid_OdadanOdaya_secilenOdanin_Demirbaslari.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int Odadan_Odaya_secilen_odaninID_silinecek;
        private void metroComboBox_OdadanOdaya_Dsilinecek_Oda_sec_SelectedIndexChanged(object sender, EventArgs e)
        {
            Odadan_Odaya_secilen_odaninID_silinecek = int.Parse(metroComboBox_OdadanOdaya_Dsilinecek_Oda_sec.SelectedValue.ToString());
            Odadan_Odaya_secilen_Odanin_Demirbaslari_silinecek();
        }
        public void Odadan_Odaya_secilen_Odanin_Demirbaslari_silinecek()
        {
            SqlDataAdapter d = new SqlDataAdapter("select d.DemirbasID, d.DemirbasAdi, od.Adet from tblDemirbaslar d INNER JOIN tblOdaDemirbas od on d.DemirbasID=od.DemirbasID where od.OdaID = '" + Odadan_Odaya_secilen_odaninID_silinecek + "'", con.mySqlConnection());
            DataSet ds = new DataSet();
            d.Fill(ds);
            metroGrid_OdadanOdaya_secilenOdanin_Demirbaslari_silinecek.DataSource = ds.Tables[0];
        }

        
        //secilen odanin demirbaslari datagridView'a gozukmesi
        int Stoktan_Odaya_secilen_odaninID;
        private void metroComboBox_StoktanOdaya_Datanacak_Oda_sec_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stoktan_Odaya_secilen_odaninID = int.Parse(metroComboBox_StoktanOdaya_Datanacak_Oda_sec.SelectedValue.ToString());
            Stoktan_Odaya_secilenOdanin_Demirbaslari();
        }
        public void Stoktan_Odaya_secilenOdanin_Demirbaslari()
        {
            SqlDataAdapter d = new SqlDataAdapter("select d.DemirbasAdi, od.Adet from tblDemirbaslar d INNER JOIN tblOdaDemirbas od on d.DemirbasID=od.DemirbasID where od.OdaID = '" + Stoktan_Odaya_secilen_odaninID + "'", con.mySqlConnection());
            DataSet ds = new DataSet();
            d.Fill(ds);
            metroGrid_StoktanOdaya_Secilen_odanin_Demirbaslari.DataSource = ds.Tables[0];
        }
        int stokOda_DemID;
        int stokOda_adet;
        private void metroGrid_StoktanOdaya_Demirbaslar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cell_Click_StoktanOdaya_Silinecek();
        }
        private void Cell_Click_StoktanOdaya_Silinecek()
        {
            try
            {
                int secilen = metroGrid_StoktanOdaya_Demirbaslar.SelectedCells[0].RowIndex;
                string ad = metroGrid_StoktanOdaya_Demirbaslar.Rows[secilen].Cells[1].Value.ToString();
                if (ad != "")
                {
                    stokOda_DemID = int.Parse(metroGrid_StoktanOdaya_Demirbaslar.Rows[secilen].Cells[0].Value.ToString());
                    stokOda_adet = int.Parse(metroGrid_StoktanOdaya_Demirbaslar.Rows[secilen].Cells[3].Value.ToString());
                }
                else
                {
                    stokOda_DemID = 0;
                    stokOda_adet = 0;
                }

            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void metroButton_StoktanOdaya_Demirbas_ata_Click(object sender, EventArgs e)
        {

            try
            {
                Stoktan_Odaya_secilen_odaninID = int.Parse(metroComboBox_StoktanOdaya_Datanacak_Oda_sec.SelectedValue.ToString());
                int miktar = int.Parse(metroTextBox_StoktanOdaya_Demirbas_miktari_ata.Text);
                OdaEkleme = new Oda();
                if (int.Parse(metroTextBox_StoktanOdaya_Demirbas_miktari_ata.Text) > stokOda_adet)
                {
                    MetroFramework.MetroMessageBox.Show(this, "odaya atmak istediginiz demirbas adeti stokta yoktur. sectiginiz demirbasin adeti :" + stokOda_adet, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (int.Parse(metroTextBox_StoktanOdaya_Demirbas_miktari_ata.Text) <= 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "1 veya daha fazla demirbas adeti atabilirsiniz odaya", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (metroTextBox_StoktanOdaya_Demirbas_miktari_ata.Text.StartsWith(0.ToString()))
                {
                    MetroFramework.MetroMessageBox.Show(this, "0 ile baslayarak demirbas adeti olmaz", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    OdaEkleme.Odaya_DemEkle(Stoktan_Odaya_secilen_odaninID, stokOda_DemID, miktar);
                    stokOda_adet = stokOda_adet - miktar;
                    OdaEkleme.demirbas_Adet_Guncellemesi(stokOda_DemID, stokOda_adet);
                    arana_demirbaslar();
                    Stoktan_Odaya_secilenOdanin_Demirbaslari();
                    Cell_Click_StoktanOdaya_Silinecek();
                    MetroFramework.MetroMessageBox.Show(this, "Atama islemi gerceklesmistir.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        int OdadanOdaya_DemID;
        int OdadanOdaya_adet;
        private void metroGrid_OdadanOdaya_secilenOdanin_Demirbaslari_silinecek_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cell_Click_OdadanOdaya_Silinecek();
        }
        private void Cell_Click_OdadanOdaya_Silinecek()
        {
            try
            {
                int secilen = metroGrid_OdadanOdaya_secilenOdanin_Demirbaslari_silinecek.SelectedCells[0].RowIndex;
                string ad = metroGrid_OdadanOdaya_secilenOdanin_Demirbaslari_silinecek.Rows[secilen].Cells[1].Value.ToString();
                if (ad != "")
                {
                    OdadanOdaya_DemID = int.Parse(metroGrid_OdadanOdaya_secilenOdanin_Demirbaslari_silinecek.Rows[secilen].Cells[0].Value.ToString());
                    OdadanOdaya_adet = int.Parse(metroGrid_OdadanOdaya_secilenOdanin_Demirbaslari_silinecek.Rows[secilen].Cells[2].Value.ToString());
                }
                else
                {
                    OdadanOdaya_DemID = 0;
                    OdadanOdaya_adet = 0;
                }

            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void metroButton_OdadanOdaya_Demirbas_Ata_Click(object sender, EventArgs e)
        {
            try
            {
                //silinecek_OdaID,   silinecek_DemID,  atanacak_OdaID, Adet
                int silinecek_OdaID = int.Parse(metroComboBox_OdadanOdaya_Dsilinecek_Oda_sec.SelectedValue.ToString());
                int silinecek_DemID = OdadanOdaya_DemID;
                int atanacak_OdaID = int.Parse(metroComboBox_OdadanOdaya_Datanacak_Oda_Adi.SelectedValue.ToString());
                int adet = int.Parse(metroTextBox_Demirbas_atanacak_miktar.Text);

                OdaEkleme = new Oda();

                if (adet > OdadanOdaya_adet)
                {
                    MetroFramework.MetroMessageBox.Show(this, "odaya atmak istediginiz demirbas adeti stokta yoktur. sectiginiz demirbasin adeti :" + stokOda_adet, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (adet <= 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "1 veya daha fazla demirbas adeti atabilirsiniz odaya", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(silinecek_OdaID == atanacak_OdaID)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Acik Kapanmistir!!! odadan demirbası alıp aynı aldıgın odaya koyamazsın... Mantıksız!!! :P ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (metroTextBox_Demirbas_atanacak_miktar.Text.StartsWith(0.ToString()))
                {
                    MetroFramework.MetroMessageBox.Show(this, "0 ile baslayarak demirbas adeti olmaz", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    OdaEkleme.OdadanOdaya_Dem_atama(silinecek_OdaID, silinecek_DemID, atanacak_OdaID, adet);
                    Odadan_Odaya_secilen_Odanin_Demirbaslari_silinecek();
                    Odadan_Odaya_secilen_Odanin_Demirbaslari_atanacak();
                    MetroFramework.MetroMessageBox.Show(this, "Atama islemi gerceklesmistir.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cell_Click_OdadanOdaya_Silinecek();
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void metroTextBox_StoktanOdaya_Demirbas_Ara_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                arana_demirbaslar();

            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void personel_uzerindeki_dem_goster(int pID)
        {
            using (SqlCommand cmd = new SqlCommand("sp_personel_uzerindeki_dem", con.mySqlConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonelID", pID);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                metroGrid_personel_uzerindeki_demirbaslar.DataSource = dt;
                con.sqlConnectionClose();
            }

        }
        private void comboBox_PersonelIDArama_SelectedIndexChanged(object sender, EventArgs e)
        {
            int perID = int.Parse(comboBox_PersonelIDArama.SelectedValue.ToString());
            try
            {
                personel_uzerindeki_dem_goster(perID);
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        //textbox TESTLERI
        private void txt_Demirbas_Adi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tests = new TestFunctions();
                if (tests.IsDigit(txt_Demirbas_Adi.Text) || tests.IsPunctuation(txt_Demirbas_Adi.Text))
                {
                    txt_Demirbas_Adi.Clear();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Demirbas_Adi.Clear();
            }
            
        }

        private void txt_Demirbas_Fiyat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tests = new TestFunctions();
                if (tests.IsLetter(txt_Demirbas_Fiyat.Text) || tests.IsPunctuation(txt_Demirbas_Fiyat.Text) || tests.IsWhitespace(txt_Demirbas_Fiyat.Text))
                {
                    txt_Demirbas_Fiyat.Clear();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Demirbas_Fiyat.Clear();
            }

            
        }

        private void txt_Demirbas_Adeti_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tests = new TestFunctions();
                if (tests.IsLetter(txt_Demirbas_Adeti.Text) || tests.IsPunctuation(txt_Demirbas_Adeti.Text) || tests.IsWhitespace(txt_Demirbas_Adeti.Text) || int.Parse(txt_Demirbas_Adeti.Text) == 0)
                {
                    txt_Demirbas_Adeti.Clear();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Demirbas_Adeti.Clear();
            }
            
        }


        //RAPOR---------------------------------------------------PDF-------------------------------------------RAPOR
        private void Oda_demirbaslar_Rapor(int OdaID)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Oda_Uzerindeki_Demirbaslar_and_Sorumlusu_rapor", con.mySqlConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OdaID", OdaID);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                metroGrid_Oda_Rapor.DataSource = dt;
                con.sqlConnectionClose();
            }

        }
        private void metroComboBox_OdaAdi_Rapor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int OdaID = int.Parse(metroComboBox_OdaAdi_Rapor.SelectedValue.ToString());
            try
            {
                Oda_demirbaslar_Rapor(OdaID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void metroButton_RaporCikar_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4);
                    try
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
                        doc.Open();

                        BaseFont text = BaseFont.CreateFont("Helvetica", "Cp1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font f = new iTextSharp.text.Font(text, 16f, 1, BaseColor.BLUE);
                        Chunk c = new Chunk();
                        c.Font = f;
                        doc.Add(c);

                        Paragraph heading = new Paragraph("STOK DEMIRBAS TAKIBI \n\n\n", f);
                        heading.Alignment = Element.ALIGN_CENTER;
                        doc.Add(heading);
                        
                        Paragraph p2 = new Paragraph(" ");
                        doc.Add(p2);

                        ////Creating iTextSharp Table from the DataTable data
                        PdfPTable pdfTable = new PdfPTable(metroGrid_Oda_Rapor.ColumnCount);
                        pdfTable.DefaultCell.Padding = 8;
                        pdfTable.WidthPercentage = 100;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
                        //pdfTable.DefaultCell.BorderWidth = 0;

                        //Adding Header row
                        foreach (DataGridViewColumn column in metroGrid_Oda_Rapor.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                            pdfTable.AddCell(cell);
                        }

                        BaseFont text3 = BaseFont.CreateFont("Helvetica", "Cp1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font f3 = new iTextSharp.text.Font(text3, 10f, 0, BaseColor.BLACK);
                        Chunk c3 = new Chunk();
                        c3.Font = f3;
                        doc.Add(c3);

                        //Adding DataRow
                        int i = 0;
                        foreach (DataGridViewRow row in metroGrid_Oda_Rapor.Rows)
                        {

                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Value != null)
                                {
                                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), f3));

                                }

                            }
                        }
                        doc.Add(pdfTable);
                        byte[] belge = ms.ToArray();
                        string[] belgeAdi = sfd.FileName.Split('\\');
                        string gercekBelgeAdi = belgeAdi[belgeAdi.Length - 1];
                        belgeAdi = gercekBelgeAdi.Split('.');
                        gercekBelgeAdi = belgeAdi[0];

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }
        //Oda guncelleme islemleri
        private void metroButton_odatanimlama_guncelleme_islemi_Click(object sender, EventArgs e)
        {
            OdaTanimGuncelleme frm2 = new OdaTanimGuncelleme(UserInfo);
            frm2.ShowDialog();
            _logOut = true;
            

        }
        //ADINA GORE ARAMA
        private void SearchByName(string name)
        {
            using (SqlCommand cmd = new SqlCommand("sp_NameSearchDemirbas", con.mySqlConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DemirbasAdi", name);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                metroGrid_Aranan_Demirbaslar.DataSource = dt;
                con.sqlConnectionClose();
            }
        }
        private void metroTextBox_Demirbas_Adi_Ara_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchByName(metroTextBox_Demirbas_Adi_Ara.Text);
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        //FIYATA GORE ARAMA
        private void searchByFiyat(int min,int max)
        {
            using (SqlCommand cmd = new SqlCommand("sp_advanced_search_fiyat", con.mySqlConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@minFiyat", min);
                cmd.Parameters.AddWithValue("@maxFiyat", max);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                metroGrid_Aranan_Demirbaslar.DataSource = dt;
                con.sqlConnectionClose();
            }
        }
        private void metroTextBox_Demirbas_Fiyati_Ara_2_TextChanged(object sender, EventArgs e)
        {
            tests = new TestFunctions();
            try
            {
                if(metroTextBox_Demirbas_Fiyati_Ara_1.Text != "" && metroTextBox_Demirbas_Fiyati_Ara_2.Text != "")
                {
                    if (tests.IsDigit(metroTextBox_Demirbas_Fiyati_Ara_1.Text) && tests.IsDigit(metroTextBox_Demirbas_Fiyati_Ara_2.Text))
                    {
                        if (!metroTextBox_Demirbas_Fiyati_Ara_1.Text.StartsWith(0.ToString()) && !metroTextBox_Demirbas_Fiyati_Ara_2.Text.StartsWith(0.ToString()))
                        {
                            searchByFiyat(int.Parse(metroTextBox_Demirbas_Fiyati_Ara_1.Text), int.Parse(metroTextBox_Demirbas_Fiyati_Ara_2.Text));
                        }
                        

                    }
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //ADETE GORE ARAMA
        private void searchByAdet(int adet)
        {
            using (SqlCommand cmd = new SqlCommand("sp_advanced_search_Adet", con.mySqlConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@adet", adet);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                metroGrid_Aranan_Demirbaslar.DataSource = dt;
                con.sqlConnectionClose();
            }
        }

        private void metroTextBox_Demirbas_Adeti_Ara_TextChanged(object sender, EventArgs e)
        {
            tests = new TestFunctions();
            try
            {
                if(metroTextBox_Demirbas_Adeti_Ara.Text != "")
                {
                    if (tests.IsDigit(metroTextBox_Demirbas_Adeti_Ara.Text))
                    {
                        if (!metroTextBox_Demirbas_Adeti_Ara.Text.StartsWith(0.ToString()))
                        {
                            searchByAdet(int.Parse(metroTextBox_Demirbas_Adeti_Ara.Text));
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //KATEGORI'YE GORE ARAMAAA
        private void searchByKategori(string kategori)
        {
            using (SqlCommand cmd = new SqlCommand("sp_advanced_search_kategori", con.mySqlConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@kategori", kategori);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                metroGrid_Aranan_Demirbaslar.DataSource = dt;
                con.sqlConnectionClose();
            }
        }

        private void metroTextBox_Demirbas_Turu_Ara_TextChanged(object sender, EventArgs e)
        {
            
            tests = new TestFunctions();
            try
            {
                if (metroTextBox_Demirbas_Turu_Ara.Text != "")
                {
                    if (tests.IsLetter(metroTextBox_Demirbas_Turu_Ara.Text))
                    {
                        searchByKategori(metroTextBox_Demirbas_Turu_Ara.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}


