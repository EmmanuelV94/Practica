<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Practica.StudentController.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Estudiantes
    </h2>
    <div class="row">
        <a runat="server" target="_self" href="Create" class="btn btn-default">Nuevo</a>
    </div>
    <div class="row">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th></th>
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
                    <td>
                        <a target="_self" href="Edit?id=<%= item.Carnet %>" class="btn btn-primary">Editar</a>
                        <a target="_self" href="Delete?id=<%= item.Carnet %>" class="btn btn-danger">Eliminar</a>
                    </td>
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
