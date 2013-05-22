<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewContractor.aspx.cs" Inherits="Qualified_Contractor_Tracking.ViewContractor" %>
<asp:Content ID="Title" ContentPlaceHolderID="Title" runat="server">View Contractor</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
Qualified Contractor Database
</asp:Content>
<asp:Content ID="Buttons" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnCancel" runat="server" Icon="~/resources/images/icons/back.png" AltText="Back" Text="View All Contractors" NavURL="~/Default.aspx" />
    <uc3:NavButton ID="btnEdit" runat="server" Icon="~/resources/images/icons/page_edit.png" AltText="Edit" Text="Edit this Contractor" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBoxHeader" runat="server">
Contractor Details
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Tabs" runat="server">
<ul class="content-box-tabs">
    <li><a href="#main" class="default-tab">Main Details</a></li> <!-- href must be unique and match the id of target div -->
	<li><a href="#insurance">Insurance</a></li>
    <li><a href="#agreements">Agreements</a></li>
    <li><a href="#permits">Permits</a></li>
    <li><a href="#licences">Licences</a></li>
    <li><a href="#wsib">WSIB,AODA,H&S</a></li>
</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<div class="tab-content default-tab" id="main">
    <!-- Main Details -->
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="column-left">

            <label>Vendor Number</label>
            <span><asp:Literal ID="ltVendorNumber" runat="server" ></asp:Literal></span>
            <br /><br />
            <label>Company/Contractor</label>
            <span><asp:Literal ID="ltCompany" runat="server" ></asp:Literal></span>
            <br /><br />
            <label>Contact Name</label>
            <span><asp:Literal ID="ltContactName" runat="server" ></asp:Literal></span>
            <br /><br />
            <label>Mailing Address</label>
            <span><asp:Literal ID="ltMailingAddress" runat="server" ></asp:Literal></span>
            <br /><br />
            <label>Town</label>
            <span><asp:Literal ID="ltTown" runat="server"></asp:Literal></span>
            <br /><br />
            <label>Postal Code</label>
            <span><asp:Literal ID="ltPostalCode" runat="server" ></asp:Literal></span>
            <br /><br />
            <label>Email</label>
            <span><asp:HyperLink ID="lnkEmail" runat="server" ></asp:HyperLink></span>
            <label>Norfolk County Contact</label>
            <span><asp:Literal ID="ltNCContact" runat="server"></asp:Literal></span>
            <br /><br />

    </div>
    <div class="column-right">
    <h4>Phone Numbers</h4>
    <asp:Repeater ID="rptPhones" runat="server">
        <HeaderTemplate>
                <table>
                <thead>
                    <tr>
                        <th>Type</th>
                        <th>Number</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="ltPhoneType" runat="server" Text='<%# Eval("PhoneType") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltPhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Literal></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br /><br />
    <h4>Services Available</h4>
    <asp:Repeater ID="rptJobs" runat="server">
        <ItemTemplate>
            <span class="tag">
            <asp:Label ID="lblJob" runat="server" Text='<%# Eval("JobTitle") %>'></asp:Label>
            </span>
        </ItemTemplate>
    </asp:Repeater>
    </div>
    <div class="clear"></div>
    
</div>
<div class="tab-content" id="insurance">
    <!-- Insurance Tab -->

    <uc4:Notification ID="notExemptFromAuto" runat="server" Type="attention" Visible="false" />

    <asp:Repeater ID="rptInsurance" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Requested For</th>
                        <th>Type</th>
                        <th>Policy Number</th>
                        <th>Policy Limit</th>
                        <th>Expiry Date</th>
                        <th>More...</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="ltRequested" runat="server" Text='<%# Eval("InsurancePolicy.CertReqFor") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltType" runat="server" Text='<%# Eval("Type") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltPolicyNumber" runat="server" Text='<%# Eval("InsurancePolicy.PolicyNumber") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltPolicyLimit" runat="server" Text='<%# Eval("Value") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltExpiryDate" runat="server" Text='<%# Eval("InsurancePolicy.ExpiryDate","{0:MMMM d, yyyy}") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="lnkMore" runat="server" NavigateUrl='<%# String.Format("InsurancePolicy.aspx?ID={0}&cID={1}&mode=read",Eval("InsurancePolicy.ID"),Request.QueryString["ID"]) %>' rel="insurance" CssClass="fancybox fancybox.ajax">View Details</asp:HyperLink></td>
            </tr>                
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>


