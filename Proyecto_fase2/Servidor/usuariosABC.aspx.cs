using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usuariosABC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        // Agregar usuario
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        metodos.AgregarUsuario(TextBox1.Text.ToString(), TextBox2.Text.ToString(), TextBox3.Text.ToString(), TextBox4.Text.ToString().ToString());
        Image1.ImageUrl = "EDD\\usuarios.png";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Modificar Usuario
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        metodos.ModificarUsuario(TextBox5.Text.ToString(), TextBox6.Text.ToString(), TextBox7.Text.ToString(), TextBox8.Text.ToString(), TextBox9.Text.ToString().ToString());
        Image1.ImageUrl = "EDD\\usuarios.png";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // Eliminar Usuario
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        metodos.EliminarUsuario(TextBox10.Text.ToString());
        Image1.ImageUrl = "EDD\\usuarios.png";
        TextBox10.Text = "";
    }
}