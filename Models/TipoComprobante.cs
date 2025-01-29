using System;
using System.Collections.Generic;

namespace Models
{
    public class TipoComprobante
    {
        public string IdTipoComprobante { get; set; }
        public string NombreTipo { get; set; }

        public List<Comprobante> comprobantes { get; set; }

        // Constructor con validación
        public TipoComprobante(string idTipoComprobante, string nombreTipo)
        {
            if (string.IsNullOrWhiteSpace(idTipoComprobante)) throw new ArgumentException("El ID del tipo de comprobante no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nombreTipo)) throw new ArgumentException("El nombre del tipo no puede estar vacío.");

            IdTipoComprobante = idTipoComprobante;
            NombreTipo = nombreTipo;
        }

        // Constructor vacío (opcional, por si necesitas crear instancias vacías)
        public TipoComprobante() {
            comprobantes = new List<Comprobante>();
        }

        private void add(Comprobante comprobante) { 
            comprobantes.Add(comprobante);
        }

    }
}
