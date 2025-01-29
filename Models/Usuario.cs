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
        public string Password { get; set; }  // Evitar que se modifique el password directamente
        public string Estado { get; set; }

        public string Email { get; set; }

        public List<Rol> Roles { get; set; }

        // Constructor
        public Usuario(string idUsuario, string idPersona, string username, string password, string estado,
                       string nombres, string apellidos, string nroDocumento, string email, string telefono,
                       DateTime fechaNacimiento, string lugarNacimiento, string direccion, string estadoPersona, TipoDocumento idTipoDoc)
            : base(idPersona, nombres, apellidos, nroDocumento, telefono, fechaNacimiento, lugarNacimiento, direccion, idTipoDoc)
        {
            this.IdUsuario = idUsuario;
            this.Username = username;
            this.Password = EncryptPassword(password); // Contraseña cifrada
            this.Estado = estado;
            this.Email = email;
        }

        // Constructor vacío
        public Usuario() {
            Roles = new List<Rol>();
        }

        // Método para cifrar contraseñas de forma segura usando PBKDF2
        private string EncryptPassword(string password)
        {
            using (var hmac = new HMACSHA256())
            {
                var salt = GenerateSalt();
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password + salt)); // Concatenamos la contraseña con el salt
                return Convert.ToBase64String(hash) + ":" + salt;  // Devuelve el hash con el salt
            }
        }

        // Método para verificar la contraseña ingresada
        public bool VerifyPassword(string inputPassword)
        {
            string[] parts = this.Password.Split(':');
            string storedHash = parts[0];
            string storedSalt = parts[1];

            using (var hmac = new HMACSHA256())
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(inputPassword + storedSalt));
                return storedHash == Convert.ToBase64String(hash);  // Compara los hashes
            }
        }

        // Generar un salt aleatorio (clave adicional para fortalecer el hash)
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
