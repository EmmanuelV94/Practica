<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Brief.aspx.cs" Inherits="Practica.ReportController.Brief" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Resumen de Cursos
    </h2>
    <div class="row">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Código</th>
                    <th>Nombre</th>
                    <th>Maestro</th>
                    <th>Estudiantes Asignados</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var item in Courses)
                    { %>
                <tr>
                    <td scope="row"><%= item.Code %></td>
                    <td><%= item.CourseName %></td>
                    <td><%= string.IsNullOrWhiteSpace(item.TeacherName) ? " Sin Maestro " : item.TeacherName %></td>
                    <td><%= item.AssignedStudents %></td>
                </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</asp:Content>
