using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Hash
/// </summary>
public class Hash
{
    public int tamInicial = 43;
    public double ocupMaximo;// = 0.5;
    public double ocupMinima;// = 0.3;
    public string[] tablaHash = new string[43];

    public Hash()
    {
        this.ocupMaximo = (this.tamInicial * 0.5) - 0.5;
        this.ocupMinima = this.tamInicial * 0.3;
    }

    public void insertar(string usuario)
    {
        int numCadena = retornoNumCadena(usuario);
        int key = funcionHash(numCadena);

        if (contadorExistente() == ocupMaximo)
        {
            this.tamInicial = primoMasCercano(tamInicial + 1);
            this.ocupMaximo = (this.tamInicial * 0.5) - 0.5;
            Array.Resize(ref tablaHash, this.tamInicial);
        }
        this.n = 0;
        rehashing(key, usuario); // Inserta con funcion hash o con rehashing

    }
    int n = 0;
    private void rehashing(int clave, string nombreUsuario)
    {
        n++;
        if (!string.IsNullOrEmpty(tablaHash[clave]))    // esta lleno
        {
            // "Hay que hacer Rehashing";
            rehashing(funcionHash(clave + (n * n)), nombreUsuario);
        }
        else
        {
            // "Se Inserto Correctamente";
            tablaHash[clave] = nombreUsuario;
        }
    }

    private int retornoNumCadena(string cadena)
    {
        int valorAscii = 0;

        var chars = cadena.ToCharArray();
        for (int ctr = 0; ctr < chars.Length; ctr++)
            valorAscii += chars[ctr];
        return valorAscii;
    }

    int funcionHash(int key)
    {
        return key % this.tamInicial;
    }

    int nuevoNum;
    int primoMasCercano(int primo)
    {

        if (verificaPrimo(primo) == true)
        {
            return nuevoNum;
        }
        nuevoNum = primo + 1;
        return primoMasCercano(primo + 1);
    }

    bool verificaPrimo(int numero)
    {
        int a = 0, i, n;
        n = Convert.ToInt32(numero);
        bool bandera;
        for (i = 1; i < (n + 1); i++)
        {
            if (n % i == 0)
            {
                a++;
            }
        }
        if (a != 2)
        {
            // "No es Primo";
            return false;
        }
        else
        {
            return true;
            // "Si es Primo";
        }
    }

    public int contadorExistente()
    {
        int contador = 0;
        for (int x = 0; x < tablaHash.Length; x++)
        {
            if (!string.IsNullOrEmpty(tablaHash[x]))    // esta lleno
            {
                contador++;
            }
        }

        return contador;
    }


    public string mostrar()
    {
        string n = "Nombre de Usuario: ";
        string cuerpo = "digraph grafica{\n";
        bool bandera = false;
        cuerpo += "node [shape = record, style=filled, fillcolor=white];\n";
        cuerpo += "subgraph cluster_0  {style=filled;color=Blue;\n\n";
        cuerpo += "hash [label=\" {\n";
        for (int x = 0; x < tablaHash.Length; x++)
        {
            if (!string.IsNullOrEmpty(tablaHash[x]))    // esta lleno
            {
                if (bandera)
                {
                    cuerpo += " | ";
                }
                cuerpo += "{" + x.ToString() + " | " + n + tablaHash[x] + "}\n";

                bandera = true;
            }
        }
        cuerpo += "\n}\" ];\n}\nlabel = \"Tabla Hash\";\n}";
        return cuerpo;
    }
}