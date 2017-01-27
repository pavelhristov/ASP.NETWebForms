<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HTMLServerControls.aspx.cs" Inherits="Random.HTMLServerControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="InputMinimum" type="text" runat="server"/>
        <input id="InputMaximum" type="text" runat="server"/>
        <input id="ButtonRandom" type="button" value="Random" runat="server" onserverclick="ButtonRandom_OnClick" />
        <div>
            <span id="SpanResult" runat="server"></span>
        </div>
    </div>
    </form>
</body>
</html>
