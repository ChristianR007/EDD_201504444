using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        // Administrador por defecto
        if ((TextBox1.Text == "Admin") && (TextBox2.Text == "Admin"))
        {
            Response.Redirect("Administrador.aspx");
        }
        else {
            if (TextBox1.Text != "Admin") {
                TextBox1.Text = "Nombre Incorrectos";
                TextBox2.Text = "";
            } else if (TextBox2.Text != "Admin") {
                TextBox2.Text = "Contraseña Incorrectos";
                TextBox1.Text = "";
            }
            
        }
        
    }
}