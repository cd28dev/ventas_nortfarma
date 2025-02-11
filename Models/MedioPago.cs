using System;
using System.Collections.Generic;

namespace Models
{
    public class MedioPago
    {
        public string IdMedio { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public Tarjeta tarjeta { get; set; } 
        public List<DetalleDePago>  detalleDePagos { get; set; }

        // Constructor con validación
        public MedioPago(string idMedio, string nombre, bool estado)
        {

            IdMedio = idMedio;
            Nombre = nombre;
            Estado = estado;
        }

        public MedioPago() { 
            this.detalleDePagos = new List<DetalleDePago>();
            tarjeta = new Tarjeta();
        }


    }
}
