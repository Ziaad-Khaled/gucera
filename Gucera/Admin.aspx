<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Gucera.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello Admin!</title>
     <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 50px;
            left: 500px;
            z-index: 1;
            width: 300px;
        }
        .auto-style2 {
            position: absolute;
            top: 100px;
            left: 500px;
            z-index: 1;
            width: 300px;
        }
        .auto-style3 {
            position: absolute;
            top: 150px;
            left: 500px;
            z-index: 1;
            width: 300px;
        }
        .auto-style4 {
            position: absolute;
            top: 200px;
            left: 500px;
            z-index: 1;
            width: 300px;
        }
        .auto-style5 {
            position: absolute;
            top: 250px;
            left: 500px;
            z-index: 1;
            width: 300px;
        }
              .auto-style6 {
            position: absolute;
            top: 300px;
            left: 500px;
            z-index: 1;
            width: 300px;
        }
         </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hello Admin!</div>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style1" OnClick="viewAllCourses" Text="View All Courses" />
        <asp:Button ID="Button2" runat="server" CssClass="auto-style2" OnClick="viewPending" Text="View Pending Courses" />
        <asp:Button ID="Button3" runat="server" CssClass="auto-style3" OnClick="acceptPending" Text="Accept Pending Courses" />
        <asp:Button ID="Button4" runat="server" CssClass="auto-style4" OnClick="createPromo" Text="Create Promocode" />
        <asp:Button ID="Button5" runat="server" CssClass="auto-style5" OnClick="issuePromo" Text="Issue Promocode to Student" />
        <asp:Button ID="Button6" runat="server" CssClass="auto-style6" OnClick="addMobile" Text="Add Mobile Number" />

    </form>
</body>
</html>
