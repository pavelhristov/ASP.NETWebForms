<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchCars.aspx.cs" Inherits="Cars.SearchCars" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList runat="server" ID="DropDownProducers" Width="180px" DataTextField="Name" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="DropDownProducers_SelectedIndexChanged">
            <asp:ListItem>--select producer--</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:DropDownList runat="server" ID="DropDownModels" Width="180px" AppendDataBoundItems="true" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="DropDownModels_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:RadioButtonList runat="server" ID="RadioButtonGroupEngines" Visible="false" AppendDataBoundItems="true"></asp:RadioButtonList>
        <br />
        <asp:CheckBoxList runat="server" ID="CheckBoxListExtras">
        </asp:CheckBoxList>
        <br />
        <asp:Button runat="server" ID="ButtonSubmit" OnClick="ButtonSubmit_Click" Visible="false"  Text="Submit!" />
        <br />
        <asp:Literal ID="LiteralResult" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
