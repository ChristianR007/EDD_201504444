using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de AVL
/// </summary>
public class AVL
{
    class nodoAVL
    {
        public string nickname;
        public string password;
        public string correo;
        public nodoAVL izquierda;
        public nodoAVL derecha;
        public nodoAVL(string nick, string pass, string correo)
        {
            this.nickname = nick;
            this.password = pass;
            this.correo = correo;
        }
    }
    nodoAVL raiz;

    public AVL()
    {
        // raiz = null;
    }
    // ------------------------------------------------------------------------------------------------------------------------- ROTACIONES
    private nodoAVL Rotacion_DD(nodoAVL actual) // Rotacion Derecha Derecha
    {
        nodoAVL pivote = actual.derecha;
        actual.derecha = pivote.izquierda;
        pivote.izquierda = actual;
        return pivote;
    }
    private nodoAVL Rotacion_II(nodoAVL actual) // Rotacion Izquierda Izquierda
    {
        nodoAVL pivote = actual.izquierda;
        actual.izquierda = pivote.derecha;
        pivote.derecha = actual;
        return pivote;
    }
    private nodoAVL Rotacion_ID(nodoAVL actual) // Rotacion Izquierda Derecha
    {
        nodoAVL pivote = actual.izquierda;
        actual.izquierda = Rotacion_DD(pivote);
        return Rotacion_II(actual);
    }
    private nodoAVL Rotacion_DI(nodoAVL actual) // Rotacion Derecha Izquierda
    {
        nodoAVL pivote = actual.derecha;
        actual.derecha = Rotacion_II(pivote);
        return Rotacion_DD(actual);
    }
    // --------------------------------------------------------------------------------------------------------------------------------------------
    private int max(int l, int r)
    {
        return l > r ? l : r;
    }
    private int altura(nodoAVL actual)
    {
        int height = 0;
        if (actual != null)
        {
            int l = altura(actual.izquierda);
            int r = altura(actual.derecha);
            int m = max(l, r);
            height = m + 1;
        }
        return height;
    }
    private int dirBalanceo(nodoAVL actual) // Indicara el tipo de balanceo
    {
        int l = altura(actual.izquierda);
        int r = altura(actual.derecha);
        int factor = l - r;
        return factor;
    }

    public void InsertarAVL(AVL root, string nick, string pass, string correo)
    {
        nodoAVL nuevo = new nodoAVL(nick, pass, correo);
        if (root.raiz == null)
        {
            root.raiz = nuevo;
        }
        else
        {
            root.raiz = InsertarAVLR(root.raiz, nuevo);
        }
    }
    private nodoAVL InsertarAVLR(nodoAVL actual, nodoAVL nuevo)
    {
        if (actual == null)
        {
            actual = nuevo;
            return actual;
        }
        else if (nuevo.nickname.CompareTo(actual.nickname) < 0)
        {
            actual.izquierda = InsertarAVLR(actual.izquierda, nuevo);
            actual = balanceo(actual);
        }
        else if (nuevo.nickname.CompareTo(actual.nickname) > 0)
        {
            actual.derecha = InsertarAVLR(actual.derecha, nuevo);
            actual = balanceo(actual);
        }
        return actual;
    }

    private nodoAVL balanceo(nodoAVL actual)
    {
        int valorB = dirBalanceo(actual);
        if (valorB > 1)
        {
            if (dirBalanceo(actual.izquierda) > 0)
            {
                actual = Rotacion_II(actual);
            }
            else
            {
                actual = Rotacion_ID(actual);
            }
        }
        else if (valorB < -1)
        {
            if (dirBalanceo(actual.derecha) > 0)
            {
                actual = Rotacion_DI(actual);
            }
            else
            {
                actual = Rotacion_DD(actual);
            }
        }
        return actual;
    }

