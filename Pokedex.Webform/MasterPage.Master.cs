using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Pokedex.Webform
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If para manejar la seguridad - ¿Puedo estar acá? 
            //...
            string pagina = Path.GetFileName(Request.Path);
            if (pagina != "Login.aspx" && pagina != "Default.aspx" && pagina != "Registro.aspx" && pagina != "Contact.aspx")
            {
                if (!(Seguridad.sessionActiva(Session["usuario"])))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            

            //If que maneja la UI - ¿Qué se muestra? 
            //...
            if (Session["usuario"] != null)
            {
                Trainee trainee = (Trainee)Session["usuario"];
                linkPerfil.Visible = true;
                linkFavoritos.Visible = true;
                if (trainee.Admin)
                {
                    linkListaPokemons.Visible = true;
                }
            }

        }
    }
}