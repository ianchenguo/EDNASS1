<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerFeatures/ManagerFeatures.master" AutoEventWireup="true" CodeBehind="ManagerValueInTransit.aspx.cs" Inherits="ENETCare.Presentation.ManagerFeatures.ManagerValueInTransit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificManagerFeatureMainContent" runat="server">

    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Value in Transit</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">

            <asp:GridView ID="ValueInTransitView"
                runat="server"
                AutoGenerateColumns="False"
                DataSourceID="ValueInTransitSource"
                AllowPaging="True"
                CssClass="table  table-hover table-bordered table-striped" 
                OnDataBound="ValueInTransitView_DataBound">
                <Columns>
                    <asp:BoundField DataField="FromDistributionCentre" HeaderText="FromDistributionCentre" SortExpression="FromDistributionCentre"></asp:BoundField>
                    <asp:BoundField DataField="ToDistributionCentre" HeaderText="ToDistributionCentre" SortExpression="ToDistributionCentre"></asp:BoundField>
                    <asp:BoundField DataField="Packages" HeaderText="Packages" SortExpression="Packages"></asp:BoundField>
                    <asp:BoundField DataField="Value" HeaderText="Value" SortExpression="Value"></asp:BoundField>
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
                PostBackUrl="~/ManagerFeatures/ManagerHome.aspx">
                Back
            </asp:LinkButton>

            <asp:ObjectDataSource runat="server"
                ID="ValueInTransitSource"
                SelectMethod="ValueInTransit"
                TypeName="ENETCare.Business.ReportBLL">
            </asp:ObjectDataSource>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
