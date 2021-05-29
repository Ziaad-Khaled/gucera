<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefiningAssignment.aspx.cs" Inherits="Gucera.DefiningAssignment" %>

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
         #insructorButton {
             Width: 200px;
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
            Instructor define assignment of different types<br />
           
            
            <br />
            Course Id
             <br />
            <asp:TextBox ID="couId"  runat="server" required="true"></asp:TextBox>
            <br />
            Number
            <br />
            <asp:TextBox ID="number" runat="server" required="true"></asp:TextBox>
            <br />
            Type
            <br />
            <asp:TextBox ID="type" runat="server" required="true" MaxLength="10"></asp:TextBox>
            <br/>
            Full grade
            <br />
            <asp:TextBox ID="fullGrade"  runat="server" ></asp:TextBox>
            <br />
            Weight
            <br />
            <asp:TextBox ID="weight" runat="server" MaxLength="5"></asp:TextBox>
            <br />
            Deadline
            <br />
            <asp:TextBox ID="dead" runat="server" TextMode="Date" ></asp:TextBox>
            <br/>
            Content
            <br />
            <asp:TextBox ID="cont" runat="server" ></asp:TextBox>
            <br />
           <asp:Button ID="insructorButton" runat="server" OnClick="DefineAssignment" Text="Define Assignment" />
        
             </div>

    </form>
</body>
</html>
