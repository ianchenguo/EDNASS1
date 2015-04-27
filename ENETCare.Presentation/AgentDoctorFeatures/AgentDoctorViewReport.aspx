﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true"
    CodeBehind="AgentDoctorViewReport.aspx.cs" Inherits="ENETCare.Presentation.AgentDoctorFeatures.AgentDoctorViewReport" %>

<asp:Content ID="AgentDoctorViewReportContent" ContentPlaceHolderID="SpecificAgentDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Package Storage Report</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <%--BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"  BorderWidth="1px" CellPadding="4" ForeColor="Black"--%>
            <%--CssClass="table  table-hover table-bordered table-striped"--%>
            <asp:GridView ID="AgentDoctorReportStockTakingGV" runat="server" AllowPaging="true" GridLines="Horizontal" OnRowCommand="AgentDoctorReportStockTakingGV_RowCommand"
                OnPageIndexChanging="AgentDoctorReportStockTakingGV_PageIndexChanging" CssClass="table  table-hover table-bordered table-striped" OnDataBound="AgentDoctorReportStockTakingGV_DataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Delete Expired">
                        <ItemTemplate>
                            <%--Visible="<%# false %>"--%>
                            <asp:LinkButton ID="lbDelete" Text="Delete" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete it?');"
                                CommandName="DeleteRow" CommandArgument='<%# Eval("Barcode") %>' ForeColor="#CC0000" runat="server" Font-Italic="True" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No Data Found.
                </EmptyDataTemplate>
            </asp:GridView>

            <!-- the following link should be optimised -->
            <asp:Button ID="CancleADViewReport" Text="Cancel" runat="server" CssClass="btn btn-danger btn-float-right btn-margin-left" OnClick="CancleADViewReport_Click" />

        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
