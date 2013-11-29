<%@ Page Title="Edit Contractor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditContractor.aspx.cs" Inherits="Qualified_Contractor_Tracking.EditContractor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">Qualified Contractor Database</asp:Content>
<asp:Content ID="Button" ContentPlaceHolderID="Buttons" runat="server">
    <uc3:NavButton ID="btnCancel" runat="server" Icon="~/resources/images/icons/back.png" AltText="Back" Text="Back to View Contractor" />
    <li>
    <asp:LinkButton ID="lnkConfirmDelete" runat="server" CssClass="shortcut-button" 
            OnClientClick="return confirm('Are you sure you want to delete this contractor?');" 
            onclick="lnkConfirmDelete_Click">
        <span><asp:Image ID="imgDelete" runat="server" AlternateText="Delete" ImageUrl="~/resources/images/icons/delete.png" />
		<br />
		Delete this Contractor
    </span></asp:LinkButton></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBoxHeader" runat="server">
    <asp:Literal ID="ltSubTitle" runat="server"></asp:Literal>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="tab-content default-tab" id="main">
        <asp:PlaceHolder ID="phMainContent" runat="server">
        <div class="column-left">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <uc4:Notification ID="notContract" runat="server" Visible="false" />
                <label>Company</label>
                <asp:TextBox ID="CompanyTextBox" CssClass="text-input medium-input" runat="server"  />
                <br />
                <label>Vendor Number</label>
                <asp:TextBox ID="VendorNumberTextBox" runat="server" CssClass="text-input medium-input" />
                <label>Contractor Contact Name</label>
                <asp:TextBox ID="ContactNameTextBox" runat="server" CssClass="text-input medium-input" />
                <label>Mailing Address</label>
                <asp:TextBox ID="MailingAddressTextBox" runat="server" CssClass="text-input medium-input"  />
                <label>Town</label>
                <asp:TextBox ID="TownTextBox" runat="server" CssClass="text-input medium-input"  />
                <label>PostalCode</label>
                <asp:TextBox ID="PostalCodeTextBox" runat="server"  CssClass="text-input medium-input" />
                <label>Contractor Email</label>
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="text-input medium-input"  />
                <label>Norfolk County Contact</label>
                <asp:TextBox ID="txtNCContact" runat="server" CssClass="text-input medium-input" />
                <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="UpdateButton" runat="server" Text="Save Changes" CssClass="button" OnClick="UpdateButton_Click" />
        </div>
        <div class="column-right">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <h4>Phone Numbers</h4>
                <uc4:Notification ID="notPhones" runat="server" />
                <asp:Repeater ID="rptPhones" runat="server">
                    <HeaderTemplate>
                        <table>
                            <thead>
                                <tr>
                                    <th>Type</th>
                                    <th>Number</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><asp:Literal ID="ltPhoneType" runat="server" Text='<%# Eval("PhoneType") %>'></asp:Literal></td>
                            <td><asp:Literal ID="ltPhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Literal></td>
                            <td><asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/resources/images/icons/cross.png" OnClick="imgDelete_Click" PhoneID='<%# Eval("ID") %>'  /></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
                <asp:Button ID="btnAddPhone" runat="server" CssClass="button" Text="Add Phone Number" onclick="btnAddPhone_Click" />
                <asp:DropDownList ID="ddPhoneType" runat="server" Visible="false"></asp:DropDownList>
                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="text-input small-input" Visible="false" />
                <asp:Button ID="btnSavePhone" runat="server" Text="Save Phone Number" Visible="false" CssClass="button" onclick="btnSavePhone_Click" />
                <br /><br />

                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAddPhone" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <h4>Services Available</h4>
                    <asp:Repeater ID="rptJobs" runat="server">
                        <ItemTemplate>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <span class="tag">
                            <asp:Label ID="lblJob" runat="server" Text='<%# Eval("JobTitle") %>'></asp:Label>
                                <asp:LinkButton ID="lnkRemoveJob" runat="server" ItemID='<%# Eval("Job.ID") %>' OnClick="lnkRemoveJob_Click">x</asp:LinkButton>
                            </span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:TextBox ID="txtJobs" runat="server" CssClass="text-input large-input" MaxLength="255" AutoComplete="off"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="txtJobsAutoComplete" runat="server" TargetControlID="txtJobs" ServicePath="~/AutoSuggestWebService.asmx" ServiceMethod="GetTags" MinimumPrefixLength="1" CompletionListCssClass="CompletionList" CompletionListItemCssClass="CompletionListItem" CompletionListHighlightedItemCssClass="CompletionListHightlightedItem" CompletionInterval="200">
                    </ajaxToolkit:AutoCompleteExtender>
                    <asp:Button ID="btnSaveJobs" runat="server" Text="Add Job" CssClass="button" OnClick="btnSaveJobs_Click" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSaveJobs" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanelNotes" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <h4>Contactor Notes</h4>
                    <asp:TextBox ID="txtContratorNotes" runat="server" TextMode="MultiLine" Rows="6" ></asp:TextBox>
                    <asp:Button ID="btnSaveNotes" runat="server" Text="Save Notes" CssClass="button" OnClick="btnSaveNotes_Click"/> <asp:Label ID="lblNotesSaved" runat="server" Text="Saved!" Visible="false"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSaveNotes" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            
        </div>
        <div class="clear"></div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phDeleteSummary" runat="server"></asp:PlaceHolder>
