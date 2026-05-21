using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Pokedex.Webform
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = "";
                lblError.Visible = false;
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtRepetirPassword.Text == "")
            {
                return;
            }
            if (txtPass.Text != txtRepetirPassword.Text)
            {
                lblError.Text = "Las contraseñas deben coincidir";
                lblError.Visible = true;
                return;
            }
            
            try
            {
                Trainee user = new Trainee();
                TraineeNegocio negocio = new TraineeNegocio();
                EmailService emailService = new EmailService();
                user.Email = txtEmail.Text;
                user.Pass = txtRepetirPassword.Text;

                int Id = negocio.insertarNuevo(user);
                user.Id = Id;
                emailService.armarCorreoRegistro(user.Email);
                emailService.enviarCorreo();
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                lblError.Text = "Error al registrarse";
                lblError.Visible = true;
                Session.Add("error", ex.ToString());
            }
        }
    }
}