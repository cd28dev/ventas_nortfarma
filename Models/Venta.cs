using System;
using System.Collections.Generic;

namespace Models
{
    public class Venta
    {
        public string IdVenta { get; private set; }
        public DateTime Fecha { get; set; }
        public double Total { get; private set; }
        public string Estado { get; private set; }
        public Pedido pedido { get; private set; }
        public Farmacia farmacia { get; private set; }
        public Empleado empleado { get; private set; }

        public List<Pago> pagos { get; private set; }
        public List<DetalleDeVenta> detalleDeVentas { get; private set; }

        public Anulacion anulacion { get; private set; }

        // Constructor
        public Venta(string idVenta, DateTime fecha, double total, string estado, Pedido p, Farmacia f, Empleado e)
        {
            this.IdVenta = idVenta;
            this.Fecha = fecha;
            this.Total = total;
            this.Estado = estado;
            this.pedido = p;
            this.farmacia = f;
            this.empleado = e;
        }


        public Venta() { 
            pagos = new List<Pago>();
            detalleDeVentas = new List<DetalleDeVenta>();
        }
    }
}
