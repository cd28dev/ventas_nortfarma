using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TipoDocService : ITipoDocService
    {
        private ITipoDocData tipoDocData;

        public TipoDocService() { 
            tipoDocData = new TipoDocData();
        }
        public List<TipoDocumento> GetTipoDocuments()
        {
            List<TipoDocumento> tipoDocumentos = new List<TipoDocumento>();

            tipoDocumentos=tipoDocData.GetTipoDocuments();
            return tipoDocumentos;
        }
    }
}
