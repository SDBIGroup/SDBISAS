<%@ Page Language="C#" AutoEventWireup="true" CodeFile="import.aspx.cs" Inherits="Test_import" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="fuload" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Btn1_Click" />
        <br />
        <asp:Label ID="lbmsg" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
