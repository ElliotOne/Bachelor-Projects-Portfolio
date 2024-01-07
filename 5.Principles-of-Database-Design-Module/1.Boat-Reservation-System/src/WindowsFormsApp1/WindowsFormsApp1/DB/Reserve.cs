using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DB
{
    public class Reserve
    {
        public int rid { get; set; }
        public int bid { get; set; }
        public int sid { get; set; }
        public string sname { get; set; }
        public string bname { get; set; }
        public DateTime rdate { get; set; }
    }
}
