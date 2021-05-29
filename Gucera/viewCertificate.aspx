<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewCertificate.aspx.cs" Inherits="Gucera.viewCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 95px;
            left: 10px;
        }
        .auto-style2 {
            position: absolute;
            top: 130px;
            left: 10px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 70px;
            left: 10px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            View Certificate</div>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1" style="z-index: 1" required="True"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style2" OnClick="submit" Text="submit" />
        <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="Course Id"></asp:Label>
    </form>
</body>
</html>
