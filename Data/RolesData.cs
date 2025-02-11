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
    public class RolesData:IRolesData
    {
        private Connection connection;
        private string query;

        public RolesData()
        {
            connection = new Connection();
        }

        public List<Rol> listRoles()
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                query = "SELECT*FROM listRoles";
                connection.OpenConnection();
                connection.SetSqlCommand(query);
                connection.SetCommandType(CommandType.Text);
                connection.executeReader();

                SqlDataReader dr = connection.GetDataReader();
                while (dr.Read())
                {
                    Rol rol = new Rol();
                    rol.IdRol = dr["idRol"].ToString();
                    rol.NameRol = dr["nombreRol"].ToString();

                    if (dr["estado"].Equals('1'))
                    {
                        rol.Estado = true;
                    }
                    else
                    {
                        rol.Estado = false;
                    }
                    roles.Add(rol);
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

            return roles;
        }
    }
}
