<%@ Page Title="Hello" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="Hello.aspx.cs" Inherits="WebForms.Hello" %>

<asp:content id="BodyContent" contentplaceholderid="MainContent" runat="server">
    <div>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSubmit" runat="server" Text="Say Hello!" onclick="ButtonSubmit_Click"/>
        <asp:Label ID="LabelMessage" runat="server"></asp:Label>
        <br />
        <asp:Label ID="LabelAssemblyLocation" runat="server"></asp:Label>
    </div>
</asp:content>
