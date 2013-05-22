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

    <asp:Label ID="lblCertReq" runat="server" Text="Certificate Requested For" AssociatedControlID="txtCertReq" />
    <asp:TextBox ID="txtCertReq" runat="server" CssClass="text-input small-input" MaxLength="255" />

    <asp:Label ID="lblTypeOfPolicy" runat="server" Text="Type of Policy" AssociatedControlID="ddTypeOfPolicy" />
    <asp:DropDownList ID="ddTypeOfPolicy" runat="server" CssClass="small-input ddTypeOfPolicy" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select--</asp:ListItem>
    </asp:DropDownList>

    <asp:Label ID="lblTenantsLiability" runat="server" Text="Tenants Legal Liability" AssociatedControlID="ddTenantsLiability" />
    <uc2:TrueFalseDropDown ID="ddTenantsLiability" runat="server" CssClass="small-input" />
                
    <asp:Label ID="lblPerOccurance" runat="server" Text="Per Occurance" AssociatedControlID="ddPerOccurance" />
    <uc2:TrueFalseDropDown ID="ddPerOccurance" runat="server" CssClass="small-input" />
                        
    <div class="CGLDetails hidden">
        <asp:Label ID="lblProductsCompletedOps" runat="server" AssociatedControlID="ddProductsCompletedOps" Text="Products/Completed Operations" />
        <uc2:TrueFalseDropDown ID="ddProductsCompletedOps" runat="server" CssClass="small-input" />
            
        <asp:Label ID="lblddNonOwnedAuto" runat="server" Text="Non-Owned Auto" AssociatedControlID="ddNonOwnedAuto" />
        <uc2:TrueFalseDropDown ID="ddNonOwnedAuto" runat="server" CssClass="small-input" />
            
        <asp:Label ID="lblCrossLiability" runat="server" Text="Cross Liability" AssociatedControlID="ddCrossLiability" />
        <uc2:TrueFalseDropDown ID="ddCrossLiability" runat="server" CssClass="small-input" />
            
        <asp:Label ID="lblNCasAddIns" runat="server" Text="Norfolk County as Additional Insured" AssociatedControlID="ddNCasAddIns" />
        <uc2:TrueFalseDropDown ID="ddNCasAddIns" runat="server" CssClass="small-input" />
    </div>
            
    <asp:Label ID="lblPolicyNumber" runat="server" Text="Policy Number" AssociatedControlID="txtPolicyNumber" />
    <asp:TextBox ID="txtPolicyNumber" runat="server" CssClass="text-input small-input" MaxLength="50" />
            
    <asp:Label ID="lblPolicyLimit" runat="server" Text="Policy Limit" AssociatedControlID="ddPolicyLimit" />
    <asp:DropDownList ID="ddPolicyLimit" runat="server" AppendDataBoundItems="true" CssClass="ddPolicyLimit">
        <asp:ListItem Value="">--Select--</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="txtPolicyLimitOther" runat="server"  CssClass="text-input small-input hidden txtPolicyLimitOther" MaxLength="10" />
            
    <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date" AssociatedControlID="dddExpiryDate" />
    <uc1:DateDropDown ID="dddExpiryDate" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Label ID="lblInsuranceCompanies" runat="server" Text="Insurance Company" AssociatedControlID="ddInsuranceCompanies" />
            <asp:DropDownList ID="ddInsuranceCompanies" runat="server" CssClass="small-input" AppendDataBoundItems="true" AutoPostBack="True" onselectedindexchanged="ddInsuranceCompanies_SelectedIndexChanged">
                <asp:ListItem Value="">--Select--</asp:ListItem>
            </asp:DropDownList>
            
            <span class="newIns hidden">
                <asp:Label ID="lblNewInsuranceCompanyName" runat="server" Text="Name: " AssociatedControlID="txtNewInsuranceCompanyName" CssClass="inline" />
                <asp:TextBox ID="txtNewInsuranceCompanyName" runat="server" CssClass="text-input small-input" ClientIDMode="Static"></asp:TextBox>
                <asp:Label ID="lblNewInsComEmail" runat="server" Text="Email: " AssociatedControlID="txtNewInsComEmail" CssClass="inline" />
                <asp:TextBox ID="txtNewInsComEmail" runat="server" CssClass="text-input small-input" ClientIDMode="Static"></asp:TextBox>
                <asp:Button ID="btnSubmitNewIns" runat="server" Text="Add!" CssClass="button addButton hidden" onclick="btnSubmitNewIns_Click" />
                <asp:Button ID="btnEditIns" runat="server" Text="Save!" CssClass="button editButton hidden" onclick="btnEditIns_Click"/>
                <asp:HiddenField ID="hdnInsName" runat="server" ClientIDMode="Static" /><asp:HiddenField ID="hdnInsEmail" runat="server" ClientIDMode="Static" />
            </span>

            <a class="button editInsuranceButton" id="lnkEditIns" runat="server" visible="false">Edit</a>
            <a class="newInsuranceCompanyLink button">Add New</a>

            <asp:Label ID="lblInsEmail" runat="server" Text="Insurance Email" AssociatedControlID="txtInsEmail" />
            <asp:TextBox ID="txtInsEmail" runat="server" CssClass="text-input small-input" MaxLength="100" Enabled="false"></asp:TextBox>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddInsuranceCompanies" />
        </Triggers>
    </asp:UpdatePanel>

            
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            
            <asp:Label ID="lblBroker" runat="server" Text="Broker" AssociatedControlID="ddBroker" />
            <asp:DropDownList ID="ddBroker" runat="server" CssClass="small-input" AppendDataBoundItems="true" AutoPostBack="True" onselectedindexchanged="ddBroker_SelectedIndexChanged" >
                <asp:ListItem Value="">--Select--</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="lblBrokerEmail" runat="server" Text="Broker Email" AssociatedControlID="ddBrokerEmail" />
            <asp:DropDownList ID="ddBrokerEmail" runat="server" CssClass="small-input" AppendDataBoundItems="true">
                <asp:ListItem Value="">--Please select a broker--</asp:ListItem>
            </asp:DropDownList>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddBroker" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:Label ID="lblCertSigned" runat="server" Text="Certificate Signed" AssociatedControlID="ddCertSigned" />
    <uc2:TrueFalseDropDown ID="ddCertSigned" runat="server" CssClass="small-input" />

    <asp:Label ID="lblActive" runat="server"  Text="Active" AssociatedControlID="ddActive" />
    <uc2:TrueFalseDropDown ID="ddActive" runat="server" CssClass="small-input" />

    <asp:Label ID="lblFiles" runat="server" Text="Attach Certificate" AssociatedControlID="lnkFiles" />
    <asp:HyperLink ID="lnkFiles" runat="server"></asp:HyperLink>

    <asp:PlaceHolder ID="phFiles" runat="server"></asp:PlaceHolder>
    <telerik:radupload ID="uploadCert" runat="server" MaxFileInputsCount="1" ControlObjectsVisibility="none" EnableFileInputSkinning="false"></telerik:RadUpload>
    <asp:Button ID="btnSubmit" runat="server" Text="Save Insurance Policy" CssClass="button" onclick="btnSubmit_Click" />

</asp:Content>
