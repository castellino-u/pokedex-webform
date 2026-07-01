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
            if (Seguridad.sessionActiva(Session["usuario"]))
            {
                Trainee trainee = (Trainee)Session["usuario"];
                linkPerfil.Visible = true;
                linkFavoritos.Visible = true;
                if (trainee.Admin)
                {
                    linkListaPokemons.Visible = true;
                }


                linkLogin.Visible = false;
                linkRegistro.Visible = false;
                btnSalir.Visible = true;
                controlHTML.Visible = false; // esto es para que el espacio donde van los botones, tampoco se dibuje tampoco se dibuje

                //Avatar
                if (!string.IsNullOrWhiteSpace(trainee.ImagenPerfil))
                {
                    string ruta = Server.MapPath("~/Images/" + trainee.ImagenPerfil);
                    long version = System.IO.File.GetLastWriteTimeUtc(ruta).Ticks;
                    imgAvatar.ImageUrl = "~/Images/" + trainee.ImagenPerfil + "?v=" + version;
                }
                else
                {
                    imgAvatar.ImageUrl = "https://png.pngtree.com/png-vector/20250512/ourmid/pngtree-default-avatar-profile-icon-gray-placeholder-vector-png-image_16213764.png";
                }
                imgAvatar.Visible = true;
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}