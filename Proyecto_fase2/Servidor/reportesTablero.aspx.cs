using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class reportesTablero : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Nivel 1
        Image1.ImageUrl = "EDD\\nivel1.png";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // Nivel 2
        Image2.ImageUrl = "EDD\\nivel2.png";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Nivel 3
        Image3.ImageUrl = "EDD\\nivel3.png";
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // Nivel 4
        Image4.ImageUrl = "EDD\\nivel4.png";
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        // Arbol de Usuarios
        Image5.ImageUrl = "EDD\\usuarios.png";
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        // Arbol de Usuarios Espejo
        Image5.ImageUrl = "EDD\\juegos.png";
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        // Arbol Espejo
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        metodos.espejo();
        Image6.ImageUrl = "EDD\\espejo.png";
    }
    
    protected void Button9_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrador.aspx");
    }

    protected void Button8_Click1(object sender, EventArgs e)
    {
        // image 7
        Image7.ImageUrl = "EDD\\contactos.png";
    }
}