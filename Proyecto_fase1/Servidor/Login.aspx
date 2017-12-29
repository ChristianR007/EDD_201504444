<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>      Login     </title>
</head>
<IMG SRC="C:\Users\Christian\Desktop\login.jpg" WIDTH=90 HEIGHT=90 BORDER=2 VSPACE=3 HSPACE=3 ALT="Christian">
    <style type="text/css">

        html {
            background-color: black;
        }

        #TextArea1 {
            height: 320px;
            width: 562px;
        }
        body{
            background-color: lightsteelblue;
            text-align:center;
            margin:0 1612px 0 434px;
            width: 432px;
            height: 404px;
        }
        #contenedor{
            margin: 0 auto;
            text-align:left;
            width:100%;
        }

    </style>
<body>
    <H1>Login</H1>
    <form id="form1" align="center" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre:     "></asp:Label>
        </div>
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="201px"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Contraseña:     "></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Width="197px"></asp:TextBox>
        </p>
        <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="Ingresar" />
        </p>
    </form>
</body>
</html>
