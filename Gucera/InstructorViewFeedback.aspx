<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorViewFeedback.aspx.cs" Inherits="Gucera.InstructorViewFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instructor View Feedback</title>
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
            Instructor view feedback added by students
            <br/>
            <br />
            Course Id
             <br />
            <asp:TextBox ID="coId"  runat="server" required="true"></asp:TextBox>
            <br />
            <asp:Button ID="insructorButton" runat="server" OnClick="viewFeedback" Text="view Feedback" />

        </div>
    </form>
</body>
</html>
