<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SuperheroesUniverse.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server" ID="ListViewFoundSuperheroes" ItemType="SuperheroesUniverse.Data.Models.Superhero" SelectMethod="ListViewFoundSuperheroes_GetData">
        <ItemTemplate>
            <div>
                <h2><%#: Item.Name %></h2>
                <p><%#: Item.SecretIdentity %></p>
                <asp:Image runat="server" ImageUrl="<%#: Item.ImgUrl %>" Height="300px" />
                <asp:HyperLink NavigateUrl='<%# string.Format("~/SuperheroDetails.aspx?id={0}", Item.Id) %>' runat="server" Text='<%# "Details" %>' />
            </div>
        </ItemTemplate>
        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
    </asp:ListView>
    
    <div class="back-link">
        <a href="/superheroes">Back to Superheroes List</a>
    </div>
</asp:Content>
