<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Permits.aspx.cs" Inherits="Qualified_Contractor_Tracking.Permits" %>
<asp:Content ID="TitleContent" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:Literal ID="ltTitle" runat="server" Text="Permits"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnCancel" runat="server" Icon="~/resources/images/icons/back.png" AltText="Back" Text="Back to Contractor" />
    <uc3:NavButton ID="btnDelete" runat="server" Icon="~/resources/images/icons/delete.png" AltText="Delete" Text="Delete this Permit" Visible="false"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentBoxHeader" runat="server">
    <asp:Literal ID="ltSubTitle" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Tabs" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

        <uc4:Notification ID="notAgreement" runat="server" Visible="false" />

        <asp:Panel ID="pnDelete" runat="server" Visible="false">
            Are you sure you want to delete this agreement?<br /><br />
        <ul class="shortcut-buttons-set">
        <li>
        <asp:LinkButton ID="lnkCancelDelete" runat="server" CssClass="shortcut-button" 
                onclick="lnkCancelDelete_Click">
            <span><img alt="Cancel" src="/resources/images/icons/back.png" />
		    <br />
		    No, back to Agreement details
        </span></asp:LinkButton>    
        </li>
        <li>
        <asp:LinkButton ID="lnkConfirmDelete" runat="server" CssClass="shortcut-button" 
                onclick="lnkConfirmDelete_Click">
            <span><img alt="Cancel" src="/resources/images/icons/delete.png" />
		    <br />
		    Yes, delete this Agreement.
        </span></asp:LinkButton></li>
        </ul>
        <div class="clear"></div>
        </asp:Panel>
        <asp:Panel ID="pnDetails" runat="server">

            <label>Type of Permit</label>
            <asp:DropDownList ID="ddTypeOfPermit" runat="server" CssClass="small-input" 
                AppendDataBoundItems="true" AutoPostBack="true" 
                onselectedindexchanged="ddTypeOfPermit_SelectedIndexChanged">
                <asp:ListItem Value="">--Select--</asp:ListItem>
            </asp:DropDownList>

            <label>CGL Insurance</label>
            <uc2:TrueFalseDropDown ID="ddCGL" runat="server" CssClass="small-input"/>
            
            &nbsp;<asp:PlaceHolder ID="phAutoInsurance" runat="server" Visible="false">
                <label>Auto Insurance</label>
                <uc2:TrueFalseDropDown ID="ddAutoInsurance" runat="server" CssClass="small-input" />
            </asp:PlaceHolder>
        
            <asp:PlaceHolder ID="phWaterSewer" runat="server" Visible="false">
                <label>Type Of Security</label>
                <asp:DropDownList ID="ddTypeOfSecurity" runat="server" CssClass="small-input" AppendDataBoundItems="true" AutoPostBack="true">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                </asp:DropDownList>

                <label>Expiry Date</label>
                <uc1:DateDropDown ID="dddExpiryDate" runat="server" />
                
            </asp:PlaceHolder>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddTypeOfPermit" />
            <asp:AsyncPostBackTrigger ControlID="ddTypeOfSecurity" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:Button ID="btnSubmit" runat="server" Text="Save Permit" CssClass="button" 
        onclick="btnSubmit_Click" />

</asp:Content>
