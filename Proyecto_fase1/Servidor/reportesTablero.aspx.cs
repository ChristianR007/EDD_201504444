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
        ServiceReference2.ServiceSoapClient metodos = new ServiceReference2.ServiceSoapClient();
        metodos.nivel1();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // Nivel 2
        ServiceReference2.ServiceSoapClient metodos = new ServiceReference2.ServiceSoapClient();
        metodos.nivel2();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Nivel 3
        ServiceReference2.ServiceSoapClient metodos = new ServiceReference2.ServiceSoapClient();
        metodos.nivel3();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // Nivel 4
        ServiceReference2.ServiceSoapClient metodos = new ServiceReference2.ServiceSoapClient();
        metodos.nivel4();
    }
}