    public void Eliminar(AVL root, string nick)
    {
        root.raiz = Eliminar(root.raiz, nick);
    }
    private nodoAVL Eliminar(nodoAVL actual, string nick)
    {
        nodoAVL aux;
        if (actual == null)
        { return null; }
        else
        {
            if (nick.CompareTo(actual.nickname) < 0)// arbol del lado izquierdo
            {
                actual.izquierda = Eliminar(actual.izquierda, nick);
                if (dirBalanceo(actual) == -2)
                {
                    if (dirBalanceo(actual.derecha) <= 0)
                    {
                        actual = Rotacion_DD(actual);
                    }
                    else
                    {
                        actual = Rotacion_DI(actual);
                    }
                }
            }
            else if (nick.CompareTo(actual.nickname) > 0)// arbol del lado derecho
            {
                actual.derecha = Eliminar(actual.derecha, nick);
                if (dirBalanceo(actual) == 2)
                {
                    if (dirBalanceo(actual.izquierda) >= 0)
                    {
                        actual = Rotacion_II(actual);
                    }
                    else
                    {
                        actual = Rotacion_ID(actual);
                    }
                }
            }
            // luego de ser encontrado
            else
            {
                if (actual.derecha != null)
                {
                    aux = actual.derecha;
                    while (aux.izquierda != null)
                    {
                        aux = aux.izquierda;
                    }
                    actual.nickname = aux.nickname;
                    actual.derecha = Eliminar(actual.derecha, aux.nickname);
                    if (dirBalanceo(actual) == 2)// Aca se rebalancea de nuevo
                    {
                        if (dirBalanceo(actual.izquierda) >= 0)
                        {
                            actual = Rotacion_II(actual);
                        }
                        else { actual = Rotacion_ID(actual); }
                    }
                }
                else
                {
                    return actual.izquierda;
                }
            }
        }
        return actual;
    }
    public bool buscar(AVL root, string nick)
    {
        if (buscarR(nick, root.raiz) != null)
        {
            if (buscarR(nick, root.raiz).nickname == nick)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;

    }

    public void modificar(AVL root, string contactoAModificar, string pass, string correo)
    {
        nodoAVL mod = buscarR(contactoAModificar, root.raiz);
        if (mod != null)
        {
            mod.password = pass;
            mod.correo = correo;
        }
    }

    private nodoAVL buscarR(string nick, nodoAVL actual)
    {
        if (actual != null)
        {
            if (nick.CompareTo(actual.nickname) < 0)
            {
                if (nick == actual.nickname)
                {
                    return actual;
                }
                else
                    return buscarR(nick, actual.izquierda);
            }
            else
            {
                if (nick == actual.nickname)
                {
                    return actual;
                }
                else
                    return buscarR(nick, actual.derecha);
            }
        }
        return null;
    }

    string cuerpo;
    public string mostrarDot(AVL root)
    {
        cuerpo = "";
        if (root.raiz == null)
        {
            return cuerpo;
        }
        return mostrarDotR(root.raiz);
    }
    private string mostrarDotR(nodoAVL actual)
    {
        if (actual != null)
        {
            cuerpo += "\"Nickname: " + actual.nickname.ToString() + "\nContraseña: " + actual.password.ToString() + "\nCorreo: " + actual.correo.ToString() + "\";\n";
            if (actual.izquierda != null)
            {
                cuerpo += "\"Nickname: " + actual.nickname.ToString() + "\nContraseña: " + actual.password.ToString() + "\nCorreo: " + actual.correo.ToString() + "\"->\"Nickname: " + actual.izquierda.nickname.ToString() + "\nContraseña: " + actual.izquierda.password.ToString() + "\nCorreo: " + actual.izquierda.correo.ToString() + "\";\n";
            }
            if (actual.derecha != null)
            {
                cuerpo += "\"Nickname: " + actual.nickname.ToString() + "\nContraseña: " + actual.password.ToString() + "\nCorreo: " + actual.correo.ToString() + "\"->\"Nickname: " + actual.derecha.nickname.ToString() + "\nContraseña: " + actual.derecha.password.ToString() + "\nCorreo: " + actual.derecha.correo.ToString() + "\";\n";
            }
            mostrarDotR(actual.izquierda);
            mostrarDotR(actual.derecha);
        }
        return cuerpo;
    }
    string sub;
    public string mostrarsub(AVL root)
    {
        sub = "";
        if (root.raiz == null)
        {
            return sub;
        }
        return mostrarsubR(root.raiz);
    }
    private string mostrarsubR(nodoAVL actual)
    {
        if (actual != null)
        {
            sub += "\"Nickname: " + actual.nickname.ToString() + "\nContraseña: " + actual.password.ToString() + "\nCorreo: " + actual.correo.ToString() + "\"[style=filled; color= white;];\n";
            mostrarsubR(actual.izquierda);
            mostrarsubR(actual.derecha);
        }
        return sub;
    }


}