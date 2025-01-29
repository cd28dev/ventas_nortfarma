using System;
using System.Collections.Generic;

namespace Models
{
    public class Tarjeta
    {
        public string IdTarjeta { get; set; }
        public string NroCuenta { get; set; }
        public string NroTarjeta { get; set; }
        public string Estado { get; set; }
        public Cliente cliente { get; set; }
        public TipoTarjeta tt { get; set; }

        public List<DetalleDePago> dePagos { get; set; }

        // Constructor con validación
        public Tarjeta(string idTarjeta, string nroCuenta, string nroTarjeta, string estado, Cliente c, TipoTarjeta tt)
        {
            if (string.IsNullOrWhiteSpace(idTarjeta)) throw new ArgumentException("El ID de la tarjeta no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nroCuenta)) throw new ArgumentException("El número de cuenta no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nroTarjeta)) throw new ArgumentException("El número de tarjeta no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(estado)) throw new ArgumentException("El estado no puede estar vacío.");

            IdTarjeta = idTarjeta;
            NroCuenta = nroCuenta;
            NroTarjeta = nroTarjeta;
            Estado = estado;
            this.cliente = c;
            this.tt = tt;
        }


        public Tarjeta() { 
            dePagos = new List<DetalleDePago>();
        }
    }
}
