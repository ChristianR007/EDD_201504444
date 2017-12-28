using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Nodo
/// </summary>
public class Nodo
{
    public int columna = 0;
    public int fila = 0;
    public String dato = "";
    public String dom = "";
    public String letra = "";
    public Nodo arriba;
    public Nodo abajo;
    public Nodo anterior;
    public Nodo siguiente;
    public Nodo atras;
    public Nodo adelante;

    public Nodo()
    {
        siguiente = null;
    }
}