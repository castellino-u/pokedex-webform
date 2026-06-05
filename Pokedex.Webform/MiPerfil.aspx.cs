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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.ReadOnly = true;
            if (!IsPostBack && Seguridad.sessionActiva(Session["usuario"]))
            {
                Trainee user = (Trainee)Session["usuario"];
                txtEmail.Text = user.Email;
                txtNombre.Text = user.Nombre;
                txtApellido.Text = user.Apellido;

                if (!string.IsNullOrWhiteSpace(user.ImagenPerfil))
                {
                    imgNuevoPerfil.ImageUrl ="~/Images/" + user.ImagenPerfil;
                }
                else
                {
                    imgNuevoPerfil.ImageUrl = "https://png.pngtree.com/png-vector/20250512/ourmid/pngtree-default-avatar-profile-icon-gray-placeholder-vector-png-image_16213764.png";

                }
                //txtFechaNacimiento.Text = (DateTime.Parse(user.FechaNacimiento)).ToString();
                txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            TraineeNegocio negocio = new TraineeNegocio();
            //Tener en cuenta al momento de actualizar datos si por ejemplo la imagen quiero actualizarla o no
            //Contemplar escenarios posibles: 1- si ya tengo una imagen guardada y no quiero actializarla, qué pasa en ese caso? 
            // si pasa eso podemos usar un if con esto para actualizar o no: if(txtImagen.PostedFile.FileName != "){//escribir la imagen si se cargó algo}

            try
            {
                Trainee user = (Trainee)Session["usuario"];
                //Escribir img
                string ruta = Server.MapPath("./Images/");
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento =  DateTime.Parse(txtFechaNacimiento.Text);

                negocio.actualizar(user);

                //Leer img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + user.ImagenPerfil;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnEditarFoto_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarDatos_Click(object sender, EventArgs e)
        {

        }
    }
}