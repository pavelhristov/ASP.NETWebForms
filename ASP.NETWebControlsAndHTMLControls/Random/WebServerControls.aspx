<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebServerControls.aspx.cs" Inherits="Random.WebServerControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="MinimumNumber" runat="server"></asp:TextBox>
        <asp:TextBox ID="MaximumNumber" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonRandom" runat="server" OnClick="ButtonRandom_Click" Text="Random" />
        <asp:Label ID="LableResult" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
