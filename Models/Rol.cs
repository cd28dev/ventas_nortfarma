using System;
using System.Collections.Generic;

namespace Models
{
    public class Rol
    {
        public string IdRol { get; set; }
        public string NameRol { get; set; }
        public bool Estado { get; set; }

        public List<Usuario> Usuarios { get; set; }

        // Constructor con validación
        public Rol(string idRol, string nameRol, bool estado)
        {

            IdRol = idRol;
            NameRol = nameRol;
            Estado = estado;
        }

        public Rol() { 
            Usuarios = new List<Usuario>();
        }
    }
}
