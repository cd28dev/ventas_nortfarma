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

        public int deleteById(string nroDoc)
        {
            int row = 0;

            try
            {
                connection.OpenConnection();
                connection.SetSqlCommand("sp_DeleteByDoc");
                connection.SetCommandType(CommandType.StoredProcedure, "@nroDoc", nroDoc);
                connection.SetCommandType(CommandType.StoredProcedure, "@resultado", string.Empty, SqlDbType.Int, ParameterDirection.Output);
                connection.executeNonQuery();
                row = (int)connection.GetOutputParameterValue("@resultado");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            }
            finally
            {
                // Liberar los recursos
                connection.Dispose();
            }

            return row;
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
                    user.IdPersona= dr["idPersona"].ToString();
                    user.IdUsuario= dr["idUsuario"].ToString();
                    user.NroDocumento = dr["nroDocumento"].ToString();
                    user.Username = dr["nombreUsuario"].ToString();
                    user.Estado = dr["estado"].ToString();
                    user.Nombres = (dr["nombres"].ToString());
                    user.Apellidos = dr["apellidos"].ToString();
                    user.Email = dr["email"].ToString();
                    user.Sexo = dr["sexo"].ToString();
                    user.Telefono = dr["telefono"].ToString();
                    user.Direccion = dr["direccion"].ToString();
                    user.FechaNacimiento = (DateTime)dr["fechaNacimiento"];
                    user.LugarNacimiento = dr["lugarNacimiento"].ToString();
                    rol.IdRol = dr["idRol"].ToString();
                    rol.NameRol = dr["nombreRol"].ToString();
                    user.Roles.Add(rol);
                    td.IdTipoDoc = dr["idTipoDoc"].ToString();
                    td.Nombre = dr["nombre"].ToString();
                    user.TipoDoc = td;
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

        public Usuario lastUser()
        {
            Usuario user = new Usuario();
            try
            {
                connection.OpenConnection();
                connection.SetSqlCommand("sp_lastUser");
                connection.SetCommandType(CommandType.StoredProcedure);
                connection.executeReader();

                SqlDataReader dr = connection.GetDataReader();
                if (dr.Read())
                {
                    Rol rol = new Rol();
                    TipoDocumento td = new TipoDocumento();
                    user.IdUsuario= dr["idUsuario"].ToString();
                    user.NroDocumento = dr["nroDocumento"].ToString();
                    user.Username = dr["nombreUsuario"].ToString();
                    user.Estado = dr["estado"].ToString();
                    user.Password = dr["contraseña"].ToString();
                    user.Nombres = (dr["nombres"].ToString());
                    user.Apellidos = dr["apellidos"].ToString();
                    user.Email = dr["email"].ToString();
                    user.Sexo = dr["sexo"].ToString();
                    user.Telefono= dr["telefono"].ToString();
                    user.Direccion = dr["direccion"].ToString();
                    user.FechaNacimiento = (DateTime)dr["fechaNacimiento"];
                    user.LugarNacimiento = dr["lugarNacimiento"].ToString();
                    rol.IdRol = dr["idRol"].ToString();
                    rol.NameRol = dr["nombreRol"].ToString();
                    user.Roles.Add(rol);
                    td.IdTipoDoc = dr["idTipoDoc"].ToString();
                    td.Nombre = dr["nombre"].ToString();
                    user.TipoDoc = td;
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

        public List<Usuario> Listar(string tipo)
        {
            List<Usuario> users;
            // Validación del parámetro tipo
            if (tipo=="activos")
            {
                query = "SELECT * FROM listUsuarioActivos";
            }
            else if (tipo == "no activos")
            {
                query = "SELECT * FROM listUsuarioNoActivos";
            }
            else if (tipo == "todos")
            {
                query = "SELECT * FROM listUsuario";
            }
            else
            {
                throw new ArgumentException("Tipo no válido");
            }
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
                    Rol rol = new Rol();
                    TipoDocumento td = new TipoDocumento();
                    user.IdUsuario = dr["idUsuario"].ToString();
                    user.NroDocumento = dr["nroDocumento"].ToString();
                    user.Username = dr["nombreUsuario"].ToString();
                    user.Estado = dr["estado"].ToString();
                    user.Nombres = (dr["nombres"].ToString());
                    user.Apellidos = dr["apellidos"].ToString();
                    user.Email = dr["email"].ToString();
                    user.Sexo = dr["sexo"].ToString();
                    user.Telefono = dr["telefono"].ToString();
                    user.Direccion = dr["direccion"].ToString();
                    user.FechaNacimiento = (DateTime)dr["fechaNacimiento"];
                    user.LugarNacimiento = dr["lugarNacimiento"].ToString();
                    rol.IdRol = dr["idRol"].ToString();
                    rol.NameRol = dr["nombreRol"].ToString();
                    user.Roles.Add(rol);
                    td.IdTipoDoc = dr["idTipoDoc"].ToString();
                    td.Nombre = dr["nombre"].ToString();
                    user.TipoDoc = td;
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

        public bool saveUser(Usuario usuario)
        {
            bool isSaved = false;
            try
            {
                connection.OpenConnection();
                connection.SetSqlCommand("sp_SaveUser");
                connection.SetCommandType(CommandType.StoredProcedure);

                connection.AddParameter("@np", SqlDbType.VarChar, 50, usuario.Nombres);
                connection.AddParameter("@ap", SqlDbType.VarChar, 50, usuario.Apellidos);
                connection.AddParameter("@nroDoc", SqlDbType.Char, 11, usuario.NroDocumento);
                connection.AddParameter("@phone", SqlDbType.Char, 9, usuario.Telefono);
                connection.AddParameter("@fn", SqlDbType.Date, 0, usuario.FechaNacimiento);
                connection.AddParameter("@ln", SqlDbType.VarChar, 50, usuario.LugarNacimiento);
                connection.AddParameter("@dir", SqlDbType.VarChar, 50, usuario.Direccion);
                connection.AddParameter("@sex", SqlDbType.Char, 1, usuario.Sexo);
                connection.AddParameter("@idTd", SqlDbType.Char, 4, usuario.TipoDoc.IdTipoDoc);
                connection.AddParameter("@username", SqlDbType.VarChar, 50, usuario.Username);
                connection.AddParameter("@contra", SqlDbType.VarChar, 8, usuario.Password);
                connection.AddParameter("@email", SqlDbType.VarChar, 50, usuario.Email);
                connection.AddParameter("@esUsu", SqlDbType.VarChar, 50, usuario.Estado); // <-- Se agregó este parámetro
                connection.AddParameter("@idRol", SqlDbType.Char, 4, usuario.Roles[0].IdRol); // <-- Se agregó este parámetro

                connection.AddParameter("@success", SqlDbType.Int, sizeof(int), DBNull.Value, ParameterDirection.Output);
                connection.executeNonQuery();

                // Obtener el valor del parámetro de salida @success
                int success = Convert.ToInt32(connection.GetOutputParameterValue("@success"));

                // Verificar si la operación fue exitosa
                isSaved = (success == 1);

                if (isSaved)
                {
                    Console.WriteLine("Registro exitoso.");
                }
                else
                {
                    Console.WriteLine("Error al registrar usuario.");
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

            return isSaved;
        }

        public bool updateUser(Usuario usuario)
        {
            bool isUpdated = false;
            try
            {
                connection.OpenConnection();
                connection.SetSqlCommand("sp_UpdateUser");
                connection.SetCommandType(CommandType.StoredProcedure);

                connection.AddParameter("@idUsuario", SqlDbType.Char, 4, usuario.IdUsuario);
                connection.AddParameter("@idPersona", SqlDbType.Char, 4, usuario.IdPersona);
                connection.AddParameter("@np", SqlDbType.VarChar, 50, usuario.Nombres);
                connection.AddParameter("@ap", SqlDbType.VarChar, 50, usuario.Apellidos);
                connection.AddParameter("@nroDoc", SqlDbType.Char, 11, usuario.NroDocumento);
                connection.AddParameter("@phone", SqlDbType.Char, 9, usuario.Telefono);
                connection.AddParameter("@fn", SqlDbType.Date, 0, usuario.FechaNacimiento);
                connection.AddParameter("@sex", SqlDbType.Char, 1, usuario.Sexo);
                connection.AddParameter("@ln", SqlDbType.VarChar, 50, usuario.LugarNacimiento);
                connection.AddParameter("@dir", SqlDbType.VarChar, 50, usuario.Direccion);
                connection.AddParameter("@idTd", SqlDbType.Char, 4, usuario.TipoDoc.IdTipoDoc);
                connection.AddParameter("@username", SqlDbType.VarChar, 50, usuario.Username);
                connection.AddParameter("@email", SqlDbType.VarChar, 50, usuario.Email);
                connection.AddParameter("@esUsu", SqlDbType.VarChar, 50, usuario.Estado);
                connection.AddParameter("@idRol", SqlDbType.Char, 4, usuario.Roles[0].IdRol);

                connection.AddParameter("@success", SqlDbType.Int, sizeof(int), DBNull.Value, ParameterDirection.Output);
                connection.executeNonQuery();

                // Obtener el valor del parámetro de salida @success
                int success = Convert.ToInt32(connection.GetOutputParameterValue("@success"));

                // Verificar si la operación fue exitosa
                isUpdated = (success == 1);

                if (isUpdated)
                {
                    Console.WriteLine("Actualización exitosa.");
                }
                else
                {
                    Console.WriteLine("Error al actualizar usuario.");
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

            return isUpdated;
        }



    }
}
