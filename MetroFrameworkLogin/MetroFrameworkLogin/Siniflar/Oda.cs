using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFrameworkLogin.Siniflar;
using System.Data.SqlClient;
using System.Data;

namespace MetroFrameworkLogin
{
    public class Oda
    {
        //public Departman departmanNo { get; set; }
        public int DepartmanNo { get; set; }
        public int odaID { get; set; }
        public string OdaAdi { get; set; }
        public string aciklama { get; set; }
        //public Personel odaSorumlusu { get; set; }
        public int odaSorumlusu { get; set; }

        ConnectionClass con = new ConnectionClass();

        public Oda()
        {

        }
        public Oda(int departman, int odaid, string odaadi, string aciklama, int personelNo)
        {
            this.DepartmanNo = departman;
            this.odaID = odaid;
            this.OdaAdi = odaadi;
            this.aciklama = aciklama;
            this.odaSorumlusu = personelNo;
        }

        public void Ekle(int departmanNo, string odaAdi, string aciklama)
        {
            string EkleQuery2 = "sp_OdaEkle";
            SqlCommand sC2 = new SqlCommand(EkleQuery2, con.mySqlConnection());
            sC2.CommandType = CommandType.StoredProcedure;
            sC2.Parameters.AddWithValue("@odaAdi", odaAdi);
            sC2.Parameters.AddWithValue("@departman", departmanNo);
            sC2.Parameters.AddWithValue("@aciklama", aciklama);

            sC2.ExecuteNonQuery();
            con.sqlConnectionClose();
        }
        public void OdaTanimla(int odaID, int personeID)
        {
            string EkleQuery2 = "sp_Oda_Tanimla";
            SqlCommand sC2 = new SqlCommand(EkleQuery2, con.mySqlConnection());
            sC2.CommandType = CommandType.StoredProcedure;
            sC2.Parameters.AddWithValue("@odaID", odaID);
            sC2.Parameters.AddWithValue("@PersonelID", personeID);

            sC2.ExecuteNonQuery();
            con.sqlConnectionClose();
        }
        public void Odaya_DemEkle(int odaID, int demID, int adet)
        {
            string EkleQuery2 = "sp_StoktanOdaya_DAtama";
            SqlCommand sC2 = new SqlCommand(EkleQuery2, con.mySqlConnection());
            sC2.CommandType = CommandType.StoredProcedure;
            sC2.Parameters.AddWithValue("@odaID", odaID);
            sC2.Parameters.AddWithValue("@demID", demID);
            sC2.Parameters.AddWithValue("@adet", adet);

            sC2.ExecuteNonQuery();
            con.sqlConnectionClose();
        }
        public void demirbas_Adet_Guncellemesi(int demID, int adet)
        {
            string EkleQuery2 = "sp_stoktaOdaya_demirbas_Adetin_Guncellemesi";
            SqlCommand sC2 = new SqlCommand(EkleQuery2, con.mySqlConnection());
            sC2.CommandType = CommandType.StoredProcedure;
            sC2.Parameters.AddWithValue("@demID", demID);
            sC2.Parameters.AddWithValue("@demAdet", adet);

            sC2.ExecuteNonQuery();
            con.sqlConnectionClose();
        }
        public void OdadanOdaya_Dem_atama(int silinecek_OdaID, int silinecek_DemID, int atanacak_OdaID, int adet)
        {
            string EkleQuery2 = "sp_Odadan_Odaya_Datama";
            SqlCommand sC2 = new SqlCommand(EkleQuery2, con.mySqlConnection());
            sC2.CommandType = CommandType.StoredProcedure;
            sC2.Parameters.AddWithValue("@silinecekdem_OdaID", silinecek_OdaID);
            sC2.Parameters.AddWithValue("@silinecekDemID", silinecek_DemID);
            sC2.Parameters.AddWithValue("@atanacakOdaID", atanacak_OdaID);
            sC2.Parameters.AddWithValue("@adet", adet);

            sC2.ExecuteNonQuery();
            con.sqlConnectionClose();
        }
    }
}
