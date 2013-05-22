<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateBrokers.aspx.cs" Inherits="Qualified_Contractor_Tracking.tools.UpdateBrokers" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Brokers | Qualified Contractors Database</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticUpdates="True" 
            AllowMultiRowEdit="True" DataSourceID="LinqDataSource1" 
            GridLines="None"
            onitemdatabound="RadGrid1_ItemDataBound" onprerender="RadGrid1_PreRender" 
            onitemupdated="RadGrid1_ItemUpdated" onsortcommand="RadGrid1_SortCommand">
    <MasterTableView allowsorting="True" 
                autogeneratecolumns="False" datasourceid="LinqDataSource1"
                EditMode="InPlace" CommandItemDisplay="TopAndBottom" DataKeyNames="ID">
<CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
    <telerik:GridEditCommandColumn UniqueName="EditCommandColumn" />
        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" 
            FilterControlAltText="Filter ID column" HeaderText="ID" SortExpression="ID" ReadOnly="true"
            UniqueName="ID"  Visible="false">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="BrokerName" 
            FilterControlAltText="Filter BrokerName column" HeaderText="BrokerName" 
            UniqueName="BrokerName" AllowSorting="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="BrokerAddress" 
            FilterControlAltText="Filter BrokerAddress column" HeaderText="BrokerAddress" 
            SortExpression="BrokerAddress" UniqueName="BrokerAddress"  AllowSorting="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="BrokerEmail" 
            FilterControlAltText="Filter BrokerEmail column" HeaderText="BrokerEmail" 
            SortExpression="BrokerEmail" UniqueName="BrokerEmail"  AllowSorting="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Company" 
            FilterControlAltText="Filter Company column" HeaderText="Company" 
            SortExpression="Company" UniqueName="Company" ReadOnly="true"  AllowSorting="False">
        </telerik:GridBoundColumn>
        <telerik:GridDropDownColumn FilterControlAltText="Filter column column" DataSourceID="dsInsType"
         DataField="TypeOfPolicy" ListTextField="Type" ListValueField="ID" UniqueName="TypeID" 
            HeaderText="Type" DropDownControlType="DropDownList"  AllowSorting="False">
        </telerik:GridDropDownColumn>
        <telerik:GridDateTimeColumn DataField="ExpiryDate" DataType="System.DateTime" 
            UniqueName="column" HeaderText="Expiry Date">
        </telerik:GridDateTimeColumn>
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
            EnableUpdate="True" EntityTypeName="" OrderBy="BrokerName, BrokerAddress" 
            TableName="ReportBrokerInfos">
        </asp:LinqDataSource>
    

        <asp:LinqDataSource ID="dsInsType" runat="server" 
            ContextTypeName="Qualified_Contractor_Tracking.tools.CLinqDataContext" 
            EntityTypeName="" OrderBy="Type" Select="new (ID, Type)" 
            TableName="lookupTypeOfPolicies" Where="Active == @Active">
            <WhereParameters>
                <asp:Parameter DefaultValue="true" Name="Active" Type="Boolean" />
            </WhereParameters>
        </asp:LinqDataSource>
    

        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        </telerik:RadWindowManager>
    

    </div>
    </form>
</body>
</html>
