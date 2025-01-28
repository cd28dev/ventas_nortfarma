using System;

namespace Models
{
    public class Farmacia
    {
        public string IdFarmacia { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public string IdCiudad { get; set; }

        // Constructor con validaciones
        public Farmacia(string idFarmacia, string nombre, string direccion, string estado, string idCiudad)
        {
            if (string.IsNullOrWhiteSpace(idFarmacia))
                throw new ArgumentException("El ID de la farmacia no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la farmacia no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado de la farmacia no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(idCiudad))
                throw new ArgumentException("El ID de la ciudad no puede estar vacío.");

            IdFarmacia = idFarmacia;
            Nombre = nombre;
            Direccion = direccion;
            Estado = estado;
            IdCiudad = idCiudad;
        }
    }
}
