<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PokemonsLista.aspx.cs" Inherits="Pokedex.Webform.PokemonsLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Pokemons</h1>
    <asp:GridView runat="server" ID="dgvPokemons" CssClass="table" AutoGenerateColumns="false">
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
        </Columns>
    </asp:GridView>
</asp:Content>
