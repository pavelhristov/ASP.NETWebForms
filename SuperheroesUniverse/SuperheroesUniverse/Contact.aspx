<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SuperheroesUniverse.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Author:</h3>
    <h4>Pavel Hristov</h4>

    <address>
        <strong>Support:</strong> <a href="mailto:pavel.hristov_@abv.bg">pavel.hristov_@abv.bg</a>
        <br />
        <strong>Source:</strong>
        <a
            href="https://github.com/pavelhristov/ASP.NETWebForms/tree/master/SuperheroesUniverse">
            <img src="https://image.flaticon.com/icons/svg/23/23957.svg" alt="GitHub"  width="25"></a>
    </address>
</asp:Content>
