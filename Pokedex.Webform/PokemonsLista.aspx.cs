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

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            //pequeña validación para traer todos los elementos denuevo
            if(txtFiltroRapido.Text == "")
            {
                cargarGrid();
                return;
            }
            string nombre;
            int numero;
            List<Pokemon> listaFiltrada = new List<Pokemon>(); //lista nueva para agregar los nuevos elementos
            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemons"];

            if (int.TryParse(txtFiltroRapido.Text, out numero))
            {
                //acá intentamos filtrar por número
                listaFiltrada = lista.Where(x => x.Numero == numero).ToList();
            }
            else
            {
                nombre = txtFiltroRapido.Text.ToLower(); //lo paso todo a minúscula por las dudas
                listaFiltrada = lista.FindAll( x => x.Nombre.ToLower().Contains(nombre));

            }
            //Primero vamos a armar un filtro rápido sobre nombres, luego sobre nombres y numeros, y luego sobre nombres, números o tipos 




            //ahora filtraremos por números también 



            //deberíamos limpíar el grid y cargarle la lista filtrada
            dgvPokemons.DataSource = null;
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();


        }
    }
}