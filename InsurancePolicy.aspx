<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsurancePolicy.aspx.cs" Inherits="Qualified_Contractor_Tracking.AddInsurancePolicy1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">Insurance Policies</asp:Content>
<asp:Content ID="TitleContent" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:Literal ID="ltTitle" runat="server" Text="Insurance Policies"></asp:Literal>
</asp:Content>
<asp:Content ID="SubtitleContent" ContentPlaceHolderID="ContentBoxHeader" runat="server">
    <asp:Literal ID="ltSubTitle" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnCancel" runat="server" Icon="~/resources/images/icons/back.png" AltText="Back" Text="Back to Contractor"  />
    <uc3:NavButton ID="btnDelete" runat="server" Icon="~/resources/images/icons/delete.png" AltText="Delete Insurance Policy" Text="Delete this policy" Visible="false"/>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <uc4:Notification ID="notIns" runat="server" Visible="false" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="pnDelete" runat="server" Visible="false">
            Are you sure you want to delete this policy?<br /><br />
        <ul class="shortcut-buttons-set">
        <li>
        <asp:LinkButton ID="lnkCancelDelete" runat="server" CssClass="shortcut-button" 
                onclick="lnkCancelDelete_Click">
            <span><img alt="Cancel" src="/resources/images/icons/back.png" />
		    <br />
		    No, back to policy details
        </span></asp:LinkButton>    
        </li>
        <li>
        <asp:LinkButton ID="lnkConfirmDelete" runat="server" CssClass="shortcut-button" onclick="lnkConfirmDelete_Click">
            <span><img alt="Cancel" src="/resources/images/icons/delete.png" />
		    <br />
		    Yes, delete this policy.
        </span></asp:LinkButton></li>
        </ul>
        <div class="clear"></div>
        </asp:Panel>
        
        <asp:Panel ID="pnDetails" runat="server">
            <label>Certificate Requested For</label>
            <asp:TextBox ID="txtCertReq" runat="server" CssClass="text-input small-input" MaxLength="255" />

            <label>Type of Policy</label>
                <asp:DropDownList ID="ddTypeOfPolicy" runat="server" CssClass="small-input ddTypeOfPolicy" AppendDataBoundItems="true">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                </asp:DropDownList>

            <asp:Label ID="lblTenantsLiability" runat="server" AssociatedControlID="ddTenantsLiability">Tenants Legal Liability</asp:Label>
            <uc2:TrueFalseDropDown ID="ddTenantsLiability" runat="server" CssClass="small-input" />
                
            <label>Per Occurance</label>
            <uc2:TrueFalseDropDown ID="ddPerOccurance" runat="server" CssClass="small-input" />
                        
            <div class="CGLDetails hidden">
                <label>Products/Completed Operations</label>
                <uc2:TrueFalseDropDown ID="ddProductsCompletedOps" runat="server" CssClass="small-input" />
            
                <label>Non-Owned Auto</label>
                <uc2:TrueFalseDropDown ID="ddNonOwnedAuto" runat="server" CssClass="small-input" />
            
                <label>Cross Liability</label>
                <uc2:TrueFalseDropDown ID="ddCrossLiability" runat="server" CssClass="small-input" />
            
                <label>Norfolk County as Additional Insured</label>
                <uc2:TrueFalseDropDown ID="ddNCasAddIns" runat="server" CssClass="small-input" />
            </div>
            
            <label>Policy Number</label>
                <asp:TextBox ID="txtPolicyNumber" runat="server" CssClass="text-input small-input" MaxLength="50" />
            
            <label>Policy Limit</label>
                <asp:DropDownList ID="ddPolicyLimit" runat="server" AppendDataBoundItems="true" CssClass="ddPolicyLimit">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtPolicyLimitOther" runat="server"  CssClass="text-input small-input hidden txtPolicyLimitOther" MaxLength="10" />
            
            <label>Expiry Date</label>
                <uc1:DateDropDown ID="dddExpiryDate" runat="server" />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <label>Insurance Company</label>
                    <asp:DropDownList ID="ddInsuranceCompanies" runat="server" CssClass="small-input" AppendDataBoundItems="true" AutoPostBack="True" onselectedindexchanged="ddInsuranceCompanies_SelectedIndexChanged">
                        <asp:ListItem Value="">--Select--</asp:ListItem>
                    </asp:DropDownList>
            
                    <span class="newIns hidden">
                        <asp:Label ID="lblNewInsuranceCompanyName" runat="server" Text="Name: " AssociatedControlID="txtNewInsuranceCompanyName" CssClass="inline"></asp:Label>
                        <asp:TextBox ID="txtNewInsuranceCompanyName" runat="server" CssClass="text-input small-input" ClientIDMode="Static"></asp:TextBox>
                        <asp:Label ID="lblNewInsComEmail" runat="server" Text="Email: " AssociatedControlID="txtNewInsComEmail" CssClass="inline"></asp:Label>
                        <asp:TextBox ID="txtNewInsComEmail" runat="server" CssClass="text-input small-input" ClientIDMode="Static"></asp:TextBox>
                        <asp:Button ID="btnSubmitNewIns" runat="server" Text="Add!" CssClass="button addButton hidden" onclick="btnSubmitNewIns_Click" />
                        <asp:Button ID="btnEditIns" runat="server" Text="Save!" CssClass="button editButton hidden" onclick="btnEditIns_Click"/>
                        <asp:HiddenField ID="hdnInsName" runat="server" ClientIDMode="Static" /><asp:HiddenField ID="hdnInsEmail" runat="server" ClientIDMode="Static" />
                    </span>
                    <a class="button editInsuranceButton" id="lnkEditIns" runat="server" visible="false">Edit</a>
                    <a class="newInsuranceCompanyLink button">Add New</a>

                    <label>Insurance Email</label>
                        <asp:TextBox ID="txtInsEmail" runat="server" CssClass="text-input small-input" MaxLength="100" Enabled="false"></asp:TextBox>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddInsuranceCompanies" />

                
                </Triggers>
            </asp:UpdatePanel>

            
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <label>Broker</label>
                    <asp:DropDownList ID="ddBroker" runat="server" CssClass="small-input" 
                            AppendDataBoundItems="true" AutoPostBack="True" 
                            onselectedindexchanged="ddBroker_SelectedIndexChanged" >
                        <asp:ListItem Value="">--Select--</asp:ListItem>
                    </asp:DropDownList>

                    <label>Broker Email</label>
                        <asp:DropDownList ID="ddBrokerEmail" runat="server" CssClass="small-input" AppendDataBoundItems="true">
                            <asp:ListItem Value="">--Select--</asp:ListItem>
                        </asp:DropDownList>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddBroker" />
                </Triggers>
            </asp:UpdatePanel>

            <label>Certificate Signed</label>
                <uc2:TrueFalseDropDown ID="ddCertSigned" runat="server" CssClass="small-input" />

            <asp:Label ID="lblActive" runat="server" AssociatedControlID="ddActive">Active</asp:Label>
            <uc2:TrueFalseDropDown ID="ddActive" runat="server" CssClass="small-input" />

            
            <label>Attach Certificate</label>
                <asp:HyperLink ID="lnkFiles" runat="server"></asp:HyperLink>
            </asp:Panel>

    <asp:PlaceHolder ID="phFiles" runat="server"></asp:PlaceHolder>
    <telerik:radupload ID="uploadCert" runat="server" MaxFileInputsCount="1" ControlObjectsVisibility="none" EnableFileInputSkinning="false"></telerik:RadUpload>
    <asp:Button ID="btnSubmit" runat="server" Text="Save Insurance Policy" CssClass="button" onclick="btnSubmit_Click" />
    

</asp:Content>
