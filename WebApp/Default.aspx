<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br/ > <br />
    <div class="jumbotron">
        <h1>Star TED - Programs</h1>
        <p class="lead">The application enables interactivity to Star TED program information with two forms, CRUD and Query.</p>
        <br />
        <p class="lead">CRUD Form - user can read, create, or edit all program related information from a selected school.</p>
        <p class="lead">Query Form - user can search for programs. In the search results, user also can view all school information.</p>
        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="homepage">

        <div>
            <h2>Known Bugs</h2>
            <ul>
                <li>None.</li>
            </ul>

        </div>

        <div>
            <h2>Stored Procedure</h2>
            <ul>
                <li>Programs_FindBySchool</li>
                <li>Programs_FindByProgramName</li>
            </ul>
        </div>
    </div>
</asp:Content>
