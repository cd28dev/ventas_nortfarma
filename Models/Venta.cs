using System;

namespace Models
{
    public class Venta
    {
        public string IdVenta { get; private set; }
        public DateTime Fecha { get; set; }
        public double Total { get; private set; }
        public string Estado { get; private set; }
        public string IdPedido { get; private set; }
        public string IdFarmacia { get; private set; }
        public string IdEmpleado { get; private set; }

        // Constructor
        public Venta(string idVenta, DateTime fecha, double total, string estado, string idPedido, string idFarmacia, string idEmpleado)
        {
            SetIdVenta(idVenta);
            Fecha = fecha;
            SetTotal(total);
            SetEstado(estado);
            SetIdPedido(idPedido);
            SetIdFarmacia(idFarmacia);
            SetIdEmpleado(idEmpleado);
        }

        // Métodos de validación
        public void SetIdVenta(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El ID de la venta no puede estar vacío.");
            IdVenta = value;
        }

        public void SetTotal(double value)
        {
            if (value < 0)
                throw new ArgumentException("El total no puede ser negativo.");
            Total = value;
        }

        public void SetEstado(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El estado no puede estar vacío.");
            Estado = value;
        }

        public void SetIdPedido(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El ID del pedido no puede estar vacío.");
            IdPedido = value;
        }

        public void SetIdFarmacia(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El ID de la farmacia no puede estar vacío.");
            IdFarmacia = value;
        }

        public void SetIdEmpleado(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El ID del empleado no puede estar vacío.");
            IdEmpleado = value;
        }
    }
}
