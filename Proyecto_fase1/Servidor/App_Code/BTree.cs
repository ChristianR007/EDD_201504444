using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de BTree
/// </summary>
public class BTree
{
    public string cadena;
    public int contador = 0;
    public Pagina p;
    public Pagina xder;
    public Pagina xizq;
    public NodoB x;
    public Pagina xr;
    public bool editado;
    public NodoB buscando;
    public bool empA = false;
    public bool esta = false;

    public BTree()
    {
        this.p = new Pagina();
        this.xder = new Pagina();
        this.xizq = new Pagina();
    }

    // Ve si el arbol esta vacio
    private bool vacio(Pagina p)
    {
        return (p == null || p.cuentas == 0) ? true : false;
    }

    // Metodo publico encargado de hacer la insercion
    public void insertarNuevoHorario(NodoB clave)
    {
        insertaPrivado(clave, this.p);
    }

    //Metodo privado que hace el llamado a las demas metodos
    private void insertaPrivado(NodoB clave, Pagina raiz)
    {
        empujar(clave, raiz);
        if (this.empA)
        {
            this.p = new Pagina();
            this.p.cuentas = 1;
            this.p.claves[0] = this.x;
            this.p.ramas[0] = raiz;
            this.p.ramas[1] = this.xr;
        }
        // "Arbol B insercion completa"
    }

    // Metodo Encargado de empujar
    private void empujar(NodoB clave, Pagina raiz)
    {
        int k = 0;
        this.esta = false;
        if (vacio(raiz))
        {
            this.empA = true;
            this.x = clave;
            this.xr = null;
        }
        else
        {
            k = buscarNodo(clave, raiz);
            if (this.esta)
            {
                // consola = "no debe haber claves repetidas"
                this.empA = false;
            }
            else
            {
                empujar(clave, raiz.ramas[k]);
                if (this.empA)
                {
                    if (raiz.cuentas < 4)
                    {
                        this.empA = false;
                        meterHoja(this.x, raiz, k);
                    }
                    else
                    {
                        this.empA = true;
                        dividirNodo(this.x, raiz, k);
                    }
                }
            }
        }
    }

    // Dividir Nodo
    private void dividirNodo(NodoB clave, Pagina raiz, int k)
    {
        int pos = 0;
        int posmda = 0;
        if (k <= 2)
        {
            posmda = 2;
        }
        else
        {
            posmda = 3;
        }
        Pagina mder = new Pagina();
        pos = posmda + 1;
        while (pos != 5)
        {
            mder.claves[(pos - posmda) - 1] = raiz.claves[pos - 1];
            mder.ramas[pos - posmda] = raiz.ramas[pos];
            ++pos;
        }
        mder.cuentas = 4 - posmda;
        raiz.cuentas = posmda;
        if (k <= 2)
        {
            meterHoja(clave, raiz, k);
        }
        else
        {
            meterHoja(clave, mder, (k - posmda));
        }
        this.x = raiz.claves[raiz.cuentas - 1];
        mder.ramas[0] = raiz.ramas[raiz.cuentas];
        raiz.cuentas = --raiz.cuentas;
        this.xr = mder;

    }

    // Metodo Encargado de Meter Hoja
    private void meterHoja(NodoB clave, Pagina raiz, int k)
    {
        int i = raiz.cuentas;
        while (i != k)
        {
            raiz.claves[i] = raiz.claves[i - 1];
            raiz.ramas[i + 1] = raiz.ramas[i];
            i--;
        }
        raiz.claves[k] = clave;
        raiz.ramas[k + 1] = this.xr;
        raiz.cuentas = ++raiz.cuentas;
    }

    private void sucesor(Pagina raiz, int k)
    {
        Pagina q = raiz.ramas[k];
        while (!vacio(q.ramas[0]))
        {
            q = q.ramas[0];
        }
        raiz.claves[k - 1] = q.claves[0];
    }

    private void combina(Pagina raiz, int pos)
    {
        int j;
        this.xder = raiz.ramas[pos];
        this.xizq = raiz.ramas[pos - 1];
        this.xizq.cuentas++;
        this.xizq.claves[this.xizq.cuentas - 1] = raiz.claves[pos - 1];
        this.xizq.ramas[this.xizq.cuentas] = this.xder.ramas[0];
        j = 1;
        while (j != this.xder.cuentas + 1)
        {
            this.xizq.cuentas++;
            this.xizq.claves[this.xizq.cuentas - 1] = this.xder.claves[j - 1];
            this.xizq.ramas[this.xizq.cuentas] = this.xder.ramas[j];
            j++;
        }
        quitar(raiz, pos);
    }

