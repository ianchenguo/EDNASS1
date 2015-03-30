<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendingMockup.aspx.cs" Inherits="ENETCare.GUI.Mockup.SendingMockup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sending</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Destination Distribution Centre:
        <asp:DropDownList ID="DistributionCentreDropDownList" runat="server" OnSelectedIndexChanged="DistributionCentreDropDownList_SelectedIndexChanged">
            <asp:ListItem>Please select</asp:ListItem>
        </asp:DropDownList>
        <br />
        Barcode:
        <asp:TextBox ID="BarcodeTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="SendButton" runat="server" OnClick="SendButton_Click" Text="Send" />
    </div>
    </form>
</body>
</html>
