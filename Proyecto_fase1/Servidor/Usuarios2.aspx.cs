using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuarios2 : System.Web.UI.Page
{
    ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (metodos.retornoNombreUsuario2() == "x")
        {
            Label2.Text = " ";
        }
        else
        {
            Label2.Text = "Bienvenido " + metodos.retornoNombreUsuario2();
        }
        
    }

    public static int cont = 0;
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //int cuantos = metodos.retornoConectadoUsuario1() + metodos.retornoConectadoUsuario2();
        Label1.Text = "Contectados: " + 2;

        Label3.Text = metodos.retornoNombreUsuario1();
        Image1.ImageUrl = "Imagenes\\conectado.png";
        Label4.Text = metodos.retornoNombreUsuario2();
        Image2.ImageUrl = "Imagenes\\conectado.png";
        Label6.Font.Size = 23;
        Label6.Font.Bold = true;
        if (metodos.retornaSiYaInicioJuego() == 1)
        {
            Label6.Font.Size = 30;
            Label6.Font.Bold = true;
            Button1.Font.Size = 20;
            Button1.Font.Bold = true;
            Label6.Text = "¡ YA PUEDES INICIAR EL JUEGO CON " + metodos.retornoNombreUsuario1();
            Button1.Visible = true;
        }
        else {
            if (cont == 0)
            {
                Label6.Text = "Esperando";
                cont++;
            }
            else if (cont == 1)
            {
                Label6.Text = "Esperando .";
                cont++;
            }
            else if (cont == 2)
            {
                Label6.Text = "Esperando . .";
                cont++;
            }
            else if (cont == 3)
            {
                Label6.Text = "Esperando . . .";
                cont = 0; ;
            }
        }
        
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
                
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //Response.Redirect("juegoCliente2.aspx");
    }



    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("juegoCliente2.aspx");
    }
}