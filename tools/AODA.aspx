<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AODA.aspx.cs" Inherits="Qualified_Contractor_Tracking.tools.AODA" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <telerik:RadGrid ID="RadGrid1" AllowAutomaticUpdates="True"  runat="server" DataSourceID="LinqDataSource1" AllowMultiRowEdit="True"
            GridLines="None" onitemdatabound="RadGrid1_ItemDataBound" onprerender="RadGrid1_PreRender" 
            onitemupdated="RadGrid1_ItemUpdated">
            <MasterTableView autogeneratecolumns="False" datasourceid="LinqDataSource1" EditMode="InPlace" datakeynames="ID" >
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridEditCommandColumn FilterControlAltText="Filter EditCommandColumn column">
                </telerik:GridEditCommandColumn>
                <telerik:GridBoundColumn DataField="ID" 
                    FilterControlAltText="Filter ID column" HeaderText="ID" 
                    SortExpression="ID" UniqueName="ID" ReadOnly="true" 
                    DataType="System.Int32" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Company" 
                    FilterControlAltText="Filter Company column" HeaderText="Company" 
                    SortExpression="Company" UniqueName="Company" ReadOnly="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MailingAddress" 
                    FilterControlAltText="Filter MailingAddress column" HeaderText="MailingAddress" 
                    SortExpression="MailingAddress" UniqueName="MailingAddress" ReadOnly="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Town" 
                    FilterControlAltText="Filter Town column" HeaderText="Town" 
                    SortExpression="Town" UniqueName="Town" ReadOnly="false">
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="AODAFormSubmit"
                    DataType="System.Boolean" FilterControlAltText="Filter AODAFormSubmit column" 
                    HeaderText="Submitted AODA Form" SortExpression="AODAFormSubmit" 
                    UniqueName="AODAFormSubmit">
                </telerik:GridCheckBoxColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False"></FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="Qualified_Contractor_Tracking.tools.CLinqDataContext" 
            EnableUpdate="True" EntityTypeName="" OrderBy="Company" TableName="ReportAODAs">
        </asp:LinqDataSource>
    
    </div>
    </form>
</body>
</html>