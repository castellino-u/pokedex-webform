<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PokemonsLista.aspx.cs" Inherits="Pokedex.Webform.PokemonsLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Pokemons</h1>
    <asp:GridView runat="server" ID="dgvPokemons" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged" 
        DataKeyNames="Id" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvPokemons_PageIndexChanging" >
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:ImageField
                DataImageUrlField="UrlImagen"
                HeaderText="Imagen"
                ControlStyle-Width="80px"
                ControlStyle-Height="80px" 
                ItemStyle-HorizontalAlign="Center" 
                />
            <asp:BoundField HeaderText="Número" DataField="Numero" /> 
            <asp:CommandField HeaderText="Modificar" SelectText="✍️" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
    <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
