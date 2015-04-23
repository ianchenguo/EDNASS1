<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerFeatures/ManagerFeatures.master" AutoEventWireup="true" CodeBehind="ManagerDistributionCentreLosses.aspx.cs" Inherits="ENETCare.Presentation.ManagerFeatures.ManagerDistributionCentreLosses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SpecificManagerFeatureMainContent" runat="server">
        <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Distribution Centre Losses</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">

            <asp:GridView ID="DistributionCenterLossesView"
                runat="server"
                AutoGenerateColumns="False"
                DataSourceID="DistributionCentreLossesSource"
                AllowPaging="True"
                CssClass="table  table-hover table-bordered table-striped" 
                OnDataBound="DistributionCenterLossesView_DataBound">
                <Columns>
                    <asp:BoundField DataField="DistributionCentre" HeaderText="DistributionCentre" SortExpression="DistributionCentre"></asp:BoundField>
                    <asp:BoundField DataField="LossValue" HeaderText="LossValue" SortExpression="LossValue"></asp:BoundField>
                    <asp:BoundField DataField="LossRatio" HeaderText="LossRatio" SortExpression="LossRatio"></asp:BoundField>
                    <asp:BoundField DataField="RiskLevel" HeaderText="RiskLevel" SortExpression="RiskLevel"></asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    No Data Found.
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:ObjectDataSource runat="server" 
                ID="DistributionCentreLossesSource" 
                SelectMethod="DistributionCentreLosses" 
                TypeName="ENETCare.Business.ReportBLL">
            </asp:ObjectDataSource>

            <asp:LinkButton ID="Back"
                runat="server"
                CssClass="btn btn-default btn-float-right"
                PostBackUrl="~/ManagerFeatures/ManagerHome.aspx">
                Back
            </asp:LinkButton>


        </div>
        <!--panel-body-end-->
    </div>
</asp:Content>
