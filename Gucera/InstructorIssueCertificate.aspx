<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorIssueCertificate.aspx.cs" Inherits="Gucera.InstructorIssueCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instructor Issue Certificate</title>
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
            Instructor issue certificate to a student
            <br />
            
            <br />
             Student Id
             <br />
            <asp:TextBox ID="sid"  runat="server" required="true"></asp:TextBox>
            <br />
            Course Id
             <br />
            <asp:TextBox ID="coId"  runat="server" required="true"></asp:TextBox>
            <br />
             Issue date 
             <br />
            <asp:TextBox ID="issue"  runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <asp:Button ID="insructorButton" runat="server" OnClick="addCertificate" Text="Certify" />
        </div>
    </form>
</body>
</html>
