<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClaySysTrainingApp._Default" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    

&nbsp;<asp:Label ID="Label1" runat="server" Text="Enter your name"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="submit" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="navigate" OnClick="Button2_Click" />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <p>
    </p>
    

</asp:Content>

