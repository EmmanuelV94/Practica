<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Practica.CourseController.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Nuevo Curso
    </h2>
    <hr />
    <h5>
        <%=message %>
    </h5>
    <div class="form-group">
        <label for="Code">Código</label>
        <asp:TextBox ID="Code" runat="server" CssClass="form-control" TabIndex="0"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="Name">Nombre</label>
        <asp:TextBox ID="Name" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="Description">Descripción</label>
        <asp:TextBox ID="Description" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="TeacherId">Maestro</label>
        <asp:DropDownList ID="TeacherId" CssClass="form-control" TabIndex="3" runat="server" DataValueField="Carnet" DataTextField="FullName"></asp:DropDownList>
    </div>
    <a runat="server" tabindex="-1" href="Index" target="_self" class="btn btn-default">Cancelar</a>
    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Guardar" TabIndex="6" OnClick="BtnSave_Click" />
</asp:Content>
