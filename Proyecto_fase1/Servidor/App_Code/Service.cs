using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;

[WebService(Namespace = "http://localhost/hola", Name ="Proyecto EDD")]
//tempuri.org/
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
//[System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    static string rutaArchivos = "C:\\Users\\Christian\\Desktop\\Archivos";

    string rutaUsuarios = rutaArchivos + "\\usuarios.csv";
    string rutaTablero = rutaArchivos + "\\tablero.csv";
    string rutaJuegos = rutaArchivos + "\\juegos.csv";
    string rutaJuegoActual = rutaArchivos + "\\juegoActual.csv";
    string rutaContactos = rutaArchivos + "\\contactos.csv";
    string rutaHistorial = rutaArchivos + "\\historial.csv";

    static ABB nuevoABB = new ABB();
    static ABBespejo nuevoAE = new ABBespejo();
    static Cubo nuevoC = new Cubo();


    //------------------------------------------------------- ABC usuarios ---------------------------------------------
    //Agregar
    [WebMethod]
    public void AgregarUsuario(string nick, string pass, string correo, string conectado)
    {
        nuevoABB.Insertar(nick, pass, correo, conectado);
        string cadena;
        string ram = "";
        if (nuevoABB.ramas() >= 0)
        {
            ram = nuevoABB.ramas().ToString();
        }
        else {
            ram = "0";
        }
        cadena = "digraph G {\nlabel = \"Arbol de Usuarios\nAltura: " + nuevoABB.altura() + "\nRamas: " + ram + "\nHojas: " + nuevoABB.hojas() + "\";\n" + nuevoABB.dotArbol() + "\n}";
        crearDot(cadena, "usuarios");
        crearPng("usuarios");
    }
    //Eliminar
    [WebMethod]
    public string EliminarUsuario(string nick)
    {
        if (nuevoABB.buscarUsu(nick) == 1)
        {
            nuevoABB.eliminar(nick);

            string cadena;
            cadena = "digraph G {\nlabel = \"Arbol de Usuarios\nAltura: " + nuevoABB.altura() + "\nRamas: " + nuevoABB.ramas() + "\nHojas: " + nuevoABB.hojas() + "\";\n" + nuevoABB.dotArbol() + "\n}";
            crearDot(cadena, "usuarios");
            crearPng("usuarios");
            return "si";
        }
        return "no";
        
    }
    //Modificar
    [WebMethod]
    public string ModificarUsuario(string nick, string nuevoNombre, string nuevaPass, string nuevoCorreo, string nuevoConec)
    {
        if (nuevoABB.buscarUsu(nick) == 1) // verificar si existe
        {
            nuevoABB.modificar(nick, nuevoNombre, nuevaPass, nuevoCorreo, nuevoConec);

            string cadena;
            cadena = "digraph G {\nlabel = \"Arbol de Usuarios\nAltura: " + nuevoABB.altura() + "\nRamas: " + nuevoABB.ramas() + "\nHojas: " + nuevoABB.hojas() + "\";\n" + nuevoABB.dotArbol() + "\n}";
            crearDot(cadena, "usuarios");
            crearPng("usuarios");
            return "si";
        }
        return "no";        
    }
    //------------------------------------------------------- ABC jugadores ---------------------------------------------
    //Agregar
    [WebMethod]
    public void AgregarJugadores(string nick, string jugador, string desple, string sobre, string dest, string gano)
    {
        nuevoABB.InsertarJuegos(nick, jugador, desple, sobre, dest, gano);
        string cadena;
        cadena = "digraph G {\nlabel = \"Arbol de Usuarios y Juegos\";\n" + nuevoABB.dotArbol() + "\n}";
        crearDot(cadena, "juegos");
        crearPng("juegos");
    }
    //Eliminar
    [WebMethod]
    public void EliminarJugadores(string nick, string jugadorAElimincar)
    {
        nuevoABB.eliminarJuego(nick, jugadorAElimincar);
        string cadena;
        cadena = "digraph G {\nlabel = \"Arbol de Usuarios y Juegos\";\n" + nuevoABB.dotArbol() + "\n}";
        crearDot(cadena, "juegos");
        crearPng("juegos");
    }
    //Modificar
    [WebMethod]
    public void ModificarJugadores(string nick, string jugadorViejo, string jugadorNuevo, string desple, string sobre, string dest, string gano)
    {
        nuevoABB.modificarJuego(nick, jugadorViejo, jugadorNuevo, desple, sobre, dest, gano);
        string cadena;
        cadena = "digraph G {\nlabel = \"Arbol de Usuarios y Juegos\";\n" + nuevoABB.dotArbol() + "\n}";
        crearDot(cadena, "juegos");
        crearPng("juegos");
    }
    //-------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------- ABC Contactos ---------------------------------------------
    //Agregar
    [WebMethod]
    public void AgregarContacto(string nick, string contactoNuevo, string pass, string correo)
    {
        if (nuevoABB.verificarABB(nick) == true) // Si ya existe el nick del abb solo inserta nuevo en AVL
        {
            nuevoABB.InsertarContactos(nick, contactoNuevo, pass, correo);
        }
        else {                                  // Si no
            nuevoABB.Insertar(nick, pass, correo, "0"); // Crear nodo ABB
            nuevoABB.InsertarContactos(nick, contactoNuevo, pass, correo); // Luego inserta AVL
        }

        string cadena;
        cadena = "digraph G {\nlabel = \"Arbol de Usuarios y Contactos\";\n" + nuevoABB.dotArbol() + "\n}";
        crearDot(cadena, "contactos");
        crearPng("contactos");
    }
    //Eliminar
    [WebMethod]
    public void EliminarContacto(string nick, string contactoAElimincar)
    {
        nuevoABB.eliminarContactos(nick, contactoAElimincar);
        string cadena;
        cadena = "digraph G {\nlabel = \"Arbol de Usuarios y Contactos\";\n" + nuevoABB.dotArbol() + "\n}";
        crearDot(cadena, "contactos");
        crearPng("contactos");
    }
    //Modificar
    [WebMethod]
    public void ModificarContacto(string nick, string contactoActual, string contactoNuevo, string pass, string correo)
    {
        if (!string.IsNullOrEmpty(contactoNuevo)) // hay un dato
        {
            nuevoABB.eliminarContactos(nick, contactoActual);
            nuevoABB.InsertarContactos(nick, contactoNuevo, pass, correo);
        }
        else {
            nuevoABB.modificarContactos(nick, contactoActual, pass, correo);
        }
        string cadena;
        cadena = "digraph G {\nlabel = \"Arbol de Usuarios y Contactos\";\n" + nuevoABB.dotArbol() + "\n}";
        crearDot(cadena, "contactos");
        crearPng("contactos");
    }
    //-------------------------------------------------------------------------------------------------------------------
    [WebMethod]
    public void espejo()
    {
        string cadena;
        cadena = "digraph G {\nlabel = \"Arbol Espejo\";\n" + nuevoABB.espejo() + "\n}";
        crearDot(cadena, "espejo");
        crearPng("espejo");
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
        string rutan1 = "C:\\Users\\Christian\\Desktop\\Graficas\\tablero.png";
        Process.Start(rutan1);
    }static Cubo n2 = new Cubo();
    [WebMethod]
    public void nivel2()
    {
        string rutan2 = "C:\\Users\\Christian\\Desktop\\Graficas\\tablero.png";
        Process.Start(rutan2);
    }static Cubo n3 = new Cubo();
    [WebMethod]
    public void nivel3()
    {
        string rutan3 = "C:\\Users\\Christian\\Desktop\\Graficas\\tablero.png";
        Process.Start(rutan3);
    }static Cubo n4 = new Cubo();
    [WebMethod]
    public void nivel4()
    {string rutan4 = "C:\\Users\\Christian\\Desktop\\Graficas\\tablero.png";
        Process.Start(rutan4);
    }
    
    [WebMethod]
    public int refABB(string usuario, string pass) // Verificar Usuarios para login
    {
        if (nuevoABB.buscarUsuario(usuario, pass) == 1) {
            return 1;
        }
        return 0;
    }

    static public string nomUsu1 = "x";
    static public string nomUsu2 = "x";
    static public int conecUsu1 = 0;
    static public int conecUsu2 = 0;
    
    [WebMethod]
    public void asignandoNombre1(string nom1)       // Asignacion Ya conectado Usuario 1 [void]
    {
        nomUsu1 = nom1;
        conecUsu1++;
    }
    [WebMethod]
    public void asignandoNombre2(string nom2)       // Asignacion Ya conectado Usuario 2 [void]
    {
        nomUsu2 = nom2;
        conecUsu2++;
    }
    [WebMethod]
    public string retornoNombreUsuario1()           // Retorno Nombre Usuario 1 [string]
    {
        return nomUsu1;
    }
    [WebMethod]
    public string retornoNombreUsuario2()           // Retorno Nombre Usuario 2 [string]
    {
        return nomUsu2;
    }
    [WebMethod]
    public int retornoConectadoUsuario1()           // Retorno Conectado Usuario 1 [int]
    {
        return conecUsu1;
    }
    [WebMethod]
    public int retornoConectadoUsuario2()           // Retorno Conectado Usuario 2 [int]
    {
        return conecUsu2;
    }
    // -----------------------------------------------------------------------------------------------------------------------------Guardar Valores Modo Juego
    static public string[] juegoActual = new string[50];
    static public int cuentaModosJuego = 0;
    [WebMethod]
    public void guardarValoresModoJuego(string cadena)           // Guarda valores de juego
    {
        juegoActual[cuentaModosJuego] = cadena;
        cuentaModosJuego++;
    }
    [WebMethod]
    public string retornoCadenaModoJuego()                    // Retorno valores de juego
    {
        string local = "";
        for (int x=0; x<cuentaModosJuego; x++) {
            local += juegoActual[x] + ";";
        }
        return local;
    }
    [WebMethod]
    public int retornoCantidadModoJuego()                       // Retorno valores de juego
    {
        return cuentaModosJuego;
    }
    // ------------------------------------------------------------------------------------------------------------------------------Validacion de Carga de Usuarios
    public static bool ya = false;
    [WebMethod]
    public bool yaHayUsuarios()                     // Validacion de carga de Usuarios [true]
    {
        ya = true;
        return ya;
    }
    [WebMethod]
    public bool LoginyaHayUsuarios()                     // Validacion de carga de Datos [bool]
    {
        return ya;
    }
    // ------------------------------------------------------------------------------------------------------------------------------- Envio a Juego Completo
    public static string cadenaJuegoCompleto = "";
    [WebMethod]
    public void guardaCadenaJuegoCompleto(string cadena)                     
    {
        cadenaJuegoCompleto = cadena;
    }
    [WebMethod]
    public string retornoCadenaJuegoCompleto()
    {
        return cadenaJuegoCompleto;
    }
    //-----------------------------------------------------------------------------------------------------------------------------------Inicio de juego
    public static int EmpezarJuego = 0;
    [WebMethod]
    public void GuardaSiYaInicioJuego()
    {
        EmpezarJuego = 1;
    }
    [WebMethod]
    public int retornaSiYaInicioJuego()
    {
        return EmpezarJuego;
    }
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------
    [WebMethod]
    public string retornoPiezas(string usuario)
    {
        string mandar = "";
        mandar=n1.retornaSoloPiezas()+",";
        mandar+=n2.retornaSoloPiezas()+",";
        mandar+=n3.retornaSoloPiezas()+",";
        mandar+=n4.retornaSoloPiezas();
        return mandar;
    }
    // ------------------------------------------------------------------------------------------------------------------------------------------ Cuerpo Consola
    public static string cuerpo = "";
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------
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
        else if (rut == "contactos") {
            path = rutaContactos;
        }
        else if (rut == "historial") {
            path = rutaHistorial;
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
                        nuevoABB.Insertar(dato[0], dato[1], dato[2], dato[3].ToString());
                        //nuevoAE.InsertarEspejo(dato[0], dato[1], dato[2], dato[3].ToString());
                        cuerpo += dato[0] + " - " + dato[1] + " - " + dato[2] + " - " + Convert.ToInt32(dato[3].ToString()) + ";\n";
                    }
                    else if (rut == "tablero")// Insertado Medio
                    {
                        // [0]jugador, [1]columna, [2]fila, [3]unidad, [4]"destruida(0 si,1 no)"
                        int queNiveles = aNivel(dato[3]);
                        if (queNiveles == 1)
                        {
                            // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                            nuevoC.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 5, 1, 2, 10, true, false, true, true, true, true);
                            n1.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 5, 1, 2, 10, true, false, true, true, true, true);
                        }
                        else if ((queNiveles == 21) ||(queNiveles == 22))
                        {
                            if (queNiveles ==21) {
                                // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                                nuevoC.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 6, 1, 3, 15, true, true, true, true, true, true);
                                n2.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 6, 1,3,15,true, true, true, true, true, true);
                            }
                            else if (queNiveles ==22) {
                                // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                                nuevoC.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 5, 6, 3, 10, true, true, true, true, true, true);
                                n2.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 5, 6, 3, 10, true, true, true, true, true, true);
                            }
                        }
                        else if ((queNiveles == 31) ||(queNiveles == 32)||(queNiveles == 33))
                        {
                            if (queNiveles == 31) {
                                // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                                nuevoC.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 9,1,3,15,true,true, true, true, true, true);
                                n3.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 9,1,3,15, true, true, true, true, true, true);
                            } else if (queNiveles == 32) {
                                // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                                nuevoC.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 9,1,2,20, true, true, true, true, true, true);
                                n3.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 9, 1, 2, 20, true, true, true, true, true, true);
                            } else if (queNiveles ==33) {
                                // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                                nuevoC.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 7,0,5,10, false, true, false, false, false, false);
                                n3.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 7, 0, 5, 10, false, true, false, false, false, false);
                            }
                        }
                        else if (queNiveles == 4)
                        {
                            // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                            nuevoC.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(),6,0,2,10,false,true,false,false,false,false);
                            n4.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 6, 0, 2, 10, false, true, false, false, false, false);
                        }
                        else {
                            // Envia a Cubo en coordenadas segund nivel de retorno de funcion
                            nuevoC.ingresarAMatriz(dato[1].ToString(), dato[2].ToString(), dato[0].ToString(), dato[3].ToString(), dato[4].ToString(), dato[1].ToString(), dato[2].ToString(), queNiveles.ToString(), 6, 0, 2, 10, false, true, false, false, false, false);
                        }

                        cuerpo += dato[0].ToString() + " - " + dato[1].ToString() + " - " + dato[2].ToString() + " - " + dato[3].ToString() + " - " + dato[4].ToString() + ";\n";
                    }
                    else if (rut == "juegos") // Insertado Completo
                    {
                        // [0]Usuario Base, [1]Oponente, [2]unidades desplegadas, [3]unidades sobrevivientes, [4]Unidades Destruidas, [5]"Gano (1 si, 0 no)"
                        nuevoABB.InsertarJuegos(dato[0], dato[1], dato[2], dato[3], dato[4], dato[5].ToString());
                        //nuevoAE.InsertarJuegos(dato[0], dato[1], dato[2], dato[3], dato[4], dato[5].ToString());
                        cuerpo += dato[0] + " - " + dato[1] + " - " + Convert.ToInt32(dato[2].ToString()) + " - " + Convert.ToInt32(dato[3].ToString()) + " - " + Convert.ToInt32(dato[4].ToString()) + " - " + Convert.ToInt32(dato[5].ToString()) + ";\n";
                    }
                    else if (rut == "juegoActual")
                    {
                        // [0]Nickname1, [1]Nickname2, [2]Naves Nivel 1, [3]Naves Nivel 2,	[4]Naves Nivel 3, [5]Naves Nivel 4, 
                        // [6]TamaÃ±o X, [7]TamaÃ±o Y, [8]"Variante (1 = normal, 2 = tiempo, 3=base)", [9]Tiempo
                        //string mandar = dato[0].ToString() + "," + dato[1].ToString() + ","+dato[2].ToString() + ","+dato[3].ToString() + "," +dato[4].ToString() + ",";
                        //mandar += dato[5].ToString() + "," + dato[6].ToString() + "," + dato[7].ToString() + "," + dato[8].ToString() + "," + dato[9].ToString();
                        //string mandar = dato[8];
                        guardarValoresModoJuego(getLine);
                        cuerpo += dato[0] + " - " + dato[1] + " - " + Convert.ToInt32(dato[2].ToString()) + " - " + Convert.ToInt32(dato[3].ToString()) + " - " + Convert.ToInt32(dato[4].ToString()) + " - " + Convert.ToInt32(dato[5].ToString()) + " - " + Convert.ToInt32(dato[6].ToString()) + " - " + Convert.ToInt32(dato[7].ToString()) + " - " + Convert.ToInt32(dato[8].ToString()) + " - " + dato[9].ToString() + ";\n";
                    }
                    else if (rut == "contactos") {
                        // [0]Usuario padre, [1]Nickname, [2]ContraseNa, [3]correo electronico
                        
                        if (nuevoABB.verificarABB(dato[0].ToString()) == true) // Si ya existe el nick del abb solo inserta nuevo en AVL
                        {
                            nuevoABB.InsertarContactos(dato[0].ToString(), dato[1].ToString(), dato[2].ToString(), dato[3].ToString());
                        }
                        else
                        {                                  // Si no
                            nuevoABB.Insertar(dato[0].ToString(), dato[2].ToString(), dato[3].ToString(), "1"); // Crear nodo ABB
                            nuevoABB.InsertarContactos(dato[0].ToString(), dato[1].ToString(), dato[2].ToString(), dato[3].ToString()); // Luego inserta AVL
                        }
                    }
                    else if (rut == "historial") {

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
            //string etiqueta;
            //etiqueta = "label=\"Altura: " + nuevoABB.altura() + "\nRamas: " + nuevoABB.ramas() + "\nHojas: " + nuevoABB.hojas() + "\"";
            cadena = "digraph G {\nlabel = \"Arbol de Usuarios\nAltura: " + nuevoABB.altura() + "\nRamas: " + nuevoABB.ramas() + "\nHojas: " + nuevoABB.hojas() + "\";\n" + nuevoABB.dotArbol() + "\n}";
            crearDot(cadena, rut);
            crearPng(rut);
            //cadena = "";
            //cadena = "digraph G {\nlabel = \"Arbol de Usuarios Espejo\";\n" + nuevoAE.dotArbolEspejo() + "\n}";
            //crearDot(cadena, "usuariosEspejo");
            //crearPng("usuariosEspejo");
        }
        else if (rut == "tablero") {
            cadena = "digraph G{\nnode[shape=box, style=filled, color=Gray95];edge[color=black];rankdir=UD;\nlabel = \"Nivel 0\";\n" + nuevoC.textoParaGraficarMatriz() + "}";
            crearDot(cadena, "tablero");
            crearPng(rut);
            cadena = "digraph G{\nnode[shape=box, style=filled, color=Gray95];edge[color=black];rankdir=UD;\nlabel = \"Nivel 1 - Submarinos\";\n" + n1.textoParaGraficarMatriz() + "}";
            crearDot(cadena, "nivel1");
            crearPng("nivel1");
            cadena = "digraph G{\nnode[shape=box, style=filled, color=Gray95];edge[color=black];rankdir=UD;\nlabel = \"Nivel 2 - Barcos\";\n" + n2.textoParaGraficarMatriz() + "}";
            crearDot(cadena, "nivel2");
            crearPng("nivel2");
            cadena = "digraph G{\nnode[shape=box, style=filled, color=Gray95];edge[color=black];rankdir=UD;\nlabel = \"Nivel 3 - Aviones\";\n" + n3.textoParaGraficarMatriz() + "}";
            crearDot(cadena, "nivel3");
            crearPng("nivel3");
            cadena = "digraph G{\nnode[shape=box, style=filled, color=Gray95];edge[color=black];rankdir=UD;\nlabel = \"Nivel 4 - Satélites\";\n" + n4.textoParaGraficarMatriz() + "}";
            crearDot(cadena, "nivel4");
            crearPng("nivel4");
        }
        else if (rut == "juegos") {
            cadena = "digraph G {\nlabel = \"Arbol de Usuarios y Juegos\";\n" + nuevoABB.dotArbol() + "\n}";
            crearDot(cadena, rut);
            crearPng(rut);
            //cadena = "";
            //cadena = "digraph G {\nlabel = \"Arbol de Usuarios y Juegos Espejo\";\n" + nuevoAE.dotArbolEspejo() + "\n}";
            //crearDot(cadena, "juegosEspejo");
            //crearPng("juegosEspejo");
        }
        else if (rut == "juegoActual") {
            //cadena = "";
        }
        else if (rut == "contactos") {
            cadena = "digraph G {\nlabel = \"Arbol de Usuarios y Contactos\";\n" + nuevoABB.dotArbol() + "\n}";
            crearDot(cadena, rut);
            crearPng(rut);
        }
        else if (rut == "historial") {
            //
        }
        
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
            return 33;
        }
        else if ((chars[0] == 67) && (chars[1] == 97)) //Caza    --> Nivel 3 <--
        {
            return 32;
        }
        else if ((chars[0] == 72)) //Helicoptero    --> Nivel 3 <--
        {
            return 31;
        }
        else if ((chars[0] == 70)) //Fragata     --> Nivel 2 <--
        {
            return 22;
        }
        else if ((chars[0] == 67) && (chars[1] == 114)) //Crucero    --> Nivel 2 <--
        {
            return 21;
        }
        else if ((chars[0] == 83)) //Submarino    --> Nivel 1 <--
        {
            return 1;
        }
        return 0;
    }

    [WebMethod] // Crea Imagen de archivo Dot
    public void crearPng(string nombre) {
        crearPngP(nombre);
        //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
        //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
        //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
        string comando = "dot -Tpng C:\\inetpub\\wwwroot\\ProyectoEDD\\EDD\\" + nombre + ".dot -o C:\\inetpub\\wwwroot\\ProyectoEDD\\EDD\\" + nombre + ".png";
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
        crearDotP(cuerpo,nombre);
        TextWriter archivo;
        string ruta = "C:\\inetpub\\wwwroot\\ProyectoEDD\\EDD\\" + nombre + ".dot";
        archivo = new StreamWriter(ruta);
        archivo.WriteLine(cuerpo);
        archivo.Close();
    }

    [WebMethod] // Crea Imagen de archivo Dot
    public void crearPngP(string nombre)
    {
        //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
        //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
        //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
        string comando = "dot -Tpng C:\\Users\\Christian\\Documents\\GitHub\\EDD_201504444\\Proyecto_fase1\\Servidor\\EDD\\" + nombre + ".dot -o C:\\Users\\Christian\\Documents\\GitHub\\EDD_201504444\\Proyecto_fase1\\Servidor\\EDD\\" + nombre + ".png";
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
    public void crearDotP(string cuerpo, string nombre)
    {
        TextWriter archivo;
        string ruta = "C:\\Users\\Christian\\Documents\\GitHub\\EDD_201504444\\Proyecto_fase1\\Servidor\\EDD\\" + nombre + ".dot";
        archivo = new StreamWriter(ruta);
        archivo.WriteLine(cuerpo);
        archivo.Close();
    }

}