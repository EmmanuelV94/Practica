<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Practica.StudentController.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Eliminar Estudiante
    </h2>
    <hr />
    <h5>
        <%=message %>
    </h5>
    <div class="form-group">
        <label for="Carnet">Carnet</label>
        <asp:TextBox ID="Carnet" runat="server" ReadOnly="true" CssClass="form-control" TextMode="Number" TabIndex="0"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="FirstName">Primer Nombre</label>
        <asp:TextBox ID="FirstName" runat="server" ReadOnly="true" CssClass="form-control" TabIndex="1"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="SecondName">Segundo Nombre</label>
        <asp:TextBox ID="SecondName" runat="server" ReadOnly="true" CssClass="form-control" TabIndex="2"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="LastName">Primer Apellido</label>
        <asp:TextBox ID="LastName" runat="server" ReadOnly="true" CssClass="form-control" TabIndex="3"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="SecondLastName">Segundo Apellido</label>
        <asp:TextBox ID="SecondLastName" runat="server" ReadOnly="true" CssClass="form-control" TabIndex="4"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="DateBirth">Fecha de Nacimiento</label>
        <asp:TextBox ID="DateBirth" runat="server" ReadOnly="true" CssClass="form-control" TextMode="Date" TabIndex="5"></asp:TextBox>
    </div>
    <a runat="server" href="Index" target="_self" class="btn btn-default">Cancelar</a>
    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Eliminar" TabIndex="6" OnClick="BtnSave_Click" />
</asp:Content>
