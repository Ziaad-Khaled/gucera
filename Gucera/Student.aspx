<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Gucera.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello Student!</title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 50px;
            left: 300px;
            z-index: 1;
            width: 250px;
        }
        .auto-style2 {
            position: absolute;
            top: 100px;
            left: 300px;
            z-index: 1;
            width: 250px;
        }
        .auto-style3 {
            position: absolute;
            top: 150px;
            left: 300px;
            z-index: 1;
            width: 250px;
        }
        .auto-style4 {
            position: absolute;
            top: 200px;
            left: 300px;
            z-index: 1;
            width: 250px;
        }
        .auto-style5 {
            position: absolute;
            top: 250px;
            left: 300px;
            z-index: 1;
            width: 250px;
        }
        .auto-style6 {
            position: absolute;
            top: 50px;
            left: 900px;
            z-index: 1;
            width: 250px;
        }
            .auto-style7 {
            position: absolute;
            top: 100px;
            left: 900px;
            z-index: 1;
            width: 250px;
        }
            .auto-style8 {
            position: absolute;
            top: 150px;
            left: 900px;
            z-index: 1;
            width: 250px;
        }
            .auto-style9 {
            position: absolute;
            top: 200px;
            left: 900px;
            z-index: 1;
            width: 250px;
        }
               .auto-style10 {
            position: absolute;
            top: 250px;
            left: 900px;
            z-index: 1;
            width: 250px;
        }
                   .auto-style11 {
            position: absolute;
            top: 300px;
            left: 600px;
            z-index: 1;
            width: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hello Student!</div>

        <asp:Button ID="Button1" runat="server" CssClass="auto-style1" Text="View My Profile" OnClick="viewMyProfile"  />
        <asp:Button ID="Button2" runat="server" CssClass="auto-style2" Text="List Accepted Courses" OnClick="listAcceptedCourses"  />
        <asp:Button ID="Button3" runat="server" CssClass="auto-style3" Text="Enroll in a Course" OnClick="enrollInCourse"  />
        <asp:Button ID="Button4" runat="server" CssClass="auto-style4" Text="Add Credit Card" OnClick="addCreditCard"  />
        <asp:Button ID="Button5" runat="server" CssClass="auto-style5" Text="View My Promocodes" OnClick="viewPromocode"  />
        <asp:Button ID="Button6" runat="server" CssClass="auto-style6" OnClick="viewMyAssignments" Text="View My Assignments" />

        <asp:Button ID="Button7" runat="server" CssClass="auto-style7" Text="Submit My Assignment" OnClick="submitMyAssignment" />
        <asp:Button ID="Button8" runat="server" CssClass="auto-style8" Text="View My Assignment Grades" OnClick="viewMyAssignmentGrades" />
        <asp:Button ID="Button9" runat="server" CssClass="auto-style9" OnClick="addFeedback" Text="Add Feedback" />
        <asp:Button ID="Button10" runat="server" CssClass="auto-style10" OnClick="listCertificates" Text="List Certificates" />
        
        <asp:Button ID="Button11" runat="server" CssClass="auto-style11" OnClick="addMobile" Text="Add Mobile Number" />
        

    </form>
</body>
</html>
