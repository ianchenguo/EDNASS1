<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerFeatures/ManagerFeatures.master" AutoEventWireup="true" CodeBehind="ManagerDistributionCentreStockCentres.aspx.cs" Inherits="ENETCare.Presentation.ManagerFeatures.ManagerDistributionCenterCenters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificManagerFeatureMainContent" runat="server">

    <!--panel-start-->
    <div class="panel panel-default">

        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Distribution Centre List</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">

            <asp:GridView ID="DistributionCentresView"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table  table-hover table-bordered table-striped"
                DataSourceID="DistributionCentresSource"
                OnDataBound="On_Distribution_Centres_Bound">

                <Columns>
                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <ItemTemplate>
                            <asp:HyperLink ID="Centre"
                                runat="server"
                                NavigateUrl='<%# "ManagerDistributionCentreStock.aspx?centreid=" + Eval("ID") + "&centrename=" + Eval("NAME")%>'
                                Text='<%# Eval("Name") %>'>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:LinkButton ID="Back"
                runat="server"
                CssClass="btn btn-default btn-float-right"
                PostBackUrl="~/ManagerFeatures/ManagerHome.aspx">
                Back
            </asp:LinkButton>

            <asp:ObjectDataSource runat="server"
                ID="DistributionCentresSource"
                SelectMethod="GetDistributionCentreList"
                TypeName="ENETCare.Business.DistributionCentreBLL"
                OnSelected="DistributionCentresSource_Selected"></asp:ObjectDataSource>
        </div>
    </div>
    <!--panel-end-->
</asp:Content>
