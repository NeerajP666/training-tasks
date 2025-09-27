<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ClaySysTrainingApp.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 218px; width: 990px; margin-left: 217px">
    <form id="form1" runat="server">
        <div style="width: 439px; margin-left: 233px">

            <asp:Panel ID="Panel1" runat="server" Height="175px">
                <asp:Label ID="Label1" runat="server" Text="enter the username"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="enter the password"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button2" runat="server" Height="31px" Text="log in" OnClick="Button2_Click" />
                <br />
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                <br />
                
                <br />
                <br />
                <br />
            </asp:Panel>

        </div>
    </form>
</body>
</html>
