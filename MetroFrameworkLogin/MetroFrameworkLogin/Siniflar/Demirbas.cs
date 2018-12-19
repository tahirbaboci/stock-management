using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MetroFrameworkLogin.Siniflar;
using System.Data;

namespace MetroFrameworkLogin
{
    public class Demirbas
    {
        public int DemID { get; set; }
        public int Fakulte { get; set; }
        public int Departman { get; set; }
        public int kategori { get; set; }
        public string Adi { get; set; }
        public string DemirbasKodu; // fakulte numarasi.departman no.d kategori.dAdi      01.03.13.456
        public double Fiyat { get; set; }
        public int Adeti { get; set; }
        public string AlmaTarihi { get; set; }

        ConnectionClass con = new ConnectionClass();
        
        public Demirbas()
        {
            
        }
        public Demirbas(int DemID, int fakulte, int departman, int kategori, string adi, double fiyat, int adet, string AlmaTarihi)
        {
            this.DemID = DemID;
            this.Fakulte = fakulte;
            this.Departman = departman;
            this.kategori = kategori;
            this.Adi = adi;
            this.Fiyat = fiyat;
            this.Adeti = adet;
            this.AlmaTarihi = AlmaTarihi;
        }


        
        public void insert(int DemID, int fakulte, int departman, int kategori, string adi, double fiyat, int adet, string AlmaTarihi)
        {
            this.DemirbasKodu = 0.ToString(); 
                //fakulte + "." + departman + "." + kategori + "." + adi;

            string EkleQuery2 = "sp_DemirbasEkleGuncelleSil";
            SqlCommand sC2 = new SqlCommand(EkleQuery2, con.mySqlConnection());
            sC2.CommandType = CommandType.StoredProcedure;
            sC2.Parameters.AddWithValue("@demID", DemID);
            sC2.Parameters.AddWithValue("@fakulte", fakulte);
            sC2.Parameters.AddWithValue("@departman", departman);
            sC2.Parameters.AddWithValue("@DAdi", adi);
            sC2.Parameters.AddWithValue("@Adeti", adet);
            sC2.Parameters.AddWithValue("@DemirbasKod", DemirbasKodu);
            sC2.Parameters.AddWithValue("@fiyat", fiyat);
            sC2.Parameters.AddWithValue("@kategori", kategori);
            sC2.Parameters.AddWithValue("@AlmaTarihi", AlmaTarihi);
            sC2.Parameters.AddWithValue("@Action", "Insert");

            sC2.ExecuteNonQuery();
            con.sqlConnectionClose();
            
            

            string UpdateQuery = "sp_DemirbasKodu";
            SqlCommand sC3 = new SqlCommand(UpdateQuery, con.mySqlConnection());
            sC3.CommandType = CommandType.StoredProcedure;

            sC3.ExecuteNonQuery();
            con.sqlConnectionClose();


        }
        public void Update(int fakulte, int departman, int kategori, string adi, double fiyat, int adet, string AlmaTarihi, int id)
        {

            this.DemirbasKodu = fakulte + "." + departman + "." + kategori + "." + adi;

            string EkleQuery2 = "sp_DemirbasEkleGuncelleSil";
            SqlCommand sC2 = new SqlCommand(EkleQuery2, con.mySqlConnection());
            sC2.CommandType = CommandType.StoredProcedure;
            sC2.Parameters.AddWithValue("@demID", id);
            sC2.Parameters.AddWithValue("@fakulte", fakulte);
            sC2.Parameters.AddWithValue("@departman", departman);
            sC2.Parameters.AddWithValue("@DAdi", adi);
            sC2.Parameters.AddWithValue("@Adeti", adet);
            sC2.Parameters.AddWithValue("@DemirbasKod", DemirbasKodu);
            sC2.Parameters.AddWithValue("@fiyat", fiyat);
            sC2.Parameters.AddWithValue("@kategori", kategori);
            sC2.Parameters.AddWithValue("@AlmaTarihi", AlmaTarihi);
            sC2.Parameters.AddWithValue("@Action", "Update");

            sC2.ExecuteNonQuery();
            con.sqlConnectionClose();
        }
        
    }
        
}

