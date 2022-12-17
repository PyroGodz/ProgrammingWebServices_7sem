<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Client.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <textarea runat="server" id="content" cols="20" rows="2"></textarea>

            <asp:Button runat="server" ID="request" OnClick="request_Click" Text="request" />  
        </div>
        <div>
            <textarea runat="server" id="content2" cols="20" rows="2"></textarea>

            <asp:Button runat="server" ID="request2" OnClick="request2_Click" Text="request" />  
        </div>
    </form>
</body>
</html>
