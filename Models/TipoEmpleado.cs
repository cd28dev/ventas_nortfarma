using System;
using System.Collections.Generic;

namespace Models
{
    public class TipoEmpleado
    {
        public string IdTipoEmpleado { get; set; }
        public string NombreTipo { get; set; }
        public string Estado { get; set; }

        public List<Empleado> empleados { get; set; }

        // Constructor con validación
        public TipoEmpleado(string idTipoEmpleado, string nombreTipo, string estado)
        {
            if (string.IsNullOrWhiteSpace(idTipoEmpleado)) throw new ArgumentException("El ID del tipo de empleado no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombreTipo)) throw new ArgumentException("El nombre del tipo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(estado)) throw new ArgumentException("El estado no puede estar vacío.");

            IdTipoEmpleado = idTipoEmpleado;
            NombreTipo = nombreTipo;
            Estado = estado;
        }

        // Constructor vacío (opcional)
        public TipoEmpleado() { 
            empleados = new List<Empleado>();
        }
    }
}
