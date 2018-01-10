using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Nodo
/// </summary>
public class Nodo
{   //jugador,columna,fila,unidad,"destruida(0 si,1 no)"
    public int columna = 0;
    public int fila = 0;

    // ---------------------------------------------------Datos de Pieza (Archivo de entrada)------------
    public String dom = "";
    public String letra = "";
    public String Jugador = "";
    public String dato = "";
    public String destruida = "";
    public String col = "";
    public String fil = "";
    public int NivelActual = 0; // n1, n2, n3, n4
    // -----------------------------------------------------Habilidades-----------------------------------
    public int movimiento =0;
    public int alcance =0;
    public int daño =0;
    public int vida =0;
    // ----------------------------------------------------- Movimiento------------------------------------
    public bool valArriba;
    public bool valAbajo;
    public bool valIzquierda;
    public bool valDerecha;
    public bool valAdelante;
    public bool valAtras;
    //-------------------------------------------------------Punteros--------------------------------------
    public Nodo arriba;
    public Nodo abajo;
    public Nodo anterior;
    public Nodo siguiente;
    public Nodo atras;
    public Nodo adelante;
    // ---------------------------------------------------- Constructor Nodo Cubo---------------------------
    public Nodo()
    {
        siguiente = null;
    }
}