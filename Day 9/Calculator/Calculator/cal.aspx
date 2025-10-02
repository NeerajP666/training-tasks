<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cal.aspx.cs" Inherits="Calculator.cal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtNum1" runat="server" />
<asp:TextBox ID="txtNum2" runat="server" />
<asp:DropDownList ID="ddlOperation" runat="server">
    <asp:ListItem Text="Add" Value="Add" />
    <asp:ListItem Text="Subtract" Value="Subtract" />
    <asp:ListItem Text="Multiply" Value="Multiply" />
    <asp:ListItem Text="Divide" Value="Divide" />
</asp:DropDownList>
<asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
<asp:Label ID="lblResult" runat="server" />
<asp:Label ID="lblLog" runat="server" ForeColor="Red" />

        </div>
    </form>
</body>
</html>
