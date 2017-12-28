using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;

[WebService(Namespace = "http://hola")]
//tempuri.org/
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }

    static ABB nuevoArbol = new ABB();
    [WebMethod]
    public string Prueba()
    {
        string x = Environment.MachineName + " <- Nombre de maquina";
        return x;
    }

    // Crea Imagen de archivo Dot
    public void crearPng() {
        //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
        //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
        //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
        string comando = "dot -Tpng C:\\Users\\Christian\\Desktop\\Graficas\\Arbol.dot -o C:\\Users\\Christian\\Desktop\\Graficas\\Arbol.png";
        System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + comando);
        // Indicamos que la salida del proceso se redireccione en un Stream
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
        procStartInfo.CreateNoWindow = false;
        //Inicializa el proceso
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo = procStartInfo;
        proc.Start();
        //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
        string result = proc.StandardOutput.ReadToEnd();
        //Muestra en pantalla la salida del Comando
        //Console.WriteLine(result);
    }

}