<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Administrador.aspx.cs" Inherits="Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <style type="text/css">
        html {
            background-color: lightseagreen;
        }
        #TextArea1 {
            height: 320px;
            width: 562px;
        }
        body{
            background-color: lightgrey;
            text-align:center;
            margin:0 1612px 35px 429px;
            width: 515px;
            height: 485px;
        }
        #contenedor{
            margin: 0 auto;
            text-align:left;
            width:100%;
        }
    </style>
<body>
    <form id="form1" runat="server">
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <IMG SRC="Imagenes\Administrador.png" WIDTH=90 HEIGHT=90 BORDER=2 VSPACE=3 HSPACE=3 ALT="Christian">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button6" runat="server" Text="Cerrar Sesion" OnClick="Button6_Click" />
&nbsp;<H1>  Administrador  </H1>
        
        <div>
            
        </div>
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
            <asp:Label ID="Label1" runat="server" Text="ABC de Usuarios"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Ir" OnClick="Button1_Click" />
            
        <p>
            <asp:Label ID="Label2" runat="server" Text="ABC de Juego"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Ir" OnClick="Button2_Click" />

        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="ABC de Contactos"></asp:Label>
            <asp:Button ID="Button5" runat="server" Text="Ir" OnClick="Button5_Click" />

        </p>
            <asp:Label ID="Label3" runat="server" Text="Carga de Datos"></asp:Label>
            <asp:Button ID="Button3" runat="server" Text="Ir" OnClick="Button3_Click" />
        <p>
        <asp:Label ID="Label4" runat="server" Text="Ver Reportes"></asp:Label>
        <asp:Button ID="Button4" runat="server" Text="Ir" OnClick="Button4_Click" />
        
        </p>
        
    </form>
</body>
</html>
