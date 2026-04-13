<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokedex.Webform.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola</h1>
    <p>Bienvenido a la web de pokedex, felicitaciones por llegar hasta esta parte!!! Eres increíble, sigue así y no te rindas, que el trabajo que buscas va a llegar muy pronto</p>


    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%--<%
            foreach (dominio.Pokemon poke in ListaPokemon)
            {



        %>
            <div class="col">
                <div class="card">
                    <img src="<%:poke.UrlImagen %>" class="card-img-top w-50 m-auto" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%: poke.Nombre %></h5>
                        <p class="card-text"><%: poke.Descripcion %></p>
                        <a href="DetallePokemon.aspx?id=<%:poke.Id %>" class="btn btn-primary">Ver Detalle</a>
                    </div>

                </div>
            </div>

        <%
            }
        %>--%>

        <%--Ahora vamos a probar una estructura nueva, un repetidor de asp--%>
        <asp:Repeater runat="server" ID="reRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImagen")%>" class="card-img-top w-50 m-auto" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <a href="DetallePokemon.aspx?id=<%#Eval("Id")%>" class="btn btn-primary">Ver Detalle</a>
                            <asp:Button Text="Ejemplo" runat="server" ID="btnEjemplo" CssClass="btn btn-secondary" CommandArgument='<%#Eval("Id")%>' CommandName="PokemonId" OnClick="btnEjemplo_Click" />
                        </div>

                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>









</asp:Content>

