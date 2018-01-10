using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuarios : System.Web.UI.Page
{
    ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (metodos.retornoNombreUsuario1() == "x")
        {
            Label2.Text = " ";
        }
        else {
            Label2.Text = "Bienvenido " + metodos.retornoNombreUsuario1();
        }
        
    }
    
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        int cuantos = metodos.retornoConectadoUsuario1() + metodos.retornoConectadoUsuario2();
        Label1.Text = "Contectados: " + cuantos;
        if (cuantos == 1)
        {
            Label3.Text = metodos.retornoNombreUsuario1();
            Image1.ImageUrl = "Imagenes\\conectado.png";
        }
        else if(cuantos ==2) {
            Label3.Text = metodos.retornoNombreUsuario1();
            Image1.ImageUrl = "Imagenes\\conectado.png";
            Label4.Text = metodos.retornoNombreUsuario2();
            Image2.ImageUrl = "Imagenes\\conectado.png";
        }
               
    }
    public static bool banderaDobleAbrir = false;
    protected void Button1_Click(object sender, EventArgs e)
    {
        string linea = metodos.retornoCadenaModoJuego();
        int cuantasLineasHay = metodos.retornoCantidadModoJuego();
        char[] delimitador2 = { ';' };
        for (int x = 0; x < cuantasLineasHay; x++)
        {
            string[] dato = linea.Split(delimitador2);
            DropDownList1.Items.Add(new ListItem(dato[x], x.ToString(), true));
        }        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // [0]Nickname1, [1]Nickname2, [2]Naves Nivel 1, [3]Naves Nivel 2,	[4]Naves Nivel 3, [5]Naves Nivel 4, 
        // [6]TamaÃ±o X, [7]TamaÃ±o Y, [8]"Variante (1 = normal, 2 = tiempo, 3=base)", [9]Tiempo
        char[] delimitador = { ',' };
        string[] dat = DropDownList1.SelectedItem.Text.Split(delimitador);
        
        TextBox1.Text = dat[0];
        TextBox2.Text = dat[1];
        TextBox3.Text = dat[2];
        TextBox4.Text = dat[3];
        TextBox5.Text = dat[4];
        TextBox6.Text = dat[5];
        TextBox7.Text = dat[6];
        TextBox8.Text = dat[7];
        TextBox9.Text = dat[8];
        TextBox10.Text = dat[9];

        int cuantos = metodos.retornoConectadoUsuario1() + metodos.retornoConectadoUsuario2();
        
        string usuario2 = "";

        if ((metodos.retornoNombreUsuario1() == TextBox1.Text) || metodos.retornoNombreUsuario1() == TextBox2.Text)
        {
            if (metodos.retornoNombreUsuario1() == TextBox1.Text)
            {
                usuario2 = TextBox2.Text;
            }
            else
            {
                usuario2 = TextBox1.Text;
            }

            if (cuantos == 2)
            {
                string Usuario2Espacio = " "+usuario2;
                if ( usuario2 == metodos.retornoNombreUsuario2() || Usuario2Espacio == metodos.retornoNombreUsuario2() || (banderaDobleAbrir = true))
                { 
                    Label15.Font.Size = 20;
                    Label15.Font.Bold = true;
                    Label15.Text = "¡ Puede Iniciar El Juego !";
                    Button3.Visible = true;
                }
                else {
                    banderaDobleAbrir = true;
                    Label15.Text = "¡ Su Oponente no esta conectado !";
                }
            }
            else {
                Label15.Text = "¡ No Hay Otro Usuario Conectado !";
            }

        }
        else {
            Label15.Text = "¡ No Apareces tu en Juego !";
        }

        // DropDownList1.SelectedItem.Text // retorna el seleccionado
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        char[] delimitador = { ',' };
        string[] dat = DropDownList1.SelectedItem.Text.Split(delimitador);
        string enviarCuerpojuego = "";
        enviarCuerpojuego = TextBox1.Text + ",";
        enviarCuerpojuego += TextBox2.Text + ",";
        enviarCuerpojuego += TextBox3.Text + ",";
        enviarCuerpojuego += TextBox4.Text + ",";
        enviarCuerpojuego += TextBox5.Text + ",";
        enviarCuerpojuego += TextBox6.Text + ",";
        enviarCuerpojuego += TextBox7.Text + ",";
        enviarCuerpojuego += TextBox8.Text + ",";
        enviarCuerpojuego += TextBox9.Text + ",";
        enviarCuerpojuego += TextBox10.Text;
        metodos.guardaCadenaJuegoCompleto(enviarCuerpojuego);
        metodos.GuardaSiYaInicioJuego();
        Response.Redirect("juegoCliente.aspx");
    }
}