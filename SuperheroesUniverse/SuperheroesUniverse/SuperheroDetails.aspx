<%@ Page Title="Superhero Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuperheroDetails.aspx.cs" Inherits="SuperheroesUniverse.SuperheroDetails" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewSuperheroDetails" ItemType="SuperheroesUniverse.Data.Models.Superhero" SelectMethod="FormViewSuperheroDetails_GetItem">
        <ItemTemplate>
            <header>
                <h1><%: Title %></h1>
                <p><%#: Item.Name %></p>
            </header>
            <div class="row-fluid">
                <p><i><%#: Item.SecretIdentity %></i></p>
                <asp:Image ImageUrl="<%#: Item.ImgUrl %>" Height="300" runat="server" />
            </div>
        </ItemTemplate>
    </asp:FormView>

    <div class="back-link">
        <a href="/superheroes/">Back to Superheroes List</a>
    </div>
</asp:Content>
