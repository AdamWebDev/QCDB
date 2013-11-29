<%@ Page Title="Edit Insurance Policy" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Qualified_Contractor_Tracking.InsurancePolicies.Edit" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">Edit Contractor</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">Qualified Contractor Database</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageIntro" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnCancel" runat="server" Icon="~/resources/images/icons/back.png" AltText="Back" Text="Back to Contractor"  />
    <li>
    <asp:LinkButton ID="lnkConfirmDelete" runat="server" CssClass="shortcut-button" 
            OnClientClick="return confirm('Are you sure you want to delete this policy?');" 
            onclick="lnkConfirmDelete_Click">
        <span><asp:Image ID="imgDelete" runat="server" AlternateText="" ImageUrl="~/resources/images/icons/delete.png" />
		<br />
		Delete this Policy
    </span></asp:LinkButton></li>

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
