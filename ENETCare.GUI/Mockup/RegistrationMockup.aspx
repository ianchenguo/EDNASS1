<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationMockup.aspx.cs" Inherits="ENETCare.GUI.Mockup.RegistrationMockup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Medication Type:
        <asp:DropDownList ID="TypeDropDownList" runat="server">
            <asp:ListItem>Please select</asp:ListItem>
        </asp:DropDownList>
        <br />
        Expire Date:
        <asp:TextBox ID="ExpireDateTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="RegisterButton" runat="server" OnClick="RegisterButton_Click" Text="Register" />
        <p><asp:label id="Msg" runat="server"/></p>
    </div>
    </form>
</body>
</html>
