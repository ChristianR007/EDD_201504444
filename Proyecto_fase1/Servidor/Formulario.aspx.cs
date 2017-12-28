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
        ServiceReference1.ServiceSoapClient miWebserv = new ServiceReference1.ServiceSoapClient();
        Label1.Text = miWebserv.Prueba();
        Response.Redirect("Login.aspx");
    }
}