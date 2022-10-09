<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Practica.CourseController.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cursos
    </h2>
    <div class="row">
        <a runat="server" target="_self" href="Create" class="btn btn-default">Nuevo</a>
    </div>
    <div class="row">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th></th>
                    <th>Código</th>
                    <th>Nombre</th>
                    <th>Descripción</th>
                    <th>Maestro</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var item in Courses)
                    { %>
                <tr>
                    <td>
                        <a target="_self" href="Edit?id=<%= item.Code %>" class="btn btn-primary">Editar</a>
                        <a target="_self" href="Delete?id=<%= item.Code %>" class="btn btn-danger">Eliminar</a>
                    </td>
                    <td scope="row"><%= item.Code %></td>
                    <td><%= item.Name %></td>
                    <td><%= item.Description %></td>
                    <td><%= item.Teacher == null ? " Sin Maestro " : item.Teacher.FirstName + " " + item.Teacher.LastName %></td>
                </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</asp:Content>
