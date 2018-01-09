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
        public AVL sigAVL = null;

    }
    NodoABB raiz = null;

    public bool Insertar(string nombreU, string passwordU, string correoU, string conectadoU)
    {
        NodoABB nuevo = new NodoABB();
        listaDoble nuevoJJ = new listaDoble();
        AVL nuevoCC = new AVL();
        nuevo.nickname = nombreU;
        nuevo.pass = passwordU;
        nuevo.correo = correoU;
        nuevo.conectado = conectadoU;
        nuevo.sigLd = nuevoJJ;
        nuevo.sigAVL = nuevoCC;

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
    // ---------------------------------------------------------------------------------------------------------------------------------------INSERTAR JUGADORES
    //Usuario Base,Oponente,unidades desplegadas,unidades sobrevivientes,Unidades Destruidas,"Gano (1 si, 0 no)"
    public string InsertarJuegos(string nick, string jugador, string uDesplegables, string uSobrevivientes, string uDestruidas, string Gano)
    {
        NodoABB aux = RetornarNodoDeABB(raiz, nick);
        if (aux != null) {
            if (aux.nickname == nick)
            {
                aux.sigLd.Insertar(aux.sigLd, jugador, uDesplegables, uSobrevivientes, uDestruidas, Gano);
                return "si";
            }
        }
        return "no";
    }
    public string modificarJuego(string nick, string jugadorViejo, string jugadorNuevo, string uDesplegables, string uSobrevivientes, string uDestruidas, string Gano) {
        NodoABB nodoUsuario = RetornarNodoDeABB(raiz, nick);
        if (nodoUsuario != null) {
            nodoUsuario.sigLd.modificar(nodoUsuario.sigLd ,jugadorViejo, jugadorNuevo, uDesplegables, uSobrevivientes, uDestruidas, Gano);
            return "si";
        }
        return "no";
    }
    public string eliminarJuego(string nick, string jugadorAEliminar)
    {
        NodoABB nodoUsuario = RetornarNodoDeABB(raiz, nick);
        if (nodoUsuario != null)
        {
            nodoUsuario.sigLd.eliminar(nodoUsuario.sigLd, jugadorAEliminar);
            return "si";
        }
        return "no";
    }

    // -----------------------------------------------------------------------------------------------------------------------------------------INSERTAR CONTACTOS
    //[0]Usuario padre, [1]Nickname, [2]ContraseNa, [3]correo electronico
    public string InsertarContactos(string nick, string nickContacto, string pass, string correo) {
        NodoABB aux = RetornarNodoDeABB(raiz, nick);
        if (aux != null)
        {
            if (aux.nickname == nick)
            {
                aux.sigAVL.InsertarAVL(aux.sigAVL, nickContacto, pass, correo);
                return "si";
            }
        }
        return "no";
    }
    public bool verificarABB(string nick) {
        NodoABB aux = RetornarNodoDeABB(raiz, nick);
        if (aux != null)
        {
            return true; // Es porque si lo encontro
        }
        else {
            return false; // Si es null es porque no hay nada
        }
    }
    public string modificarContactos(string nick, string ContactoActual, string pass, string correo)
    {
        NodoABB nodoUsuario = RetornarNodoDeABB(raiz, nick);
        if (nodoUsuario != null)
        {
            nodoUsuario.sigAVL.modificar(nodoUsuario.sigAVL, ContactoActual, pass, correo);
            return "si";
        }
        return "no";
    }
    public string eliminarContactos(string nick, string ContactoAEliminar)
    {
        NodoABB nodoUsuario = RetornarNodoDeABB(raiz, nick);
        if (nodoUsuario != null)
        {
            nodoUsuario.sigAVL.Eliminar(nodoUsuario.sigAVL, ContactoAEliminar);
            return "si";
        }
        return "no";
    }
    // -----------------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------- RETORNO ABB
    NodoABB tmp;
    private NodoABB RetornarNodoDeABB(NodoABB jj, string nickn) // Retorna el nodo del ABB que estoy buscando
    {
        if (jj != null)
        {
            if (jj.nickname == nickn)
            {
                tmp = jj;
            }
            RetornarNodoDeABB(jj.izq, nickn);
            RetornarNodoDeABB(jj.der, nickn);
        }

        return tmp;
    }
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------
    public string espejo()
    {
        NodoABB nuevaRaizEspejo = raiz;
        espejoR(nuevaRaizEspejo);
        return dotArbolR(nuevaRaizEspejo); ;
    }
    private void espejoR(NodoABB actual)
    {
        if (actual == null)
        {
            return;
        }
        else
        {
            NodoABB tmp;
            espejoR(actual.izq);
            espejoR(actual.der);

            tmp = actual.izq;
            actual.izq = actual.der;
            actual.der = tmp;
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


    int verificacion;
    public int buscarUsuario(string nombre, string pass)
    {
        verificacion = 0;
        if ((raiz.nickname == nombre) && (raiz.pass == pass))
        {
            return 1;
        }
        else
        {
            return buscarUsuarioR(raiz, nombre, pass);
        }
    }

    private int buscarUsuarioR(NodoABB rec, string nombre, string pass)
    {
        if (rec != null)
        {
            if ((rec.nickname == nombre) && (rec.pass == pass))
            {
                return verificacion++;
            }
            else
            {
                buscarUsuarioR(rec.izq, nombre, pass);
                buscarUsuarioR(rec.der, nombre, pass);
            }
        }
        else {
            return 0;
        }
        return verificacion;
    }

    int verificacion2;
    public int buscarUsu(string nombre)
    {
        verificacion2 = 0;
        if (raiz.nickname == nombre)
        {
            return 1;
        }
        else
        {
            return buscarUsuR(raiz, nombre);
        }
    }

    private int buscarUsuR(NodoABB rec, string nombre)
    {
        if (rec != null)
        {
            if (rec.nickname == nombre)
            {
                return verificacion2++;
            }
            else
            {
                buscarUsuR(rec.izq, nombre);
                buscarUsuR(rec.der, nombre);
            }
        }
        return verificacion2;
    }

    public void modificar(string nick, string nuevoNombre, string nuevaPass, string nuevoCorreo, string nuevoConec)
    {
        if (raiz.nickname == nick)
        {
            raiz.nickname = "";
            raiz.nickname = nuevoNombre;
            raiz.pass = nuevaPass;
            raiz.correo = nuevoCorreo;
            raiz.conectado = nuevoConec;
        }
        else
        {
            modificarR(raiz, nick, nuevoNombre, nuevaPass, nuevoCorreo, nuevoConec);
        }
    }

    private void modificarR(NodoABB rec, string nick, string nuevoNombre, string nuevaPass, string nuevoCorreo, string nuevoConec)
    {
        if (rec != null)
        {
            if (rec.nickname == nick)
            {
                rec.nickname = "";
                rec.nickname = nuevoNombre;
                rec.pass = nuevaPass;
                rec.correo = nuevoCorreo;
                rec.conectado = nuevoConec;
            }
            else
            {
                modificarR(rec.izq, nick, nuevoNombre, nuevaPass, nuevoCorreo, nuevoConec);
                modificarR(rec.der, nick, nuevoNombre, nuevaPass, nuevoCorreo, nuevoConec);
            }
        }
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
        else if (nombre.CompareTo(raizSub.nickname) < 0)
        {
            NodoABB iz;
            iz = eliminarR(raizSub.izq, nombre);
            raizSub.izq = iz;
        }
        else if (nombre.CompareTo(raizSub.nickname) > 0)
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
    int clu;
    int clu2;
    public string dotArbol()
    {
        clu = 0;
        clu2 = 1000;
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
            cadena += "\"Nickname: " + actual.nickname + "\nContraseña: " + actual.pass + "\nCorreo: " + actual.correo + "\nConectado: " + actual.conectado + "\"[style=filled; color= lightgray;];\n";
            if (!string.IsNullOrEmpty(actual.sigLd.mostrar(actual.sigLd)))
            {
                cadena += "\"Nickname: " + actual.nickname + "\nContraseña: " + actual.pass + "\nCorreo: " + actual.correo + "\nConectado: " + actual.conectado + "\"->";
                cadena += actual.sigLd.mostrar(actual.sigLd) + "\n";
                cadena += "subgraph cluster_" + clu + "  {style=filled;color=Blue;\n" + actual.sigLd.sub(actual.sigLd) + "}";
                clu++;
            }
            if (!string.IsNullOrEmpty(actual.sigAVL.mostrarDot(actual.sigAVL)))
            {
                cadena += "\"Nickname: " + actual.nickname + "\nContraseña: " + actual.pass + "\nCorreo: " + actual.correo + "\nConectado: " + actual.conectado + "\"->";
                cadena += actual.sigAVL.mostrarDot(actual.sigAVL) + "\n";
                cadena += "subgraph cluster_" + clu2 + "  {style=filled;color=Green;\n" + actual.sigAVL.mostrarsub(actual.sigAVL) + "}";
                clu2++;
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