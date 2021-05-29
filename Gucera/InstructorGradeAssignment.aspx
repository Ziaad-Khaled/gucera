<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorGradeAssignment.aspx.cs" Inherits="Gucera.InstructorGradeAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instructor grade assignment</title>
     <style>
         #form1 {
             background-color:#DDDDDD;
               font-style: italic;
              font-size: 30px;
              }
        #insructorButton{
            Width:200px;
            border: 5px double black;
            padding:5px;
            font-style: italic;
              font-size: 20px;
            background-color:#f7dd72;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
           <br/>
            Instructor grade assignment of a student <br />
            
            <br />
            Student Id
             <br />
            <asp:TextBox ID="studentId"  runat="server" required="true"></asp:TextBox>
            <br />
            Course Id
             <br />
            <asp:TextBox ID="coursId"  runat="server" required="true"></asp:TextBox>
            <br />
            Assignment Number
            <br />
            <asp:TextBox ID="num" runat="server" required="true"></asp:TextBox>
            <br />
            Assignment Type
            <br />
            <asp:TextBox ID="type" runat="server" required="true"></asp:TextBox>
            <br/>
            Grade
            <br />
            <asp:TextBox ID="Grade"  runat="server" required="true" MaxLength="6"></asp:TextBox>
            <br />
           <asp:Button ID="insructorButton" runat="server" OnClick="grade" Text="Grade Assignment" />
        
             </div>

    </form>
</body>
</html>
