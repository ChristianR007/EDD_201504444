using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoB
/// </summary>
public class NodoB
{
    //public int codigo;
    public string coordenadaX;
    public int coordenadaY;
    public string unidadAtacante;
    public int resultado;
    public string tipoUnidadDanada;
    public string emisor;
    public string receptor;
    public string fecha;
    public string tiempoRestante;
    public int numeroAtaque;
    //public Horario(int codigo, string rango, string dia, Salon refSalon, Catedratico refCatedra, Curso refCurso, int semestre, int year, string edif ) {
    public NodoB(string cX, int cy, string uAtacante, int resultado, string uDanada, string emisor, string receptor, string fecha, string tRes, int nAtaq)
    {
        this.coordenadaX = cX;
        this.coordenadaY = cy;
        this.unidadAtacante = uAtacante;
        this.resultado = resultado;
        this.tipoUnidadDanada = uDanada;
        this.emisor = emisor;
        this.receptor = receptor;
        this.fecha = fecha;
        this.tiempoRestante = tRes;
        this.numeroAtaque = nAtaq;
        //this.asigandos = new ListadoAsignacion(this.refSalon.capacidad);
    }
}