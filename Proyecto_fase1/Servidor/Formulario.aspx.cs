using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        ServiceReference2.ServiceSoapClient metodos = new ServiceReference2.ServiceSoapClient();

        //Label1.Text = metodos.Prueba();
        TextBox1.Text = metodos.CargaMaestra("usuarios");
        TextBox1.Text = metodos.CargaMaestra("juegos");
        TextBox1.Text = metodos.CargaMaestra("tablero");

        //Response.Redirect("Login.aspx");
    }
}