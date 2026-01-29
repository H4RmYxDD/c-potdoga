using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace potdoga
{
    public class Rootobject
    {
        public DateTime export_date { get; set; }
        public string shop_name { get; set; }
        public Customer[] customers { get; set; }
        public Part[] parts { get; set; }
        public Order[] orders { get; set; }
        public Summary summary { get; set; }
    }
    }