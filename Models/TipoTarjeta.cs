using System;

namespace Models
{
    public class TipoTarjeta
    {
        public string IdTipo { get; set; }
        public string NombreTipo { get; set; }
        public string IdEntidad { get; set; }

        // Constructor con validación
        public TipoTarjeta(string idTipo, string nombreTipo, string idEntidad)
        {
            if (string.IsNullOrWhiteSpace(idTipo)) throw new ArgumentException("El ID del tipo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombreTipo)) throw new ArgumentException("El nombre del tipo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idEntidad)) throw new ArgumentException("El ID de la entidad no puede estar vacío.");

            IdTipo = idTipo;
            NombreTipo = nombreTipo;
            IdEntidad = idEntidad;
        }

        // Constructor vacío (opcional)
        public TipoTarjeta() { }
    }
}
