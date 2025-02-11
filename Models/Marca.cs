using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Marca
    {
        public string IdMarca {get; set;}
        public string NameMarca {get; set;}

        public bool estado {get; set;}

        List<Producto> Products {get; set;}

        public Marca() { 
            Products = new List<Producto>();
        }

        public Marca(string idMarca, string nameMarca, bool estado)
        {
            IdMarca = idMarca; NameMarca = nameMarca;
            this.estado = estado;
        }
    }
}
