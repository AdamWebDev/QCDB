<%@ Page Title="" Language="C#" MasterPageFile="~/SubPage.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Qualified_Contractor_Tracking.InsurancePolicies.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    View Insurance Policy
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="h2">Insurance Policy for <asp:Literal ID="ltContractorName" runat="server"></asp:Literal></h2>
    
    <ul>
    
    <li><label class="inline">Certificate Requested For: </label>
    <asp:Label ID="lblCertReq" runat="server"></asp:Label></li>

    <li><label class="inline">Type of Policy:</label>
    <asp:Label ID="lblTypeOfPolicy" runat="server"></asp:Label></li>

    <li><label class="inline">Tenants Legal Liability:</label>
    <asp:Label ID="lblTenantsLegalLiability" runat="server"></asp:Label></li>

    <li><label class="inline">Per Occurance:</label>
    <asp:Label ID="lblPerOccurance" runat="server"></asp:Label></li>

    <li><label class="inline">Products/Complteted Operations:</label>
    <asp:Label ID="lblProductsCompletedOps" runat="server"></asp:Label></li>

    <li><label class="inline">Non-Owned Auto:</label>
    <asp:Label ID="lblNonOwnedAuto" runat="server"></asp:Label></li>

    <li><label class="inline">Cross Liability:</label>
    <asp:Label ID="lblCrossLiability" runat="server"></asp:Label></li>

    <li><label class="inline">Norfolk County as Additional Insured:</label>
    <asp:Label ID="lblNorCountAddIns" runat="server"></asp:Label></li>

    <li><label class="inline">Policy Number:</label>
    <asp:Label ID="lblPolicyNumber" runat="server"></asp:Label></li>

    <li><label class="inline">Policy Limit:</label>
    <asp:Label ID="lblPolicyLimit" runat="server"></asp:Label></li>

    <li><label class="inline">Expiry Date:</label>
    <asp:Label ID="lblExpiryDate" runat="server"></asp:Label></li>

    <li><label class="inline">Insurance Company:</label>
    <asp:Label ID="lblInsComp" runat="server"></asp:Label> - <asp:Label ID="lblInsEmail" runat="server"></asp:Label></li>

    <li><label class="inline">Broker:</label>
    <asp:Label ID="lblBroker" runat="server"></asp:Label> - <asp:Label ID="lblBrokerEmail" runat="server"></asp:Label></li>

    <li><label class="inline">Certificate Signed:</label>
    <asp:Label ID="lblCertSigned" runat="server"></asp:Label></li>

    <li><label class="inline">Active:</label>
    <asp:Label ID="lblActive" runat="server"></asp:Label></li>

    <li><label class="inline">View Certificate:</label>
    <asp:HyperLink ID="lnkFiles" runat="server" Text="No certificate attached"></asp:HyperLink></li>
    
    </ul>

    

</asp:Content>
