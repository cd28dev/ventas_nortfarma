using System;

namespace Models
{
    public class MedioPago
    {
        public string IdMedio { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        // Constructor con validación
        public MedioPago(string idMedio, string nombre, string estado)
        {
            if (string.IsNullOrWhiteSpace(idMedio))
                throw new ArgumentException("El ID del medio de pago no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado no puede estar vacío.");

            IdMedio = idMedio;
            Nombre = nombre;
            Estado = estado;
        }
    }
}
