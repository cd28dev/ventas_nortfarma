using System;

namespace Models
{
    public class Pago
    {
        public string IdPago { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }
        public string IdEmpleado { get; set; }
        public string IdVenta { get; set; }

        // Constructor con validación
        public Pago(string idPago, DateTime fecha, double total, string estado, string idEmpleado, string idVenta)
        {
            if (string.IsNullOrWhiteSpace(idPago))
                throw new ArgumentException("El ID de pago no puede estar vacío.");
            if (total < 0)
                throw new ArgumentException("El total no puede ser negativo.");
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idEmpleado))
                throw new ArgumentException("El ID del empleado no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idVenta))
                throw new ArgumentException("El ID de la venta no puede estar vacío.");

            IdPago = idPago;
            Fecha = fecha;
            Total = total;
            Estado = estado;
            IdEmpleado = idEmpleado;
            IdVenta = idVenta;
        }
    }
}
