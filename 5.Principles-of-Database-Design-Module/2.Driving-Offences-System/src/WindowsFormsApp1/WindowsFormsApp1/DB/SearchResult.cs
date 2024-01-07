using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DB
{
    public class SearchResult
    {
        public string CarCode { get; set; }
        public string PersonId { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public double PriceSum { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
