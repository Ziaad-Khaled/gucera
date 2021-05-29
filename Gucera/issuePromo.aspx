<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="issuePromo.aspx.cs" Inherits="Gucera.issuePromo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Issue Promocode</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Kindly Fill The Deatils Below:<br />
            <br />
            Promocode:<br />
            <asp:TextBox ID="cd" runat="server" required ="True" MaxLength="6"></asp:TextBox>
            <br />
            <br />
            Student ID:<br />
            <asp:TextBox ID="sid" runat="server" required ="True"></asp:TextBox>
            <br />
            <br />
            </div>
            <asp:Button ID="issuecode" OnClick ="issueToStudent" runat="server" Text="Issue Code To Student" />
            </form>
    </body>
</html>
