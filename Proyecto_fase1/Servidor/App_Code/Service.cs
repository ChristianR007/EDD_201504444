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
    
    [WebMethod]
    public void Prueba()
    {
        string rutaImagen = "C:\\Users\\Christian\\Desktop\\Graficas\\tablero.png";
        Process.Start(rutaImagen);      
    }
    static Cubo n1 = new Cubo();
    [WebMethod]
    public void nivel1()
    {
        string rutan1 = "C:\\Users\\Christian\\Desktop\\Graficas\\n1.png";
        Process.Start(rutan1);
    }static Cubo n2 = new Cubo();
    [WebMethod]
    public void nivel2()
    {
        string rutan2 = "C:\\Users\\Christian\\Desktop\\Graficas\\n1.png";
        Process.Start(rutan2);
    }static Cubo n3 = new Cubo();
    [WebMethod]
    public void nivel3()
    {
        string rutan3 = "C:\\Users\\Christian\\Desktop\\Graficas\\n1.png";
        Process.Start(rutan3);
    }static Cubo n4 = new Cubo();
    [WebMethod]
    public void nivel4()
    {
        string rutan4 = "C:\\Users\\Christian\\Desktop\\Graficas\\n1.png";
        Process.Start(rutan4);
    }

    string rutaUsuarios = "C:\\Users\\Christian\\Desktop\\Archivos\\usuarios.csv";
    string rutaTablero = "C:\\Users\\Christian\\Desktop\\Archivos\\tablero.csv";
    string rutaJuegos = "C:\\Users\\Christian\\Desktop\\Archivos\\juegos.csv";
    string rutaJuegoActual = "C:\\Users\\Christian\\Desktop\\Archivos\\juegoActual.csv";

    static ABB nuevoArbol = new ABB();
    static ABB nuevoA = new ABB();
    static Cubo nuevoC = new Cubo();
    

    [WebMethod]
    public string CargaMaestra(string rut)
    {
        string cuerpo = "";
        bool banderaEncabezado = false;
        string path="";
        if (rut == "usuarios")
        {
            path = (rutaUsuarios);
        }
        else if (rut == "tablero")
        {
            path = (rutaTablero);
        }
        else if (rut == "juegos")
        {
            path = (rutaJuegos);
        }
        else if (rut == "juegoActual")
        {
            path = (rutaJuegoActual);
        }
        try {
            StreamReader leer = new StreamReader(path);
            string getLine = leer.ReadLine();
            while (getLine != null) {
                if (banderaEncabezado != false) {
                    char[] delimitador = { ',' };
                    string[] dato = getLine.Split(delimitador);
                    if (rut == "usuarios")  // Insertado Completo
                    {
                        // [0]Nickname, [1]Contraseña, [2]Correo electronico, [3]"Conectado (1 si, 0 no)"
                        nuevoA.Insertar(dato[0], dato[1], dato[2], dato[3].ToString());
                        cuerpo += dato[0] + " - " + dato[1] + " - " + dato[2] + " - " + Convert.ToInt32(dato[3].ToString()) + ";\n";
                    }
                    else if (rut == "tablero")// Insertado Medio
                    {
                        // [0]jugador, [1]columna, [2]fila, [3]unidad, [4]"destruida(0 si,1 no)"
                        int queNiveles = aNivel(dato[3]);
                        if (queNiveles == 1)
                        {
                            // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                            nuevoC.ingresarAMatriz(dato[1], dato[2], dato[0], dato[3], dato[4].ToString(), dato[1], dato[2]);
                            n1.ingresarAMatriz(dato[1], dato[2], dato[0], dato[3], dato[4].ToString(), dato[1], dato[2]);
                        }
                        else if (queNiveles == 2)
                        {
                            // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                            nuevoC.ingresarAMatriz(dato[1], dato[2], dato[0], dato[3], dato[4].ToString(), dato[1], dato[2]);
                            n2.ingresarAMatriz(dato[1], dato[2], dato[0], dato[3], dato[4].ToString(), dato[1], dato[2]);
                        }
                        else if (queNiveles == 3)
                        {
                            // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                            nuevoC.ingresarAMatriz(dato[1], dato[2], dato[0], dato[3], dato[4].ToString(), dato[1], dato[2]);
                            n3.ingresarAMatriz(dato[1], dato[2], dato[0], dato[3], dato[4].ToString(), dato[1], dato[2]);
                        }
                        else if (queNiveles == 4)
                        {
                            // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                            nuevoC.ingresarAMatriz(dato[1], dato[2], dato[0], dato[3], dato[4].ToString(), dato[1], dato[2]);
                            n4.ingresarAMatriz(dato[1], dato[2], dato[0], dato[3], dato[4].ToString(), dato[1], dato[2]);
                        }
                        else {
                            // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                            nuevoC.ingresarAMatriz(dato[1], dato[2], dato[0], dato[3], dato[4].ToString(), dato[1], dato[2]);
                        }
                        
                        cuerpo += dato[0] + " - " + dato[1] + " - " + dato[2] + " - " + dato[3] + " - " + Convert.ToInt32(dato[4].ToString()) + ";\n";
                    }
                    else if (rut == "juegos") // Insertado Completo
                    {
                        // [0]Usuario Base, [1]Oponente, [2]unidades desplegadas, [3]unidades sobrevivientes, [4]Unidades Destruidas, [5]"Gano (1 si, 0 no)"
                        nuevoA.InsertarJuegos(dato[0], dato[1], dato[2], dato[3], dato[4], dato[5].ToString());
                        cuerpo += dato[0] + " - " + dato[1] + " - " + Convert.ToInt32(dato[2].ToString()) + " - " + Convert.ToInt32(dato[3].ToString()) + " - " + Convert.ToInt32(dato[4].ToString()) + " - " + Convert.ToInt32(dato[5].ToString()) + ";\n";
                    }
                    else if (rut == "juegoActual")
                    {
                        // [0]Nickname1, [1]Nickname2, [2]Naves Nivel 1, [3]Naves Nivel 2,	[4]Naves Nivel 3, [5]Naves Nivel 4, 
                        // [6]TamaÃ±o X, [7]TamaÃ±o Y, [8]"Variante (1 = normal, 2 = tiempo, 3=base)", [9]Tiempo

                        cuerpo += dato[0] + " - " + dato[1] + " - " + Convert.ToInt32(dato[2].ToString()) + " - " + Convert.ToInt32(dato[3].ToString()) + " - " + Convert.ToInt32(dato[4].ToString()) + " - " + Convert.ToInt32(dato[5].ToString()) + " - " + Convert.ToInt32(dato[6].ToString()) + " - " + Convert.ToInt32(dato[7].ToString()) + " - " + Convert.ToInt32(dato[8].ToString()) + " - " + dato[9].ToString() + ";\n";
                    }
                    
                }
                banderaEncabezado = true;
                getLine = leer.ReadLine();
            }
            leer.Close();
        }
        catch (Exception e) {
            Console.WriteLine("Exception: " + e.Message);
        }
        // Crea el dot y el png
        string cadena = "";
        if (rut == "usuarios") {
            cadena = "digraph G {\n" + nuevoA.dotArbol() + "\n}";
        }
        else if (rut == "tablero") {
            cadena = nuevoC.textoParaGraficarMatriz();
        }
        else if (rut == "juegos") {
            cadena = "digraph G {\n" + nuevoA.dotArbol() + "\n}";
        }
        else if (rut == "juegoActual") {
            //cadena = "";
        }
        crearDot(cadena, rut);
        crearPng(rut);
        return cuerpo;
    }

    [WebMethod]
    public int aNivel(string pieza)
    {
        var chars = pieza.ToCharArray();
        if ((chars[0] == 78)) // Neosatelite    --> Nivel 4 <--
        {
            return 4;
        }
        else if ((chars[0] == 66)) //Bombardero    --> Nivel 3 <--
        {
            return 3;
        }
        else if ((chars[0] == 67) && (chars[1] == 97)) //Caza    --> Nivel 3 <--
        {
            return 3;
        }
        else if ((chars[0] == 72)) //Helicoptero    --> Nivel 3 <--
        {
            return 3;
        }
        else if ((chars[0] == 70)) //Fragata     --> Nivel 2 <--
        {
            return 2;
        }
        else if ((chars[0] == 67) && (chars[1] == 114)) //Crucero    --> Nivel 2 <--
        {
            return 2;
        }
        else if ((chars[0] == 83)) //Submarino    --> Nivel 1 <--
        {
            return 1;
        }
        return 0;
    }

    [WebMethod] // Crea Imagen de archivo Dot
    public void crearPng(string nombre) {
        //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
        //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
        //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
        string comando = "dot -Tpng C:\\Users\\Christian\\Desktop\\Graficas\\"+ nombre + ".dot -o C:\\Users\\Christian\\Desktop\\Graficas\\" + nombre + ".png";
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

    [WebMethod] // Crea Imagen de archivo Dot
    public void crearDot(string cuerpo, string nombre)
    {
        TextWriter archivo;
        string ruta = "C:\\Users\\Christian\\Desktop\\Graficas\\" + nombre + ".dot";
        archivo = new StreamWriter(ruta);
        archivo.WriteLine(cuerpo);
        archivo.Close();
    }

}