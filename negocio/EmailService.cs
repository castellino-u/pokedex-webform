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
            string usuario = Environment.GetEnvironmentVariable("EMAIL_USER");
            string password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");

            server = new SmtpClient();
            server.Credentials = new NetworkCredential(usuario, password);

            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailUsuario, string asunto, string cuerpo)
        {
            email = new MailMessage();
            //Desde dónde va a salir el email, desde mi cuenta, mi correo
            email.From = new MailAddress(Environment.GetEnvironmentVariable("EMAIL_USER"), "No Reply");

            //Dónde se va a recibir el mensaje. En mi cuenta en este caso
            email.To.Add(Environment.GetEnvironmentVariable("EMAIL_USER")); //acá va quién recibe el mail - yo en este caso en la dirección que ponga que quiero recibir el mensaje- en ese ejemplo lo recibo en  programationiii

            //Esto es para responderle al usuario.
            email.ReplyToList.Add(emailUsuario);
            email.Subject = asunto;
            email.Body = $@"<p><strong>Email del usuario:</strong> {emailUsuario}</p><p>{cuerpo}</p>";
            email.IsBodyHtml = true;
        }
        public void enviarCorreo()
        {
            server.Send(email);

        }

    }
}


//falta armar la autentificación en 2 pasos, poner la contraseña y el correo del que voy a enviar y recibir mails
//en web.confi y listo