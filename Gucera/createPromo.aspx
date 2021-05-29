
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createPromo.aspx.cs" Inherits="Gucera.createPromo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Promocode</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Kindly Enter The Promocode Deatils Below:<br />
            <br />
            Code:<br />
            <asp:TextBox ID="cd" runat="server"  required="True" MaxLength="6"></asp:TextBox>
            <br />
            <br />

            Issue Date:<br />
            <asp:TextBox ID="isDat" runat="server" TextMode ="Date" required="True" ></asp:TextBox>
            <br />
            <br />
            Expirey Date:<br />
            <asp:TextBox ID="expDat" runat="server" TextMode ="Date"  required="True" ></asp:TextBox>
            <br />
            <br />
            Discount:<br />
            <asp:TextBox ID="disc" runat="server"  required="True"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:Button ID="Create" runat="server" OnClick ="createPromocode" Text="Create!" />
    </form>
</body>
</html>
