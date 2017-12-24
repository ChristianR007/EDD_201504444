using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tarea3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        ABB nuevoArbol = new ABB();
        private void button1_Click(object sender, EventArgs e)
        {
            nuevoArbol.Insertar( richTextBox1.Text );

            StreamWriter archivo = new StreamWriter("Arbol.txt");
            string d = "digraph G {\n" + nuevoArbol.dotArbol() + "}\n\n";
            archivo.WriteLine( d );
            archivo.Close();
            string cuerpo;
            cuerpo = "dot -Tpng Arbol.txt -o Arbol.png";
            System.Diagnostics.ProcessStartInfo dot = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + cuerpo);
            System.Diagnostics.Process.Start(dot);
            
            richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "Recorrido en Preorden:\n" + nuevoArbol.preorden() + "\n\nRecorrido en Enorden:\n" + nuevoArbol.enorden() + "\n\nRecorrido en Postorden:\n" + nuevoArbol.postorden();

        }
    }
}
