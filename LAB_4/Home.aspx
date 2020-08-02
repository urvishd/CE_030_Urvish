<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication_lab4.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Homepage</h1>
        <div>
            Full Name:<asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="TextBox1"   Text="Name is required!"
ErrorMessage="Please enter a user name" ForeColor="Red"></asp:RequiredFieldValidator>  
            <br />
            <br />
            Age:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2"   
ErrorMessage="Enter Valid Age!!" ForeColor="Red" MaximumValue="50" MinimumValue="18"   
SetFocusOnError="True" Type=" Integer"></asp:RangeValidator>  
            <br />
            <br />
            Password:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            Confirm Password:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox4"   
ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Re-entered password is not matching!" ForeColor="Red"  Type="Integer"></asp:CompareValidator>
            <br />
            <br />
            Gender:&nbsp;
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Mobile No:
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5"   
ErrorMessage="Please enter valid Mobile number!" ForeColor="Red" ValidationExpression="\d{10}">  </asp:RegularExpressionValidator>
            <br />
            <br />
            Hobbies:
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem>Reading</asp:ListItem>
                <asp:ListItem>Travelling</asp:ListItem>
                <asp:ListItem>Listening Music</asp:ListItem>
            </asp:CheckBoxList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            State:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem>Gujarat</asp:ListItem>
                <asp:ListItem>Maharashtra</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            City:<asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>Ahmedabad</asp:ListItem>
                <asp:ListItem>Vadodara</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            PAN Number:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <asp:CustomValidator runat="server" id="cusCustom" controltovalidate="TextBox6" Display="Dynamic" ForeColor="Red"
                onservervalidate="pan_verify" errormessage="Enter a valid PAN Number!!"  ValidateEmptyText="true"/>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
