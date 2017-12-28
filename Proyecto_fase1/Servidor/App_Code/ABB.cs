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
        public NodoABB izq = null;
        public NodoABB der = null;

    }
    NodoABB raiz = null;

    private int convertir(string cadena)
    {
        int valorAscii = 0;
        int ascii = Encoding.ASCII.GetBytes("A")[0];

        var chars = cadena.ToCharArray();
        for (int ctr = 0; ctr < chars.Length; ctr++)
            valorAscii += chars[ctr];

        return valorAscii;
    }

    public bool Insertar(string nombre)
    {
        NodoABB nuevo = new NodoABB();
        nuevo.nickname = nombre;
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
        if (convertir(nuevo.nickname) < convertir(raizSig.nickname))
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
        else if (convertir(nombre) < convertir(raizSub.nickname))
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
        }
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
            cadena += "\"" + actual.nickname + "\";\n";
            if (actual.izq != null)
            {
                cadena += "\"" + actual.nickname + "\" -> \"" + actual.izq.nickname + "\";\n";
                cadena += dotArbolR(actual.izq);
            }

            if (actual.der != null)
            {
                cadena += "\"" + actual.nickname + "\" -> \"" + actual.der.nickname + "\";\n";
                cadena += dotArbolR(actual.der);
            }
            return cadena;
        }
    }

    public void graficar() {
        TextWriter archivo;
        archivo = new StreamWriter("C:\\Users\\Christian\\Desktop\\Graficas\\prueba.dot");
        archivo.WriteLine("digraph G{a->b;}");
        archivo.Close();
    }

    public void Imagen() {
        string cuerpo;
        cuerpo = "dot -Tpng prueba.txt -o prueba.png";
        System.Diagnostics.ProcessStartInfo dot = new System.Diagnostics.ProcessStartInfo("cmd", "C:\\Users\\Christian\\Desktop\\Graficas " + cuerpo);
        System.Diagnostics.Process.Start(dot);
    }



}