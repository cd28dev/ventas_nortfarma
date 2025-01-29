using System.Collections.Generic;

namespace Models
{
    public class Ciudad
    {
        // Propiedades automáticas
        public string IdCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public string Estado { get; set; }

        public List<Farmacia> farmacias { get; set; }

        // Constructor vacío
        public Ciudad() { 
            farmacias = new List<Farmacia>();
        }

        // Constructor lleno
        public Ciudad(string idCiudad, string nombreCiudad, string estado)
        {
            IdCiudad = idCiudad;
            NombreCiudad = nombreCiudad;
            Estado = estado;
        }
    }
}
