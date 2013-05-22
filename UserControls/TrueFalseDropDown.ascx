<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrueFalseDropDown.ascx.cs" Inherits="Qualified_Contractor_Tracking.TrueFalseDropDown" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:DropDownList ID="dd" runat="server">
    <asp:ListItem Value="">--Select--</asp:ListItem>
    <asp:ListItem Value="true">Yes</asp:ListItem>
    <asp:ListItem Value="false">No</asp:ListItem>
</asp:DropDownList>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="dd" EventName="SelectedIndexChanged" />
</Triggers>
</asp:UpdatePanel>