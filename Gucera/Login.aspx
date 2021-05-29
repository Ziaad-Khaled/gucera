<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Gucera.Login" %>

<!DOCTYPE html>
<script runat="server">

    protected void InstructorRegistration(object sender, EventArgs e)
    {
        Response.Redirect("InstructorRegister.aspx");
    }

    protected void StudentRegistration(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please sign in<br />
            User Id<br />
            <asp:TextBox ID="username" runat="server" required="True"></asp:TextBox>
            <br />
            password
            <br />
        <asp:TextBox ID="password" runat="server" TextMode="password"  required="True" MaxLength="10"></asp:TextBox>
        <br />
        <asp:Button ID="signin" runat="server" OnClick="login" Text="log in" />

             </div>

    <br />
    Do not have an account? Register Now!
    <br />
    <asp:Button ID="StudentRegister" runat="server" Text="I am a student" OnClick="StudentRegistration" formnovalidate="True" />
    <asp:Button ID="InstructorRegister" runat="server" Text="I am an instructor" OnClick="InstructorRegistration" formnovalidate="True" />

    </form>

    </body>
</html>