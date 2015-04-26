<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerFeatures/ManagerFeatures.master" AutoEventWireup="true" CodeBehind="ManagerDistributionCentreStock.aspx.cs" Inherits="ENETCare.Presentation.ManagerFeatures.ManagerDistributionCentreStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificManagerFeatureMainContent" runat="server">

    <!--panel-start-->
    <div class="panel panel-default">

        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title"
                runat="server">
                <asp:Literal ID="HeadingLiteral"
                    runat="server"
                    OnDataBinding="Page_Load">
                </asp:Literal>
                Stock
            </h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <asp:GridView ID="DistributionCentreStockView"
                runat="server"
                AutoGenerateColumns="False"
                DataSourceID="CentreStockSource"
                CssClass="table  table-hover table-bordered table-striped"
                AllowPaging="True" 
                OnDataBound="DistributionCentreStockView_DataBound">
                <Columns>
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                    <asp:BoundField DataField="Value" HeaderText="Value ($)" SortExpression="Value"></asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    No Data Found.
                </EmptyDataTemplate>
            </asp:GridView>

            <p class="text-right">
                <strong>Grand Total:</strong> $               
                <asp:Literal ID="TotalValueLiteral"
                    runat="server">
                </asp:Literal>
            </p>


            <asp:LinkButton ID="Back"
                runat="server"
                CssClass="btn btn-default btn-float-right"
                PostBackUrl="~/ManagerFeatures/ManagerDistributionCentreStockCentres.aspx">
                Back
            </asp:LinkButton>

            <asp:ObjectDataSource runat="server"
                ID="CentreStockSource"
                SelectMethod="DistributionCentreStock"
                TypeName="ENETCare.Business.ReportBLL"
                OnSelected="CentreStockSource_Selected">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="centreID"
                        Name="distributionCentreId"
                        Type="Int32"></asp:QueryStringParameter>
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->
</asp:Content>
