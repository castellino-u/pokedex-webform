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
            

        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            

            //if (txtEmail.Text == "")
            //{
            //    return;
            //}
            //if (txtPass.Text == "")
            //{
            //    return;
            //}

            Trainee nuevo = new Trainee();
            TraineeNegocio negocio = new TraineeNegocio();

            try
            {

                nuevo.Email = txtEmail.Text;
                nuevo.Pass = txtPass.Text;

                if (negocio.Login(nuevo))
                {
                    Session["usuario"] = nuevo;
                    if (nuevo.Admin)
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
                //lblError.Text = "Ocurrió un error al iniciar sesión";
                lblError.Text = ex.ToString();
                lblError.Visible = true;

                Session["error"] = ex.Message;
            }

            //----------------------------------------------------------------------------------------
        }


    }
}