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
    public partial class PokemonsLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
            }

        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvPokemons.SelectedDataKey.Value.ToString()); //esto es así porque yo quise parsearlo a int, pero sino no es necesario poner el int.parse, ya con solo lo demás podes tener el id en formato string
            Response.Redirect("DetallePokemon.aspx?id=" + id);
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            cargarDatos(); //debo hacer esto porque no alcanza con solo bindear, debo volver a cargar el grid
        }

        private void cargarDatos()
        {

            PokemonNegocio pokemonNegocio = new PokemonNegocio();

            //if (Session["listaPokemons"] == null )
            //{
            //    Session["listaPokemons"] = pokemonNegocio.listarConSp();
            //}

            dgvPokemons.DataSource = pokemonNegocio.listarConSp();
            dgvPokemons.DataBind();
        }
    }
}