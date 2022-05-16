<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication13.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <h2>Edit Parameter</h2>
            <br />
            <asp:Label ID="lblParameterName" runat="server" Text="Label" align="left" style="margin-right:120px;" Font-Bold="True"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Update Parameter" style="margin-right:40px;margin-top:5px;margin-bottom:5px;"  Width="126px" CssClass="auto-style1" />
        </div>
    </form>
</body>
</html>
