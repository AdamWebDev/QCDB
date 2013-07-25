<%@ Page Title="Edit Insurance Policy" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Qualified_Contractor_Tracking.InsurancePolicies.Edit" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageIntro" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnCancel" runat="server" Icon="~/resources/images/icons/back.png" AltText="Back" Text="Back to Contractor"  />
    <uc3:NavButton ID="btnDelete" runat="server" Icon="~/resources/images/icons/delete.png" AltText="Delete Insurance Policy" Text="Delete this policy" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentBoxHeader" runat="server">
    <asp:Literal ID="ltSubTitle" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Tabs" runat="server">
</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <uc4:Notification ID="notIns" runat="server" Visible="false" />
   
    <uc6:InsurancePolicyEditor ID="EditInsurance" runat="server" Mode="Edit" />

    <asp:Button ID="btnSubmit" runat="server" Text="Save Insurance Policy" CssClass="button" onclick="btnSubmit_Click" />
    
</asp:Content>
