using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Pokedex.Webform
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio elementoNegocio = new ElementoNegocio();
                    List<Elemento> lista = elementoNegocio.listar();

                    ddlDebilidad.DataSource = lista;
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataBind();

                    //dropdownlist tipo

                    ddlTipo.DataSource = lista;
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();
            try
            {
                Pokemon nuevo = new Pokemon();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagenUrl.Text;
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                pokemonNegocio.agregarConSP(nuevo);
                Response.Redirect("PokemonsLista.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            ImgPokemon.ImageUrl = txtImagenUrl.Text;
        }
    }
}