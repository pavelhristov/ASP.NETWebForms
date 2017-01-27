<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="StudentsAndCourses.RegisterStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Faculty Number"></asp:Label>
        <asp:TextBox ID="TextBoxFacultyNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="University"></asp:Label>
        <asp:DropDownList ID="DropDownUniversity" runat="server">
            <asp:ListItem Value="SU">SU</asp:ListItem>
            <asp:ListItem Value="TU-Sofia">TU-Sofia</asp:ListItem>
            <asp:ListItem Value="other uni">other uni</asp:ListItem>
            <asp:ListItem Value="unnamed uni">unnamed uni</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label runat="server" Text="Specialty"></asp:Label>
        <asp:DropDownList ID="DropDownSpeciality" runat="server">
            <asp:ListItem Value="Mathematics">Mathematics</asp:ListItem>
            <asp:ListItem Value="Informatics">Informatics</asp:ListItem>
            <asp:ListItem Value="Coding">Coding</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:CheckBoxList ID="Courses" runat="server">
            <asp:ListItem Value="Calculus">Calculus</asp:ListItem>
            <asp:ListItem Value="Complex Calculus">Complex Calculus</asp:ListItem>
            <asp:ListItem Value="Linear Algebra">Linear Algebra</asp:ListItem>
        </asp:CheckBoxList>
        
        <asp:Button ID="ButtonSend" runat="server" OnClick="ButtonSend_Click" Text="Register" />
    </div>
    <hr />
    <div>
        <asp:Label ID="LabelResult" runat="server"></asp:Label>
        <div id="RegistrationResult" runat="server">

        </div>
    </div>
    </form>
</body>
</html>
