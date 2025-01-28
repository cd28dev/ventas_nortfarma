using System;

namespace Models
{
    public class DetalleDePago
    {
        public string IdDetalle { get; set; }
        public double Monto { get; set; }
        public string IdTarjeta { get; set; }
        public string IdMedio { get; set; }
        public string IdPago { get; set; }

        // Constructor con validación
        public DetalleDePago(string idDetalle, double monto, string idTarjeta, string idMedio, string idPago)
        {
            if (string.IsNullOrWhiteSpace(idDetalle))
                throw new ArgumentException("El ID del detalle no puede estar vacío.");
            if (monto < 0)
                throw new ArgumentException("El monto no puede ser negativo.");
            if (string.IsNullOrWhiteSpace(idTarjeta))
                throw new ArgumentException("El ID de la tarjeta no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idMedio))
                throw new ArgumentException("El ID del medio no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idPago))
                throw new ArgumentException("El ID de pago no puede estar vacío.");

            IdDetalle = idDetalle;
            Monto = monto;
            IdTarjeta = idTarjeta;
            IdMedio = idMedio;
            IdPago = idPago;
        }
    }
}
