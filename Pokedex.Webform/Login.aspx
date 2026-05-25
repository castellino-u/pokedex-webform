<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pokedex.Webform.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center mt-4">
        <div class="col-4">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                <div id="emailHelp" class="form-text">Nunca vamos a compartir tu email con cualquier otra persona.</div>
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" type="password"  />
            </div>
            <div class="mb-3">
                <asp:Button Text="Iniciar" CssClass="btn btn-primary" runat="server" ID="btnIniciar" OnClick="btnIniciar_Click" />
                <asp:Label Text="" runat="server" ID="lblError" CssClass="form-label"  />
            </div>

        </div>
    </div>

</asp:Content>
