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

    public bool Buscar(listaDoble ld, string dato)
    {
        NodoD aux = ld.primero;
        bool bandera = false;
        while (aux != null)
        {
            if (aux.jugador == dato)
            {
                bandera = true;
                break;
            }
            aux = aux.siguiente;
        }

        return bandera;
    }

    public void eliminar(listaDoble ld, String nombre)
    {
        NodoD aux = null;
        if (Buscar(ld, nombre) == true)
        {
            if (ld.primero.jugador == nombre)
            {
                if (ld.primero.siguiente != null)
                {
                    aux = ld.primero.siguiente;
                    aux.atras = null;
                    ld.primero.siguiente = null;
                    ld.primero = aux;
                }
                else
                {
                    ld.primero = null;
                }

            }
            else
            {
                aux = ld.primero;
                while (aux != null)
                {
                    if (aux.siguiente == null)
                    {
                        NodoD auxT = null;
                        if (aux.jugador == nombre)
                        {
                            auxT = aux.atras;
                            auxT.siguiente = null;
                            aux.atras = null;
                            aux = auxT;
                            break;
                        }
                    }
                    else if (aux.jugador == nombre)
                    {
                        NodoD auxA = aux.atras;
                        NodoD auxS = aux.siguiente;
                        aux.siguiente = null;
                        aux.atras = null;
                        auxA.siguiente = auxS;
                        auxS.atras = auxA;
                        break;
                    }
                    else
                    {
                        aux = aux.siguiente;
                    }
                }
            }
        }
    }

    public void modificar(listaDoble ld,string jugViejo, string jug, string desp, string sobre, string dest, string gano)
    {
        NodoD aux = ld.primero;
        while (aux != null)
        {
            if (aux.jugador == jugViejo)
            {
                aux.jugador = "";
                aux.jugador = jug;
                aux.uDesplegables = desp;
                aux.uSobrevivientes = sobre;
                aux.uDestruidas = dest;
                aux.Gano = gano;
                break;
            }
            else
            {
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
    public string sub(listaDoble ld) {
        NodoD tmp = ld.primero;
        string cuerpo = "";
        while (tmp != null)
        {
            cuerpo += "\"Nombre Jugador: " + tmp.jugador + "\nUnidades Desplegables: " + tmp.uDesplegables + "\nUnidades Sobrevivientes: " + tmp.uSobrevivientes + "\nUnidades Destruidas: " + tmp.uDestruidas + "\nGano: " + tmp.Gano + "\"[style=filled; color= white;];\n";
            tmp = tmp.siguiente;
        }
        return cuerpo;
    }
}