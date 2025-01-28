using System;

namespace Models
{
    public class UsuarioRol
    {
        public string IdUsuario { get; private set; }
        public string IdRol { get; private set; }

        // Constructor
        public UsuarioRol(string idUsuario, string idRol)
        {
            SetIdUsuario(idUsuario);
            SetIdRol(idRol);
        }

        // Validación para IdUsuario
        public void SetIdUsuario(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El ID del usuario no puede estar vacío.");
            }
            IdUsuario = value;
        }

        // Validación para IdRol
        public void SetIdRol(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El ID del rol no puede estar vacío.");
            }
            IdRol = value;
        }
    }
}
