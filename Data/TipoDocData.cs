using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TipoDocData : ITipoDocData
    {

        private Connection connection;
        private string query;

        public TipoDocData()
        {
            connection = new Connection();
        }

        public List<TipoDocumento> GetTipoDocuments()
        {
            List<TipoDocumento> documents = new List<TipoDocumento>();

            try
            {
                query = "SELECT*FROM listTipDoc";
                connection.OpenConnection();
                connection.SetSqlCommand(query);
                connection.SetCommandType(CommandType.Text);
                connection.executeReader();

                SqlDataReader dr = connection.GetDataReader();
                while (dr.Read())
                {
                    TipoDocumento td = new TipoDocumento();
                    td.IdTipoDoc = dr["idTipoDoc"].ToString();
                    td.Nombre = dr["nombre"].ToString();

                    if (dr["estado"].Equals('1'))
                    {
                        td.Estado = true;
                    }
                    else
                    {
                        td.Estado = false;
                    }
                    documents.Add(td);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            }
            finally
            {
                connection.Dispose();
            }

            return documents;
        }
    }
}
