using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Descripción breve de Cubo
/// </summary>
public class Cubo
{
    Nodo raiz = new Nodo();
    Nodo node;
    bool esta3D;
    Nodo puntero3D;
    public Cubo()
    {
        node = raiz;
        esta3D = false;
        puntero3D = new Nodo();
        raiz.dato = "";
    }
    public bool matrizVacia()
    {
        if ((raiz.siguiente == null) || (raiz.abajo == null))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public int numeroDeDatosEnColumnas(Nodo nodoB)
    {
        Nodo aux = nodoB;
        int contador = -1;
        while (aux != null)
        {
            aux = aux.abajo;
            contador = contador + 1;

        }
        return contador;
    }
    public int numeroDeDatosEnFilas(Nodo nodoB)
    {

        Nodo aux = nodoB;
        int contador = 0;
        while (aux != null)
        {
            if (aux.siguiente != null)
            {
                aux = aux.siguiente;
            }
            else
            {
                break;
            }

            contador++;
        }
        return contador;
    }

    public Nodo punteroAEliminarDesdeFila(Nodo nodoB, string dato)
    {
        Nodo aux = nodoB;
        while (aux != null)
        {
            if (aux.dato == dato)
            {
                break;
            }
            else
            {
                if (aux.adelante != null)
                {
                    puntero3D = punterAEliminar3D(aux, dato);
                }
            }
            aux = aux.abajo;
        }

        return aux;
    }

    public Nodo punteroAEliminarDesdeColumna(Nodo nodoB, string dato)
    {
        Nodo aux = nodoB;
        while (aux != null)
        {
            if (aux.dato == dato)
            {
                break;
            }
            else
            {
                if (aux.adelante != null)
                {
                    puntero3D = punterAEliminar3D(aux, dato);
                }
            }
            aux = aux.abajo;
        }

        return aux;
    }

    public Nodo punterAEliminar3D(Nodo nodoB, string dato)
    {
        Nodo aux = nodoB.adelante;
        while (aux != null)
        {
            if (aux.dato == dato)
            {
                esta3D = true;
                break;
            }
            aux = aux.adelante;
        }

        return aux;
    }

    public bool existeColumna(string dominio)
    {
        bool bandera = false;
        Nodo auxiliarColumnas = raiz.siguiente;
        while (auxiliarColumnas != null)
        {
            if (auxiliarColumnas.dato == dominio)
            {
                bandera = true;
                break;
            }
            auxiliarColumnas = auxiliarColumnas.siguiente;
        }

        return bandera;
    }

    public bool existeFila(string letter)
    {
        bool bandera = false;
        Nodo auxiliarFilas = raiz.abajo;
        while (auxiliarFilas != null)
        {
            if (auxiliarFilas.dato == letter)
            {
                bandera = true;
                break;
            }
            auxiliarFilas = auxiliarFilas.abajo;
        }

        return bandera;
    }

    public Nodo crearCabezaraDominio(string dominio)
    {
        Nodo auxiliar = raiz.siguiente;
        Nodo nuevo = new Nodo();
        nuevo.dato = dominio;
        if (matrizVacia() == true)
        {
            raiz.siguiente = nuevo;
            nuevo.anterior = raiz;
            return nuevo;
        }
        else
        {
            while (auxiliar.siguiente != null)
            {
                auxiliar = auxiliar.siguiente;
            }
            auxiliar.siguiente = nuevo;
            nuevo.anterior = auxiliar;
            return nuevo;
        }
    }

    public int convertir(string cadena)
    {
        int valorAscii = 0;
        int ascii = Encoding.ASCII.GetBytes("A")[0];

        var chars = cadena.ToCharArray();
        for (int ctr = 0; ctr < chars.Length; ctr++)
            valorAscii += chars[ctr];

        return valorAscii;
    }

    public Nodo crearCabezeraDeLetras(string letter)
    {
        int bandera = 0;
        Nodo auxiliar = raiz.abajo;
        Nodo nuevo = new Nodo();
        nuevo.dato = letter;
        if (matrizVacia() == true)
        {
            raiz.abajo = nuevo;
            nuevo.arriba = raiz;
        }
        else
        {
            while (auxiliar != null)
            {
                if (convertir(letter) < convertir(auxiliar.dato))
                {
                    bandera = 1;
                    break;
                }
                if (auxiliar.abajo != null)
                {
                    auxiliar = auxiliar.abajo;
                }
                else { break; }
            }
            if (bandera == 1)
            {
                auxiliar.arriba.abajo = nuevo;
                nuevo.arriba = auxiliar.arriba;
                nuevo.abajo = auxiliar;
                auxiliar.arriba = nuevo;
            }
            if (bandera == 0)
            {
                auxiliar.abajo = nuevo;
                nuevo.arriba = auxiliar;
            }
        }
        return nuevo;
    }

    public Nodo ingresarAMatriz(string dominio, string letra, string dato)
    {
        if ((existeColumna(dominio) == false) && (existeFila(letra) == false))
        {
            // Primer Caso
            Console.WriteLine("primer caso puto");
            Nodo punteroCol = crearCabezaraDominio(dominio);
            Nodo punterofil = crearCabezeraDeLetras(letra);
            Nodo nuevo = new Nodo();
            nuevo.dato = dato;
            nuevo.letra = letra;
            nuevo.dom = dominio;
            punteroCol.abajo = nuevo;
            nuevo.arriba = punteroCol;
            punterofil.siguiente = nuevo;
            nuevo.anterior = punterofil;
            return null;
        }
        if ((existeColumna(dominio) == false) && (existeFila(letra) == true))
        {
            // Segundo Caso
            Nodo punteroCol = crearCabezaraDominio(dominio);
            Nodo punterofil = encuentraFila(letra);
            Nodo posicion = recorreLaFilaDeLetra(punterofil);
            Nodo nuevo = new Nodo();
            nuevo.dato = dato;
            nuevo.letra = letra;
            nuevo.dom = dominio;
            punteroCol.abajo = nuevo;
            nuevo.arriba = punteroCol;
            posicion.siguiente = nuevo;
            nuevo.anterior = posicion;
            return null;
        }
        if ((existeColumna(dominio) == true) && (existeFila(letra) == false))
        {
            // Tercer Caso
            Nodo punteroCol = encuentraColumna(dominio);
            Nodo punterofil = crearCabezeraDeLetras(letra);
            Nodo nuevo = new Nodo();
            nuevo.dato = dato;
            nuevo.letra = letra;
            nuevo.dom = dominio;
            Nodo nodoColocado = recorreLaColumnaDeDominios(punteroCol, nuevo);
            punterofil.siguiente = nodoColocado;
            nodoColocado.anterior = punterofil;
            return null;
        }
        if ((existeColumna(dominio) == true) && (existeFila(letra) == true))
        {
            // Cuarto Caso
            Nodo punteroCol = encuentraColumna(dominio);
            punteroCol.dom = dominio;
            Nodo punterofil = encuentraFila(letra);
            punterofil.letra = letra;
            Nodo nuevo = new Nodo();
            nuevo.dato = dato;
            nuevo.letra = letra;
            nuevo.dom = dominio;
            Nodo colFil = colocaDatoEnFilaConPosicionCorrecta(punterofil, dominio, nuevo);
            if (colFil != null)
            {
                colocarDatoEnColumnaConPosicionCorrecta(punteroCol, colFil);
            }
        }
        return null;
    }

    public Nodo eliminarDeMatriz(string dominio, string letra, string dato)
    {
        Nodo punteroColumna = encuentraColumna(dominio);
        Nodo punteroFila = encuentraFila(letra);
        Nodo punteroEliminar = punteroAEliminarDesdeFila(punteroFila, dato);
        int fil = numeroDeDatosEnFilas(punteroFila);
        int col = numeroDeDatosEnColumnas(punteroColumna);
        if (esta3D == true)
        {
            esta3D = false;
            puntero3D.atras.adelante = puntero3D.adelante;
            if (puntero3D.adelante != null)
            {
                puntero3D.adelante.atras = puntero3D.atras;
            }
            puntero3D.atras = null;
        }
        else
        {
            if ((fil == 1) && (col == 1))
            {
                if (punteroEliminar.adelante != null)
                {
                    punteroEliminar.anterior.siguiente = punteroEliminar.adelante;
                    punteroEliminar.arriba.abajo = punteroEliminar.adelante;
                    punteroEliminar.adelante.arriba = punteroEliminar.arriba;
                    punteroEliminar.adelante.anterior = punteroEliminar.anterior;
                    punteroEliminar.adelante.atras = null;
                    punteroEliminar.arriba = null;
                    punteroEliminar.anterior = null;
                    punteroEliminar.adelante = null;
                    return null;
                }
                else
                {
                    punteroColumna.anterior.siguiente = punteroColumna.siguiente;
                    if (punteroColumna.siguiente != null)
                    {
                        punteroColumna.siguiente.anterior = punteroColumna.anterior;
                    }
                    punteroColumna.anterior = null;
                    punteroFila.arriba.abajo = punteroFila.abajo;
                    if (punteroFila.abajo != null)
                    {
                        punteroFila.abajo.arriba = punteroFila.arriba;
                    }
                    punteroFila.arriba = null;
                    return null;
                }
            }
            if ((fil > 1) && (col == 1))
            {
                if (punteroEliminar.adelante != null)
                {
                    punteroEliminar.anterior.siguiente = punteroEliminar.adelante;
                    punteroEliminar.adelante.anterior = punteroEliminar.anterior;
                    punteroEliminar.arriba.abajo = punteroEliminar.adelante;
                    punteroEliminar.adelante.arriba = punteroEliminar.arriba;
                    if (punteroEliminar.siguiente != null)
                    {
                        punteroEliminar.siguiente.anterior = punteroEliminar.adelante;
                        punteroEliminar.adelante.siguiente = punteroEliminar.siguiente;
                    }
                    punteroEliminar.anterior = null;
                    punteroEliminar.siguiente = null;
                    punteroEliminar.arriba = null;
                    punteroEliminar.adelante.atras = null;
                    punteroEliminar.adelante = null;
                }
                else
                {
                    punteroColumna.anterior.siguiente = punteroColumna.siguiente;
                    if (punteroColumna.siguiente != null)
                    {
                        punteroColumna.siguiente.anterior = punteroColumna.anterior;
                    }
                    punteroColumna.anterior = null;
                    punteroEliminar.anterior.siguiente = punteroEliminar.siguiente;
                    if (punteroEliminar.siguiente != null)
                    {
                        punteroEliminar.siguiente.anterior = punteroEliminar.anterior;
                    }
                    punteroEliminar.anterior = null;
                    return null;
                }
            }
            if ((fil == 1) && (col > 1))
            {
                if (punteroEliminar.adelante != null)
                {
                    punteroEliminar.arriba.abajo = punteroEliminar.adelante;
                    punteroEliminar.adelante.arriba = punteroEliminar.arriba;
                    punteroEliminar.anterior.siguiente = punteroEliminar.adelante;
                    punteroEliminar.adelante.anterior = punteroEliminar.anterior;
                    if (punteroEliminar.abajo != null)
                    {
                        punteroEliminar.abajo.arriba = punteroEliminar.adelante;
                        punteroEliminar.adelante.abajo = punteroEliminar.abajo;
                    }
                    punteroEliminar.arriba = null;
                    punteroEliminar.anterior = null;
                    punteroEliminar.abajo = null;
                    punteroEliminar.adelante.atras = null;
                    punteroEliminar.adelante = null;
                    return null;
                }
                else
                {
                    punteroFila.arriba.abajo = punteroFila.abajo;
                    if (punteroFila.abajo != null)
                    {
                        punteroFila.abajo.arriba = punteroFila.arriba;
                    }
                    punteroFila.arriba = null;
                    punteroEliminar.arriba.abajo = punteroEliminar.abajo;
                    if (punteroEliminar.abajo != null)
                    {
                        punteroEliminar.abajo.arriba = punteroEliminar.arriba;
                    }
                    punteroEliminar.arriba = null;
                    return null;
                }
            }
            if ((fil > 1) && (col > 1))
            {
                if (punteroEliminar.adelante != null)
                {
                    punteroEliminar.arriba.abajo = punteroEliminar.adelante;
                    punteroEliminar.adelante.arriba = punteroEliminar.arriba;
                    punteroEliminar.anterior.siguiente = punteroEliminar.adelante;
                    punteroEliminar.adelante.anterior = punteroEliminar.anterior;
                    if (punteroEliminar.abajo != null)
                    {
                        punteroEliminar.abajo.arriba = punteroEliminar.adelante;
                        punteroEliminar.adelante.abajo = punteroEliminar.abajo;
                    }
                    if (punteroEliminar.siguiente != null)
                    {
                        punteroEliminar.siguiente.anterior = punteroEliminar.adelante;
                        punteroEliminar.adelante.siguiente = punteroEliminar.siguiente;
                    }
                    punteroEliminar.adelante.atras = null;
                    punteroEliminar.arriba = null;
                    punteroEliminar.anterior = null;
                    punteroEliminar.siguiente = null;
                    punteroEliminar.abajo = null;
                    punteroEliminar.adelante = null;
                    return null;
                }
                else
                {
                    punteroEliminar.anterior.siguiente = punteroEliminar.siguiente;
                    if (punteroEliminar.siguiente != null)
                    {
                        punteroEliminar.siguiente.anterior = punteroEliminar.anterior;
                    }
                    punteroEliminar.anterior = null;
                    punteroEliminar.arriba.abajo = punteroEliminar.abajo;
                    if (punteroEliminar.abajo != null)
                    {
                        punteroEliminar.abajo.arriba = punteroEliminar.arriba;
                    }
                    punteroEliminar.arriba = null;
                    return null;
                }
            }
        }
        return null;
    }

    public Nodo encuentraFila(String letra)
    {
        Nodo nodoBusquedad = raiz;
        while (nodoBusquedad != null)
        {
            if (nodoBusquedad.dato == letra)
            {
                break;
            }
            if (nodoBusquedad.abajo != null)
            {
                nodoBusquedad = nodoBusquedad.abajo;
            }
            else
            {
                break;
            }
        }

        return nodoBusquedad;
    }

    public Nodo encuentraColumna(string dominio)
    {
        Nodo nodoBusquedad = raiz;
        while (nodoBusquedad != null)
        {
            if (nodoBusquedad.dato == dominio)
            {
                break;
            }
            if (nodoBusquedad.siguiente != null)
            {
                nodoBusquedad = nodoBusquedad.siguiente;
            }
            else
            {
                break;
            }
        }
        return nodoBusquedad;
    }

    // Este metodo se encarga de recorrer las filas de las letras para
    // encontrar su interseccion con la columna
    public Nodo recorreLaFilaDeLetra(Nodo nodoB)
    {
        Nodo retorno = null;
        while (nodoB.siguiente != null)
        {
            nodoB = nodoB.siguiente;
        }
        retorno = nodoB;
        return retorno;
    }

    // Este metodo se encarga de recorrer las columnas del dominio
    // correspondiente cuando la columna existe y la letra no
    public Nodo recorreLaColumnaDeDominios(Nodo nodoB, Nodo nuevo)
    {
        int bandera = 0;
        Nodo retorno = null;
        while (nodoB.abajo != null)
        {
            if (convertir(nuevo.letra) < convertir(nodoB.abajo.letra))
            {
                bandera = 1;
                break;
            }
            if (nodoB.abajo != null)
            {
                nodoB = nodoB.abajo;
            }
        }
        if (bandera == 1)
        {
            nodoB.abajo.arriba = nuevo;
            nuevo.abajo = nodoB.abajo;
            nodoB.abajo = nuevo;
            nuevo.arriba = nodoB;
        }
        if (bandera == 0)
        {
            nodoB.abajo = nuevo;
            nuevo.arriba = nodoB;
        }

        retorno = nuevo;
        return retorno;
    }

    // CUANDO FILA Y COLUMNAS EXITEN USARE 
    //ESTE METODO QUE COLOCA EL DATO EN POSICION CORRECTA
    public Nodo colocaDatoEnFilaConPosicionCorrecta(Nodo nodoB, string dominio, Nodo nuevo)
    {
        int bandera = 0;
        Nodo retorno = null;
        while (nodoB.siguiente != null)
        {
            if (devuelvemeElIndiceDelDominio(dominio) < devuelvemeElIndiceDelDominio(nodoB.siguiente.dom))
            {
                bandera = 1;
                break;
            }
            if (devuelvemeElIndiceDelDominio(dominio) == devuelvemeElIndiceDelDominio(nodoB.siguiente.dom))
            {
                bandera = 2;
                break;
            }
            if (nodoB.siguiente != null)
            {
                nodoB = nodoB.siguiente;
            }
            else
            {
                break;
            }
        }
        if (bandera == 1)
        {
            nodoB.siguiente.anterior = nuevo;
            nuevo.siguiente = nodoB.siguiente;
            nodoB.siguiente = nuevo;
            nuevo.anterior = nodoB;
            retorno = nuevo;
        }
        if (bandera == 0)
        {
            nodoB.siguiente = nuevo;
            nuevo.anterior = nodoB;
            retorno = nuevo;
        }
        if (bandera == 2)
        {
            retorno = null;
            colocaEnLaTerceraDimensionDelCubo(nodoB.siguiente, nuevo);
        }

        return retorno;
    }

    public Nodo colocaEnLaTerceraDimensionDelCubo(Nodo nodoB, Nodo nuevo)
    {
        while (true)
        {
            if (nodoB.adelante == null)
            {
                // 3D
                break;
            }
            nodoB = nodoB.adelante;
        }
        nodoB.adelante = nuevo;
        nuevo.atras = nodoB;

        return nuevo;
    }

    public Nodo colocarDatoEnColumnaConPosicionCorrecta(Nodo nodoB, Nodo nuevo)
    {
        int bandera = 0;
        Nodo retorno = null;
        while (nodoB.abajo != null)
        {
            if (convertir(nuevo.letra) < convertir(nodoB.abajo.letra))
            {
                bandera = 1;
                break;
            }
            if (nodoB.abajo != null)
            {
                nodoB = nodoB.abajo;
            }
        }
        if (bandera == 1)
        {
            nodoB.abajo.arriba = nuevo;
            nuevo.abajo = nodoB.abajo;
            nodoB.abajo = nuevo;
            nuevo.arriba = nodoB;
        }
        if (bandera == 0)
        {
            nodoB.abajo = nuevo;
            nuevo.arriba = nodoB;
        }

        retorno = nuevo;
        return retorno;
    }

    public string printDomains()
    {
        string cuerpo = "";
        Nodo auxiliar = raiz.siguiente;
        while (auxiliar != null)
        {
            cuerpo += "| " + auxiliar.dato + " | ";
            auxiliar = auxiliar.siguiente;
        }

        return cuerpo;
    }

    public string printLetters()
    {
        string cuerpo = "";
        Nodo auxiliar = raiz.abajo;
        while (auxiliar != null)
        {
            cuerpo += "| " + auxiliar.dato + " | ";
            auxiliar = auxiliar.abajo;
        }

        return cuerpo;
    }

    public string moverAbajo()
    {
        string cuerpo = "";
        if (node.abajo != null)
        {
            node = node.abajo;
            cuerpo += "| " + node.dato + " | ";
        }

        return cuerpo;
    }

    public string moverArriba()
    {
        string cuerpo = "";
        if (node.arriba != null)
        {
            node = node.arriba;
            cuerpo += "| " + node.dato + " | ";
        }

        return cuerpo;
    }

    public string moverSiguiente()
    {
        string cuerpo = "";
        if (node.siguiente != null)
        {
            node = node.siguiente;
            cuerpo += "| " + node.dato + " | ";
        }

        return cuerpo;
    }

    public string moverAnterior()
    {
        string cuerpo = "";
        if (node.anterior != null)
        {
            node = node.anterior;
            cuerpo += "| " + node.dato + " | ";
        }

        return cuerpo;
    }

    public string moverAdelante()
    {
        string cuerpo = "";
        if (node.adelante != null)
        {
            node = node.adelante;
            cuerpo += "| " + node.dato + " | ";
        }

        return cuerpo;
    }

    public string moverAtras()
    {
        string cuerpo = "";
        if (node.atras != null)
        {
            node = node.atras;
            cuerpo += "| " + node.dato + " | ";
        }

        return cuerpo;
    }

    public int devuelvemeElIndiceDelDominio(string dominio)
    {
        int index = 0;
        Nodo nodoB = raiz;
        while (nodoB.siguiente != null)
        {
            if (nodoB.siguiente.dato == dominio)
            {
                break;
            }
            index = index + 1;
            nodoB = nodoB.siguiente;
        }

        return index;
    }

    public string nombresConletra(string letra)
    {
        Nodo aux = encuentraFila(letra);
        string retorno = "";
        while (aux != null)
        {
            if (aux.dato != null)
            {
                retorno += "| " + aux.dato + " |---->";
                retorno += recorreSubListaDeNombres(aux) + "\n";
            }
            aux = aux.siguiente;
        }

        return retorno;
    }

    public string recorreSubListaDeNombres(Nodo aux)
    {
        Nodo aux1 = aux.adelante;
        string retorno = "";
        while (aux1 != null)
        {
            retorno += " | " + aux1.dato + " |---->";
            aux1 = aux1.adelante;
        }

        return retorno;
    }

    public string nombresConDominio(string dominio)
    {
        Nodo aux = encuentraColumna(dominio);
        string retorno = "";
        while (aux != null)
        {
            if (aux.dato != null)
            {
                retorno += " | " + aux.dato + " |-----> ";
                retorno += recorreSubListaDeNombres(aux) + "\n";
            }
            aux = aux.abajo;
        }
        return retorno;
    }

    public string textoDotParaMatrizPorLetra(String letra)
    {
        Nodo aux = encuentraFila(letra);
        string retorno = "digraph G {";
        while (aux != null)
        {
            if (aux.dato != null)
            {
                if (aux.adelante != null)
                {
                    retorno += aux.dato + "->" + textoParaMatrizLetra3D(aux);
                }
                if (aux.siguiente != null)
                {
                    retorno += aux.dato + "->" + aux.siguiente.dato;
                }
                else
                {
                    retorno += aux.dato + ";";
                }
                if (aux.anterior != null)
                {
                    retorno += aux.dato + "->" + aux.anterior.dato + ";";
                }
                else
                {
                    retorno += aux.dato + ";";
                }
                aux = aux.siguiente;
            }
        }

        retorno += "\n}";
        return retorno;
    }

    public string textoParaMatrizPorDominio(string dominio)
    {
        Nodo aux = encuentraColumna(dominio);
        string retorno = "digraph G {";
        while (aux != null)
        {
            if (aux.dato != null)
            {
                if (aux.adelante != null)
                {
                    retorno += aux.dato + "->" + textoParaMatrizLetra3D(aux);
                }
                if (aux.abajo != null)
                {
                    retorno += aux.dato + "->" + aux.abajo.dato + ";";
                }
                else
                {
                    retorno += aux.dato + ";";
                }
                if (aux.arriba != null)
                {
                    retorno += aux.dato + "->" + aux.arriba.dato + ";";
                }
                else
                {
                    retorno += aux.dato + ";";
                }
                aux = aux.abajo;
            }
        }

        retorno += "}";
        return retorno;
    }

    public string textoParaMatrizLetra3D(Nodo nodoB)
    {
        Nodo aux1 = nodoB.adelante;
        string retorno = "";
        while (aux1 != null)
        {
            if (aux1.dato != null)
            {
                if (aux1.adelante != null)
                {
                    retorno += aux1.dato + "->" + aux1.adelante.dato + ";";
                }
                else
                {
                    retorno += aux1.dato + ";";
                }
                if (aux1.atras != null)
                {
                    retorno += aux1.dato + "->" + aux1.atras.dato + ";";
                }
                else
                {
                    retorno += aux1.dato + ";";
                }
                aux1 = aux1.adelante;
            }
        }

        return retorno;
    }
    int x = 0;
    public string textoParaGraficarMatriz()
    {
        Nodo auxFil = raiz;
        String retorno = "digraph G {\nnode[shape=box, style=filled, color=Gray95];edge[color=black];rankdir=UD;\nlabel = \"Nivel 1\";\n";
        String min = "";
        retorno += "root -> \"" + raiz.abajo.dato + "\";\n";
        retorno += "root -> \"" + raiz.siguiente.dato + "\";\n";
        while (auxFil != null)
        {
            Nodo aux2 = auxFil;
            while (aux2 != null)
            {
                if (aux2.adelante != null)
                {
                    if (!string.IsNullOrEmpty(aux2.dato) && !string.IsNullOrEmpty(aux2.adelante.dato))
                    {
                        retorno += "\"" + aux2.dato + "\"->\"" + textoParaMatrizLetra3D(aux2) + "\";\n";
                    }

                }
                if (aux2.abajo != null)
                {
                    if (!string.IsNullOrEmpty(aux2.dato) && !string.IsNullOrEmpty(aux2.abajo.dato))
                    {
                        retorno += "\"" + aux2.dato + "\"->\"" + aux2.abajo.dato + "\";\n";
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(aux2.dato))
                    {
                        retorno += "\"" + aux2.dato + "\";\n";
                    }

                }
                if (aux2.arriba != null)
                {
                    if (!string.IsNullOrEmpty(aux2.dato) && !string.IsNullOrEmpty(aux2.arriba.dato))
                    {
                        retorno += "\"" + aux2.dato + "\"->\"" + aux2.arriba.dato + "\";\n";
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(aux2.dato))
                    {
                        retorno += "\"" + aux2.dato + "\";\n";
                    }

                }
                if (aux2.siguiente != null)
                {
                    if (!string.IsNullOrEmpty(aux2.dato) && !string.IsNullOrEmpty(aux2.siguiente.dato))
                    {
                        retorno += "\"" + aux2.dato + "\"->\"" + aux2.siguiente.dato + "\";\n";
                        if (x == 0)
                        {
                            min += "\"" + aux2.dato + "\";\n";
                        }
                        else
                        {
                            retorno += "{rank=same; \"" + aux2.dato + "\"; \"" + aux2.siguiente.dato + "\";}\n";
                        }
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(aux2.dato))
                    {
                        retorno += "\"" + aux2.dato + "\";\n";
                        if (x == 0)
                        {
                            min += "\"" + aux2.dato + "\";\n";
                        }
                        else
                        {
                            retorno += "{rank=same; \"" + aux2.dato + "\";}\n";
                        }
                    }

                }
                if (aux2.anterior != null)
                {
                    if (!string.IsNullOrEmpty(aux2.dato) && !string.IsNullOrEmpty(aux2.anterior.dato))
                    {
                        retorno += "\"" + aux2.dato + "\"->\"" + aux2.anterior.dato + "\";\n";
                        if (x == 0)
                        {
                            min += "\"" + aux2.dato + "\";\n";
                        }
                        else
                        {
                            retorno += "{rank=same; \"" + aux2.dato + "\";}\n";
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(aux2.dato))
                    {
                        retorno += "\"" + aux2.dato + "\";\n";
                        if (!string.IsNullOrEmpty(aux2.dato))
                        {
                            retorno += "{rank=same; \"" + aux2.dato + "\";}\n";
                        }
                    }

                }
                aux2 = aux2.siguiente;
            }
            x++;
            auxFil = auxFil.abajo;
        }
        min = "{rank=min;\nroot;\n" + min + "};\n";
        retorno += min + "}";
        return retorno;
    }

    public string ff()
    {
        Nodo auxFil = raiz;
        String retorno = "digraph G {";
        while (auxFil != null)
        {
            Nodo aux2 = auxFil;
            while (aux2 != null)
            {
                if (aux2.adelante != null)
                {
                    retorno += aux2.dato + "->" + textoParaMatrizLetra3D(aux2);
                }
                if (aux2.abajo != null)
                {
                    retorno += aux2.dato + "->" + aux2.abajo.dato + ";";
                }
                else
                {
                    retorno += aux2.dato + ";";
                }
                if (aux2.arriba != null)
                {
                    retorno += aux2.dato + "->" + aux2.arriba.dato + ";";
                }
                else
                {
                    retorno += aux2.dato + ";";
                }
                if (aux2.siguiente != null)
                {
                    retorno += aux2.dato + "->" + aux2.siguiente.dato + ";";
                }
                else
                {
                    retorno += aux2.dato + ";";
                }
                if (aux2.anterior != null)
                {
                    retorno += aux2.dato + "->" + aux2.anterior.dato + ";";
                }
                else
                {
                    retorno += aux2.dato + ";";
                }
                aux2 = aux2.siguiente;
            }
            auxFil = auxFil.abajo;
        }

        retorno += "}";
        return retorno;
    }
    //Fin Metodos   
}