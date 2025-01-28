namespace Models
{
    public class Ciudad
    {
        // Propiedades automáticas
        public string IdCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public string Estado { get; set; }

        // Constructor vacío
        public Ciudad() { }

        // Constructor lleno
        public Ciudad(string idCiudad, string nombreCiudad, string estado)
        {
            IdCiudad = idCiudad;
            NombreCiudad = nombreCiudad;
            Estado = estado;
        }
    }
}
