using System;
using System.Collections.Generic;

namespace Models
{
    public class TipoDocumento
    {
        public string IdTipoDoc { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public List<Persona> personas { get; set; }  

        // Constructor con validación
        public TipoDocumento(string idTipoDoc, string nombre, bool estado)
        {

            IdTipoDoc = idTipoDoc;
            Nombre = nombre;
            Estado = estado;
        }

        // Constructor vacío (opcional)
        public TipoDocumento() {
            personas = new List<Persona>();
        }

        private void add(Persona persona)
        {
            personas.Add(persona);
        }
    }
}
