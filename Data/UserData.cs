using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;


namespace Data
{
    public class UserData : IUserData
    {
        private Connection connection;
        private string query;

        public UserData()
        {
            connection = new Connection();
        }

        public Usuario findById(string nroDoc)
        {
            Usuario user = new Usuario();
            try
            {
                connection.OpenConnection();
                connection.SetSqlCommand("sp_findByDoc");
                connection.SetCommandType(CommandType.StoredProcedure,"@nroDoc",nroDoc);
                connection.executeReader();

                SqlDataReader dr = connection.GetDataReader();
                if (dr.Read())
                {
                    Rol rol = new Rol();
                    TipoDocumento td = new TipoDocumento();
                    List<Rol> roles = new List<Rol>();
                    user.NroDocumento = dr["nroDocumento"].ToString();
                    user.Username = dr["nombreUsuario"].ToString();
                    user.Estado = dr["estado"].ToString();
                    user.Password = dr["contraseña"].ToString();
                    user.Nombres = (dr["nombres"].ToString());
                    user.Apellidos = dr["apellidos"].ToString();
                    user.Email = dr["email"].ToString();
                    user.Direccion = dr["direccion"].ToString();
                    user.FechaNacimiento = (DateTime)dr["fechaNacimiento"];
                    user.LugarNacimiento = dr["lugarNacimiento"].ToString();
                    rol.IdRol = dr["idRol"].ToString();
                    rol.NameRol = dr["nombreRol"].ToString();
                    roles.Add(rol);
                    user.Roles = roles;
                    td.IdTipoDoc = dr["idTipoDoc"].ToString();
                    td.Nombre = dr["nombre"].ToString();
                    td.users.Add(user);
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

            return user;
        }

        public List<Usuario> Listar()
        {
            List<Usuario> users;
            query = "SELECT * FROM listUsuario";
            users = new List<Usuario>();
            try
            {
                connection.OpenConnection();
                connection.SetSqlCommand(query);
                connection.SetCommandType(CommandType.Text);
                connection.executeReader();

                SqlDataReader dr = connection.GetDataReader();
                while (dr.Read()) {
                    Usuario user = new Usuario();
                    user.NroDocumento = dr["nroDocumento"].ToString();
                    user.Username=dr["nombreUsuario"].ToString();
                    user.Estado=dr["estado"].ToString();
                    user.Nombres=dr["nombres"].ToString();
                    user.Apellidos=dr["apellidos"].ToString();
                    user.Email=dr["email"].ToString();
                    users.Add(user);
                }

            }
            catch (SqlException ex) {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            }
            finally
            {
                connection.Dispose();
            }

            return users;
        }
        
    }
}
