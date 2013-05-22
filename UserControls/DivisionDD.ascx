<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DivisionDD.ascx.cs" Inherits="Qualified_Contractor_Tracking.DivisionDD" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<label>Department</label>
<asp:DropDownList ID="ddDept" runat="server" AppendDataBoundItems="true" CssClass="small-input">
    <asp:ListItem Value="">--Select--</asp:ListItem>
</asp:DropDownList>
<label>Division</label>
<asp:DropDownList ID="ddDiv" runat="server" AppendDataBoundItems="true" CssClass="small-input">
    <asp:ListItem Value="">--Select--</asp:ListItem>
</asp:DropDownList>
    <asp:CascadingDropDown ID="ccd1" runat="server" ServiceMethod="GetDepartments" TargetControlID="ddDept" Category="Departments" ServicePath="~/DivisionDropDownService.asmx" />
    <asp:CascadingDropDown ID="ccd2" runat="server" ServiceMethod="GetDivisions" TargetControlID="ddDiv" ParentControlID="ddDept" Category="Divisions" ServicePath="~/DivisionDropDownService.asmx" EmptyText="Select a Department" />
</ContentTemplate>
</asp:UpdatePanel>