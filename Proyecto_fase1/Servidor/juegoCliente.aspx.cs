using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class juegoCliente : System.Web.UI.Page
{
    ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
    public static string usuario = "";
    public static string tamX = "";
    public static string tamY = "";
    public static int variante = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public static int uSeg = 0;
    public static int dSeg = 0;
    public static int uMin = 0;
    public static int dMin = 0;
    public static string tCronometroLocal = "";
    public static string tCronometroTope = "";
    public static bool banderaCronometro = false;
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (banderaCronometro) {
            if (tCronometroLocal == tCronometroTope) // Aca se indicara en consola que se acabo el juego
            {
                Label9.Text = "Tiempo: " + tCronometroLocal + " ¡ TERMINO JUEGO !";
                banderaCronometro = false;
            }
            else
            {
                if (uMin == 9)
                {
                    uSeg = 0;
                    dSeg = 0;
                    uMin = 0;
                    dMin++;
                    tCronometroLocal = (dMin).ToString() + (uMin).ToString() + ":" + (dSeg).ToString() + (uSeg).ToString();
                    Label9.Text = "Tiempo: " + tCronometroLocal;
                }
                else
                {
                    if (dSeg == 6)
                    {
                        uSeg = 0;
                        dSeg = 0;
                        uMin++;
                        tCronometroLocal = (dMin).ToString() + (uMin).ToString() + ":" + (dSeg).ToString() + (uSeg).ToString();
                        Label9.Text = "Tiempo: " + tCronometroLocal;
                    }
                    else
                    {
                        if (uSeg == 10)
                        {
                            uSeg = 0;
                            dSeg++;
                            tCronometroLocal = (dMin).ToString() + (uMin).ToString() + ":" + (dSeg).ToString() + (uSeg).ToString();
                            Label9.Text = "Tiempo: " + tCronometroLocal;
                        }
                        else
                        {
                            tCronometroLocal = (dMin).ToString() + (uMin).ToString() + ":" + (dSeg).ToString() + (uSeg).ToString();
                            Label9.Text = "Tiempo: " + tCronometroLocal;
                        }
                        uSeg++;
                    }
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e) // Mover
    {
        
    }

    protected void Button2_Click(object sender, EventArgs e) // Atacar
    {
        
    }
    
    protected void Button3_Click1(object sender, EventArgs e) // Inicio de Juego
    {
        string cadenaJuegoCC = "";
        string parametros = "";
        char[] delimitador = { ',' };
        cadenaJuegoCC = metodos.retornoCadenaJuegoCompleto();
        string[] dat = cadenaJuegoCC.Split(delimitador);
        /*
        [0] Nickname1 = dat[0];
        [1] Nickname2 = dat[1];
        [2] Naves Nivel 1 = dat[2];
        [3] Naves Nivel 2 = dat[3];
        [4] Naves Nivel 3 = dat[4];
        [5] Naves Nivel 4 = dat[5];
        [6] TamaÃ±o X = dat[6];
        [7] TamaÃ±o Y= dat[7];
        [8] "Variante (1 = normal, 2 = tiempo, 3=base)" = dat[8];
        [9] TiempoTextBox10.Text = dat[9];
        */
        // ----------------------------------------------------------------------------------------------------------- Muestra en pantalla los parametros
        
        parametros = "Parametros de Juego:      | ";
        parametros += dat[0].ToString() + " vs  " + dat[1].ToString() + " |     | Tablero (" + dat[6].ToString() + ", " + dat[7].ToString() + ") |      | Juego ";
        var ascii = dat[8].ToCharArray();
        if ((ascii[0] == 49)|| (ascii[1] == 49))
        {
            variante = 1;
            parametros += "Normal";
        }
        else if (ascii[8] == 50|| ascii[1] == 50)
        {
            variante = 2;
            parametros += "Con Tiempo de: " + dat[9].ToString();
            tCronometroTope = dat[9].ToString();
            banderaCronometro = true;
        }
        else if (ascii[0] == 51 || ascii[1] ==51)
        {
            variante = 3;
            parametros += "de Base";
        }
        else {
            variante = 0;
            parametros += "No especificado";
        }

        Label1.Text = parametros + " |      ";

        // ------------------------------------------------------------------------------------------------------------ Guarda Nombre de Usuarios para consola
        usuario = metodos.retornoNombreUsuario1();
        // ---------------------------------------------------------------------------------------------------------------------------- LLena Listado de Naves
        //TextBox1.Text = DropDownList1.SelectedItem.Text;
        //DropDownList1.Items.Clear();
        
    }
}