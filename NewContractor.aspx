<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewContractor.aspx.cs" Inherits="Qualified_Contractor_Tracking.NewContractor" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Title" runat="server">Add a New Contractor</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    Add a Contractor
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBoxHeader" runat="server">
    Contractor Details
</asp:Content>
<asp:Content ID="Buttons" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnBack" runat="server" Icon="~/resources/images/icons/back.png" AltText="Back" Text="Back" NavURL="~/Default.aspx" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<uc4:Notification ID="notCont" runat="server" Visible="false" />
<label>Company/Contractor</label>
    <asp:TextBox ID="txtCompany" runat="server" CssClass="text-input medium-input" MaxLength="255"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqCompany" ControlToValidate="txtCompany" runat="server" ErrorMessage="Company is required" CssClass="input-notification error png_bg"></asp:RequiredFieldValidator>
<label>Vendor Number</label>
    <asp:TextBox ID="txtVendorNumber" runat="server" CssClass="text-input small-input" MaxLength="50"></asp:TextBox>
<label>Contractor Contact Name</label>
    <asp:TextBox ID="txtContactName" runat="server" CssClass="text-input small-input" MaxLength="100"></asp:TextBox>
<label>Mailing Address</label>
    <asp:TextBox ID="txtMailAddress" runat="server" CssClass="text-input medium-input" MaxLength="255"></asp:TextBox>
<label>Town</label>
    <asp:TextBox ID="txtTown" runat="server" CssClass="text-input small-input" MaxLength="50"></asp:TextBox>
<label>Postal Code</label>
    <asp:TextBox ID="txtPostalCode" runat="server" CssClass="text-input small-input" MaxLength="10"></asp:TextBox>
<label>Email Address</label>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtEmail" ErrorMessage="Not a valid email address" 
        CssClass="input-notification error png_bg" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        Display="Dynamic"></asp:RegularExpressionValidator>
<label>Norfolk County Contact</label>
    <asp:TextBox ID="txtNCContact" runat="server" CssClass="text-input small-input" MaxLength="100"></asp:TextBox>

    <br />
<asp:Button ID="btnCreate" runat="server" Text="Create Contractor" CssClass="button" onclick="btnCreate_Click" CausesValidation="true" />



</asp:Content>
