using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroFrameworkLogin.Siniflar
{
    public class Fakulte
    {
        public int fakulteID { get; set; }
        public string fakulteAdi { get; set; }
        List<Departman> listDepartmans = new List<Departman>();
        public Fakulte()
        {
            
        }
    }
}
