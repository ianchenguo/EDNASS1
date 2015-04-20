<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistributionCentreStockReport.aspx.cs" Inherits="ENETCare.GUI.Mockup.ReportMockup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            1. DistributionCentreStock
            Destination Distribution Centre:
            <asp:DropDownList ID="DistributionCentreDropDownList" runat="server">
                <asp:ListItem>Please select</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="QueryButton" runat="server" OnClick="QueryButton_Click" Text="Query" />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <div>
            2. GlobalStock
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </div>
        <div>
            3. DistributionCentreLosses
            <asp:GridView ID="GridView3" runat="server">
            </asp:GridView>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        </div>
        <div>
            4. ValueInTransit
            <asp:GridView ID="GridView4" runat="server">
            </asp:GridView>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        </div>
        <div>
            5. DoctorActivity
            <asp:GridView ID="GridView5" runat="server">
            </asp:GridView>
            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
