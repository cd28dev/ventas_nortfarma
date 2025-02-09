using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace Models
{
    public class Usuario : Persona
    {
        public string IdUsuario { get; set; }
        public string Username { get; set; }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = EncryptPassword(value); }
        }
        public string Estado { get; set; }
        public string Email { get; set; }

        public List<Rol> Roles { get; set; }

        // Constructor
        public Usuario(string sexo, string idUsuario, string idPersona, string username, string password, string estado,
                       string nombres, string apellidos, string nroDocumento, string email, string telefono,
                       DateTime fechaNacimiento, string lugarNacimiento, string direccion, TipoDocumento idTipoDoc)
            : base(sexo, idPersona, nombres, apellidos, nroDocumento, telefono, fechaNacimiento, lugarNacimiento, direccion, idTipoDoc)
        {
            this.IdUsuario = idUsuario;
            this.Username = username;
            this.Password = EncryptPassword(password);
            this.Estado = estado;
            this.Email = email;
        }

        public Usuario() {
            Roles = new List<Rol>();
        }

        private string EncryptPassword(string password)
        {
            using (var hmac = new HMACSHA256())
            {
                var salt = GenerateSalt();
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                return Convert.ToBase64String(hash) + ":" + salt;
            }
        }

        public bool VerifyPassword(string inputPassword)
        {
            string[] parts = this.Password.Split(':');
            string storedHash = parts[0];
            string storedSalt = parts[1];

            using (var hmac = new HMACSHA256())
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(inputPassword + storedSalt));
                return storedHash == Convert.ToBase64String(hash);
            }
        }


        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }


    }
}
