<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Pokedex.Webform.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>    

        function validarCampo(campo) {
            if (campo.value.trim() == "") {
                campo.classList.remove("is-valid");
                campo.classList.add("is-invalid");
                return false
            }
            campo.classList.remove("is-invalid");
            campo.classList.add("is-valid");
            return true;
        }


        function validar() {
            const txtNombre = document.getElementById("txtNombre");
            const txtApellido = document.getElementById("txtApellido");

            let formularioValido = true;

            formularioValido = validarCampo(txtNombre) && formularioValido;
            formularioValido = validarCampo(txtApellido) && formularioValido;
            if (!formularioValido) {
                alert("Hay campos sin completar");
            }

            return formularioValido;


        }
    </script>
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
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"  ClientIDMode="Static" />
            </div>

            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" ClientIDMode="Static"/>
            </div>

            <div class="mb-3">
                <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="date" />

            </div>
            <div class="mb-3">
                <%--Acá van los botones para confirmar o cancelar la edición de los datos--%>
                <asp:Button Text="Confirmar" runat="server" ID="btnConfirmarDatos" CssClass="btn btn-primary" Visible="false" OnClientClick="return validar()" OnClick="btnConfirmarDatos_Click" />
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelarDatos" CssClass="btn btn-dark" Visible="false" OnClick="btnCancelarDatos_Click" />
            </div>
        </div>

        <div class="col-md-4">
            <div class="mb-3 gap-2">
                <label for="txtImagen" class="form-label">Imagen Perfil</label>
                <input type="file" class="form-control mb-1" id="txtImagen" runat="server">
                <asp:Image ImageUrl="https://impactify.io/wp-content/uploads/2024/05/placeholder-5.png" runat="server" ID="imgNuevoPerfil" CssClass="img-fluid mb-3" />
                <%--//Acá deben ir los botones para confirmar o cancelar la edición de las fotos --%>
                
            </div>
            <div class="mb-3 gap-2">
                <asp:Button Text="Confirmar" runat="server" ID="btnConfirmarFoto" CssClass="btn btn-primary" Visible="false" OnClick="btnConfirmarFoto_Click"/>
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelarFoto" CssClass="btn btn-dark" Visible="false" OnClick="btnCancelarFoto_Click"/>
            </div>
        </div>
        <div class="col-md-4 ">
            <div class="mb-3 d-grid gap-2 w-25">
                <asp:Button Text="Editar Foto" ID="btnEditarFoto" OnClick="btnEditarFoto_Click" CssClass="btn btn-primary"  runat="server" />

                <asp:Button Text="Editar datos" ID="btnEditarDatos" OnClick="btnEditarDatos_Click" CssClass="btn btn-primary" runat="server" />

                <a href="Default.aspx" class="btn btn-dark">Regresar</a>

            </div>
        </div>

    </div>
    <div class="row justify-content-center">
        <div class="col-3">
        </div>

    </div>


</asp:Content>
