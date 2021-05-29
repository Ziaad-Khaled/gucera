<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewAssignGrades.aspx.cs" Inherits="Gucera.viewAssignGrades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 65px;
            left: 10px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 90px;
            left: 7px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 124px;
            left: 9px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 152px;
            left: 6px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 193px;
            left: 7px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 217px;
            left: 4px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 252px;
            left: 10px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            My Assignment Grades</div>
        <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="Assignment Type"></asp:Label>
        <asp:TextBox ID="AssignmentType" runat="server" CssClass="auto-style2" required="True"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" CssClass="auto-style3" Text="Assignment Number"></asp:Label>
        <asp:TextBox ID="AssignmentNumber" runat="server" CssClass="auto-style4" required="True"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" CssClass="auto-style5" Text="Course Number"></asp:Label>
        <asp:TextBox ID="courseId" runat="server" CssClass="auto-style6" required="True"></asp:TextBox>
        <asp:Button ID="button1" runat="server" CssClass="auto-style7" OnClick="submit" Text="Submit" />
    </form>
</body>
</html>
