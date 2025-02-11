using System;

namespace Models
{
    public class DetalleDeVenta
    {
        public string IdDetalleVenta { get; set; }
        public int Cantidad { get; set; }
        public double Descuento { get; set; }
        public double Subtotal { get; set; }
        public Venta venta { get; set; }

        public Anulacion anulacion { get; set; }

        // Constructor con validación
        public DetalleDeVenta(string idDetalleVenta, int cantidad, double descuento, double subtotal, Venta v)
        {

            IdDetalleVenta = idDetalleVenta;
            Cantidad = cantidad;
            Descuento = descuento;
            Subtotal = subtotal;
            venta = v;
        }
    }
}
