<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="persistent_cookie.aspx.cs" Inherits="WebApplication_lab5.persistent_cookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Your favourite products in cookies:&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="set cookies" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete Cookies" />

        </div>
    </form>
</body>
</html>
