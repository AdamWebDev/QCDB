<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InsurancePolicyEditor.ascx.cs" Inherits="Qualified_Contractor_Tracking.UserControls.InsurancePolicyEditor" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
    
    <asp:Label ID="lblCertReq" runat="server" AssociatedControlID="txtCertReq" Text="Certificate Requested For"></asp:Label>
    <asp:TextBox ID="txtCertReq" runat="server" CssClass="text-input small-input" MaxLength="255" />

    <asp:Label ID="lblTypeOfPolicy" runat="server" Text="Type of Policy" AssociatedControlID="ddTypeOfPolicy"></asp:Label>
    <asp:DropDownList ID="ddTypeOfPolicy" runat="server" CssClass="small-input ddTypeOfPolicy" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select--</asp:ListItem>
    </asp:DropDownList>

    <asp:Label ID="lblTenantsLiability" runat="server" AssociatedControlID="ddTenantsLiability" Text="Tenants Legal Liability"></asp:Label>
    <uc2:TrueFalseDropDown ID="ddTenantsLiability" runat="server" CssClass="small-input" />
                
    <asp:Label ID="lblPerOccurance" runat="server" Text="Per Occurance" AssociatedControlID="ddPerOccurance"></asp:Label>
    <uc2:TrueFalseDropDown ID="ddPerOccurance" runat="server" CssClass="small-input" />
                        
    <div class="CGLDetails hidden">
        <asp:Label ID="lblProductsCompletedOps" runat="server" Text="Products/Completed Operations" AssociatedControlID="ddProductsCompletedOps"></asp:Label>
        <uc2:TrueFalseDropDown ID="ddProductsCompletedOps" runat="server" CssClass="small-input" />
            
        <asp:Label ID="lblNonOwnedAuto" runat="server" Text="Non-Owned Auto" AssociatedControlID="ddNonOwnedAuto"></asp:Label>
        <uc2:TrueFalseDropDown ID="ddNonOwnedAuto" runat="server" CssClass="small-input" />
            
        <asp:Label ID="lblCrossLiability" runat="server" Text="Cross Liability" AssociatedControlID="ddCrossLiability"></asp:Label>
        <uc2:TrueFalseDropDown ID="ddCrossLiability" runat="server" CssClass="small-input" />
            
        <asp:Label ID="lblNCasAddIns" runat="server" Text="Norfolk County as Additional Insured" AssociatedControlID="ddNCasAddIns"></asp:Label>
        <uc2:TrueFalseDropDown ID="ddNCasAddIns" runat="server" CssClass="small-input" />
    </div>
            
    <asp:Label ID="lblPolicyNumber" runat="server" Text="Policy Number" AssociatedControlID="txtPolicyNumber"></asp:Label>
    <asp:TextBox ID="txtPolicyNumber" runat="server" CssClass="text-input small-input" MaxLength="50" />
            
    <asp:Label ID="lblPolicyLimit" runat="server" Text="Policy Limit" AssociatedControlID="ddPolicyLimit"></asp:Label>
    <asp:DropDownList ID="ddPolicyLimit" runat="server" AppendDataBoundItems="true" CssClass="ddPolicyLimit">
        <asp:ListItem Value="">--Select--</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="txtPolicyLimitOther" runat="server"  CssClass="text-input small-input hidden txtPolicyLimitOther" MaxLength="10" />
            
    <asp:Label ID="lblExpirtyDate" runat="server" Text="Expiry Date" AssociatedControlID="dddExpiryDate"></asp:Label>
    <uc1:DateDropDown ID="dddExpiryDate" runat="server" />

    <asp:UpdatePanel ID="upnlInsuranceCompany" runat="server">
        <ContentTemplate>
            <asp:Label ID="lnlInsuranceCompanies" runat="server" Text="Insurance Company" AssociatedControlID="ddInsuranceCompanies"></asp:Label>
            <asp:DropDownList ID="ddInsuranceCompanies" runat="server" CssClass="small-input ddInsuranceCompanies" AppendDataBoundItems="true" AutoPostBack="True" onselectedindexchanged="ddInsuranceCompanies_SelectedIndexChanged">
                <asp:ListItem Value="">--Select--</asp:ListItem>
            </asp:DropDownList>
            
            <span class="newIns hidden">
                <asp:Label ID="lblNewInsuranceCompanyName" runat="server" Text="Name: " AssociatedControlID="txtNewInsuranceCompanyName" CssClass="inline"></asp:Label>
                <asp:TextBox ID="txtNewInsuranceCompanyName" runat="server" CssClass="text-input small-input" ClientIDMode="Static"></asp:TextBox>
                <asp:Label ID="lblNewInsComEmail" runat="server" Text="Email: " AssociatedControlID="txtNewInsComEmail" CssClass="inline"></asp:Label>
                <asp:TextBox ID="txtNewInsComEmail" runat="server" CssClass="text-input small-input" ClientIDMode="Static"></asp:TextBox>
                <asp:Button ID="btnSubmitNewIns" runat="server" Text="Add!" CssClass="button addInsButton hidden" onclick="btnSubmitNewIns_Click" />
                <asp:Button ID="btnEditIns" runat="server" Text="Save!" CssClass="button editButton hidden" onclick="btnEditIns_Click"/>
            </span>
            <a class="button editInsuranceButton" id="lnkEditIns" runat="server" visible="false">Edit</a>
            <a class="newInsuranceCompanyLink button">Add New</a>

            <asp:Label ID="lblInsEmail" runat="server" Text="Insurance Email" AssociatedControlID="txtInsEmail"></asp:Label>
            <asp:TextBox ID="txtInsEmail" runat="server" CssClass="txtInsEmail text-input small-input" MaxLength="100" Enabled="false"></asp:TextBox>
        
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddInsuranceCompanies" />
        </Triggers>
    </asp:UpdatePanel>

            
    <asp:UpdatePanel ID="upnlInsuranceBroker" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblBroker" runat="server" Text="Broker" AssociatedControlID="ddBroker"></asp:Label>
            <asp:DropDownList ID="ddBroker" runat="server" CssClass="small-input ddBroker" AppendDataBoundItems="true" AutoPostBack="True" onselectedindexchanged="ddBroker_SelectedIndexChanged" >
                <asp:ListItem Value="">--Select--</asp:ListItem>
            </asp:DropDownList>

            <span class="newBroker hidden">
                <asp:Label ID="lblNewBrokerName" runat="server" Text="Name: " AssociatedControlID="txtNewBroker" CssClass="inline"></asp:Label>
                <asp:TextBox ID="txtNewBroker" runat="server" CssClass="text-input small-input" ClientIDMode="Static"></asp:TextBox>
                <asp:Button ID="bnSubmitNewBroker" runat="server" Text="Add!" CssClass="button addBrokerButton hidden" onclick="btnSubmitNewBroker_Click" />
                <asp:Button ID="btnEditBroker" runat="server" Text="Save!" CssClass="button saveBrokerButton hidden" onclick="btnEditBroker_Click"/>
            </span>
            <a class="button editBrokerButton" ID="lnkEditBroker" runat="server" visible="false">Edit</a>
            <a class="newBrokerLink button">Add New</a>


            <asp:Label ID="lblBrokerEmail" runat="server" Text="Broker Email" AssociatedControlID="ddBrokerEmail"></asp:Label>
            <asp:DropDownList ID="ddBrokerEmail" runat="server" CssClass="small-input ddBrokerEmail" AutoPostBack="true"
                AppendDataBoundItems="true" onselectedindexchanged="ddBrokerEmail_SelectedIndexChanged">
                <asp:ListItem Value="">--Select--</asp:ListItem>
            </asp:DropDownList>

            <span class="newBrokerEmail hidden">
                <asp:Label ID="lblNewBrokerEmail" runat="server" Text="Email: " AssociatedControlID="txtNewBrokerEmail" CssClass="inline"></asp:Label>
                <asp:TextBox ID="txtNewBrokerEmail" runat="server" CssClass="text-input small-input " ClientIDMode="Static"></asp:TextBox>
                <asp:Button ID="btnSubmitNewBrokerEmail" runat="server" Text="Add!" CssClass="button addBrokerEmailButton hidden" onclick="btnSubmitNewBrokerEmail_Click" />
                <asp:Button ID="btnEditBrokerEmail" runat="server" Text="Save!" CssClass="button saveBrokerEmailButton hidden" onclick="btnEditBrokerEmail_Click"/>
            </span>
            <a class="button editBrokerEmailButton" id="lnkEditBrokeEmail" runat="server" visible="false">Edit</a>
            <a class="newBrokerEmailLink button hidden">Add New</a>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddBroker" />
            <asp:AsyncPostBackTrigger ControlID="ddBrokerEmail" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:Label ID="lblCertSigned" runat="server" Text="Certificate Signed" AssociatedControlID="ddCertSigned"></asp:Label>
    <uc2:TrueFalseDropDown ID="ddCertSigned" runat="server" CssClass="small-input" />

    <asp:Label ID="lblActive" runat="server" AssociatedControlID="ddActive">Active</asp:Label>
    <uc2:TrueFalseDropDown ID="ddActive" runat="server" CssClass="small-input" />

    <asp:Label ID="lblFiles" runat="server" Text="Attach Certificate" AssociatedControlID="lnkFiles"></asp:Label>        
    <asp:HyperLink ID="lnkFiles" runat="server"></asp:HyperLink>

    <telerik:radupload ID="uploadCert" runat="server" MaxFileInputsCount="1" ControlObjectsVisibility="none" EnableFileInputSkinning="false" ></telerik:RadUpload>