    private void moverDer(Pagina raiz, int pos)
    {
        int i = raiz.ramas[pos].cuentas;
        while (i != 0)
        {
            raiz.ramas[pos].claves[i] = raiz.ramas[pos].claves[i - 1];
            raiz.ramas[pos].ramas[i + 1] = raiz.ramas[pos].ramas[i];
            --i;
        }
        raiz.ramas[pos].cuentas++;
        raiz.ramas[pos].ramas[1] = raiz.ramas[pos].ramas[0];
        raiz.ramas[pos].claves[0] = raiz.claves[pos - 1];
        raiz.claves[pos - 1] = raiz.ramas[pos - 1].claves[raiz.ramas[pos - 1].cuentas - 1];
        raiz.ramas[pos].ramas[0] = raiz.ramas[pos - 1].ramas[raiz.ramas[pos - 1].cuentas];
        raiz.ramas[pos - 1].cuentas--;
    }

    private void moverIzq(Pagina raiz, int pos)
    {
        int i;
        raiz.ramas[pos - 1].cuentas++;
        raiz.ramas[pos - 1].claves[raiz.ramas[pos - 1].cuentas - 1] = raiz.claves[pos - 1];
        raiz.ramas[pos - 1].ramas[raiz.ramas[pos - 1].cuentas] = raiz.ramas[pos].ramas[0];
        raiz.claves[pos - 1] = raiz.ramas[pos].claves[0];
        raiz.ramas[pos].ramas[0] = raiz.ramas[pos].ramas[1];
        raiz.ramas[pos].cuentas--;
        i = 1;
        while (i != raiz.ramas[pos].cuentas + 1)
        {
            raiz.ramas[pos].claves[i - 1] = raiz.ramas[pos].claves[i];
            raiz.ramas[pos].ramas[i] = raiz.ramas[pos].ramas[i + 1];
            i++;
        }
    }

    private void quitar(Pagina raiz, int pos)
    {
        int j = pos + 1;
        while (j != raiz.cuentas + 1)
        {
            raiz.claves[j - 2] = raiz.claves[j - 1];
            raiz.ramas[j - 1] = raiz.ramas[j];
            j++;
        }
        raiz.cuentas--;
    }

    private int buscarNodo(NodoB clave, Pagina raiz)
    {
        int j = 0;
        if (clave.numeroAtaque < raiz.claves[0].numeroAtaque)
        {
            this.esta = false;
            j = 0;
        }
        else
        {
            j = raiz.cuentas;
            while (clave.numeroAtaque < raiz.claves[j - 1].numeroAtaque && j > 1)
            {
                --j;
            }
            this.esta = (clave.numeroAtaque == raiz.claves[j - 1].numeroAtaque);
        }
        return j;
    }

    private void restablecer(Pagina raiz, int pos)
    {
        if (pos > 0)
        {
            if (raiz.ramas[pos - 1].cuentas > 2)
            {
                moverDer(raiz, pos);
            }
            else
            {
                combina(raiz, pos);
            }
        }
        else if (raiz.ramas[1].cuentas > 2)
        {
            moverIzq(raiz, 1);
        }
        else
        {
            combina(raiz, 1);
        }
    }

    // Inicia las operaciones de eliminar

    public void eliminarHorario(NodoB clave)
    {
        if (vacio(this.p))
        {
            // NO elimina
        }
        else
        {
            eliminarPrivad(this.p, clave);
        }
    }

    //Eliminar Privado
    private void eliminarPrivad(Pagina raiz, NodoB clave)
    {
        try
        {
            elimarRegistro(raiz, clave);
        }
        catch (Exception e)
        {
            this.esta = false;
            // consola = "error"
        }

        if (!esta)
        {
            // consola = "No se encontro el elemento"
        }
        else
        {
            if (raiz.cuentas == 0)
            {
                raiz = raiz.ramas[0];
            }
            this.p = raiz;
            // consola = "Elemento eliminado"
        }
    }

    // Elimina el registro
    private void elimarRegistro(Pagina raiz, NodoB clave)
    {
        int pos = 0;
        NodoB suce;
        if (vacio(raiz))
        {
            this.esta = false;
        }
        else
        {
            pos = buscarNodo(clave, raiz);
            if (esta)
            {
                if (vacio(raiz.ramas[pos - 1]))
                {
                    quitar(raiz, pos);
                }
                else
                {
                    sucesor(raiz, pos);
                    elimarRegistro(raiz.ramas[pos], raiz.claves[pos - 1]);
                }
            }
            else
            {
                elimarRegistro(raiz.ramas[pos], clave);
                if ((raiz.ramas[pos] != null) && (raiz.ramas[pos].cuentas < 2))
                {
                    restablecer(raiz, pos);
                }
            }
        }
    }

