<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavButton.ascx.cs" Inherits="Qualified_Contractor_Tracking.NavButton" %>
<li>
<asp:HyperLink ID="lnkLink" runat="server" CssClass="shortcut-button">
    <span><asp:Image ID="imgIcon" runat="server" AlternateText="" ImageUrl="" />
		<br />
		<asp:Literal ID="ltText" runat="server"></asp:Literal>
</span></asp:HyperLink>
</li>