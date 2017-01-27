<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HTMLEscaping.aspx.cs" Inherits="Escaping.HTMLEscaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBoxScriptContainer" runat="server" Width="300px" ValidateRequestMode="Disabled"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonRunScript" runat="server" Text="Run Script!" OnClick="ButtonRunScript_Click"/>
        <br />
        <asp:Label ID="LabelScriptResult" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxScriptResult" runat="server" Width="300px" Mode="Encode" Enabled="false"></asp:TextBox>
    </div>
    </form>
</body>
</html>
