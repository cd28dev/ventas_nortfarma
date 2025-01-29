using System;

namespace Models
{
    public class Comprobante
    {
        // Propiedades automáticas
        public string IdComprobante { get; set; }
        public string NroComprobante { get; set; }
        public DateTime FechaEmision { get; set; }
        public TipoComprobante tipoComprobante { get; set; }
        public Pago pago { get; set; }

        // Constructor
        public Comprobante(string idComprobante, string nroComprobante, DateTime fechaEmision, TipoComprobante tc, Pago pago)
        {
            IdComprobante = idComprobante;
            NroComprobante = nroComprobante;
            FechaEmision = fechaEmision;
            this.tipoComprobante = tc;
            this.pago = pago;
        }
    }
}
