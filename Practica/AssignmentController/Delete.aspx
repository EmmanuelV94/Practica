<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Practica.AssignmentController.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Eliminar Asignación
    </h2>
    <hr />
    <h5>
        <%=message %>
    </h5>
    <div class="form-group">
        <label for="StudentId">Código</label>
        <asp:DropDownList ID="StudentId" Enabled="false" CssClass="form-control" TabIndex="1" runat="server" DataValueField="Carnet" DataTextField="FullName"></asp:DropDownList>

    </div>
    <div class="form-group">
        <label for="CourseId">Nombre</label>
        <asp:DropDownList ID="CourseId" Enabled="false" CssClass="form-control" TabIndex="2" runat="server" DataValueField="Code" DataTextField="Name"></asp:DropDownList>

    </div>
    <a runat="server" tabindex="-1" href="Index" target="_self" class="btn btn-default">Cancelar</a>
    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Eliminar" TabIndex="3" OnClick="BtnSave_Click" />
</asp:Content>
