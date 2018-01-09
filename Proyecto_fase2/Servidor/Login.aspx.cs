using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //<IMG SRC="Imagenes\login.jpg" WIDTH=90 HEIGHT=90 BORDER=2 VSPACE=3 HSPACE=3 ALT="Christian">
        Image1.ImageUrl = "Imagenes\\login.jpg";
    }
    public static bool bandera = false;

    protected void Button1_Click(object sender, EventArgs e)
    {
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();

        if (Movil.Checked) // Opcion de Movil
        {
            /*string getLine = "Christian, Ramos";
            char[] delimitador = { ',' };
            string[] dato = getLine.Split(delimitador);
            TextBox1.Text = dato[0];
            TextBox2.Text = dato[1];
            */
            
            Label3.Text = "Selecciono Movil<br/>SI";
        }
        else {
            if ((TextBox1.Text == "Admin") && (TextBox2.Text == "Admin"))
            {
                //Label3.Text = "Bienvenido Administrador";
                Response.Redirect("Administrador.aspx");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                if (metodos.LoginyaHayUsuarios())
                {
                    if (metodos.refABB(TextBox1.Text, TextBox2.Text) == 1)
                    {
                        if (metodos.retornoConectadoUsuario1() == 0)
                        {
                            //Label3.Text = "Bienvenido " + TextBox1.Text;
                            metodos.asignandoNombre1(TextBox1.Text);
                            Response.Redirect("Usuarios.aspx");
                        }
                        else if(metodos.retornoConectadoUsuario1() ==1)
                        {
                            //Label3.Text = "Bienvenido " + TextBox1.Text;
                            metodos.asignandoNombre2(TextBox1.Text);
                            Response.Redirect("Usuarios2.aspx");
                        }
                        
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                    }
                    else
                    {
                        Label3.Text = "Nickname o Password Incorrectos";
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                    }
                }
                else
                {
                    Label3.Text = "No existen Usuarios, debe Ingresar Administrador";
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                }


            }
        }
        
        
        
    }
}