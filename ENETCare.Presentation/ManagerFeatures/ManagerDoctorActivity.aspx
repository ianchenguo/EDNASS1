<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerFeatures/ManagerFeatures.master" AutoEventWireup="true" CodeBehind="ManagerDoctorActivity.aspx.cs" Inherits="ENETCare.Presentation.ManagerFeatures.ManagerDoctorActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SpecificManagerFeatureMainContent" runat="server">

        <!--panel-start-->
    <div class="panel panel-default">

        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title"
                runat="server">
                Doctor 
                <asp:Literal ID="HeadingLiteral"
                    runat="server"
                    OnDataBinding="Page_Load">
                </asp:Literal>
                's Activity
            </h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <asp:GridView ID="DoctorActivityView"
                runat="server"
                AutoGenerateColumns="False"
                DataSourceID="CentreStockSource"
                CssClass="table  table-hover table-bordered table-striped"
                AllowPaging="True" 
                OnDataBound="DoctorActivityView_DataBound">
                <Columns>
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
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
                PostBackUrl="~/ManagerFeatures/ManagerDoctorActivityDoctors.aspx">
                Back
            </asp:LinkButton>

            <asp:ObjectDataSource runat="server"
                ID="CentreStockSource"
                SelectMethod="DoctorActivity"
                TypeName="ENETCare.Business.ReportBLL">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="username"
                        Name="username"
                        Type="String"></asp:QueryStringParameter>
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->
</asp:Content>
