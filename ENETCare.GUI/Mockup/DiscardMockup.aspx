<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiscardMockup.aspx.cs" Inherits="ENETCare.GUI.Mockup.Discard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Discard</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Barcode:
        <asp:TextBox ID="BarcodeTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="DiscardButton" runat="server" OnClick="DiscardButton_Click" Text="Discard" />
    </div>
    </form>
</body>
</html>
