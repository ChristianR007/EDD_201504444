<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cargaDeDatos.aspx.cs" Inherits="cargaDeDatos" %>

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
    <H1>Carga de Datos</H1>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            <H4>Carga de Usuarios</H4>
            <asp:Button ID="Button1" runat="server" Text="Cargar" OnClick="Button1_Click" />
        </p>
        <p>
            <H4>Carga de Tablero</H4>
            <asp:Button ID="Button2" runat="server" Text="Cargar" OnClick="Button2_Click" />
        </p>
        <p>
            <H4>Carga de Juegos</H4>
            <asp:Button ID="Button3" runat="server" Text="Cargar" OnClick="Button3_Click" />
        </p>
        <p>
            <H4>Carga de juegoActual</H4>
            <asp:Button ID="Button4" runat="server" Text="Cargar" OnClick="Button4_Click" />
        </p>
        
    </form>
</body>
</html>
