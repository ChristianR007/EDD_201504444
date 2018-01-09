using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Top
/// </summary>
public class Top
{
    class nodoTop
    {
        public string nombre;
        public int comparador;
        public nodoTop sig;
        public nodoTop atras;
        public nodoTop(string nombre, int gano)
        {
            this.nombre = nombre;
            this.comparador = gano;
        }
    }
    nodoTop primero = null;

    public void Insertar(Top ld, string nombre, int comparador)
    {
        nodoTop nuevo = new nodoTop(nombre, comparador);

        if (ld.primero == null)
        {
            ld.primero = nuevo;
        }
        else
        {
            nodoTop aux = ld.primero;
            while (aux != null)
            {
                if (nuevo.comparador > aux.comparador)
                {
                    nodoTop tmp = aux.atras;
                    nuevo.sig = aux;
                    aux.atras = nuevo;
                    if (aux == ld.primero)
                    {
                        ld.primero = nuevo;
                    }
                    else
                    {
                        tmp.sig = nuevo;
                        nuevo.atras = tmp;
                    }
                    break;
                }
                else
                {
                    if (aux.sig == null)
                    {
                        aux.sig = nuevo;
                        nuevo.atras = aux;
                        break;
                    }
                    else
                    {
                        aux = aux.sig;
                    }

                }

            }
        }
    }

    public string mostrar(Top ld, string nombrelabel)
    {
        nodoTop tmp = ld.primero;
        string cuerpo = "digraph Top{\nrankdir=TB;\n node [shape = record, style=filled, fillcolor=white];\n";
        cuerpo += "label=\"Top 10 de " + nombrelabel + " \";";
        int pos = 1;
        while (tmp != null)
        {
            if (pos == 11)
            {
                break;
            }
            else
            {
                cuerpo += tmp.nombre + "[label=\"" + pos.ToString();
                cuerpo += " | Nombre: " + tmp.nombre;
                cuerpo += Convert.ToChar(92).ToString() + Convert.ToChar(110).ToString();
                cuerpo += "Gano: " + tmp.comparador;
                cuerpo += "\"];\n";
                if (tmp.sig != null && pos + 1 != 11)
                {
                    cuerpo += tmp.nombre + " -> " + tmp.sig.nombre + ";\n";
                }
                pos++;
                tmp = tmp.sig;
            }
        }
        return cuerpo + "\n}";
    }
}