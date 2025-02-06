using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Data
{
    public class Connection : IDisposable
    {
        private string stringConnection;
        private SqlConnection _connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private int row;

        public Connection()
        {
            this.stringConnection = ConfigurationManager.ConnectionStrings["cadena"].ToString();
            _connection = new SqlConnection(stringConnection);
            command = null;
            reader = null;
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }


        public SqlCommand GetSqlCommand() { 
            return command; 
        }

        public SqlDataReader GetDataReader() { 
            return reader; 
        }

        public void SetSqlCommand(string query) { 
            this.command = new SqlCommand(query, _connection); 
        }

        public void SetDataReader(SqlDataReader reader) { 
            this.reader = reader; 
        }

        public void executeReader()
        {
            this.reader = this.command.ExecuteReader();
        }

        public int executeNonQuery()
        {
            row = this.command.ExecuteNonQuery();
            return row;
        }

        public SqlConnection GetConnection() { 
            return _connection; 
        }

        public void SetCommandType(CommandType ct)
        {
            this.command.CommandType = ct;
        }

        public void SetCommandType(CommandType ct, String nameVar, String input)
        {
            this.command.CommandType = ct;
            this.command.Parameters.AddWithValue(nameVar, input);
        }

        public void SetCommandType(CommandType ct, string nameVar, string input, SqlDbType type = SqlDbType.VarChar, ParameterDirection direction = ParameterDirection.Input)
        {
            this.command.CommandType = ct;

            // Agregar el parámetro con tipo y dirección
            SqlParameter param = new SqlParameter(nameVar, type)
            {
                Value = input,
                Direction = direction
            };
            this.command.Parameters.Add(param);
        }

        // Método para obtener el valor de un parámetro de salida
        public object GetOutputParameterValue(string parameterName)
        {
            return this.command.Parameters[parameterName].Value;
        }

        public void AddParameter(string nameVar, SqlDbType type, int size, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            SqlParameter param = new SqlParameter(nameVar, type, size)
            {
                Value = value,
                Direction = direction
            };
            this.command.Parameters.Add(param);
        }

    }

}
