using System;

namespace Models
{
    public class Comprobante
    {
        // Propiedades automáticas
        public string IdComprobante { get; set; }
        public string NroComprobante { get; set; }
        public DateTime FechaEmision { get; set; }
        public string IdTipoComprobante { get; set; }
        public string IdPago { get; set; }

        // Constructor
        public Comprobante(string idComprobante, string nroComprobante, DateTime fechaEmision, string idTipoComprobante, string idPago)
        {
            IdComprobante = idComprobante;
            NroComprobante = nroComprobante;
            FechaEmision = fechaEmision;
            IdTipoComprobante = idTipoComprobante;
            IdPago = idPago;
        }
    }
}
