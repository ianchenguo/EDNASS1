<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexMockup.aspx.cs" Inherits="ENETCare.GUI.Mockup.IndexMockup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        table {
            border-collapse: collapse;
        }
        table, td, th {
            border: 1px solid black;
            padding: 5px;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="RegistrationMockup.aspx">Registration</a>
        <a href="SendingMockup.aspx">Sending</a>
        <a href="ReceivingMockup.aspx">Receiving</a>
        <a href="DistributionMockup.aspx">Distribution</a>
        <a href="DiscardMockup.aspx">Discard</a>
    </div>
    </form>
</body>
</html>
