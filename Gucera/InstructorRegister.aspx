<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorRegister.aspx.cs" Inherits="Gucera.InstructorRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Instructor register<br />
            First name<br />
            <asp:TextBox ID="first_name" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            Last Name
            <br />
              <asp:TextBox ID="last_name" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="password" type="password" runat="server" required="true" MaxLength="10"></asp:TextBox>
            <br />
            E-mail
            <br />
            <asp:TextBox ID="email" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            Address
            <br />
            <asp:TextBox ID="address" runat="server" MaxLength="10"></asp:TextBox>
            <br/>
            Gender
            <asp:RadioButtonList ID="gender" runat="server" OnSelectedIndexChanged="genderChoosen" RepeatDirection="Horizontal">
                <asp:ListItem  Value="0">Male</asp:ListItem>
                <asp:ListItem  Value="1">Female</asp:ListItem>
            </asp:RadioButtonList>
            <br/>
            
        
           <asp:Button ID="signin" runat="server" OnClick="Register" Text="Register" />
        
             </div>
    </form>
</body>
</html>
