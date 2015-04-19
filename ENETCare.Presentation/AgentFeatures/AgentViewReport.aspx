<%@ Page Title="" Language="C#" MasterPageFile="~/AgentFeatures/AgentFeatures.master" AutoEventWireup="true"
    CodeBehind="AgentViewReport.aspx.cs" Inherits="ENETCare.Presentation.AgentFeatures.AgentViewReport" %>

<asp:Content ID="AgentViewReportContent" ContentPlaceHolderID="SpecificAgentFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Package Storage Report</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <asp:GridView ID="AgentReportStockTakingGV" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCommand="AgentReportStockTakingGV_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete Expired">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDelete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete it?');"
                                CommandName="DeleteRow" CommandArgument='<%# Eval("Barcode") %>' Text="Delet" ForeColor="#cc0000" runat="server" Font-Italic="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>

            <!-- the following link should be optimised -->
            <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentHome.aspx">Cancel</a>

        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
