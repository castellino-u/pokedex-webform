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
            //usaré los servidores smtp de mailtrap, por ende modificaré un poco la configuración
            //esta config corresponde a los servidores de gmail
            //...
            //string usuario = Environment.GetEnvironmentVariable("EMAIL_USER");
            //string password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");

            //server = new SmtpClient();
            //server.Credentials = new NetworkCredential(usuario, password);

            //server.EnableSsl = true;
            //server.Port = 587;
            //server.Host = "smtp.gmail.com";

            //Config para mailtrap
            //...
            string usuario = Environment.GetEnvironmentVariable("EMAIL_USER");
            string password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            server = new SmtpClient();
            server.Credentials = new NetworkCredential(usuario,password );

            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";
        }

        public void armarCorreoContacto(string emailUsuario, string asunto, string cuerpo)
        {
            email = new MailMessage();
            //Desde dónde va a salir el email, desde mi cuenta, mi correo
            email.From = new MailAddress("noresponder@pokedex.com", "No Reply");

            //Dónde se va a recibir el mensaje. En mi cuenta en este caso
            email.To.Add("oscar_castel@outlook.com"); //acá va quién recibe el mail - yo en este caso en la dirección que ponga que quiero recibir el mensaje- en ese ejemplo lo recibo en  programationiii

            //Esto es para responderle al usuario.
            email.ReplyToList.Add(emailUsuario);
            email.Subject = asunto;
            email.Body = $@"<p><strong>Email del usuario:</strong> {emailUsuario}</p><p>{cuerpo}</p>";
            email.IsBodyHtml = true;
        }

        public void armarCorreoRegistro(string destino)
        {
            email = new MailMessage();
            //Desde dónde va a salir el email
            email.From = new MailAddress("noresponder@pokedex.com", "No Reply");
            //Dónde se va a recibir el correo
            email.To.Add(destino);
            email.Subject = "Registro exitoso";
            email.Body = $@"<h1>Gracias por registrarse en nuestros servicios </h1>
                        <p> Estimado {destino}, su registro en nuestros servicios ha sido exitoso. </p>";
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