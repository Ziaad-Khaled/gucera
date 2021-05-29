<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseInformation.aspx.cs" Inherits="Gucera.CourseInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:Label ID="Label1" runat="server" Text="Write the ID of the instructor you want to enroll with."></asp:Label>
        <br />
        <asp:TextBox ID="instid" runat="server" required="True"></asp:TextBox>
        <br />
        <asp:Button ID="enrollButton" runat="server" Text="Enroll"  OnClick="enroll"/>
        <div>
         <br />
        <br />
        <br />
         <asp:Label ID="Label2" runat="server" Text="This is all the information recorded for the Course you entered:"></asp:Label>
        </div>
       
    </form>
</body>
</html>
