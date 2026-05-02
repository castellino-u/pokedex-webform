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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
            }
            if (Session["usuario"] != null)
            {
                Response.Redirect("Default.aspx", false);
            }

        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            

            if (txtEmail.Text == "")
            {
                return;
            }
            if (txtPass.Text == "")
            {
                return;
            }


            try
            {
                Usuario nuevo = new Usuario();
                nuevo.User = txtEmail.Text;
                nuevo.Pass = txtPass.Text;

                UsuarioNegocio negocio = new UsuarioNegocio();
                if (negocio.Loguear(nuevo))
                {
                    Session["usuario"] = nuevo; 
                    if (nuevo.TipoUsuario == TipoUsuario.ADMIN)
                    {
                        Response.Redirect("PageLoginAdmin.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("PageLogin.aspx", false);
                    }
                }
                else
                {
                    //acá muestro algún mensaje en los labels si el usuario o contraseña es incorrecto. Ya si es un error de base de datos o demas, lo marco en la label del catch
                    lblError.Text = "Usuario o contraseña incorrectos";
                    lblError.Visible = true;
                    txtEmail.Focus();
                    txtPass.Focus();
                }

            }
            catch (Exception ex)
            {
                //Acá lo muestro 
                lblError.Text = "Ocurrió un error al iniciar sesión";
                lblError.Visible = true;

                Session["error"] = ex.Message;
            }
        }
    }
}