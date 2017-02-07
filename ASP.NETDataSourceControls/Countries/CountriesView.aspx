<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountriesView.aspx.cs" Inherits="Countries.CountriesView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:ListBox ID="ListBoxContinents" runat="server" DataSourceID="EntityDataSource1" DataTextField="Name" DataValueField="Id"></asp:ListBox>
            <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=EarthEntities" DefaultContainerName="EarthEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Continents" EntityTypeFilter="Continents">
            </asp:EntityDataSource>
            <asp:GridView ID="GridViewCountries" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="EntityDataSourceCountries">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Continents.Name" HeaderText="Continent" SortExpression="ContinentId" />
                </Columns>
            </asp:GridView>
            <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server" ConnectionString="name=EarthEntities" DefaultContainerName="EarthEntities" Include="Continents" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Countries" EntityTypeFilter="Countries">
            </asp:EntityDataSource>
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="EntityDataSourceCities" InsertItemPosition="LastItem">
                <AlternatingItemTemplate>
                    <li style="background-color: #FFFFFF;color: #284775;">
                        Name:
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        Country:
                        <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("Countries.Name") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <li style="background-color: #999999;">
                        Name:
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        Country:
                        <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%# Bind("Countries.Name") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </li>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    No data was returned.
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <li style="">
                        Name:
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        Country:
                        <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%# Bind("Countries.Name") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </li>
                </InsertItemTemplate>
                <ItemSeparatorTemplate>
                    <br />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <li style="background-color: #E0FFFF;color: #333333;">
                        Name:
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        Country:
                        <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("Countries.Name") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <li style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                        Name:
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        Country:
                        <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("Countries.Name") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:EntityDataSource ID="EntityDataSourceCities" runat="server" Include="Countries" ConnectionString="name=EarthEntities" DefaultContainerName="EarthEntities" EnableFlattening="False" EntitySetName="Cities" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
            </asp:EntityDataSource>
        </div>
    </form>
</body>
</html>
