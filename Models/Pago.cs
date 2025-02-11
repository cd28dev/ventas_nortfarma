using System;
using System.Collections.Generic;

namespace Models
{
    public class Pago
    {
        public string IdPago { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }
        public Empleado empleado { get; set; }
        public Venta venta { get; set; }
        public Comprobante comprobante { get; set; }
        public List<DetalleDePago> detalleDePagos { get; set; }

        // Constructor con validación
        public Pago(string idPago, DateTime fecha, double total, string estado, Empleado e, Venta v)
        {

            IdPago = idPago;
            Fecha = fecha;
            Total = total;
            Estado = estado;
            this.empleado = e;
            this.venta = v;
        }


        public Pago() { 
            detalleDePagos = new List<DetalleDePago>();
            
        }

        private void addDetalles(DetalleDePago detalleDePago)
        {
            detalleDePagos.Add(detalleDePago);
        }
    }
}
