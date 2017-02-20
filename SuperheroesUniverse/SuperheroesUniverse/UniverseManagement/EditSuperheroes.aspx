<%@ Page Title="Edit Superheroes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSuperheroes.aspx.cs" Inherits="SuperheroesUniverse.UniverseManagement.EditSuperheroes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>PESHO !</h1>
    <asp:ListView ID="ListViewEditSuperheroes" runat="server" ItemType="SuperheroesUniverse.Data.Models.Superhero" InsertItemPosition="None"
        SelectMethod="ListViewEditSuperheroes_GetData"
        UpdateMethod="ListViewEditSuperheroes_UpdateItem"
        DeleteMethod="ListViewEditSuperheroes_DeleteItem"
        InsertMethod="ListViewEditSuperheroes_InsertItem"
        DataKeyNames="Id">

        <LayoutTemplate>
            <table class="gridview" border="1" id="MainContent_GridViewCategories" style="border-collapse: collapse;">
                <thead>
                    <tr>
                        <th scope="col">
                            <asp:LinkButton Text="Name" runat="server" ID="LinkButtonSortByCategory" CommandName="Sort" CommandArgument="Name" />
                        </th>
                        <th scope="col">
                            <asp:LinkButton Text="Secret identity" runat="server" ID="LinkButton1" CommandName="Sort" CommandArgument="SecretIdentity" />
                        </th>
                        <th scope="col">
                            <asp:Label Text="Image location" runat="server"></asp:Label>
                        </th>
                        <th scope="col">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    <tr>
                        <td colspan="4">
                            <asp:DataPager runat="server" ID="DataPagerCategories" PagedControlID="ListViewEditSuperheroes" PageSize="5">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                            </asp:DataPager>
                            <asp:LinkButton runat="server" ID="LinkButtonInsert" Text="Insert" OnClick="LinkButtonInsert_Click" CssClass="btn btn-primary pull-right"></asp:LinkButton>
                        </td>
                    </tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.Name %></td>
                <td><%#: Item.SecretIdentity %></td>
                <td><%#: Item.ImgUrl %></td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Edit" CommandName="Edit" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Delete" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxSecretIdentity" Text="<%#: BindItem.SecretIdentity %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" Width="100%" ID="TextBoxImgUrl" Text="<%#: BindItem.ImgUrl %>" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Save" CommandName="Update" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxSecretIdentity" Text="<%#: BindItem.SecretIdentity %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" Width="100%" ID="TextBoxImgUrl" Text="<%#: BindItem.ImgUrl %>" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Insert" CommandName="Insert" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" OnClick="LinkButtonDelete_Click" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>
    <div class="back-link">
        <a href="/superheroes">Back to Superheroes</a>
    </div>
</asp:Content>
