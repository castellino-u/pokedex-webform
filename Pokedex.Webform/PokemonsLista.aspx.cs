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

                ElementoNegocio negocio = new ElementoNegocio();
                List<Elemento> elementos = negocio.listar();
                Session["elementos"] = elementos;

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
            if (txtFiltroRapido.Text == "")
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
                listaFiltrada = lista.FindAll(x => x.Nombre.ToLower().Contains(nombre));

            }
            //Primero vamos a armar un filtro rápido sobre nombres, luego sobre nombres y numeros, y luego sobre nombres, números o tipos 




            //ahora filtraremos por números también 



            //deberíamos limpíar el grid y cargarle la lista filtrada
            dgvPokemons.DataSource = null;
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();


        }

        protected void cbxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            div.Visible = cbxFiltroAvanzado.Checked;
            if (cbxFiltroAvanzado.Checked)
            {
                ddlCampo.Items.Add(new ListItem("Seleccione...", ""));
                ddlCampo.Items.Add("Número");
                ddlCampo.Items.Add("Nombre");
                ddlCampo.Items.Add("Tipo");
            }
            else
            {
                ddlCampo.Items.Clear();
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            txtFiltroAvanzado.Enabled = true;
            txtFiltroAvanzado.Text = "";

            if (ddlCampo.SelectedItem.Text == "Seleccione...")
            {
                txtFiltroAvanzado.Enabled = false;
                return;
            }


            if (ddlCampo.SelectedValue == "Número")
            {

                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");

            }
            else if (ddlCampo.SelectedValue == "Nombre")
            {
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");

            }
            else if (ddlCampo.SelectedValue == "Tipo")
            {
                txtFiltroAvanzado.Enabled = false;
                if (Session["elementos"] != null)
                {
                    ddlCriterio.DataSource = Session["elementos"];
                    ddlCriterio.DataValueField = "Id";
                    ddlCriterio.DataTextField = "Descripcion";
                    ddlCriterio.DataBind();
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Debemos capturar todos los datosde los sontroles y llamar al método filtrar

            if (ddlCampo.SelectedValue == "Seleccione...")
            {
                return;
            }

           

            PokemonNegocio negocio = new PokemonNegocio();
            List<Pokemon> listaFiltrada;

            string campo = ddlCampo.SelectedValue;
            string criterio = ddlCriterio.SelectedValue;
            string filtro = txtFiltroAvanzado.Text;

            if (campo == "Tipo")
            {
                listaFiltrada = negocio.filtrar(campo, criterio);
            }
            else
            {
                listaFiltrada = negocio.filtrar(campo, criterio, filtro);
            }

            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();
        }
    }
}