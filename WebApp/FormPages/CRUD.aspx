<%@ Page Title="CRUD - StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="WebApp.FormPages.CRUD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Programs - Single Item Edtiting</h1>
    <hr />

    <p class="text-muted">Please select a school from the list below to see available programs.</p>
    <div class="crud-ddl">
        <asp:Label ID="Label1" runat="server" Text="School: " AssociatedControlID="SchoolSearchList"></asp:Label>
        <asp:DropDownList ID="SchoolSearchList" runat="server">
        </asp:DropDownList>
        <asp:Button ID="ViewProgram" runat="server" Text="View Program" CssClass="btn btn-info" OnClick="ViewProgram_Click" CausesValidation="false" />
    </div>
    <br />
    <p class="text-muted">Please select a program to enable edit.</p>
    <div class="crud-ddl">
        <asp:Label ID="Label2" runat="server" Text="Program: " AssociatedControlID="ProgramSearchList"></asp:Label>
        <asp:DropDownList ID="ProgramSearchList" runat="server">
        </asp:DropDownList>
        <asp:Button ID="SelectProgram" runat="server" Text="Select Program" CssClass="btn btn-info" OnClick="SelectProgram_Click" CausesValidation="false" />
    </div>
    <br /><br />
 

    <asp:Label ID="Message" runat="server"></asp:Label>
    <asp:Label ID="MessageSuccess" runat="server" CssClass="text-success"></asp:Label>
    <asp:Label ID="MessageWarning" runat="server" CssClass="text-danger"></asp:Label>

    

    <%-- Form Validators --%>
    <asp:ValidationSummary ID="ProgramValidation" runat="server" HeaderText="Please correct your input to resolve the following issues." CssClass="alert alert-danger" />
    <%-- Program Name --%>
    <asp:RequiredFieldValidator ID="ProgramNameRequired" runat="server" ErrorMessage="Program Name is requried." ControlToValidate="ProgramName" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="ProgramNameLength" runat="server" ErrorMessage="Program name is limited up to 100 characters" ValidationExpression="^.{1,100}$" ControlToValidate="ProgramName" SetFocusOnError="true" Display="None"></asp:RegularExpressionValidator>
    <%-- Diploma --%>
    <asp:RegularExpressionValidator ID="DiplomaNameLength" runat="server" ErrorMessage="Diploma name is limited up to 100 characters." ValidationExpression="^.{0,100}$" ControlToValidate="Diploma" SetFocusOnError="true" Display="None"></asp:RegularExpressionValidator>
    <%-- School Code --%>
    <asp:RegularExpressionValidator ID="SchoolCodeRequired" runat="server" ErrorMessage="Must select a school." ValidationExpression="^.{1,10}$" ControlToValidate="Schoolcode" SetFocusOnError="true" Display="None"></asp:RegularExpressionValidator>
    <%-- Tuition --%>
    <asp:RequiredFieldValidator ID="DmstcTuitionRequired" runat="server" ErrorMessage="Domestic Tuition is required." ControlToValidate="DmstcTuition" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="DmstcTuitionRange" runat="server" ErrorMessage="Invalid Domestic Tuition value. Ex. value cannot be negative." ControlToValidate="DmstcTuition" Type="Double" MinimumValue="0" MaximumValue="99999999" SetFocusOnError="true" Display="None"></asp:RangeValidator>
    <%-- Intl Tuition --%>
    <asp:RequiredFieldValidator ID="IntlTuitionRequired" runat="server" ErrorMessage="International Tuition is required." ControlToValidate="IntlTuition" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="IntlTuitionRange" runat="server" ErrorMessage="Invalid International Tuition value. Ex. value cannot be negative." ControlToValidate="IntlTuition" Type="Double" MinimumValue="0" MaximumValue="99999999" SetFocusOnError="true" Display="None"></asp:RangeValidator>
    <br />

    <h2>Information Details</h2>

    <fieldset>
        <asp:Label ID="Label3" runat="server" Text="Program ID: " AssociatedControlID="ProgramID"></asp:Label>
        <asp:TextBox ID="ProgramID" runat="server" Enabled="False" ReadOnly="True" ></asp:TextBox>

        <asp:Label ID="Label4" runat="server" Text="Program Name: " AssociatedControlID="ProgramName"></asp:Label>
        <asp:TextBox ID="ProgramName" runat="server"  ></asp:TextBox>

        <asp:Label ID="Label5" runat="server" Text="Diploma: " AssociatedControlID="Diploma"></asp:Label>
        <asp:TextBox ID="Diploma" runat="server"></asp:TextBox>

        <asp:Label ID="Label6" runat="server" Text="School: " AssociatedControlID="SchoolCode"></asp:Label>
        <asp:DropDownList ID="SchoolCode" runat="server">
        </asp:DropDownList>

        <asp:Label ID="Label7" runat="server" Text="Domestic Tuition ($): " AssociatedControlID="DmstcTuition"></asp:Label>
        <asp:TextBox ID="DmstcTuition" runat="server"  ></asp:TextBox>

        <asp:Label ID="Label8" runat="server" Text="International Tuition ($): " AssociatedControlID="IntlTuition"></asp:Label>
        <asp:TextBox ID="IntlTuition" runat="server"  ></asp:TextBox>

        <br /><br />
        <asp:Button ID="Clear" runat="server" Text="Clear" CausesValidation="false" CssClass="btn btn-secondary" OnClick="Clear_Click"  />
        <asp:Button ID="Insert" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Insert_Click"  />
        <asp:Button ID="Update" runat="server" Text="Update" CssClass="btn btn-success" OnClick="Update_Click"  />
        <asp:Button ID="Delete" runat="server" Text="Delete" CssClass="btn btn-danger" CausesValidation="false"  OnClientClick="return confirm('Are you sure you want to delete the program record?');" OnClick="Delete_Click" />
    </fieldset>

    <script src="../Scripts/bootwrap-freecode.js"></script>


</asp:Content>
