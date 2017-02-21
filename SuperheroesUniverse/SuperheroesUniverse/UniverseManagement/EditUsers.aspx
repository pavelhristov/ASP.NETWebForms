<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUsers.aspx.cs" Inherits="SuperheroesUniverse.UniverseManagement.EditUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Role Membership</h3>
    <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
    <table cellpadding="3" border="0">
        <tr>
            <td valign="top">Roles:</td>
            <td valign="top">
                <asp:ListBox ID="RolesListBox" runat="server" Rows="8" /></td>
            <td valign="top">Users:</td>
            <td valign="top">
                <asp:ListBox ID="UsersListBox" DataTextField="Username"
                    Rows="8" runat="server" /></td>
            <td valign="top">
                <asp:Button Text="Add User to Role" ID="AddUserButton"
                    runat="server" OnClick="AddUser_OnClick" /></td>
        </tr>
    </table>
    <b>Create a New Role: </b>
    <asp:TextBox ID="RoleName" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="CreateRoleButton" runat="server" Text="Create Role" OnClick="CreateRoleButton_Click"/>
</asp:Content>
