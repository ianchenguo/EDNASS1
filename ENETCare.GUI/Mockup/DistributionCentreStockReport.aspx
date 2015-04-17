<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistributionCentreStockReport.aspx.cs" Inherits="ENETCare.GUI.Mockup.ReportMockup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Destination Distribution Centre:
        <asp:DropDownList ID="DistributionCentreDropDownList" runat="server">
            <asp:ListItem>Please select</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="QueryButton" runat="server" OnClick="QueryButton_Click" Text="Query" />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