    // Grafica del Arbol

    public string graficarArbol()
    {
        this.contador = this.contador + 1;
        string archivo = "";
        archivo = "digraph Btree{\n";
        archivo += "node [shape = record, style=filled, fillcolor=white];\n";
        string cuerpo = "";
        archivo += enlazarRamas(this.p, cuerpo);
        archivo += encabezado(this.p, cuerpo);
        archivo += "\n}";
        return archivo;
    }

    private string enlazarRamas(Pagina p, string cuerpo)
    {

        if (p.cuentas > 0 && p.ramas[0] != null)
        {
            for (int i = 0; i <= p.cuentas; i++)
            {
                if (p.ramas[i] != null)
                {
                    if (p.ramas[i].printPage2().CompareTo("") != 0)
                    {
                        cuerpo += "\"" + p.printPage2() + "\"->\"" + p.ramas[i].printPage2() + "\";\n";
                    }
                    if (p.ramas[i].printPage2().CompareTo("") == 0)
                    {
                        cuerpo += "\"" + p.printPage2() + "\";\n";
                    }
                    enlazarRamas(p.ramas[i], cuerpo);
                }
            }
        }

        return cuerpo;
    }

    private string encabezado(Pagina p, string cuerpo)
    {

        if (p.cuentas > 0 && p.ramas[0] != null)
        {
            for (int i = 0; i <= p.cuentas; i++)
            {
                if (p.ramas[i] != null)
                {
                    if (p.ramas[i].printPage().CompareTo("") != 0)
                    {
                        cuerpo += p.printPage() + "\n " + p.ramas[i].printPage() + "\n";
                    }
                    if (p.ramas[i].printPage().CompareTo("") == 0)
                    {
                        cuerpo += p.printPage() + "\n";
                    }
                    enlazarRamas(p.ramas[i], cuerpo);
                }
            }
        }

        return cuerpo;
    }

    public bool editarHorario(int codigo, NodoB nuevo)
    {
        this.editado = false;
        if (this.p.editarHorario(codigo, nuevo))
        {
            return true;
        }
        editarHorarioPrivado(codigo, nuevo, this.p);
        return this.editado;
    }

    private void editarHorarioPrivado(int codigo, NodoB nuevo, Pagina raiz)
    {
        if (raiz.cuentas > 0 && raiz.ramas[0] != null)
        {
            for (int i = 0; i <= raiz.cuentas; i++)
            {
                if (raiz.ramas[i] != null)
                {
                    if (raiz.ramas[i].editarHorario(codigo, nuevo))
                    {
                        this.editado = true;
                        return;
                    }
                    else
                    {
                        editarHorarioPrivado(codigo, nuevo, raiz.ramas[i]);
                    }
                }
            }
        }
    }

    private NodoB buscarHorario(int codigo)
    {
        this.buscando = null;
        for (int i = 0; i <= this.p.cuentas; i++)
        {
            if (this.p.claves[i] != null)
            {
                if (this.p.claves[i].numeroAtaque == codigo)
                {
                    this.buscando = this.p.claves[i];
                    return this.buscando;
                }
            }
        }
        buscarPrivado(codigo, this.p);
        return this.buscando;
    }

    /*
    private string generarNombreImagen() {
        return "Horarios\\Horarios_" + this.contador.Tostring();
    }
    */

    public string reporteDeCursosPorEstudiante(int carnet)
    {
        this.cadena = "";
        if (this.p != null)
        {
            for (int i = 0; i <= this.p.cuentas; i++)
            {
                if (this.p.claves[i] != null)
                {
                    //this.cadena = this.cadena + this.p.claves[i].asigandos.cursosAsignadosPorEstudiante(carnet, this.p.claves[i].refCurso.nombre);
                }
            }
        }
        recorreReporteCursosEstudiante(carnet, this.p);
        //this.cadena = this.cadena;
        return this.cadena;
    }

