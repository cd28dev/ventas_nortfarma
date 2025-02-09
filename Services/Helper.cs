using System;
using System.Net;
using System.Net.Mail;

namespace Services
{
    public class Helper
    {

        public static string genPassword()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0,6);
            return clave;
        }

        public static bool SendEmail(string destinatario, string asunto, string mensaje)
        {
            try
            {
                // Datos del remitente
                string remitente = "carlos.informatico.28@gmail.com";
                string contraseña = "waaxnffygmygkitz";

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(remitente);
                correo.To.Add(destinatario);
                correo.Subject = asunto;
                correo.Body = mensaje;
                correo.IsBodyHtml = true;

                // Configuración del servidor SMTP
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(remitente, contraseña);
                smtp.EnableSsl = true;

                // Enviar el correo
                smtp.Send(correo);
                Console.WriteLine("Correo enviado correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
                return false;
            }
        }
    }
}
