using System;

namespace Models
{
    public class Tarjeta
    {
        public string IdTarjeta { get; set; }
        public string NroCuenta { get; set; }
        public string NroTarjeta { get; set; }
        public string Estado { get; set; }
        public string IdCliente { get; set; }
        public string IdTipoTarjeta { get; set; }

        // Constructor con validación
        public Tarjeta(string idTarjeta, string nroCuenta, string nroTarjeta, string estado, string idCliente, string idTipoTarjeta)
        {
            if (string.IsNullOrWhiteSpace(idTarjeta)) throw new ArgumentException("El ID de la tarjeta no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nroCuenta)) throw new ArgumentException("El número de cuenta no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nroTarjeta)) throw new ArgumentException("El número de tarjeta no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(estado)) throw new ArgumentException("El estado no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idCliente)) throw new ArgumentException("El ID del cliente no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idTipoTarjeta)) throw new ArgumentException("El tipo de tarjeta no puede estar vacío.");

            IdTarjeta = idTarjeta;
            NroCuenta = nroCuenta;
            NroTarjeta = nroTarjeta;
            Estado = estado;
            IdCliente = idCliente;
            IdTipoTarjeta = idTipoTarjeta;
        }
    }
}
