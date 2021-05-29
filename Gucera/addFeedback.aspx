<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addFeedback.aspx.cs" Inherits="Gucera.addFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 159px;
            left: 10px;
            z-index: 1;
            height: 99px;
        }
        .auto-style2 {
            position: absolute;
            top: 61px;
            left: 10px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 86px;
            left: 8px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 124px;
            left: 11px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 276px;
            left: 11px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Add Feedback</div>
        <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="course Id"></asp:Label>
    <p>
        <textarea id="comment" class="auto-style1" runat="server" cols="20" name="S1" maxlength="100"></textarea></p>
        <asp:TextBox ID="courseId" runat="server" CssClass="auto-style3" required="True"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" CssClass="auto-style4" Text="comment"></asp:Label>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style5" OnClick="submit" Text="submit" />
    </form>
    </body>
</html>
