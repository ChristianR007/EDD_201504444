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
        public string jugador;
        public string uDesplegables;
        public string uSobrevivientes;
        public string uDestruidas;
        public string Gano;
        public NodoD siguiente;
        public NodoD atras;
    }
    NodoD primero = null;

    public void Insertar(listaDoble ld, string jug, string desp, string sobre, string dest, string gano)
    {
        NodoD nuevo = new NodoD();
        nuevo.jugador = jug;
        nuevo.uDesplegables = desp;
        nuevo.uSobrevivientes = sobre;
        nuevo.uDestruidas = dest;
        nuevo.Gano = gano;
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
            cuerpo += "\"Nombre Jugador: " + tmp.jugador + "\nUnidades Desplegables: " + tmp.uDesplegables + "\nUnidades Sobrevivientes: " + tmp.uSobrevivientes + "\nUnidades Destruidas: " + tmp.uDestruidas + "\nGano: " + tmp.Gano + "\";\n";
            if (tmp.siguiente != null)
            {
                cuerpo += "\"Nombre Jugador: " + tmp.jugador + "\nUnidades Desplegables: " + tmp.uDesplegables + "\nUnidades Sobrevivientes: " + tmp.uSobrevivientes + "\nUnidades Destruidas: " + tmp.uDestruidas + "\nGano: " + tmp.Gano + "\" -> \"Nombre Jugador: " + tmp.siguiente.jugador + "\nUnidades Desplegables: " + tmp.siguiente.uDesplegables + "\nUnidades Sobrevivientes: " + tmp.siguiente.uSobrevivientes + "\nUnidades Destruidas: " + tmp.siguiente.uDestruidas + "\nGano: " + tmp.siguiente.Gano + "\";\n";
                cuerpo += "\"Nombre Jugador: " + tmp.siguiente.jugador + "\nUnidades Desplegables: " + tmp.siguiente.uDesplegables + "\nUnidades Sobrevivientes: " + tmp.siguiente.uSobrevivientes + "\nUnidades Destruidas: " + tmp.siguiente.uDestruidas + "\nGano: " + tmp.siguiente.Gano + "\" -> \"Nombre Jugador: " + tmp.jugador + "\nUnidades Desplegables: " + tmp.uDesplegables + "\nUnidades Sobrevivientes: " + tmp.uSobrevivientes + "\nUnidades Destruidas: " + tmp.uDestruidas + "\nGano: " + tmp.Gano + "\";\n";
            }
            tmp = tmp.siguiente;
        }
        return cuerpo;
    }
}