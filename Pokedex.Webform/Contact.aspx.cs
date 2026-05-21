using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace Pokedex.Webform
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblConfirmacion.Visible = false;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtAsunto.Text == "" || txtEmail.Text == "" || txtCuerpo.Text == "")
            {
                return;
            }

            try
            {
                EmailService negocio = new EmailService();
                negocio.armarCorreoContacto(txtEmail.Text, txtAsunto.Text, txtCuerpo.Text);

                negocio.enviarCorreo();
                lblConfirmacion.Text = "Mensaje enviado correctamente";
                lblConfirmacion.Visible = true;
            }
            catch (Exception ex)
            {
                lblConfirmacion.Text = "Error al enviar correo. Reintente más tarde";
                lblConfirmacion.Visible = true;
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            //falta modificar las credenciales, activar la verificacion de dos pasos y la app password y listo, esto funciona.
        }
    }
}