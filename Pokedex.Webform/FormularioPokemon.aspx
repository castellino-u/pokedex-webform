<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="Pokedex.Webform.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--d
        public bool Estado { get; set; }
        public int Id { get; set; }

        [DisplayName("Número")]
        public int Numero { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public Elemento Tipo { get; set; }
        public Elemento Debilidad { get; set; }
        
        
    --%>

    <div class="row justify-content-center">
        <div class="col-4">
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" class="form-control" ID="txtNombre" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" class="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Número</label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList runat="server">
                    <asp:ListItem Text="text1" />
                    <asp:ListItem Text="text2" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList runat="server">
                    <asp:ListItem Text="text1" />
                    <asp:ListItem Text="text2" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
                <a href="Default.aspx" class="btn btn-dark" >Cancelar</a>
            </div>
        </div>
    </div>




</asp:Content>
