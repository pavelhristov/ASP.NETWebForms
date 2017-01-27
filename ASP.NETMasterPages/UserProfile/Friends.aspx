<%@ Page Title="Friends" Language="C#" MasterPageFile="~/UserProfile.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="UserProfile.Friends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListBox runat="server">
        <asp:ListItem Value="1" Text="Mariika"></asp:ListItem>
        <asp:ListItem Value="2" Text="Gosho"></asp:ListItem>
        <asp:ListItem Value="3" Text="Tosho"></asp:ListItem>
        <asp:ListItem Value="4" Text="Someone"></asp:ListItem>
        <asp:ListItem Value="5" Text="None"></asp:ListItem>
    </asp:ListBox>
</asp:Content>
