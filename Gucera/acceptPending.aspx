<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceptPending.aspx.cs" Inherits="Gucera.acceptPending" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Accept Courses</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Kindly Enter The ID Of The Course You Want To Accept<br />
            <br />
            ID:<br />
            <asp:TextBox ID="CourseID" runat="server" required ="True"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="AcceptCourseB" OnClick ="CourseAccept" runat="server" Text="Accept!" />
        </div>
    </form>
</body>
</html>