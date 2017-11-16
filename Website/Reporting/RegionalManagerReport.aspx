<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RegionalManagerReport.aspx.cs" Inherits="Reporting_RegionalManagerReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 class="page-content">Regional Managers</h1>

    <div class="row">
        <div class="col-md-12">
            <%-- PlaceHolder my ReportViewer control --%>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                <LocalReport ReportPath="Reporting\RegionalManagerReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource Name="RegionalManagerDataSet" DataSourceId="RegionalManagerDataSource"></rsweb:ReportDataSource>
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="RegionalManagerDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetRegionalManagers" TypeName="NorthwindTraders.BLL.SalesController">

            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>

