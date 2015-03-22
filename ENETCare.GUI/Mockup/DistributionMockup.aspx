<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistributionMockup.aspx.cs" Inherits="ENETCare.GUI.Mockup.Distribution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Distribution</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Barcode:
        <asp:TextBox ID="BarcodeTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="DistributeButton" runat="server" OnClick="DistributeButton_Click" Text="Distribute" />
    </div>
    </form>
</body>
</html>
