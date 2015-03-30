<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceivingMockup.aspx.cs" Inherits="ENETCare.GUI.Mockup.ReceivingMockup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receiving</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Barcode:
        <asp:TextBox ID="BarcodeTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ReceiveButton" runat="server" OnClick="ReceiveButton_Click" Text="Receive" />
    </div>
    </form>
</body>
</html>
