<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Pokedex.Webform.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center mt-4">
        <div class="col-6">
        <h2>Registro Trainee</h2>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                <div id="emailHelp" class="form-text">Nunca vamos a compartir tu email con nadie más.</div>
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" TextMode="Password" />
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Repetir Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtRepetirPassword" type="password" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Registrarse" CssClass="btn btn-primary" runat="server" ID="btnRegistrarse" OnClick="btnRegistrarse_Click"  />
                <a href="Default.aspx" class="btn btn-dark">Cancelar</a>
                <asp:Label Text="" runat="server" ID="lblError" CssClass="form-label" />
            </div>

        </div>
    </div>

</asp:Content>