</div>
<div class="tab-content" id="insurance">
    <!-- Insurance Tab -->
    <div class="tab-header">
        <uc4:Notification ID="notInsurance" runat="server" />

        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblExemptFromAuto" runat="server" AssociatedControlID="ddExemptFromAuto" CssClass="inline" Text="Is this contractor exempt from auto?"  />
                <uc2:TrueFalseDropDown ID="ddExemptFromAuto" runat="server" OnSelectedIndexChanged="ddExemptFromAuto_SelectedIndexChanged" AutoPostBack="true" />
                <asp:PlaceHolder ID="phExemptFromAutoComments" runat="server" Visible="false">
                    <asp:Label ID="lblExemptFromAutoComments" runat="server" AssociatedControlID="txtExemptFromAutoComments" CssClass="inline" Text="Description:"  />&nbsp;
                    <asp:TextBox ID="txtExemptFromAutoComments" runat="server" CssClass="text-input medium-input" />
                </asp:PlaceHolder>
                <asp:Button ID="btnSaveAutoExemption" runat="server" CssClass="button"  Text="Save" onclick="btnSaveAutoExemption_Click" />
                <uc4:Notification ID="notSaveExemption" runat="server" Type="success" Message="Saved!" Visible="false" />
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

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
                <td><asp:HyperLink ID="lnkMore" runat="server" NavigateUrl='<%# String.Format("InsurancePolicies/Edit.aspx?ID={0}&cID={1}",Eval("InsurancePolicy.ID"), Eval("InsurancePolicy.cID")) %>'>View/Edit Details</asp:HyperLink></td>
            </tr>                
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:HyperLink ID="lnkNewInsurance" runat="server" CssClass="button">Add New Insurance Policy</asp:HyperLink>

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
                <td><asp:Literal ID="ltEffective" runat="server" Text='<%# Eval("Agreement.Description","{0:MMMM d, yyyy}") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltExpiry" runat="server" Text='<%# Eval("Agreement.TermExpiryDate","{0:MMMM d, yyyy}") %>'></asp:Literal></td>
                <td><asp:Literal ID="ltExtension" runat="server" Text='<%# Eval("Agreement.ExtensionExpiryDate","{0:MMMM d, yyyy}") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="lnkMore" runat="server" NavigateUrl='<%# String.Format("Agreements.aspx?ID={0}&cID={1}&mode=edit",Eval("Agreement.ID"),Request.QueryString["ID"]) %>'>View/Edit Details</asp:HyperLink></td>
            </tr>                
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:HyperLink ID="lnkNewAgreemnt" runat="server" CssClass="button" >Add New Agreement</asp:HyperLink>
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
                <td><asp:HyperLink ID="lnkMore" runat="server" NavigateUrl='<%# String.Format("Permits.aspx?ID={0}&cID={1}&mode=edit",Eval("ID"),Request.QueryString["ID"]) %>'>View/Edit Details</asp:HyperLink></td>
            </tr>                
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />  
    <asp:HyperLink ID="lnkNewPermit" runat="server" CssClass="button" >Add New Permit</asp:HyperLink>
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
                        <th>Division</th>
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
                <td><asp:HyperLink ID="lnkMore" runat="server" NavigateUrl='<%# String.Format("Licences.aspx?ID={0}&cID={1}&mode=edit",Eval("ID"),Request.QueryString["ID"]) %>'>View/Edit Details</asp:HyperLink></td>
            </tr>                
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
            <br />
        <asp:HyperLink ID="lnkNewLicence" runat="server" CssClass="button" >Add New Licence</asp:HyperLink>
