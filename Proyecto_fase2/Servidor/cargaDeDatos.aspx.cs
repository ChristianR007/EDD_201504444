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
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        string carga = metodos.CargaMaestra("usuarios");
        bool soloEnvia = metodos.yaHayUsuarios();

        //string FilePath = FileUpload1.PostedFile.FileName;
        //Label1.Text = FilePath;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // tablero
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        string carga = metodos.CargaMaestra("tablero");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //juegos
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        string carga = metodos.CargaMaestra("juegos");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // juegoActual
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        string carga = metodos.CargaMaestra("juegoActual");
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrador.aspx");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        // contactos
        ServiceReference1.ProyectoEDDSoapClient metodos = new ServiceReference1.ProyectoEDDSoapClient();
        string carga = metodos.CargaMaestra("contactos");
    }
}