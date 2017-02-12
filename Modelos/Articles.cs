using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Articles
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double total_in_shelf { get; set; }
        public double total_in_vault { get; set; }
        public int store_id { get; set; }

        public virtual Stores stores { get; set; } //pilas que sea publica para poder accesar desde aca
    }
}
