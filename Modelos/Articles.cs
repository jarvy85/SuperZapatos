using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class articles
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double total_in_shelf { get; set; }
        public double total_in_vault { get; set; }
        public int store_id { get; set; }
        public string store_name { 
            get 
            {
                return stores?.name ?? "";
            } 
        }

        public virtual stores stores { get; set; } //pilas que sea publica para poder accesar desde aca
    }
}
