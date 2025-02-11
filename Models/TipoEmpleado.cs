using System;
using System.Collections.Generic;

namespace Models
{
    public class TipoEmpleado
    {
        public string IdTipoEmpleado { get; set; }
        public string NombreTipo { get; set; }
        public bool Estado { get; set; }
        public List<Empleado> empleados { get; set; }

        // Constructor con validación
        public TipoEmpleado(string idTipoEmpleado, string nombreTipo, bool estado)
        {
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
