<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addMobile.aspx.cs" Inherits="Gucera.addMobile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Please add your mobile number here:
        <br />
        <asp:TextBox ID="mobileNumber" runat="server" required="True"></asp:TextBox>
        <br />
        <asp:Button ID="add" runat="server" Text="Submit" OnClick="addMobileNumber" />
        <div>
        </div>
    </form>
</body>
</html>
