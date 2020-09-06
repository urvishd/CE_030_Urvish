<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebApplication_lab6_1.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <br />
            ID:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Fetch" />
        </p>
        <asp:Panel ID="Panel1" runat="server">
            Name:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="225px"></asp:TextBox>
            <br />
            <br />
            Sem:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Width="226px"></asp:TextBox>
            <br />
            <br />
            Mobile:&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" Width="227px"></asp:TextBox>
            <br />
            <br />
            Email Id:<asp:TextBox ID="TextBox5" runat="server" Width="227px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" ForeColor="Green"></asp:Label>
        </asp:Panel>
        <p>
        </p>
        <p>
            &nbsp;</p>
        <div>
        </div>
    </form>
</body>
</html>
