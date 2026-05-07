using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;


        public EmailService()
        {
            string usuario = ConfigurationManager.AppSettings["EmailUser"];
            string password = ConfigurationManager.AppSettings["EmailPassword"];
            string host = ConfigurationManager.AppSettings["EmailHost"];

            int port = int.Parse(ConfigurationManager.AppSettings["EmailPort"]);




            server = new SmtpClient();
            server.Credentials = new NetworkCredential(usuario, password);

            server.EnableSsl = true;
            server.Port = port;

            server.Host = host;
        }

        public void armarCorreo(string emailUsuario, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress(ConfigurationManager.AppSettings["EmailUser"]);
            
            //Yo recibo el mensaje
            email.To.Add(ConfigurationManager.AppSettings["EmailUser"]); //acá va quién recibe el mail - yo en este caso en la dirección que ponga que quiero recibir el mensaje- en ese ejemplo lo recibo en  programationiii
            
            //Esto es para responderle aul usuario.
            email.ReplyToList.Add(emailUsuario);
            email.Subject = asunto;
            email.Body = $@"<p><strong>Email del usuario:</strong> {emailUsuario}</p><p>{cuerpo}</p>";
            email.IsBodyHtml = true;
        }
        public void enviarEmail()

        {
            try
            {
                server.Send(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}


//falta armar la autentificación en 2 pasos, poner la contraseña y el correo del que voy a enviar y recibir mails
//en web.confi y listo