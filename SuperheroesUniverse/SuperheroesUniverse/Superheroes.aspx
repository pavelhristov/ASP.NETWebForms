<%@ Page Title="Superheroes List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Superheroes.aspx.cs" Inherits="SuperheroesUniverse.Superheroes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:TextBox ID="TextBoxSearch" runat="server" placeholder="Search by name or secret identity."></asp:TextBox>
        <asp:LinkButton runat="server" ID="LinkButtonSearch" Text="Search" OnClick="LinkButtonSearch_Click"></asp:LinkButton>
    </div>
    <asp:ListView runat="server" ID="ListViewSuperheroes" ItemType="SuperheroesUniverse.Data.Models.Superhero" SelectMethod="ListViewSuperheroes_GetData">
        <%--<GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>--%>
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
</asp:Content>
