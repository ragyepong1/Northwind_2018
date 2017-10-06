<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SandBox.aspx.cs" Inherits="SandBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 class="page-header">Employees</h1>
    <div class="row">
        <asp:Repeater ID="EmployeeBioRepeater" runat="server" ItemType="NorthwindTraders.BLL.SandboxController+Bio" DataSourceID="EmployeeBioDataSource">
            <ItemTemplate>
                <div class="col-md-6">
                    <img src='data:<%# Item.MimeType.Replace(@"\",@"/") %>;base64,<%# Convert.ToBase64String(Item.Photo) %>' class="pull-left img-thumbnail" />
                    <h3><%# Item.FullName %></h3>
                    <h4><%# Item.JobTitle %>
                        <small>(Extension <%# Item.CompanyPhoneExtension %>)</small>
                    </h4>
                    <p><%# Item.Notes %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource runat="server" ID="EmployeeBioDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="EmployeeBios" TypeName="NorthwindTraders.BLL.SandboxController"></asp:ObjectDataSource>
    </div>

    <hr />

    <h1 class="page-header">Customer Order Histories</h1>
    <div class="row">
        <asp:Repeater ID="OrderHistoryRepeater" runat="server" ItemType="NorthwindTraders.BLL.SandboxController+CustomerOrderHistory" DataSourceID="OrderHistoryDataSource">
            <ItemTemplate>
                <div class="col-md-4">
                    <h3><%# Item.Company %></h3>
                    <p><%# Item.TotalCost.ToString("C") %>
                        <span runat="server" visible="<%# Item.FreightCharge.HasValue %>">
                            (<%# Item.FreightCharge.Value.ToString("C") %> freight)
                        </span>
                        &mdash; Ordered on <%# Item.OrdersDate.Value.ToShortDateString() %>
                    </p>
                    <asp:GridView ID="OrderDetailGridView" runat="server" DataSource="<%# Item.OrderItems %>"></asp:GridView>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource runat="server" ID="OrderHistoryDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllCustomerOrders" TypeName="NorthwindTraders.BLL.SandboxController"></asp:ObjectDataSource>
    </div>

    <hr />

    <asp:GridView ID="GridView1" runat="server" DataSourceID="SandboxDataSource" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"></asp:BoundField>
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName"></asp:BoundField>
            <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID"></asp:BoundField>
            <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID"></asp:BoundField>
            <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit"></asp:BoundField>
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
            <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock"></asp:BoundField>
            <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder"></asp:BoundField>
            <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel"></asp:BoundField>
            <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"></asp:CheckBoxField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource runat="server" ID="SandboxDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ClearanceItems" TypeName="NorthwindTraders.BLL.SandboxController"></asp:ObjectDataSource>


</asp:Content>

