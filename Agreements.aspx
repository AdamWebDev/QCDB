<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agreements.aspx.cs" Inherits="Qualified_Contractor_Tracking.Agreements" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    Agreements
</asp:Content>
<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">Agreements</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnCancel" runat="server" Icon="~/resources/images/icons/back.png" AltText="Back" Text="Back to Contractor" />
    <uc3:NavButton ID="btnDelete" runat="server" Icon="~/resources/images/icons/delete.png" AltText="Delete" Text="Delete this Agreement" Visible="false"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentBoxHeader" runat="server">
    <asp:Literal ID="ltSubTitle" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Tabs" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
    <label>Type</label>
    <asp:DropDownList ID="ddTypeOfAgreement" runat="server"  CssClass="small-input" AppendDataBoundItems="true" onselectedindexchanged="ddTypeOfAgreement_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="">--Select--</asp:ListItem>
    </asp:DropDownList>
    
    <label>Description</label>
    <asp:TextBox ID="txtDescription" runat="server" CssClass="text-input small-input" 
                MaxLength="255" />
            
    <label>Term Effective Date</label>
        <uc1:DateDropDown ID="dddTermEffectiveDate" runat="server"/>

    <label>Term Expiry Date</label>
        <uc1:DateDropDown ID="dddTermExpiryDate" runat="server" />

        <label>Term Extension Date</label>
        <uc1:DateDropDown ID="dddExtensionExpiryDate" runat="server" />
            
    <label>Amount Before Tax</label>
    <asp:TextBox ID="txtAmtBeforeTax" runat="server" CssClass="text-input small-input" 
                MaxLength="10" />
            
    <label>Agreement Signed</label>
        <asp:DropDownList ID="ddAgreementSigned" runat="server" CssClass="small-input" AppendDataBoundItems="true" >
            <asp:ListItem Value="">--Select--</asp:ListItem>
        </asp:DropDownList>
            
    <asp:PlaceHolder ID="phContract" runat="server" Visible="false">            
        <label>PO Number</label>
        <asp:TextBox ID="txtPONumber" runat="server" CssClass="text-input small-input" MaxLength="10" />
            
        <label>Division Issued:</label>
        <uc5:DivisionDD ID="ddDivisionIssued" runat="server" />

        
            
        <h3>Securities Required</h3>
        <label>Type of Security Required</label>
        <asp:CheckBoxList ID="chkTypeSecurity" runat="server" OnSelectedIndexChanged="chkTypeSecurity_OnSelectedIndexChanged" AutoPostBack="true" CssClass="checkboxtable">
        </asp:CheckBoxList>
        <br />

        <asp:PlaceHolder ID="phBidDeposit" runat="server" Visible="false">
        <label>Bid Deposit Received</label>
        <uc2:TrueFalseDropDown ID="ddBidDepositRecd" runat="server" CssClass="small-input" /><br />
        Amount: <asp:TextBox ID="txtBidDepositAmnt" runat="server" CssClass="text-input small-input" MaxLength="10" />
        </asp:PlaceHolder>
            
        <asp:PlaceHolder ID="phPerfBond" runat="server" Visible="false">
        <label>Performance Bond Received:</label>
        <uc2:TrueFalseDropDown ID="ddPerfBondRecd" runat="server" CssClass="small-input" /><br />
        Amount: <asp:TextBox ID="txtPerfBondAmt" runat="server" CssClass="text-input small-input" MaxLength="10" />
        </asp:PlaceHolder>
        
        <asp:PlaceHolder ID="phLabourBond" runat="server" Visible="false">    
        <label>Labour & Material Bond Received:</label>
        <uc2:TrueFalseDropDown ID="ddLabourBondRecd" runat="server" CssClass="small-input" /><br />
        Amount: <asp:TextBox ID="txtLabourBondAmt" runat="server" CssClass="text-input small-input" MaxLength="10" />
        </asp:PlaceHolder>

        <label>Testing Required:</label>
        <uc2:TrueFalseDropDown ID="ddTestingRequired" runat="server" CssClass="small-input" />
        
        <label>Testing Received:</label>
        <uc2:TrueFalseDropDown ID="ddTestingReceived" runat="server" CssClass="small-input" />
                    
        <label>Notification of Contract to MOL Required</label>
        <uc2:TrueFalseDropDown ID="ddMOLReqd" runat="server" CssClass="small-input" />
        
        <label>Notification of Contract to MOL Received</label>
        <uc2:TrueFalseDropDown ID="ddMOLRecd" runat="server" CssClass="small-input" />
        
        <label>MTO Inspection Certificate Received:</label>
        <uc2:TrueFalseDropDown ID="ddMTOCertRecd" runat="server" CssClass="small-input" />
        
        <label>Trucks Calibrated:</label>
        <uc1:DateDropDown ID="dddTrucksCalibrated" runat="server" />
            
        <label>Form 1000 Required</label>
        <uc2:TrueFalseDropDown ID="ddForm1000Req" runat="server" CssClass="small-input" />
            
        <label>Form 1000 Received</label>
        <uc2:TrueFalseDropDown ID="ddForm1000Rec" runat="server" CssClass="small-input" />

        <label>Other Requirements:</label>
        <asp:TextBox ID="txtOtherReq" runat="server" CssClass="text-input small-input" MaxLength="255"  />
            
        <label>10% Holdback</label>
        <uc2:TrueFalseDropDown ID="ddTenPerHoldback" runat="server" CssClass="small-input" />
    </asp:PlaceHolder>
            
        <asp:PlaceHolder ID="phCRC" runat="server" Visible="false">
            <h3>Criminal Reference Check</h3>
            <label>CRC Filed With:</label>
            <asp:TextBox ID="txtCRCFiledWith" runat="server" CssClass="text-input small-input" MaxLength="50" />
            
            <uc5:DivisionDD ID="ddDivision" runat="server" />
        </asp:PlaceHolder>
    </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddTypeOfAgreement" />
        <asp:AsyncPostBackTrigger ControlID="chkTypeSecurity" />
    </Triggers>
    </asp:UpdatePanel>
    <asp:Button ID="btnSubmit" runat="server" Text="Save Agreement" 
        CssClass="button" onclick="btnSubmit_Click" />

</asp:Content>
