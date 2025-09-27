<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ClaySysTrainingApp.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="371px">
                <asp:Label ID="Label1" runat="server" Text="Enter name"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Enter emailid"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Enter password"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" Height="25px"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="login" OnClick="Button2_Click" />
                <br />
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
