using System;

namespace Models
{
    public class Rol
    {
        public string IdRol { get; set; }
        public string NameRol { get; set; }

        // Constructor con validación
        public Rol(string idRol, string nameRol)
        {
            if (string.IsNullOrWhiteSpace(idRol)) throw new ArgumentException("El ID del rol no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nameRol)) throw new ArgumentException("El nombre del rol no puede estar vacío.");

            IdRol = idRol;
            NameRol = nameRol;
        }

        public Rol() { }
    }
}
