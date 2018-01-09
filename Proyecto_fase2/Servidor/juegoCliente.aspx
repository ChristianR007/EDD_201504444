<%@ Page Language="C#" AutoEventWireup="true" CodeFile="juegoCliente.aspx.cs" Inherits="juegoCliente" %>

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

        #TextArea1 {
            height: 267px;
            width: 283px;
            margin-bottom: 0px;
        }
        body{
            background-color: ghostwhite;
            margin:0 1612px 0 4px;
            width: 1340px;
            height: 651px;
        }
        #contenedor{
            margin: 0 auto;
            text-align:left;
            width:100%;
        }

        .auto-style1 {
            width: 1038px;
        }
        
    </style>
<body>
    
    <p></p>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
    <table style="height: 660px; width: 1344px">    
        <asp:Label ID="Label1" runat="server" Text="Parametros de Juego: "></asp:Label>                         
        <asp:Button ID="Button3" runat="server" Text="Inicio" OnClick="Button3_Click1" />
        <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="800">
            </asp:Timer>
        <tr> 
        <td>
        <asp:Panel ID="Panel1" runat="server" BorderColor ="Black" BackColor="LightGray" Height="585px" Width="1038px">
            
            Satelites&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Aviones<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image1" runat="server" Height="237px" Width="409px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image3" runat="server" Height="237px" Width="409px" />
    <p>
        Barcos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Submarinos</p>
            &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image2" runat="server" Height="237px" Width="409px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image4" runat="server" Height="237px" Width="409px" />
        </asp:Panel>
        </td>
        <td class="auto-style1"><asp:Panel ID="Panel2" runat="server" BorderColor ="Black" BackColor="LightGray" Height="580px" Width="293px">
            <asp:UpdatePanel ID="UpdatePanel1"   runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label ID="Label9" runat="server" Font-Size="Large" Text=" "></asp:Label>
                
                
            </ContentTemplate>
        </asp:UpdatePanel>
            &nbsp;&nbsp;<br />
            &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            &nbsp;<asp:Label ID="Label2" runat="server" Text="Movimientos de Nave"></asp:Label>
            &nbsp;<br />
            &nbsp;<asp:Label ID="Label3" runat="server" Text="Coordenada en X"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
&nbsp;<asp:Label ID="Label4" runat="server" Text="Coordenada en Y"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="MOVER" OnClick="Button1_Click" style="height: 26px" />
            <br />
            <br />
            &nbsp;<asp:Label ID="Label5" runat="server" Text="Coordenada en X "></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            &nbsp;<asp:Label ID="Label6" runat="server" Text="Coordenada en Y "></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            &nbsp;<asp:Label ID="Label7" runat="server" Text="Nivel"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="ATACAR" OnClick="Button2_Click" />
            <br />
            <br />
            &nbsp;<asp:Label ID="Label8" runat="server" Text="CONSOLA"></asp:Label>
            <br />
            <br />
            <textarea id="TextArea1" runat="server" name="S1"></textarea></asp:Panel>
        </td>
        </tr>
    </table>
    </div>
    </form>
    
</body>
</html>
