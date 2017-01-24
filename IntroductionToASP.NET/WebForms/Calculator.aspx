<%@ Page Title="Calculator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebForms.Calculator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Ready to calculate?</h1>
        <asp:TextBox ID="TextBoxNumber1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelPlus" runat="server">+</asp:Label>
        <br />
        <asp:TextBox ID="TextBoxNumber2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonEquals" runat="server" Text="=" OnClick="ButtonEquals_Click"></asp:Button>
        <br />
        <asp:Label ID="LabelSum" runat="server"></asp:Label>
    </div>
</asp:Content>
