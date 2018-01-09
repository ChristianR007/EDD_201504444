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
        //ServiceReference1.ServiceSoapClient metodos = new ServiceReference1.ServiceSoapClient();
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();

        //Label1.Text = metodos.Prueba();
        //metodos.crearDot("digraph G {a->b;}", "o");
        //metodos.crearPng("o");

        //Response.Redirect("Login.aspx");
    }
}