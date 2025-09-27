<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="ClaySysTrainingApp.page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    
        </div>
        <asp:Button ID="Button1" runat="server" Text="return back" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" text="male" GroupName="gender"/>
        <asp:RadioButton ID="RadioButton2" runat="server"  text="female" GroupName="gender"/>

        <br />
        <asp:Button ID="Button2" runat="server" Text="submit" OnClick="Button2_Click" />

        <br />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <asp:Panel ID="Panel1" runat="server" Height="61px" Width="392px">
            <asp:Label ID="Label3" runat="server" Text="enter email"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Text="save" OnClick="Button3_Click" />
        </asp:Panel>
        <br />
        <br />

    </form>
</body>
</html>
