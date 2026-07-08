<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Pokedex.Webform.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validation{
            color:red;
            font-size:15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center mt-4">
        <div class="col-6">
        <h2>Registro Trainee</h2>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                <asp:RegularExpressionValidator ErrorMessage="Ingrese un email con formato válido" CssClass="validation" ControlToValidate="txtEmail" runat="server" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" />
                <div id="emailHelp" class="form-text">Nunca vamos a compartir tu email con nadie más.</div>
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" TextMode="Password" />
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Repetir Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtRepetirPassword" type="password" />
                <asp:RangeValidator ErrorMessage="La contraseña es muy corta" CssClass="validation" ControlToValidate="txtRepetirPassword" runat="server" Type="Integer" MinimumValue="1" MaximumValue="10" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Registrarse" CssClass="btn btn-primary" runat="server" ID="btnRegistrarse" OnClick="btnRegistrarse_Click"  />
                <a href="Default.aspx" class="btn btn-dark">Cancelar</a>
                <asp:Label Text="" runat="server" ID="lblError" CssClass="form-label" />
            </div>

        </div>
    </div>

</asp:Content>
