using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Customer
    {
        public string fullname { get; set; }
        public int ssid { get; set; }
        public string address { get; set; }

        public List<Product> products { get; set; }
    }
}
