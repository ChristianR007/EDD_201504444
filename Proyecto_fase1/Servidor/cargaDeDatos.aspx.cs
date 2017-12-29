using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cargaDeDatos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // usuarios
        ServiceReference2.ServiceSoapClient metodos = new ServiceReference2.ServiceSoapClient();
        string carga = metodos.CargaMaestra("usuarios");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // tablero
        ServiceReference2.ServiceSoapClient metodos = new ServiceReference2.ServiceSoapClient();
        string carga = metodos.CargaMaestra("tablero");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //juegos
        ServiceReference2.ServiceSoapClient metodos = new ServiceReference2.ServiceSoapClient();
        string carga = metodos.CargaMaestra("juegos");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // juegoActual
        ServiceReference2.ServiceSoapClient metodos = new ServiceReference2.ServiceSoapClient();
        string carga = metodos.CargaMaestra("juegoActual");
    }
}