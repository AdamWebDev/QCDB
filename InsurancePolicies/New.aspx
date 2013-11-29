<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="Qualified_Contractor_Tracking.InsurancePolicies.New" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">Add New - Insurance Policies</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">Insurance Policies</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageIntro" runat="server"></asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnCancel" runat="server" Icon="~/resources/images/icons/back.png" AltText="Back" Text="Back to Contractor"  />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentBoxHeader" runat="server">Add a New Policy</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Tabs" runat="server"></asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <uc4:Notification ID="notIns" runat="server" Visible="false" />

    <uc6:InsurancePolicyEditor ID="NewPolicy" runat="server" Mode="New" />
    
    <asp:Button ID="btnSubmit" runat="server" Text="Save Insurance Policy" CssClass="button" onclick="btnSubmit_Click" />

</asp:Content>
