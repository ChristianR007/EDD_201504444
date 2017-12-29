using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;

/// <summary>
/// Descripción breve de ABB
/// </summary>
public class ABB
{
    class NodoABB
    {
        public string nickname;
        public string pass;
        public string correo;
        public string conectado;
        public NodoABB izq = null;
        public NodoABB der = null;

        public listaDoble sigLd = null;

    }
    NodoABB raiz = null;

    public bool Insertar(string nombreU, string passwordU, string correoU, string conectadoU)
    {
        NodoABB nuevo = new NodoABB();
        listaDoble nuevoJJ = new listaDoble();
        nuevo.nickname = nombreU;
        nuevo.pass = passwordU;
        nuevo.correo = correoU;
        nuevo.conectado = conectadoU;
        nuevo.sigLd = nuevoJJ;

        if (raiz == null)
        {
            raiz = nuevo;
            return true;
        }
        else
        {
            return InsertarR(raiz, nuevo);
        }
    }

    private bool InsertarR(NodoABB raizSig, NodoABB nuevo)
    {
        if (nuevo.nickname.CompareTo(raizSig.nickname) < 0)//&& convertir(nuevo.nickname) < convertir(raizSig.nickname))
        {
            if (raizSig.izq == null)
            {
                raizSig.izq = nuevo;
                return true;
            }
            else
            {
                return InsertarR(raizSig.izq, nuevo);
            }
        }
        else
        {
            if (raizSig.der == null)
            {
                raizSig.der = nuevo;
                return true;
            }
            else
            {
                return InsertarR(raizSig.der, nuevo);
            }
        }
    }

    //Usuario Base,Oponente,unidades desplegadas,unidades sobrevivientes,Unidades Destruidas,"Gano (1 si, 0 no)"
    public string InsertarJuegos(string nick, string jugador, string uDesplegables, string uSobrevivientes, string uDestruidas, string Gano)
    {
        NodoABB aux = InsertarJuegosR(raiz, nick);
        if (aux.nickname == nick)
        {
            aux.sigLd.Insertar(aux.sigLd, jugador, uDesplegables, uSobrevivientes, uDestruidas, Gano);
            return "si";
        }
        else
        {
            return "no";
        }
    }

    NodoABB tmp;
    private NodoABB InsertarJuegosR(NodoABB jj, string nickn)
    {
        if (jj != null)
        {
            if (jj.nickname == nickn)
            {
                tmp = jj;
            }
            InsertarJuegosR(jj.izq, nickn);
            InsertarJuegosR(jj.der, nickn);
        }

        return tmp;
    }


    private string buscarABB(NodoABB rr, string nombre)
    {
        if (rr != null)
        {
            if (rr.nickname == nombre)
            {
                return "si";
            }
            else
            {
                buscarABB(rr.izq, nombre);
                buscarABB(rr.der, nombre);
            }
        }

        return "";
    }

    // -------------------------------------------------    RECORRIDOS ------------------------------------------------------

    string cuerpoPre; // Recorrido en preorden
    public string preorden()
    {
        return preordenR(raiz);
    }
    private string preordenR(NodoABB reco)
    {
        if (reco != null)
        {
            cuerpoPre += reco.nickname + " - ";
            preordenR(reco.izq);
            preordenR(reco.der);
        }

        return cuerpoPre;
    }

    string cuerpoEnorden; // Recorrido enOrden
    public string enorden()
    {
        return enordenR(raiz);
    }
    private string enordenR(NodoABB reco)
    {
        if (reco != null)
        {
            enordenR(reco.izq);
            cuerpoEnorden += reco.nickname + " - ";
            enordenR(reco.der);
        }
        return cuerpoEnorden;
    }

    string cuerpoPost;
    public string postorden()   // Recorrido en postorden
    {
        return postordenR(raiz);
    }
    private string postordenR(NodoABB reco)
    {
        if (reco != null)
        {
            postordenR(reco.izq);
            postordenR(reco.der);
            cuerpoPost += reco.nickname + " - ";
        }
        return cuerpoPost;
    }

    // ----------------------------------------------------------------------------------------------------------------------



    public void eliminar(string nombre)
    {
        raiz = eliminarR(raiz, nombre);
    }

