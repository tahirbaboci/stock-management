using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroFrameworkLogin.Siniflar
{
    public class Departman
    {
        public int departmanID { get; set; }
        public string departmanAdi { get; set; }
        public Fakulte fakulteID { get; set; }
    }
}
