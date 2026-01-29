using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace potdoga
{
    public class Part
    {
        public int part_id { get; set; }
        public string name { get; set; }
        public string manufacturer { get; set; }
        public string sku { get; set; }
        public string category { get; set; }
        public int unit_price { get; set; }
        public int in_stock { get; set; }
    }
}
