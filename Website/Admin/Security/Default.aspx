<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Security_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row jumbotron">
        <h1>Site Administration</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- Nav tabs via Bootstrap -->
            <ul class="nav nav-tabs">
                <li class="active"><a href="#users" data-toggle="tab">Users</a></li>
                <li><a href="#roles" data-toggle="tab">Security Roles</a></li>
                <li><a href="#unregistered" data-toggle="tab">Unassigned Users</a></li>
            </ul>
            <div class="tab-content">
                <div id="users" class="tab-pane fade in active">
                    <blockquote>Registered Users in the Site</blockquote>
                    <asp:ListView ID="UsersListView" runat="server" DataSourceID="UsersDataSource" ItemType="NorthwindTraders.Security.Entities.UserProfile">
                        <LayoutTemplate>
                            <div class="row bg-info">
                                <div class="col-sm-3 h4">Action</div>
                                <div class="col-sm-3 h4">User</div>
                                <div class="col-sm-6 h4">Profile</div>
                            </div>
                            <div runat="server" id="itemPlaceholder"></div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-sm-3">TODO</div>
                                <div class="col-sm-3">
                                    <%# Item.UserName %>
                                    <br />
                                    <%# Item.FullName %>
                                </div>
                                <div class="col-sm-6">
                                    Email: <%# Item.EmailService %>
                                    <asp:CheckBox ID="IsConfirmed" runat="server" Enabled="false" Checked="<%# Item.EmailConfirmed %>" Text="Confirmed" />
                                    <br />
                                    <%# Item.EmployeeId.HasValue ? "Employee" : !string.IsNullOrEmpty(Item.CustomerId) ? "Customer" : "-unassigned-" %>
                                    <br />
                                    <label>Security Roles: </label>
                                    <%# string.Join(", ", Item.RoleMemberships) %>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:ObjectDataSource runat="server" ID="UsersDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllUsers" TypeName="Website.UserManager"></asp:ObjectDataSource>
                </div>

                <div id="roles" class="tab-pane fade in">
                    <blockquote>Security Roles for the Site</blockquote>
                    <%--<asp:ListView ID="SecurityRolesListView" runat="server" DataSourceID="RolesDataSource" ItemType="NorthwindTraders.Security.BLL.RoleManager">
                        <LayoutTemplate>
                            <div class="row bg-info">
                                <div class="col-sm-12 h4">Roles</div>
                            </div>
                            <div runat="server" id="itemPlaceholder"></div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-sm-12">
                                    
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:ObjectDataSource runat="server" ID="RolesDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllSecurityRoles" TypeName="NorthwindTraders.Security.BLL.RoleManager"></asp:ObjectDataSource>--%>
                </div>

                <div id="unregistered" class="tab-pane fade in">
                    <blockquote>Users who are not assigned to security roles</blockquote>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
