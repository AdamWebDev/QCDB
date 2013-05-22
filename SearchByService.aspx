<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByService.aspx.cs" Inherits="Qualified_Contractor_Tracking.SearchByService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
Search by Service
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">Qualified Contractor Database</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageIntro" runat="server"></asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnViewAll" runat="server" Icon="~/resources/images/icons/home.png" AltText="Home" Text="Home/View All" NavURL="~/Default.aspx" />
    <uc3:NavButton ID="btnViewAvailable" runat="server" Icon="~/resources/images/icons/page_preview.png" AltText="Available" Text="View Available Contractors" NavURL="~/Default.aspx?view=available" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentBoxHeader" runat="server">
Search by Service
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Tabs" runat="server">
</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:Label ID="lblSearch" runat="server" Text="Search" AssociatedControlID="txtSearch"></asp:Label>
    <asp:TextBox ID="txtSearch" runat="server" CssClass="text-input medium-input"></asp:TextBox>
    <ajaxToolkit:AutoCompleteExtender ID="txtSearchAutoComplete" runat="server" TargetControlID="txtSearch" ServicePath="~/AutoSuggestWebService.asmx" ServiceMethod="GetTags" MinimumPrefixLength="1" CompletionListCssClass="CompletionList" CompletionListItemCssClass="CompletionListItem" CompletionListHighlightedItemCssClass="CompletionListHightlightedItem" CompletionInterval="200"></ajaxToolkit:AutoCompleteExtender>
    <asp:Button ID="btn" runat="server" Text="Search!" CssClass="button" />



    <asp:PlaceHolder ID="phEmpty" runat="server" Visible='false'>
        <p>Sorry, but no results were found!</p>
    </asp:PlaceHolder>
    <asp:Repeater ID="rptContractor" runat="server" Visible="false">
    <HeaderTemplate>
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Available?</th>
                    <th>Service Provided</th>
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
                <td><asp:Literal ID="ltService" runat="server" Text='<%# Eval("MatchingService") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="lnkDetails" runat="server" Text="View Details" NavigateUrl='<%# String.Format("~/ViewContractor.aspx?ID={0}",Eval("ID")) %>'></asp:HyperLink></td>
            </tr>
        </ItemTemplate>
    <FooterTemplate>
            </tbody>
    </table>
    
    </FooterTemplate>
    </asp:Repeater>
</asp:Content>
