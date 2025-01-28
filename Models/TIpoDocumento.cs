using System;
using System.Collections.Generic;

namespace Models
{
    public class TipoDocumento
    {
        public string IdTipoDoc { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public List<Usuario> users { get; set; }  

        // Constructor con validación
        public TipoDocumento(string idTipoDoc, string nombre, string estado)
        {
            if (string.IsNullOrWhiteSpace(idTipoDoc)) throw new ArgumentException("El ID del tipo de documento no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(estado)) throw new ArgumentException("El estado no puede estar vacío.");

            IdTipoDoc = idTipoDoc;
            Nombre = nombre;
            Estado = estado;
        }

        // Constructor vacío (opcional)
        public TipoDocumento() { }

        private void add(Usuario user)
        {
            users.Add(user);
        }
    }
}
