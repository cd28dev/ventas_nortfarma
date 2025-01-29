using System;
using System.Collections.Generic;

namespace Models
{
    public class TipoTarjeta
    {
        public string IdTipo { get; set; }
        public string NombreTipo { get; set; }
        public EntidadFinanciera entidad { get; set; }

        public List<Tarjeta> tarjetas { get; set; }

        // Constructor con validación
        public TipoTarjeta(string idTipo, string nombreTipo, EntidadFinanciera entidad)
        {
            if (string.IsNullOrWhiteSpace(idTipo)) throw new ArgumentException("El ID del tipo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombreTipo)) throw new ArgumentException("El nombre del tipo no puede estar vacío.");

            IdTipo = idTipo;
            NombreTipo = nombreTipo;
            this.entidad = entidad;
        }

        // Constructor vacío (opcional)
        public TipoTarjeta() { 
            tarjetas = new List<Tarjeta>();
        }


        private void add(Tarjeta tarjeta) { 
            tarjetas.Add(tarjeta);
        }
    }
}
