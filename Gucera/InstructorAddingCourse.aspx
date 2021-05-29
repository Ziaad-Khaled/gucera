<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorAddingCourse.aspx.cs" Inherits="Gucera.InstructorAddingCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instructor Add Course</title>
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
            Instructor Adding Course<br />

            <br />
             
            Course Name
             <br />
            <asp:TextBox ID="name"  runat="server" required="true" MaxLength="10"></asp:TextBox>
            <br />
            price
            <br />
            <asp:TextBox ID="price" runat="server" MaxLength="7" ></asp:TextBox>
            <br />
            Credit hours
            <br />
            <asp:TextBox ID="credit_hours" runat="server"  ></asp:TextBox>
            <br/>
           <asp:Button ID="insructorButton" runat="server" OnClick="addCourse" Text="Add course" />
        
             </div>

    </form>
</body>
</html>
