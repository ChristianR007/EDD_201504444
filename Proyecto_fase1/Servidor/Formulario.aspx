<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formulario.aspx.cs" Inherits="Formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <style type="text/css">

        html {
            background-color: black;
        }
        body {
            background-color: steelblue;
            height: 489px;
        }

        #TextArea1 {
            height: 320px;
            width: 562px;
        }

    </style>

<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
            </p>
        <asp:TextBox ID="TextBox1" runat="server" Height="305px" Width="586px"></asp:TextBox>
    </form>
</body>
</html>
