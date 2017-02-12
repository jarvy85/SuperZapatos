using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Modelos.ViewModel
{
    public class storesViewModel
    {
        public List<stores> stores { get; set; }
        public bool sucess { get; set; }
        public int total_elements
        {
            get
            {
                return stores?.Count ?? 0; //Operador de Nullidad    
            }
        }
    }

}
