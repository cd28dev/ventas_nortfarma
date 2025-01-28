using System;

namespace Models
{
    public class DetalleDeVenta
    {
        public string IdDetalleVenta { get; set; }
        public int Cantidad { get; set; }
        public double Descuento { get; set; }
        public double Subtotal { get; set; }
        public string IdVenta { get; set; }

        // Constructor con validación
        public DetalleDeVenta(string idDetalleVenta, int cantidad, double descuento, double subtotal, string idVenta)
        {
            if (string.IsNullOrWhiteSpace(idDetalleVenta))
                throw new ArgumentException("El ID del detalle de venta no puede estar vacío.");
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            if (descuento < 0)
                throw new ArgumentException("El descuento no puede ser negativo.");
            if (subtotal < 0)
                throw new ArgumentException("El subtotal no puede ser negativo.");
            if (string.IsNullOrWhiteSpace(idVenta))
                throw new ArgumentException("El ID de la venta no puede estar vacío.");

            IdDetalleVenta = idDetalleVenta;
            Cantidad = cantidad;
            Descuento = descuento;
            Subtotal = subtotal;
            IdVenta = idVenta;
        }
    }
}
