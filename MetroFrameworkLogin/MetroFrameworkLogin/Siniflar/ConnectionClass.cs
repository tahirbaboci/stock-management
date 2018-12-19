using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MetroFrameworkLogin.Siniflar
{
    public class ConnectionClass
    {
        private string conection = "Data Source=DESKTOP-RI864PG\\SQLEXPRESS;Initial Catalog=StokDemirbasTakibi;Integrated Security=True";
        SqlConnection connect;
        public SqlConnection mySqlConnection()
        {
          connect = new SqlConnection(conection);
            connect.Open();
            return connect;
        }
        public SqlConnection sqlConnectionClose()
        {
            connect.Close();
            return connect;
        }
        
    }
}
