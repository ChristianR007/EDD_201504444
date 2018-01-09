using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Pagina
/// </summary>
public class Pagina
{
    public NodoB[] claves;// = new Horario[4];
    public Pagina[] ramas;// = 
    public int cuentas;
    private int num = 5;
    public Pagina()
    {
        claves = new NodoB[4];
        ramas = new Pagina[5];

        for (int i = 0; i < 4; i++)
        {
            this.claves[i] = null;
        }
        for (int i = 0; i < 5; i++)
        {
            this.ramas[i] = null;
        }
        this.cuentas = 0;

    }

    public string printPage()
    {
        string cadena = claves[0].numeroAtaque.ToString() + "[label=\""; ;
        int i = 0;
        for (i = 0; i < this.cuentas; i++)
        {
            if (claves[i] != null)
            {
                //string cX, int cy, string uAtacante, int resultado, string uDanada, string emisor, string receptor, string fecha, string tRes, int nAtaq
                cadena += "<C" + i.ToString() + ">|";
                cadena += " Coordenada X: " + claves[i].coordenadaX + Convert.ToChar(92).ToString();
                cadena += Convert.ToChar(110).ToString() + "Coordenada Y: " + claves[i].coordenadaY.ToString() + Convert.ToChar(92).ToString();
                cadena += Convert.ToChar(110).ToString() + "Unidad Atacante: " + claves[i].unidadAtacante + Convert.ToChar(92).ToString();
                cadena += Convert.ToChar(110).ToString() + "Resultado: " + claves[i].resultado + Convert.ToChar(92).ToString();
                cadena += Convert.ToChar(110).ToString() + "Unidad Dañada: " + claves[i].tipoUnidadDanada + Convert.ToChar(92).ToString();
                cadena += Convert.ToChar(110).ToString() + "Emisor: " + claves[i].emisor + Convert.ToChar(92).ToString();
                cadena += Convert.ToChar(110).ToString() + "Receptor: " + claves[i].receptor + Convert.ToChar(92).ToString();
                cadena += Convert.ToChar(110).ToString() + "Fecha: " + claves[i].fecha + Convert.ToChar(92).ToString();
                cadena += Convert.ToChar(110).ToString() + "Tiempo Restante: " + claves[i].tiempoRestante + Convert.ToChar(92).ToString();
                cadena += Convert.ToChar(110).ToString() + "Numero de ataque: " + claves[i].numeroAtaque.ToString() + Convert.ToChar(92).ToString();
                cadena += " |";
            }
        }
        cadena += "<C" + (i).ToString() + "> \"];\n";
        return cadena;
    }

    public string printPage2()
    {
        string cadena = "";
        for (int i = 0; i < 1; i++)
        {
            if (claves[i] != null)
            {
                cadena += claves[i].numeroAtaque.ToString();
            }
        }
        return cadena;
    }

    public NodoB encuentraHorario(int codigo)
    {
        for (int i = 0; i < this.cuentas; i++)
        {
            if (claves[i] != null)
            {
                if (claves[i].numeroAtaque == codigo)
                {
                    return claves[i];
                }
            }
        }
        return null;
    }

    public bool editarHorario(int codigo, NodoB nuevo)
    {
        for (int i = 0; i < this.cuentas; i++)
        {
            if (claves[i] != null)
            {
                if (claves[i].numeroAtaque == codigo)
                {
                    //claves[i].dia = nuevo.dia;
                    //claves[i].rango = nuevo.rango;
                    //claves[i].refCatedra = nuevo.refCatedra;
                    //claves[i].refCurso = nuevo.refCurso;
                    //claves[i].refSalon = nuevo.refSalon;
                    return true;
                }
            }
        }
        return false;
    }

    public string reporteUno(int carnet)
    {
        string cadena = "";
        for (int i = 0; i < this.cuentas; i++)
        {
            if (claves[i] != null)
            {
                /*if (claves[i].asigandos.elementos > 0)
                {
                    cadena += claves[i].asigandos.cursosAsignadosPorEstudiante(carnet, claves[i].refCurso.nombre);
                }*/
            }
        }
        return cadena;
    }

    public string reporteDos(int codCurso, int year, int semes)
    {
        string cadena = "";
        for (int i = 0; i < this.cuentas; i++)
        {
            if (claves[i] != null)
            {
                /*if (claves[i].asigandos.elementos > 0)
                {
                    if (claves[i].refCurso.codigo == codCurso && claves[i].semestre == semes && claves[i].year == year)
                    {
                        cadena += claves[i].asigandos.AsignadosACurso(0);
                    }
                }*/
            }
        }
        return cadena;
    }

    public string reporteTres(int cod, int semestre, int year)
    {
        string cadena = "";
        for (int i = 0; i < this.cuentas; i++)
        {
            if (claves[i] != null)
            {
                /*if (claves[i].asigandos.elementos > 0)
                {
                    if (claves[i].refSalon.numSalon == cod && claves[i].semestre == semestre && claves[i].year == year)
                    {
                        //cadena = cadena + "<tr>\n";
                        cadena += (claves[i].refCurso.codigo).ToString() + " - " + claves[i].refCurso.nombre + " - " + claves[i].rango + " - " + claves[i].dia;
                        //cadena = cadena + "</tr>\n";
                    }
                }*/
            }
        }
        return cadena;
    }

    public string reporteCuatro()
    {
        string cadena = "";
        for (int i = 0; i < this.cuentas; i++)
        {
            if (claves[i] != null)
            {
                /*if (claves[i].asigandos.elementos > 0)
                {
                    cadena += claves[i].asigandos.aproRepro(claves[i].refCurso.nombre);
                }*/
            }
        }
        return cadena;
    }
}