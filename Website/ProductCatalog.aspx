﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductCatalog.aspx.cs" Inherits="ProductCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 class="page-header">Product Catalog</h1>
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="CategoryRepeater" runat="server" DataSourceID="CatalogDataSource" ItemType="NorthwindTraders.Entities.DTOs.ProductCategory" >
                <ItemTemplate>
                    <div>
                        <img  src="data:image/png;base64,<%# Convert.ToBase64String(Item.Picture) %>" />
                        <h3><%# Item.Name %></h3>
                        <p><%# Item.Description %></p>
                        <blockquote>
                            <asp:Repeater ID="ProductRepeater" runat="server" DataSource="<%# Item.Products %>" ItemType="NorthwindTraders.Entities.POCOs.ProductInfo">
                                <HeaderTemplate>
                                    <table class="table table-hover table-condensed">
                                </HeaderTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <th><%# Item.Name %></th>
                                        <td><%# $"{Item.Price:C}" %></td>
                                        <td><%# Item.QuantityPerUnit %></td>
                                        <td><%# Item.InStock %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </blockquote>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <asp:ObjectDataSource ID="CatalogDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="AllProductsByCategory" TypeName="NorthwindTraders.BLL.ProductCategoryController"></asp:ObjectDataSource>

</asp:Content>

