using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class EntidadFinanciera
    {
        public string idEntidad {  get; set; }
        public string razonSocial { get; set; }
        public string ruc {  get; set; }
        public string ubicacion {  get; set; }
        public string estado {  get; set; }

        public List<TipoTarjeta> tipoTarjetas { get; set; }

        public EntidadFinanciera() { 
            tipoTarjetas = new List<TipoTarjeta>();
        }

        public EntidadFinanciera(string idEntidad, string razonSocial, string ruc, string ubicacion, string estado, List<TipoTarjeta> tipoTarjetas)
        {
            this.idEntidad = idEntidad;
            this.razonSocial = razonSocial;
            this.ruc = ruc;
            this.ubicacion = ubicacion;
            this.estado = estado;
            this.tipoTarjetas = tipoTarjetas;
        }

        private void add(TipoTarjeta t) { 
            tipoTarjetas.Add(t);
        }
    }
}