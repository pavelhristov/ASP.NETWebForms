<%@ Page Title="Superheroes List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Superheroes.aspx.cs" Inherits="SuperheroesUniverse.Superheroes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group" style="max-width: 320px">
                <asp:TextBox ID="TextBoxSearch" runat="server" placeholder="Search by name or secret identity." class="form-control"></asp:TextBox>
                <div class="input-group-btn">
                    <asp:LinkButton runat="server" ID="LinkButtonSearch" Text="Search" OnClick="LinkButtonSearch_Click" class="btn btn-default"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <asp:ListView runat="server" ID="ListViewSuperheroes" ItemType="SuperheroesUniverse.Data.Models.Superhero" SelectMethod="ListViewSuperheroes_GetData">
        <LayoutTemplate>
            <div class="col-md-12">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
            <div class="btn-group">
                <asp:DataPager runat="server" ID="DataPagerCategories" PagedControlID="ListViewSuperheroes" PageSize="2">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="False" ShowNextPageButton="False" ButtonCssClass="btn btn-default" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="False" ShowPreviousPageButton="False" ButtonCssClass="btn btn-default" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="list-group-item">
                <div class="media">
                    <div class="media-left waves-light" style="float: left; width: 100px;">
                        <asp:Image runat="server" ImageUrl="<%#: Item.ImgUrl %>" Height="100px" />
                    </div>
                    <div class="media-body" style="float: left">
                        <h2><%#: Item.Name %></h2>
                    </div>
                    <div class="media-body" style="float: right">
                        <asp:HyperLink NavigateUrl='<%# string.Format("~/superherodetails.aspx?id={0}", Item.Id) %>' runat="server" CssClass="btn btn-primary" Text='<%# "Details" %>' />
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <%--<ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>--%>
    </asp:ListView>
</asp:Content>
