<%@ Page Title="" Language="C#" MasterPageFile="~/AgentFeatures/AgentFeatures.master" AutoEventWireup="true" CodeBehind="TestAgent.aspx.cs" Inherits="ENETCare.Presentation.AgentFeatures.TestAgent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentFeatureMainContent" runat="server">
    <%--<asp:GridView ID="AgentTestGV" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" AllowPaging="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Barcode" HeaderText="Barcode" SortExpression="Barcode" />
            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
            <asp:BoundField DataField="ExpireDate" HeaderText="ExpireDate" SortExpression="ExpireDate" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="StockDC" HeaderText="StockDC" SortExpression="StockDC" />
            <asp:BoundField DataField="SourceDC" HeaderText="SourceDC" SortExpression="SourceDC" />
            <asp:BoundField DataField="DestinationDC" HeaderText="DestinationDC" SortExpression="DestinationDC" />
            <asp:BoundField DataField="Updatetime" HeaderText="Updatetime" SortExpression="Updatetime" />
        </Columns>
    </asp:GridView>--%>

    <asp:GridView ID="AgentTestGV" runat="server" OnRowCommand="AgentTestGV_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Delete Expired">
                <ItemTemplate>
                    <asp:LinkButton ID="lbDelete" CausesValidation="false" OnClientClick ="return confirm('Are you sure you want to delete it?');" 
                        CommandName="DeleteRow" CommandArgument='<%# Eval("Barcode") %>' Text="Delet" ForeColor="#cc0000" runat="server" Font-Italic="true" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </asp:Content>
