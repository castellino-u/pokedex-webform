<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PokemonsLista.aspx.cs" Inherits="Pokedex.Webform.PokemonsLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Pokemons</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtFiltroRapido" class="form-label">Filtro</label>
                <asp:TextBox runat="server" ID="txtFiltroRapido" CssClass="form-control" OnTextChanged="txtFiltroRapido_TextChanged" AutoPostBack="true" />
            </div>
            <div class="mb-3">
                <asp:CheckBox Text=" Filtro avanzado" runat="server" CssClass="form-check" ID="cbxFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="cbxFiltroAvanzado_CheckedChanged" />
            </div>
        </div>
    </div>
    <div class="row" runat="server" id="div" visible="false">
        <%-- Acá cargaremos el filtro  --%>
        <div class="col-3">
            <div class="mb-3">
                <label for="ddlCampo" class="form-label">Campo</label>
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <label for="ddlCriterio" class="form-label">Criterio</label>
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlCriterio">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <label for="txtFiltroAvanzado" class="form-label">Filtro</label>
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn text-bg-primary mt-4"/>
            </div>
        </div>

    </div>
    <asp:GridView runat="server" ID="dgvPokemons" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
        DataKeyNames="Id" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvPokemons_PageIndexChanging">
        <Columns>
            <asp:CheckBoxField HeaderText="Activo" DataField="Estado" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:ImageField
                DataImageUrlField="UrlImagen"
                HeaderText="Imagen"
                ControlStyle-Width="80px"
                ControlStyle-Height="80px"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Número" DataField="Numero" />
            <asp:CommandField HeaderText="Modificar" SelectText="✍️" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
    <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
