using System;

namespace Models
{
    public class Persona
    {
        public string IdPersona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NroDocumento { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public string Direccion { get; set; }
        public string IdTipoDoc { get; set; }

        // Constructor con validación
        public Persona(string idPersona, string nombres, string apellidos, string nroDocumento, string telefono, DateTime fechaNacimiento, string lugarNacimiento, string direccion, string idTipoDoc)
        {
            if (string.IsNullOrWhiteSpace(idPersona)) throw new ArgumentException("El ID de la persona no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombres)) throw new ArgumentException("Los nombres no pueden estar vacíos.");
            if (string.IsNullOrWhiteSpace(apellidos)) throw new ArgumentException("Los apellidos no pueden estar vacíos.");
            if (string.IsNullOrWhiteSpace(nroDocumento)) throw new ArgumentException("El número de documento no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(telefono)) throw new ArgumentException("El teléfono no puede estar vacío.");
            if (fechaNacimiento == default(DateTime)) throw new ArgumentException("La fecha de nacimiento no es válida.");
            if (string.IsNullOrWhiteSpace(lugarNacimiento)) throw new ArgumentException("El lugar de nacimiento no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(direccion)) throw new ArgumentException("La dirección no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(idTipoDoc)) throw new ArgumentException("El tipo de documento no puede estar vacío.");

            IdPersona = idPersona;
            Nombres = nombres;
            Apellidos = apellidos;
            NroDocumento = nroDocumento;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            LugarNacimiento = lugarNacimiento;
            Direccion = direccion;
            IdTipoDoc = idTipoDoc;
        }

        public Persona() { }
    }


}
