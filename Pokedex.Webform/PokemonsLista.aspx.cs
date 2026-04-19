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
                cargarDatosDesdeDB();
                cargarGrid();
            }

        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvPokemons.SelectedDataKey.Value; //esto es así porque yo quise parsearlo a int, pero sino no es necesario poner el int.parse, ya con solo lo demás podes tener el id en formato string
            Response.Redirect("FormularioPokemon.aspx?id=" + id);
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            cargarGrid();
            
        }

        private void cargarDatosDesdeDB()
        {

            PokemonNegocio pokemonNegocio = new PokemonNegocio();
            Session["listaPokemons"] = pokemonNegocio.listarConSp();
        }

        private void cargarGrid()
        {
            dgvPokemons.DataSource = Session["listaPokemons"];
            dgvPokemons.DataBind();
        }
    }
}