using System;

namespace Models
{
    public class DetalleDePago
    {
        public string IdDetalle { get; set; }
        public double Monto { get; set; }
        public Tarjeta tarjeta { get; set; }
        public MedioPago medio { get; set; }
        public Pago pago { get; set; }

        // Constructor con validación
        public DetalleDePago(string idDetalle, double monto, Tarjeta t, MedioPago m, Pago p)
        {
            IdDetalle = idDetalle;
            Monto = monto;
            this.tarjeta = t;
            this.medio = m;
            this.pago= p;
        }


        public DetalleDePago() { }  
    }
}
