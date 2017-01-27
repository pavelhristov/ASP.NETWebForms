<%@ Page Title="" Language="C#" MasterPageFile="~/International.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="InternationalCompany.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" Text="Welcome! This is the home page." />
        <br />
    <a href="/Bulgarian.aspx">Бълагарски</a>
    <a href="/English.aspx">English</a>
</asp:Content>
