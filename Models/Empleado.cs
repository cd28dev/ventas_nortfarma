using System;

namespace Models
{
    public class Empleado : Persona
    {
        public string IdEmpleado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public float Salario { get; set; }
        public string Estado { get; set; }
        public string TipoEmpleado { get; set; }

        // Constructor con validación
        public Empleado(string idPersona, string nombres, string apellidos, string nroDocumento, string email, string telefono, DateTime fechaNacimiento, string lugarNacimiento, string direccion, string estado, string idTipoDoc, string idEmpleado, DateTime fechaIngreso, float salario, string estadoEmpleado, string tipoEmpleado)
            : base(idPersona, nombres, apellidos, nroDocumento, telefono, fechaNacimiento, lugarNacimiento, direccion, idTipoDoc) // Llamada al constructor de Persona
        {
            if (string.IsNullOrWhiteSpace(idEmpleado))
                throw new ArgumentException("El ID del empleado no puede estar vacío.");
            if (salario < 0)
                throw new ArgumentException("El salario no puede ser negativo.");
            if (string.IsNullOrWhiteSpace(estadoEmpleado))
                throw new ArgumentException("El estado del empleado no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(tipoEmpleado))
                throw new ArgumentException("El tipo de empleado no puede estar vacío.");

            IdEmpleado = idEmpleado;
            FechaIngreso = fechaIngreso;
            Salario = salario;
            Estado = estadoEmpleado;
            TipoEmpleado = tipoEmpleado;
        }
    }
}
