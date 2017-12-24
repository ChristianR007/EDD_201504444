using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class ABB
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
            string p1 = preordenR(raiz);
            return p1;
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
            string p2 = enordenR(raiz);
            return p2;
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
            string p3 = postordenR(raiz);
            return p3;
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

    }
}
