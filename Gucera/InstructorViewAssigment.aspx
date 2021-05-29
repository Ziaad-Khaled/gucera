<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorViewAssigment.aspx.cs" Inherits="Gucera.InstructorViewAssigment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instructor View Assignment</title>
     <style>
 #form1 {
             background-color:#DDDDDD;
               font-style: italic;
              font-size: 30px;
              }
         #insructorButton {
             Width: 180px;
             border: 5px double black;
             padding: 5px;
             font-style: italic;
             font-size: 20px;
             background-color: #f7dd72;
         }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
           <br/>
            Instructor view Assignments of Students
            <br/>
            <br />
            Course Id
             <br />
            <asp:TextBox ID="coId"  runat="server" required="true"></asp:TextBox>
            <br />
            <asp:Button ID="insructorButton" runat="server" OnClick="viewAssignment" Text="view Assignment" />

        </div>
    </form>
</body>
</html>