</div>
<div class="tab-content" id="wsib">
    <!-- WSIB -->
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <uc4:Notification ID="notWSIB" runat="server" Visible="false" />
    <h4>WSIB</h4>
    <label>WSIB Coverage:</label>
    <asp:DropDownList ID="ddWSIBCoverage" runat="server" AppendDataBoundItems="true" onselectedindexchanged="ddWSIBCoverage_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="">--Select--</asp:ListItem>
    </asp:DropDownList>
    
    <asp:PlaceHolder ID="phClearance" runat="server" Visible="false">
        <h4>WSIB Clearance Certificate (<a href="http://net3/services/contractors/Shared%20Documents/Clearance%20Certificate%20Example.pdf" target="_blank">What does this look like?</a>)</h4>
        <label>Certificate Received</label>
        <uc2:TrueFalseDropDown ID="ddCertRecd" CssClass="small-input" runat="server" />
    
    </asp:PlaceHolder>


    <asp:PlaceHolder ID="phIndOp" runat="server" Visible="false">
        <h4>Independant Operator Letter (<a href="http://net3/services/contractors/Shared%20Documents/Independant%20Operator%20Letter.pdf" target="_blank">What Does this look like?</a>)</h4>
        <label>Independent Operator Letter Received</label>
        <uc2:TrueFalseDropDown ID="ddIndOpLetter" CssClass="small-input" runat="server" />

        <label>ID Number</label>
        <asp:TextBox runat="server" ID="txtIDNum" CssClass="text-input small-input"></asp:TextBox>
    </asp:PlaceHolder>
    
    <asp:PlaceHolder ID="phWSIBExempt" runat="server" Visible="false">
        <h4>WSIB Exemption</h4>
        <label>Exemption Form Received</label>
        <uc2:TrueFalseDropDown ID="ddWSIBExempt" CssClass="small-input" runat="server" />
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="phAODA" runat="server">
    <h4>A.O.D.A.</h4>
        <label>Customer Service Compliance Form Submitted</label>
        <uc2:TrueFalseDropDown ID="ddAODASubmitted" CssClass="small-input" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddAODASubmitted_SelectedIndexChanged" />
        <uc4:Notification ID="notAODA" runat="server" Type="attention" Message="Please note that contractors MUST have their AODA Compliance Form submitted before they can be used. There are no exceptions." Visible="false" />

        <label>Integrated Accessibility Standards Compliance Form Submitted</label>
        <uc2:TrueFalseDropDown ID="ddAODAStandardsCompliance" CssClass="small-input" runat="server" />
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="phHealthSafety" runat="server">
        <h4>Health & Safety</h4>
        <label>Norfolk County's H&S Policy Form Required</label>
        <uc2:TrueFalseDropDown ID="ddNCHSReqd" CssClass="small-input" runat="server" OnSelectedIndexChanged="ddNCHS_SelectedIndexChanged" AutoPostBack="true" />

        <asp:PlaceHolder ID="phNCHSPolicyRecd" runat="server" Visible="false">
            <label>Norfolk County's H&S Policy Form Received</label>
            <uc2:TrueFalseDropDown ID="ddNCHSReceived" CssClass="small-input" runat="server" />
        </asp:PlaceHolder>

        <label>Ministry of Labour Form 100 Received</label>
        <asp:DropDownList ID="ddMoL100" runat="server" CssClass="small-input">
            <asp:ListItem Value="">--Select--</asp:ListItem>
            <asp:ListItem Value="No">No</asp:ListItem>
            <asp:ListItem Value="Yes">Yes</asp:ListItem>
            <asp:ListItem Value="N/A">N/A</asp:ListItem>
        </asp:DropDownList>

        <label>Contractor's H&S Policy</label>
        <asp:DropDownList ID="ddContHS" runat="server" AppendDataBoundItems="true" CssClass="small-input">
            <asp:ListItem Value="">--Select--</asp:ListItem>
            <asp:ListItem Value="No">No</asp:ListItem>
            <asp:ListItem Value="Yes">Yes</asp:ListItem>
            <asp:ListItem Value="N/A">N/A</asp:ListItem>
        </asp:DropDownList>
    </asp:PlaceHolder>
    <br />
    <asp:Button ID="btnSaveWSIB" runat="server" Text="Save" CssClass="button" onclick="btnSaveWSIB_Click" />

    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddWSIBCoverage" />
        <asp:AsyncPostBackTrigger ControlID="ddNCHSReqd" />
        <asp:AsyncPostBackTrigger ControlID="ddAODASubmitted" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>

    

</div>
</asp:Content>