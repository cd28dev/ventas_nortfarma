using System;
using System.Collections.Generic;

namespace Models
{
    public class Farmacia
    {
        public string IdFarmacia { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public Ciudad ciudad { get; set; }

        public List<Venta> ventas { get; set; }
        public Farmacia() { 
            ventas = new List<Venta>();
        }

        // Constructor con validaciones
        public Farmacia(string idFarmacia, string nombre, string direccion, string estado, Ciudad city)
        {
            
            IdFarmacia = idFarmacia;
            Nombre = nombre;
            Direccion = direccion;
            Estado = estado;
            this.ciudad = city;
        }
    }


}
