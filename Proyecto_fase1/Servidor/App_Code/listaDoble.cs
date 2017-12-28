using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de listaDoble
/// </summary>
public class listaDoble
{
    class NodoD
    {
        public string nombre;
        public NodoD siguiente;
        public NodoD atras;
    }
    NodoD primero = null;

    public void Insertar(listaDoble ld, string Vnombre)
    {
        NodoD nuevo = new NodoD();
        nuevo.nombre = Vnombre;
        if (ld.primero == null)
        {
            ld.primero = nuevo;
        }
        else
        {
            NodoD aux = ld.primero;
            while (aux != null)
            {
                if (aux.siguiente == null)
                {
                    aux.siguiente = nuevo;
                    nuevo.atras = aux;
                    break;
                }
                aux = aux.siguiente;
            }
        }
    }

    public string mostrar(listaDoble ld)
    {
        NodoD tmp = ld.primero;
        string cuerpo = "";
        while (tmp != null)
        {
            cuerpo += "\"" + tmp.nombre + "\";\n";
            if (tmp.siguiente != null)
            {
                cuerpo += "\"" + tmp.nombre + "\" -> \"" + tmp.siguiente.nombre + "\";\n";
                cuerpo += "\"" + tmp.siguiente.nombre + "\" -> \"" + tmp.nombre + "\";\n";
            }
            tmp = tmp.siguiente;
        }
        return cuerpo;
    }
}