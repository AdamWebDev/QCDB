<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateDropDown.ascx.cs" Inherits="Qualified_Contractor_Tracking.DateDropDown" %>
<asp:DropDownList ID="ddMonth" runat="server" AppendDataBoundItems="true">
    <asp:ListItem Value="">--Month--</asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="ddDay" runat="server" AppendDataBoundItems="true">
    <asp:ListItem Value="">--Day--</asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="ddYear" runat="server" AppendDataBoundItems="true">
    <asp:ListItem Value="">--Year--</asp:ListItem>
</asp:DropDownList>