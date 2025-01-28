using System;

namespace Models
{
    public class Cliente : Persona
    {
        // Propiedades automáticas
        public string IdCliente { get; set; }
        public string Estado { get; set; }
        public string IdTipo { get; set; }

        // Constructor
        public Cliente(string idCliente, string estado, string idPersona, string idTipo, string nombres, string apellidos, string nroDocumento, string email, string telefono, DateTime fechaNacimiento, string lugarNacimiento, string direccion, string estadoPersona, string idTipoDoc)
            : base(idPersona, nombres, apellidos, nroDocumento, telefono, fechaNacimiento, lugarNacimiento, direccion, idTipoDoc)
        {
            IdCliente = idCliente;
            Estado = estado;
            IdTipo = idTipo;
        }
    }
}
