<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication_lab5.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <h1>  <asp:Label ID="Label1" runat="server"></asp:Label></h1>
            <br />
            <br />
            Products:<br />
            <br />
            Mobile&nbsp; At&nbsp;&nbsp; ₹<asp:Label ID="Label2" runat="server" Text=" 39999"></asp:Label>
            <br />
            Smartphone At&nbsp;&nbsp; ₹<asp:Label ID="Label3" runat="server" Text="  9999"></asp:Label>
            <br />
            Pendrive At&nbsp;&nbsp; ₹<asp:Label ID="Label4" runat="server" Text="699"></asp:Label>
            <br />
            <br />
            Product by categories:<br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem>Electronics</asp:ListItem>
                <asp:ListItem>Books</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Width="197px" ></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Add to Cart" />
            <br />
            <br />
           <h2> Your cart:</h2>
            <br />
            <asp:ListBox ID="ListBox2" runat="server" Width="201px"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Checkout" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Remove From Cart" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
