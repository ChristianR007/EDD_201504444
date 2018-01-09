using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class juegoABC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        // Agregar jugador
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        metodos.AgregarJugadores(TextBox1.Text.ToString(), TextBox2.Text.ToString(), TextBox3.Text.ToString(), TextBox4.Text.ToString(), TextBox5.Text.ToString(), TextBox6.Text.ToString());
        Image1.ImageUrl = "EDD\\juegos.png";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Modificar jugador
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        metodos.ModificarJugadores(TextBox7.Text.ToString(), TextBox8.Text.ToString(), TextBox9.Text.ToString(), TextBox10.Text.ToString(), TextBox11.Text.ToString(), TextBox12.Text.ToString(), TextBox13.Text.ToString());
        Image1.ImageUrl = "EDD\\juegos.png";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox13.Text = "";
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // Elimincar jugador
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        metodos.EliminarJugadores(TextBox14.Text.ToString(), TextBox15.Text.ToString());
        TextBox14.Text = "";
        TextBox15.Text = "";
    }
}