<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="TicTacToe.Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Cell_0_0" runat="server" Width="30px" OnClick="Cell_Click" />
            <asp:Button ID="Cell_0_1" runat="server" Width="30px" OnClick="Cell_Click" />
            <asp:Button ID="Cell_0_2" runat="server" Width="30px" OnClick="Cell_Click" />
            <br />                              
            <asp:Button ID="Cell_1_0" runat="server" Width="30px" OnClick="Cell_Click" />
            <asp:Button ID="Cell_1_1" runat="server" Width="30px" OnClick="Cell_Click" />
            <asp:Button ID="Cell_1_2" runat="server" Width="30px" OnClick="Cell_Click" />
            <br />                            
            <asp:Button ID="Cell_2_0" runat="server" Width="30px" OnClick="Cell_Click" />
            <asp:Button ID="Cell_2_1" runat="server" Width="30px" OnClick="Cell_Click" />
            <asp:Button ID="Cell_2_2" runat="server" Width="30px" OnClick="Cell_Click" />
            <br />
            <asp:Label ID="LabelScore" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
