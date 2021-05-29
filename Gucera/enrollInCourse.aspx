<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enrollInCourse.aspx.cs" Inherits="Gucera.enrollInCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        Enter the ID of the Course you want to Enroll in!
        <br />
            <asp:TextBox ID="courseIdBox" runat="server" required="True"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Enter" OnClick="courseInfo" />
        </div>
    </form>
</body>
</html>
