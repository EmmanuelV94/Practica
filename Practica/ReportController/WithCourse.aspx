<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WithCourse.aspx.cs" Inherits="Practica.ReportController.WithCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Estudiantes con al menos un curso
    </h2>
    <div class="row">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Carnet</th>
                    <th>Nombres</th>
                    <th>Apellidos</th>
                    <th>Fecha de Nacimiento</th>
                    <th>Edad</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var item in Students)
                    { %>
                <tr>
                    <td scope="row"><%= item.Carnet %></td>
                    <td><%= item.FirstName + " " + item.SecondName %></td>
                    <td><%= item.LastName + " " + item.SecondLastName %></td>
                    <td><%= item.DateBirth.ToString("dd/MM/yyyy") %></td>
                    <td><%= item.Age %></td>
                </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</asp:Content>
