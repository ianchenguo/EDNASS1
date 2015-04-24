<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true"
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
            <asp:GridView ID="AgentDoctorReportStockTakingGV" runat="server" 
                AllowPaging="true" GridLines="Horizontal" OnRowCommand="AgentDoctorReportStockTakingGV_RowCommand" 
                OnPageIndexChanging="AgentDoctorReportStockTakingGV_PageIndexChanging" CssClass="table  table-hover table-bordered table-striped">
                <Columns>
                    <asp:TemplateField HeaderText="Delete Expired">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDelete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete it?');"
                                CommandName="DeleteRow" CommandArgument='<%# Eval("Barcode") %>' Text="Delete" ForeColor="#cc0000" runat="server" Font-Italic="true"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <%--<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="#000000" />--%>
                <%--<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />--%>
            </asp:GridView>

            <!-- the following link should be optimised -->
            <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentDoctorHome.aspx">Cancel</a>
            <asp:Label ID="lblValues" runat="server" Text=""></asp:Label>
            <asp:Label ID="lb2" runat="server" Text=""></asp:Label>

        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
