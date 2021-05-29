<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorPage.aspx.cs" Inherits="Gucera.InstructorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
         #form1 {
             background-color:#DDDDDD;
               font-style: italic;
              font-size: 30px;
              }
        .buttonS{
            Width:180px;
            border: 5px double black;
            padding:5px;
            background-color:#FFFF00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
           <br/>


            <asp:Button ID="Button1" CssClass="buttonS" runat="server" Text="Add Courses"  OnClick="addCoursess"  /> 
            <br /><br />
            <asp:Button ID="Button2" runat="server" CssClass="buttonS" Text="Define Assignment"  OnClick="DEFINE"/><br /><br />
            <asp:Button ID="Button3" runat="server" CssClass="buttonS" Text="View Assignment"  OnClick="VIEWA"/><br /><br />
            <asp:Button ID="Button4" runat="server" CssClass="buttonS" Text="Grade Assignment"  OnClick="GRADE"/><br /><br />
            <asp:Button ID="Button5" runat="server" CssClass="buttonS" Text="View Feedback"  OnClick="VIEWF"/><br /><br />
            <asp:Button ID="Button6" runat="server" CssClass="buttonS" Text="Issue Certificate"  OnClick="ISSUE"/><br /><br />
            <asp:Button ID="Button7" runat="server" CssClass="buttonS" Text="addMobile"  OnClick="addM"/>



        </div>
        
    </form>
</body>
</html>
