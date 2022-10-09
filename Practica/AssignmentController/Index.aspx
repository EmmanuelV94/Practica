<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Practica.AssignmentController.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Asignaciones
    </h2>
    <div class="row">
        <a runat="server" target="_self" href="Create" class="btn btn-default">Nuevo</a>
    </div>
    <div class="row">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th></th>
                    <th>Curso</th>
                    <th>Estudiante</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var item in Assignments)
                    { %>
                <tr>
                    <td>
                        <a target="_self" href="Delete?studentId=<%= item.StudentId %>&courseId=<%= item.CourseId %>" class="btn btn-danger">Eliminar</a>
                    </td>
                    <td><%= item.Course.Name %></td>
                    <td><%= item.Student.FullName %></td>
                </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</asp:Content>
