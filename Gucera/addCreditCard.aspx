<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCreditCard.aspx.cs" Inherits="Gucera.addCreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please fill in this form to add your credit card:
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Credit Card Number:"></asp:Label>
            <br />
            <asp:TextBox ID="number" runat="server" required="True" maxlength="15"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Card Holder Name:"></asp:Label>
            <br />
            <asp:TextBox ID="cardHolderName" runat="server" maxlength="16"></asp:TextBox>
             <br />
            <asp:Label ID="Label3" runat="server" Text="Expiry Date"></asp:Label>
            <br />
            <asp:TextBox ID="expiryDate" TextMode="Date" runat="server"></asp:TextBox>
             <br />
            <asp:Label ID="Label4" runat="server" Text="CVV"></asp:Label>
            <br />
            <asp:TextBox ID="cvv" runat="server" maxlength="3"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="addCC" />

        </div>
    </form>
</body>
</html>
