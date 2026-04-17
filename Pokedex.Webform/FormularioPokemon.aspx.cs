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
                //configuración inicial
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
                //Acá vamos a ver si atravez del querystring viene el id o no, en base a eso vamos a precargar los datos o no. 
                if ((Request.QueryString["id"] != null) && (!IsPostBack))
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    List<Pokemon> temporal = (List<Pokemon>)Session["listaPokemons"];
                    Pokemon seleccionado = temporal.Find(x => x.Id == id);


                    txtId.Text = seleccionado.Id.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.UrlImagen;
                    txtUrlImagen_TextChanged(sender, e);

                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }





        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio pokemonNegocio = new PokemonNegocio();
                Pokemon nuevo = new Pokemon();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagenUrl.Text;
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    pokemonNegocio.modificarConSP(nuevo);
                }
                else
                {
                    pokemonNegocio.agregarConSP(nuevo);

                }
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