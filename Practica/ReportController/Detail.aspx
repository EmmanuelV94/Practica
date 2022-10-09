<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Practica.ReportController.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Detalle de Cursos
    </h2>
    <div class="row">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Código</th>
                    <th>Nombre</th>
                    <th>Maestro</th>
                    <th>Estudiantes</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var item in Courses)
                    { %>
                <tr>
                    <td scope="row"><%= item.Code %></td>
                    <td><%= item.CourseName %></td>
                    <td><%= string.IsNullOrWhiteSpace(item.TeacherName) ? " Sin Maestro " : item.TeacherName %></td>
                    <td colspan="2">
                        <h5>Asignados: <%= item.AssignedStudents %></h5>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Carnet</th>
                                    <th>Nombre</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var student in item.Students)
                                    { %>
                                <tr>
                                    <td><%= student.Carnet %></td>
                                    <td><%= student.FullName %></td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</asp:Content>
