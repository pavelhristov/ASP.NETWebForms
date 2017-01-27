<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calc.aspx.cs" Inherits="Calculator.Calc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="InputField" runat="server" Enabled="false"></asp:TextBox>
            <asp:Label ID="LabelLastNumber" runat="server" />
            <asp:Label ID="LabelOperation" runat="server" />
            <br />
            <asp:Button ID="Button1" Text="1" runat="server" OnClick="Number_Click" />
            <asp:Button ID="Button2" Text="2" runat="server" OnClick="Number_Click" />
            <asp:Button ID="Button3" Text="3" runat="server" OnClick="Number_Click" />
            <asp:Button ID="ButtonPlus" Text="+" runat="server" OnClick="Operation_Click" />
            <br />
            <asp:Button ID="Button4" Text="4" runat="server" OnClick="Number_Click" />
            <asp:Button ID="Button5" Text="5" runat="server" OnClick="Number_Click" />
            <asp:Button ID="Button6" Text="6" runat="server" OnClick="Number_Click" />
            <asp:Button ID="ButtonMinus" Text="-" runat="server" OnClick="Operation_Click" />
            <br />
            <asp:Button ID="Button7" Text="7" runat="server" OnClick="Number_Click" />
            <asp:Button ID="Button8" Text="8" runat="server" OnClick="Number_Click" />
            <asp:Button ID="Button9" Text="9" runat="server" OnClick="Number_Click" />
            <asp:Button ID="ButtonMultiply" Text="x" runat="server" OnClick="Operation_Click" />
            <br />
            <asp:Button ID="ButtonClear" Text="Clear" runat="server" OnClick="ButtonClear_Click" />
            <asp:Button ID="Button0" Text="0" runat="server" OnClick="Number_Click" />
            <asp:Button ID="ButtonDivide" Text="/" runat="server" OnClick="Operation_Click" />
            <asp:Button ID="ButtonSqrt" Text="√" runat="server" OnClick="Operation_Click" />
            <br />
            <asp:Button ID="ButtonEquals" Text="=" runat="server" OnClick="Operation_Click" />
            <br />
            <asp:Label ID="LabelInfo" runat="server" />
        </div>
    </form>
</body>
</html>
