using System;

namespace Models
{
    public class TipoCliente
    {
        public string IdTipo { get; set; }
        public string NombreTipo { get; set; }
        public string Estado { get; set; }

        // Constructor con validación
        public TipoCliente(string idTipo, string nombreTipo, string estado)
        {
            if (string.IsNullOrWhiteSpace(idTipo)) throw new ArgumentException("El ID del tipo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombreTipo)) throw new ArgumentException("El nombre del tipo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(estado)) throw new ArgumentException("El estado no puede estar vacío.");

            IdTipo = idTipo;
            NombreTipo = nombreTipo;
            Estado = estado;
        }

        // Constructor vacío (opcional, por si necesitas crear instancias vacías)
        public TipoCliente() { }
    }
}
