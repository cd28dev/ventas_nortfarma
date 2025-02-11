using System;

namespace Models
{
    public class Anulacion
    {
        // Propiedades automáticas con validación en el set
        public string IdAnulacion { get; set; }
        public string Estado { get; set; }
        public Empleado empleado { get; set; }
        public DetalleDeVenta detVenta { get; set; }

        public Anulacion(string idAnulacion, string estado, Empleado e, DetalleDeVenta dv)
        {
            this.IdAnulacion = idAnulacion;
            this.Estado = estado;
            this.empleado = e;
            this.detVenta = dv;
        }

        public Anulacion() { }
        
    }
}
