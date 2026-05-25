using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace Pokedex.Webform
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                Trainee trainee = (Trainee)Session["usuario"];
            }
        }
    }
}