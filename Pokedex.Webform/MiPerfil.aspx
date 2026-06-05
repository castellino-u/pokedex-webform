<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Pokedex.Webform.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenido  a Mi perfil </h1>
    <asp:Label Text="" runat="server" ID="lblUser" />
    <div class="row mt-2">
        <div class="col-md-4">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
            </div>

            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
            </div>

            <div class="mb-3">
                <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="date" />

            </div>
        </div>

        <div class="col-md-4">
            <div class="mb-3 gap-2">
                <label for="txtImagen" class="form-label">Imagen Perfil</label>
                <input type="file" class="form-control" id="txtImagen" runat="server">
                <asp:Image ImageUrl="https://impactify.io/wp-content/uploads/2024/05/placeholder-5.png" runat="server" ID="imgNuevoPerfil" CssClass="img-fluid mb-3" />
            </div>
        </div>
        <div class="col-md-4 ">
            <div class="mb-3 d-grid gap-2 w-25">
                <asp:Button Text="Editar Foto" ID="btnEditarFoto" OnClick="btnEditarFoto_Click" CssClass="btn btn-primary"  runat="server" />

                <asp:Button Text="Editar datos" ID="btnEditarDatos" OnClick="btnEditarDatos_Click" CssClass="btn btn-primary" runat="server" />

                <asp:Button Text="Guardar" runat="server" ID="btnGuardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Visible="false" />

                <a href="Default.aspx" class="btn btn-dark">Regresar</a>

            </div>
        </div>

    </div>
    <div class="row justify-content-center">
        <div class="col-3">
        </div>

    </div>


</asp:Content>
