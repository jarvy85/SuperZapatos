using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModel
{
    public class articlesViewModel
    {
        public List<articles> articles { get; set; }
        public bool sucess { get; set; }
        public int total_elements
        {
            get 
            {
                return articles?.Count ?? 0; //Operador de Nullidad    
            }
        }
    }
}
