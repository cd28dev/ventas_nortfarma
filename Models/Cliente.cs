using System;

namespace Models
{
    public class Cliente : Persona
    {
        public string IdCliente { get; set; }
        public string Estado { get; set; }

        // Constructor
        public Cliente(string sexo,string idCliente, string estado, string idPersona, string nombres, string apellidos, string nroDocumento, string email, string telefono, DateTime fechaNacimiento, string lugarNacimiento, string direccion, string estadoPersona, TipoDocumento tipoDoc)
            : base(sexo,idPersona, nombres, apellidos, nroDocumento, telefono, fechaNacimiento, lugarNacimiento, direccion, tipoDoc)
        {
            IdCliente = idCliente;
            Estado = estado;

        }

        public Cliente() { }


        //Que habrás pensado que te estoy enviando xd

    }
}
