<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Qualified_Contractor_Tracking.Default" %>
<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">Home</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    Qualified Contractor Database
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBoxHeader" runat="server">
    Contractor Listing
</asp:Content>
<asp:Content ID="Tabs" ContentPlaceHolderID="Tabs" runat="server">
    <div class="searchbox"><asp:TextBox ID="txtSearch" runat="server" CssClass="text-input"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" 
            onclick="btnSearch_Click" /></div>
</asp:Content>
<asp:Content ID="Buttons" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnViewAll" runat="server" Icon="~/resources/images/icons/home.png" AltText="Home" Text="Home/View All" NavURL="~/Default.aspx" />
    <uc3:NavButton ID="btnViewAvailable" runat="server" Icon="~/resources/images/icons/page_preview.png" AltText="Available" Text="View Available Contractors" NavURL="~/Default.aspx?view=available" />
    <uc3:NavButton ID="btnSearchByService" runat="server" Icon="~/resources/images/icons/search.png" AltText="Search by Service" Text="Search by Services" NavURL="~/SearchByService.aspx" />
    <uc3:NavButton ID="btnNewContractor" runat="server" Icon="~/resources/images/icons/add.png" AltText="Add" Text="Add New Contractor" NavURL="~/NewContractor.aspx" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="rptContractor" runat="server">
    <HeaderTemplate>
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Available?</th>
                    <th>More Details</th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="ltCompany" runat="server" Text='<%# Eval("Company") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="lnkEmail" runat="server" NavigateUrl='<%# Eval("Email","mailto:{0}") %>' Text='<%# Eval("Email") %>'></asp:HyperLink></td>
                <td><asp:Image ID="imgCheck" runat="server" ImageUrl="~/resources/images/icons/tick_circle.png" Visible='<%# Eval("IsValid") %>' /><asp:Image ID="Image1" runat="server" ImageUrl="~/resources/images/icons/cross_circle.png" Visible='<%# Eval("IsValid").ToString().Equals("False") %>' /></td>
                <td><asp:HyperLink ID="lnkDetails" runat="server" Text="View Details" NavigateUrl='<%# String.Format("~/ViewContractor.aspx?ID={0}",Eval("ID")) %>'></asp:HyperLink></td>
            </tr>
        </ItemTemplate>
    <FooterTemplate>
            </tbody>
    </table>
    
    </FooterTemplate>
    </asp:Repeater>
    
</asp:Content>
