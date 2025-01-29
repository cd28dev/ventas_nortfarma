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
        public TipoDocumento TipoDoc { get; set; }

        // Constructor con validación
        public Persona(string idPersona, string nombres, string apellidos, string nroDocumento, string telefono, DateTime fechaNacimiento, string lugarNacimiento, string direccion, TipoDocumento tipoDoc)
        {
            IdPersona = idPersona;
            Nombres = nombres;
            Apellidos = apellidos;
            NroDocumento = nroDocumento;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            LugarNacimiento = lugarNacimiento;
            Direccion = direccion;
            this.TipoDoc = tipoDoc;
        }

        public Persona() { }
    }


}