    private NodoABB eliminarR(NodoABB raizSub, string nombre)
    {
        if (raizSub == null)
        {
            // No se pudo eliminar, no se encontro
        }
        /*else if (convertir(nombre) < convertir(raizSub.nickname))
        {
            NodoABB iz;
            iz = eliminarR(raizSub.izq, nombre);
            raizSub.izq = iz;
        }
        else if (convertir(nombre) > convertir(raizSub.nickname))
        {
            NodoABB de;
            de = eliminarR(raizSub.der, nombre);
            raizSub.der = de;
        }*/
        else
        {
            NodoABB q;
            q = raizSub;
            if (q.izq == null)
            {
                raizSub = q.der;
            }
            else if (q.der == null)
            {
                raizSub = q.der;
            }
            else
            {
                q = reemplazar(q);
            }
            q = null;
        }
        return raizSub;
    }

    private NodoABB reemplazar(NodoABB act)
    {
        NodoABB a, p;
        p = act;
        a = act.izq;
        while (a.der != null)
        {
            p = a;
            a = a.der;
        }
        act.nickname = a.nickname;
        if (p == act)
        {
            p.izq = a.izq;
        }
        else
        {
            p.der = a.izq;
        }
        return a;
    }

    public int altura()
    {
        if (raiz == null)
        {
            return 0;
        }
        else
        {
            return alturaR(raiz);
        }
    }

    private int alturaR(NodoABB actual)
    {
        if (actual == null)
        {
            return 0;
        }
        else
        {
            int hi = alturaR(actual.izq);
            int hd = alturaR(actual.der);
            return (hi > hd ? hi : hd) + 1;
        }
    }

    public int hojas()
    {
        if (raiz == null)
        {
            return 0;
        }
        else
        {
            return hojasR(raiz);
        }
    }

    private int hojasR(NodoABB actual)
    {
        if (actual == null)
        {
            return 0;
        }
        else
        {
            if ((actual.izq == null) && (actual.der == null))
            {
                return 1;
            }
            else
            {
                return hojasR(actual.izq) + hojasR(actual.der);
            }
        }
    }

    public int ramas()
    {
        if (raiz == null)
        {
            return 0;
        }
        else
        {
            return ramasR(raiz) - 1;
        }
    }

    private int ramasR(NodoABB actual)
    {
        if (actual == null)
        {
            return 0;
        }
        else
        {
            if ((actual.izq != null) || (actual.der != null))
            {
                return ramasR(actual.der) + ramasR(actual.izq) + 1;
            }
            else
            {
                return 0;
            }
        }
    }

    public string dotArbol()
    {
        NodoABB aux = raiz;
        return dotArbolR(aux);
    }

    private string dotArbolR(NodoABB actual)
    {
        if (actual == null)
        {
            return "";
        }
        else
        {
            string cadena = "";
            cadena += "\"Nickname: " + actual.nickname + "\nContraseña: " + actual.pass + "\nCorreo: " + actual.correo + "\nConectado: " + actual.conectado + "\";\n";
            if (!string.IsNullOrEmpty(actual.sigLd.mostrar(actual.sigLd)))
            {
                cadena += "\"Nickname: " + actual.nickname + "\nContraseña: " + actual.pass + "\nCorreo: " + actual.correo + "\nConectado: " + actual.conectado + "\"->";
                cadena += actual.sigLd.mostrar(actual.sigLd) + "\n";
            }

            if (actual.izq != null)
            {
                cadena += "\"Nickname: " + actual.nickname + "\nContraseña: " + actual.pass + "\nCorreo: " + actual.correo + "\nConectado: " + actual.conectado + "\" -> \"Nickname: " + actual.izq.nickname + "\nContraseña: " + actual.izq.pass + "\nCorreo: " + actual.izq.correo + "\nConectado: " + actual.izq.conectado + "\";\n";
                cadena += dotArbolR(actual.izq);
            }

            if (actual.der != null)
            {
                cadena += "\"Nickname: " + actual.nickname + "\nContraseña: " + actual.pass + "\nCorreo: " + actual.correo + "\nConectado: " + actual.conectado + "\" -> \"Nickname: " + actual.der.nickname + "\nContraseña: " + actual.der.pass + "\nCorreo: " + actual.der.correo + "\nConectado: " + actual.der.conectado + "\";\n";
                cadena += dotArbolR(actual.der);
            }
            return cadena;
        }
    }



}