</div>
<div class="tab-content" id="agreements">
    <!-- Agreements -->
    
    <asp:Repeater ID="rptAgreements" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Type of Agreement</th>
                        <th>Description</th>
                        <th>Term Expiry Date</th>
                        <th>Extension Expiry Date</th>
                        <th>More...</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="ltType" runat="server" Text='<%# Eval("TypeOfAgreement") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltDescription" runat="server" Text='<%# Eval("Agreement.Description") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltExpiry" runat="server" Text='<%# Eval("Agreement.TermExpiryDate","{0:MMMM d, yyyy}") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltExtension" runat="server" Text='<%# Eval("Agreement.ExtensionExpiryDate","{0:MMMM d, yyyy}") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="lnkMore" runat="server" NavigateUrl='<%# String.Format("Agreements.aspx?ID={0}&cID={1}&mode=read",Eval("Agreement.ID"),Request.QueryString["ID"]) %>'  rel="agreements" CssClass="fancybox fancybox.ajax">View Details</asp:HyperLink></td>
            </tr>                
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</div>
<div class="tab-content" id="permits">
    <!-- Permits -->
    <asp:Repeater ID="rptPermits" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Type of Permit</th>
                        <th>CGL Insurance</th>
                        <th>More...</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="ltType" runat="server" Text='<%# Eval("TypeOfPermit") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltCGL" runat="server" Text='<%# Eval("CGLIns").ToString() == "True" ? "Yes":"No" %>'></asp:Literal></td>
                <td><asp:HyperLink ID="lnkMore" runat="server" NavigateUrl='<%# String.Format("Permits.aspx?ID={0}&cID={1}&mode=read",Eval("ID"),Request.QueryString["ID"]) %>'  rel="permits" CssClass="fancybox fancybox.ajax">View Details</asp:HyperLink></td>
            </tr>                
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div class="tab-content" id="licences">
    <!-- Licenses -->
    <asp:Repeater ID="rptLicenses" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Type of License</th>
                        <th>Copy Received</th>
                        <th>Filed With</th>
                        <th>Department</th>
                        <th>More...</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="ltType" runat="server" Text='<%# Eval("TypeOfLicence") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltCGL" runat="server" Text='<%# Eval("CopyReceived").ToString() == "True" ? "Yes":"No" %>'></asp:Literal></td>
                <td><asp:Literal ID="ltFiledWith" runat="server" Text='<%# Eval("LicFiledWith") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltDept" runat="server" Text='<%# Eval("Dept") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="lnkMore" runat="server" NavigateUrl='<%# String.Format("Licences.aspx?ID={0}&cID={1}&mode=read",Eval("ID"),Request.QueryString["ID"]) %>'  rel="licences" CssClass="fancybox fancybox.ajax">View Details</asp:HyperLink></td>
            </tr>                
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div class="tab-content" id="wsib">
    <!-- WSIB -->
    <h4>WSIB</h4>
    <label>WSIB Coverage:</label>
        <span><asp:Literal ID="ltWSIBCoverage" runat="server"></asp:Literal></span>
    
    <asp:PlaceHolder ID="phClearance" runat="server" Visible="false">
        <h4>WSIB Clearance Certificate (<a href="http://net3/services/contractors/Shared%20Documents/Clearance%20Certificate%20Example.pdf" target="_blank">What does this look like?</a>)</h4>
        <label>Certificate Received</label>
            <span><asp:Literal ID="ltlWSIBCert" runat="server"></asp:Literal></span>
    
        <label>Certificate Number</label>
        <span><asp:Literal ID="ltCertNum" runat="server"></asp:Literal></span>

        <label>Certificate Effective Date</label>
        <span><asp:Literal ID="ltCertEffDate" runat="server"></asp:Literal></span>
    
        <label>Certificate Expiry Date</label>
        <span><asp:Literal ID="ltCertExpDate" runat="server"></asp:Literal></span>

        <label>Certificate Descriptions</label>
        <span><asp:Literal ID="ltCertDesc" runat="server"></asp:Literal></span>
    </asp:PlaceHolder>


    <asp:PlaceHolder ID="phIndOp" runat="server" Visible="false">
        <h4>Independant Operator Letter (<a href="http://net3/services/contractors/Shared%20Documents/Independant%20Operator%20Letter.pdf" target="_blank">What Does this look like?</a>)</h4>
        <label>Independent Operator Letter Received</label>
        <span><asp:Literal ID="ltIndOp" runat="server"></asp:Literal></span>

        <label>ID Number</label>
        <span><asp:Literal ID="ltIDNum" runat="server"></asp:Literal></span>
    </asp:PlaceHolder>
    
    <asp:PlaceHolder ID="phWSIBExempt" runat="server" Visible="false">
        <h4>WSIB Exemption</h4>
        <label>Exemption Form Received</label>
        <span><asp:Literal ID="ltExemptionRecd" runat="server"></asp:Literal></span>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="phAODA" runat="server">
    <h4>A.O.D.A.</h4>
        <label>Compliance Form Submitted</label>
        <span><asp:Literal ID="ltCompSub" runat="server"></asp:Literal></span>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="phHealthSafety" runat="server">
        <h4>Health & Safety</h4>
        <label>Norfolk County's H&S Policy</label>
        <span><asp:Literal ID="ltNCHS" runat="server"></asp:Literal></span>

        <label>Contractor's H&S Policy</label>
        <span><asp:Literal ID="ltConHS" runat="server"></asp:Literal></span>
    </asp:PlaceHolder>
    <br />


</div>
</asp:Content>
