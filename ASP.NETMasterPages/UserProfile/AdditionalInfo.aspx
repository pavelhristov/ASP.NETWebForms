<%@ Page Title="Additional Info" Language="C#" MasterPageFile="~/UserProfile.Master" AutoEventWireup="true" CodeBehind="AdditionalInfo.aspx.cs" Inherits="UserProfile.AdditionalInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label Text="Some info that is not on the profile page."  runat="server"/>
    <asp:Label Text="Pesho likes fishing."  runat="server"/>
    <asp:Label Text="Pesho does not like eating fish."  runat="server"/>
    <asp:Label Text="Pesho has never played tic-tac-toe."  runat="server"/>
    <asp:Label Text="Pesho does not know what 'undefined' is."  runat="server"/>
</asp:Content>
