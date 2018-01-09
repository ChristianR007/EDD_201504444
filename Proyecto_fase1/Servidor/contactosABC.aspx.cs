using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contactosABC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        // Agregar Contacto
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        metodos.AgregarContacto(TextBox1.Text.ToString(), TextBox2.Text.ToString(), TextBox3.Text.ToString(), TextBox4.Text.ToString());
        Image1.ImageUrl = "EDD\\contactos.png";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Modificar Contacto 16
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        metodos.ModificarContacto(TextBox7.Text.ToString(), TextBox8.Text.ToString(), TextBox9.Text.ToString(), TextBox10.Text.ToString(), TextBox16.Text.ToString());
        Image1.ImageUrl = "EDD\\contactos.png";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // Eliminar Contacto
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        metodos.EliminarContacto(TextBox14.Text.ToString(), TextBox15.Text.ToString());
        Image1.ImageUrl = "EDD\\contactos.png";
        TextBox14.Text = "";
        TextBox15.Text = "";
    }
}