    public string reporteDeAlAsignadosCurso(int codCurso, int year, int semes)
    {
        this.cadena = "";
        if (this.p != null)
        {
            for (int i = 0; i <= this.p.cuentas; i++)
            {
                if (this.p.claves[i] != null)
                {
                    /*if (this.p.claves[i].refCurso.codigo == codCurso && this.p.claves[i].semestre == semes && this.p.claves[i].year == year) {
                        this.cadena = this.cadena + this.p.claves[i].asigandos.asignadosACurso(0);
                    }*/
                }
            }
        }
        recorreReporteDeAsignados(codCurso, year, semes, this.p);
        //this.cadena = this.cadena;
        return this.cadena;
    }

    public string reporteDeCursosEnSalon(int salon, int semestre, int year)
    {
        this.cadena = "";
        if (this.p != null)
        {
            for (int i = 0; i <= this.p.cuentas; i++)
            {
                if (this.p.claves[i] != null)
                {
                    /*if (this.p.claves[i].refSalon.numSalon == salon && this.p.claves[i].semestre == semestre && this.p.claves[i].year == year)
                    {
                        //this.cadena = this.cadena + "<tr>\n";
                        this.cadena = this.cadena + this.p.claves[i].refCurso.codigo.ToString() + this.p.claves[i].refCurso.nombre + this.p.claves[i].rango + this.p.claves[i].dia;
                        //this.cadena = this.cadena + "</tr>\n";
                    }*/
                }
            }
        }
        recorreReporteDeCursosEnSalon(salon, semestre, year, this.p);
        //this.cadena = this.cadena;
        return this.cadena;
    }

    public string reporteDeAprobReprob(int semestre, int year)
    {
        this.cadena = "";

        if (this.p != null)
        {
            for (int i = 0; i <= this.p.cuentas; i++)
            {
                if (this.p.claves[i] != null)
                {
                    //this.cadena = this.cadena + this.p.claves[i].asigandos.aproRepro(this.p.claves[i].refCurso.nombre);
                }
            }
        }
        recorreReporteDeAprobadoReprob(semestre, year, this.p);
        this.cadena = this.cadena;// + "</table>\n";
        return this.cadena;
    }

    public void recorreReporteDeAprobadoReprob(int semestre, int year, Pagina raiz)
    {
        if (raiz.cuentas > 0 && raiz.ramas[0] != null)
        {
            for (int i = 0; i <= raiz.cuentas; i++)
            {
                if (raiz.ramas[i] != null)
                {
                    this.cadena = this.cadena + raiz.ramas[i].reporteCuatro();
                    recorreReporteDeAprobadoReprob(semestre, year, raiz.ramas[i]);
                }

            }
        }
    }

    public void recorreReporteDeCursosEnSalon(int salon, int semestr, int year, Pagina raiz)
    {
        if (raiz.cuentas > 0 && raiz.ramas[0] != null)
        {
            for (int i = 0; i <= raiz.cuentas; i++)
            {
                if (raiz.ramas[i] != null)
                {
                    this.cadena = this.cadena + raiz.ramas[i].reporteTres(salon, semestr, year);
                    recorreReporteDeCursosEnSalon(salon, semestr, year, raiz.ramas[i]);
                }

            }
        }
    }
    public void recorreReporteDeAsignados(int codCurso, int year, int semes, Pagina raiz)
    {
        if (raiz.cuentas > 0 && raiz.ramas[0] != null)
        {
            for (int i = 0; i <= raiz.cuentas; i++)
            {
                if (raiz.ramas[i] != null)
                {
                    this.cadena = this.cadena + raiz.ramas[i].reporteDos(codCurso, year, semes);
                    recorreReporteDeAsignados(codCurso, year, semes, raiz.ramas[i]);
                }

            }
        }
    }

    public void recorreReporteCursosEstudiante(int carnet, Pagina raiz)
    {
        if (raiz.cuentas > 0 && raiz.ramas[0] != null)
        {
            for (int i = 0; i <= raiz.cuentas; i++)
            {
                if (raiz.ramas[i] != null)
                {
                    this.cadena = this.cadena + raiz.ramas[i].reporteUno(carnet);
                    recorreReporteCursosEstudiante(carnet, raiz.ramas[i]);
                }

            }
        }
    }

    private void buscarPrivado(int codigo, Pagina raiz)
    {
        if (raiz.cuentas > 0 && raiz.ramas[0] != null)
        {
            for (int i = 0; i <= raiz.cuentas; i++)
            {
                if (raiz.ramas[i] != null)
                {
                    NodoB aux = raiz.ramas[i].encuentraHorario(codigo);
                    if (aux != null)
                    {
                        this.buscando = aux;
                    }
                    else
                    {
                        buscarPrivado(codigo, raiz.ramas[i]);
                    }
                }
            }
        }
    }
}