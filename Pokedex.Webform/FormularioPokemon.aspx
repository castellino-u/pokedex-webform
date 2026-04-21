<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="Pokedex.Webform.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" />
    <style>
        .img-preview {
            max-width: 250px;
            height: auto;
        }
    </style>
    <div class="row justify-content-center m-3">
        <div class="col-6">

            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" class="form-control" ID="txtNombre" />
            </div>

            <div class="mb-3">
                <label for="txtNumero" class="form-label">Número</label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlTipo">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlDebilidad">
                </asp:DropDownList>
            </div>

        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" class="form-control" />
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" OnTextChanged="txtUrlImagen_TextChanged" class="form-control" AutoPostBack="true" />
                    </div>
                    <div class="mb-3">
                        <asp:Image ImageUrl="https://capacitacion.fundacionbancopampa.com.ar/wp-content/uploads/2024/09/placeholder-4.png"
                            runat="server" ID="ImgPokemon" CssClass="img-fluid img-preview" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
    <div class="row justify-content-center align-content-center h-100">
        <div class="col-6">
            <div class="mb-3 text-center">
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                <a href="PokemonsLista.aspx" class="btn btn-dark">Cancelar</a>
                <asp:Button Text="Eliminar Lógico" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" OnClientClick="return confirm('¿Seguro que querés eliminar este Pokémon?');"/>
                <asp:Button Text="Activar" runat="server" CssClass="btn btn-info" ID="btnActivar" OnClick="btnActivar_Click"/>
            </div>

        </div>

    </div>



</asp:Content>
