using System;

namespace Models
{
    public class Anulacion
    {
        // Propiedades automáticas con validación en el set
        public string IdAnulacion { get; set; }
        public string Estado { get; set; }
        public string IdVenta { get; set; }
        public string IdEmpleado { get; set; }
        public string IdDetalleVenta { get; set; }

        public Anulacion(string idAnulacion, string estado, string idVenta, string idEmpleado, string idDetalleVenta)
        {
            this.IdAnulacion = idAnulacion;
            this.Estado = estado;
            this.IdVenta = idVenta;
            this.IdEmpleado = idEmpleado;
            this.IdDetalleVenta = idDetalleVenta;
        }

        
    }
}
