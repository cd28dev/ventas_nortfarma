using System;
using System.Collections.Generic;

namespace Models
{
    public class Empleado : Persona
    {
        public string IdEmpleado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public float Salario { get; set; }
        public string Estado { get; set; }
        public TipoEmpleado tipoEmpleado { get; set; }

        public List<Venta> Ventas { get; set; }

        public List<Anulacion> anulaciones { get; set; }

        // Constructor con validación
        public Empleado(string sexo,string idPersona, string nombres, string apellidos, string nroDocumento, string email, string telefono, DateTime fechaNacimiento, string lugarNacimiento, string direccion, string estado, TipoDocumento idTipoDoc, string idEmpleado, DateTime fechaIngreso, float salario, string estadoEmpleado, TipoEmpleado te)
            : base(sexo, idPersona, nombres, apellidos, nroDocumento, telefono, fechaNacimiento, lugarNacimiento, direccion, idTipoDoc) // Llamada al constructor de Persona
        {
            IdEmpleado = idEmpleado;
            FechaIngreso = fechaIngreso;
            Salario = salario;
            Estado = estadoEmpleado;
            tipoEmpleado = te;
        }


        public Empleado()
        {
            Ventas = new List<Venta> ();    
            anulaciones = new List<Anulacion> ();
        }
    }
}
