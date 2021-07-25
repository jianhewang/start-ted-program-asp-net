<%@ Page Title="ODS - StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="WebApp.FormPages.Query" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Program Lookup by Program Name</h1>
    <hr />
    <asp:Label ID="Label1" runat="server" Text="Please enter a (partial) program name: " AssociatedControlID="ProgramSearch" ></asp:Label>
    <asp:TextBox ID="ProgramSearch" runat="server"></asp:TextBox>
    <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
    <br />
    <asp:Label ID="Message" runat="server" CssClass="text-danger"></asp:Label>
    <br /><br />
    <h3>Program Details</h3>
    <%-- ToDo: customize grid view;   --%>
    <asp:GridView ID="ProgramGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ProgramsGridODS" CssClass="table table-hover" AllowPaging="True" PageSize="5" >
        <Columns>
            <asp:TemplateField HeaderText="Program">
                
                <ItemTemplate>
                    <asp:Label ID="ProgramName" runat="server" Text='<%# Eval("ProgramName") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="300px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diploma">
                
                <ItemTemplate>
                    <asp:Label ID="Diploma" runat="server" Text='<%# Eval("DiplomaName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="School">
                
                <ItemTemplate>
                    <asp:DropDownList ID="GridSchoolList" runat="server" DataSourceID="SchoolListODS" DataTextField="SchoolName" DataValueField="SchoolCode" SelectedValue='<%# Eval("SchoolCode") %>' Width="360px" CssClass="schools">
                    </asp:DropDownList>
                </ItemTemplate>
                <ControlStyle Width="360px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Domestic Tuition">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Tuition", "${0:0,0.00}") %>'></asp:Label>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="International Tuition">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("InternationalTuition", "${0:0,0.00}") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="True" />
                <ItemStyle HorizontalAlign="Right" Wrap="False" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No results found.
        </EmptyDataTemplate>
    </asp:GridView>


    <asp:ObjectDataSource ID="ProgramsGridODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Programs_FindByProgramName" TypeName="StarTEDSystem.BLL.ProgramController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ProgramSearch" PropertyName="Text" DefaultValue="noprogramused" Name="programName" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SchoolListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllSchools" TypeName="StarTEDSystem.BLL.SchoolController"></asp:ObjectDataSource>

</asp:Content>
