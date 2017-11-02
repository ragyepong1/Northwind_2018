<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditShippers.aspx.cs" Inherits="Admin_CRUD_EditShippers" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron">
        <h1>Manage Shippers</h1>
        <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
    </div>
    <div class="row">
        <div class="col-md-6">
            <h2>Shippers for Northwind Traders</h2>
            <asp:ListView ID="ShippersListView" runat="server" DataSourceID="ShippersDataSource" InsertItemPosition="LastItem" DataKeyNames="ShipperID">
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFF8DC;">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("ShipperID") %>' runat="server" ID="ShipperIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("CompanyName") %>' runat="server" ID="CompanyNameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Phone") %>' runat="server" ID="PhoneLabel" /></td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #008A8C; color: #FFFFFF;">
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("ShipperID") %>' runat="server" ID="ShipperIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("CompanyName") %>' runat="server" ID="CompanyNameTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Phone") %>' runat="server" ID="PhoneTextBox" /></td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("ShipperID") %>' runat="server" ID="ShipperIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("CompanyName") %>' runat="server" ID="CompanyNameTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Phone") %>' runat="server" ID="PhoneTextBox" /></td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: #DCDCDC; color: #000000;">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("ShipperID") %>' runat="server" ID="ShipperIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("CompanyName") %>' runat="server" ID="CompanyNameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Phone") %>' runat="server" ID="PhoneLabel" /></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                    <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                        <th runat="server"></th>
                                        <th runat="server">ShipperID</th>
                                        <th runat="server">CompanyName</th>
                                        <th runat="server">Phone</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                <asp:DataPager runat="server" ID="DataPager1">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("ShipperID") %>' runat="server" ID="ShipperIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("CompanyName") %>' runat="server" ID="CompanyNameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Phone") %>' runat="server" ID="PhoneLabel" /></td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="ShippersDataSource" runat="server" DataObjectTypeName="NorthwindTraders.Entities.Shipper" DeleteMethod="RemoveShipper" InsertMethod="AddShipper" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllShippers" TypeName="NorthwindTraders.BLL.CRUD.ShipperController" UpdateMethod="UpdateShipper"
                OnUpdated="CheckForExceptions"
                OnDeleted="CheckForExceptions"
                OnInserted="CheckForExceptions"></asp:ObjectDataSource>
        </div>
        <div class="col-md-6">
            <h2>About Managing Shippers</h2>
        </div>
    </div>
</asp:Content>

