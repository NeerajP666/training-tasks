<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register5.aspx.cs" Inherits="ClaysysTraining2.register5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="296px">
    <asp:Label ID="Label1" runat="server" Text="username"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="password"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="email"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="register" OnClick="Button1_Click" />
    <br />
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
</asp:Panel>
        </div>
    </form>
</body>
</html>
