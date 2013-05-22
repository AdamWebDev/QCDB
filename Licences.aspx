<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Licences.aspx.cs" Inherits="Qualified_Contractor_Tracking.Licenses" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
Applicable Licenses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="TitleContent" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:Literal ID="ltTitle" runat="server" Text="Licences"></asp:Literal>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnCancel" runat="server" Icon="~/resources/images/icons/back.png" AltText="Back" Text="Back to Contractor" />
    <uc3:NavButton ID="btnDelete" runat="server" Icon="~/resources/images/icons/delete.png" AltText="Delete" Text="Delete this Licence" Visible="false"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentBoxHeader" runat="server">
    <asp:Literal ID="ltSubTitle" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
    <ContentTemplate>
    <uc4:Notification ID="notNotification" runat="server" Message="test" Type="Success" Visible="false" />
    <asp:Panel ID="pnDelete" runat="server" Visible="false">
            Are you sure you want to delete this agreement?<br /><br />
        <ul class="shortcut-buttons-set">
        <li>
        <asp:LinkButton ID="lnkCancelDelete" runat="server" CssClass="shortcut-button" onclick="lnkCancelDelete_Click">
            <span><img alt="Cancel" src="/resources/images/icons/back.png" />
		    <br />
		    No, back to Licence details
        </span></asp:LinkButton>    
        </li>
        <li>
        <asp:LinkButton ID="lnkConfirmDelete" runat="server" CssClass="shortcut-button" 
                onclick="lnkConfirmDelete_Click">
            <span><img alt="Cancel" src="/resources/images/icons/delete.png" />
		    <br />
		    Yes, delete this Licence.
        </span></asp:LinkButton></li>
        </ul>
        <div class="clear"></div>
        </asp:Panel>
        <asp:Panel ID="pnDetails" runat="server">

    <label>Type of Licence Required</label>
    <asp:TextBox ID="txtTypeOfLicense" runat="server" CssClass="text-input small-input" MaxLength="100"></asp:TextBox>

    <label>Copy of Licence Received</label>
    <uc2:TrueFalseDropDown ID="ddCopyReceived" runat="server" CssClass="small-input"/>

    <label>Licence Filed With</label>
    <asp:TextBox ID="txtFiledWith" runat="server" CssClass="text-input small-input" MaxLength="25"></asp:TextBox>

    <uc5:DivisionDD ID="ddDivision" runat="server" />
    
    
    <asp:Button ID="btnSubmit" runat="server" Text="Save Licence" CssClass="button" onclick="btnSubmit_Click" />
    <br />

    
    </asp:Panel>
        </ContentTemplate>
        </asp:UpdatePanel>

        
</asp:Content>
