<%@ Page Title="Expiring Insurance Policies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExpiringInsurancePolicies.aspx.cs" Inherits="Qualified_Contractor_Tracking.ExpiringInsurancePolicies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">Expiring Insurance Policies</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
<script type="text/javascript" src="/resources/scripts/expiring.contracts.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">Expiring Insurance Policies</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageIntro" runat="server"></asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Buttons" runat="server"></asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentBoxHeader" runat="server">Expiring Insurance Policies</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Tabs" runat="server"></asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="rptExpIns" runat="server">
    <HeaderTemplate>
        <table class="expiring-insurance-table" summary="A list of insurance policies expiring soon">
            <caption>Insurance policies set to expire within 45 days</caption>
            <thead>
                <tr>
                    <th></th>
                    <th scope="col">Company</th>
                    <th scope="col">Type</th>
                    <th scope="col">Expiry</th>
                    <th scope="col">Required For</th>
                    <th scope="col">Actions</th>
                </tr>
            </thead>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="summary" data-companyID='<%# Eval("cID") %>' data-brokerEmailID='<%# Eval("BrokerEmailID") %>' data-similarRecords='<%# Eval("Count") %>'>
            <td><asp:CheckBox ID="chkBox" runat="server" /></td>
            <th scope="row">
                <asp:HyperLink ID="lnkContractor" CssClass="company" runat="server" Text='<%# Eval("Company") %>' NavigateUrl='<%# String.Format("ViewContractor.aspx?ID={0}",Eval("cID")) %>'></asp:HyperLink></th>
            <td>
                <asp:Literal ID="ltType" runat="server" Text='<%# Eval("Type") %>'></asp:Literal></td>
            <td>
                <asp:Literal ID="ltExpiry" runat="server" Text='<%# Eval("ExpiryDate","{0:MMMM d, yyyy}") %>'></asp:Literal></td>
            <td>
                <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("CertReqFor") %>'></asp:Literal></td>
            <td>
                <a class="button show-details" href="#">Details</a></td>
        </tr>
        <tr class="details hidden" >
            <td colspan="4">
                <div class="column-left">
                    <label class="inline">Insurance Company:</label> <asp:Label ID="lblInsCompany" runat="server" Text='<%# Eval("Name") %>'></asp:Label><br />
                    <label class="inline">Insurance Company Email:</label> <asp:HyperLink ID="lnkInsCompEmail" runat="server" Text='<%# Eval("InsuranceCompanyEmail") %>' NavigateUrl='<%# String.Format("mailto:{0}",Eval("InsuranceCompanyEmail")) %>'> </asp:HyperLink>
                </div>
                <label class="inline">Insurance Broker:</label> <asp:Label ID="lblInsBroker" runat="server" Text='<%# Eval("InsuranceBroker") %>'></asp:Label><br />
                <label class="inline">Insurance Broker Email:</label> <asp:HyperLink ID="lnkInsBrokerEmail" CssClass="broker-email" runat="server" Text='<%# Eval("InsuranceBrokerEmail") %>' NavigateUrl='<%# String.Format("mailto:{0}",Eval("InsuranceBrokerEmail")) %>'> </asp:HyperLink>
                
            </td>
            <td colspan="2">
                <p class="hidden">This has multiple entries.</p>
                <a class="button create-email" href="#">Send Email</a>
                <a class="button create-multiple-email hidden" href="#">Send Multiple Emails</a>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
    </asp:Repeater>
</asp:Content>
