<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TODOListPage.aspx.cs" Inherits="TODOListApp.TODOListPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownListCategory" runat="server" DataSourceID="EntityDataSourceCategories" DataTextField="Name" DataValueField="Id" AutoPostBack="true"></asp:DropDownList>

            <asp:EntityDataSource ID="EntityDataSourceCategories" runat="server" ConnectionString="name=TODOListEntities" DefaultContainerName="TODOListEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Categories" EntityTypeFilter="Categories">
            </asp:EntityDataSource>

        </div>
        <asp:EntityDataSource ID="EntityDataSourceTODOs" runat="server" Include="Categories" ConnectionString="name=TODOListEntities" DefaultContainerName="TODOListEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="TODOs" EntityTypeFilter="TODOs"
            Where="it.CategoryId=@Id">
            <WhereParameters>
                <asp:ControlParameter ControlID="DropDownListCategory" DbType="Int32" Name="Id" DefaultValue="1" />
            </WhereParameters>
        </asp:EntityDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="EntityDataSourceTODOs">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Body" HeaderText="Description" SortExpression="Body" />
                <asp:BoundField DataField="Last_Edited" HeaderText="Last Edited" SortExpression="Last_Edited" ReadOnly="true" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:DetailsView ID="DetailsViewTODO" runat="server"
            DataSourceID="EntityDataSourceTODOs" AutoGenerateRows="False" ItemType="TODOListApp.TODOs"
            DefaultMode="Insert">
            <Fields>
                <asp:BoundField DataField="Title" HeaderText="Title"
                    SortExpression="Title" />
                <asp:BoundField DataField="Body" HeaderText="Description"
                    SortExpression="Body" />
                <%--<asp:BoundField DataField="CategoryId" NullDisplayText="<%=: int.Parse(this.DropDownListCategory.SelectedValue) %>" ReadOnly="True" Visible="false" />
                <asp:BoundField DataField="Last_Edited" NullDisplayText="<%=: DateTime.Now %>" ReadOnly="True" Visible="false" />--%>
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </form>
</body>
</html>
