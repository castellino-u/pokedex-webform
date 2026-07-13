<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Pokedex.Webform.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center">
        <div class="col-6 mt-4">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" type="email" CssClass="form-control" ID="txtEmail" required />
                <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
            </div>
            <div class="mb-3">
                <label for="txtAsunto" class="form-label">Asunto</label>
                <asp:TextBox runat="server" ID="txtAsunto" CssClass="form-control" required />
            </div>
            <div class="mb-3">
                <label class="form-label" for="txtCuerpo">Mensaje</label>
                <asp:TextBox runat="server" ID="txtCuerpo" TextMode="MultiLine" CssClass="form-control" required />

            </div>
            <asp:Button Text="Enviar" runat="server" ID="btnEnviar" CssClass="btn btn-primary" OnClick="btnEnviar_Click" />
            <%-- por ahora lo vamos a manejar así pero más adelante pondremos algo mejor --%>
            <asp:Label Text="" runat="server" ID="lblConfirmacion" CssClass="form-label"/>
        </div>
    </div>






</asp:Content>
