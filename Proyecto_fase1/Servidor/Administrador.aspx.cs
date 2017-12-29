using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // .ImageUrl = "C:\\Users\\Christian\\Desktop\\Administrador.png";


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("usuariosABC.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("juegoABC.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("cargaDeDatos.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("reportesTablero.aspx");
    }
}