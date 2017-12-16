#ifndef ESCRITORIOS_H
#define ESCRITORIOS_H
#include <stdlib.h>
#include <stdio.h>
#include <iostream>

#include "colapasajeros.h"
#include "piladocumentos.h"

using namespace std;
typedef struct nodoEscritorio nodoEscritorio;
typedef struct listaEscritorio listaEscritorio;

struct nodoEscritorio{
    string letraEscritorio;
    string libre;
    string ocupado;
    string turnosFaltan;
    string NumDocumentos;

    colaPasajero * sigPasajero;
    pilaDocumento * sigDocumento;

    nodoEscritorio* siguiente;
    nodoEscritorio* atras;
    nodoEscritorio(colaPasajero * sigPasajero, pilaDocumento * sigDocumento, string letraEscritorio, string libre, string ocupado, string turnosFaltan,string NumDocumentos);
};

struct listaEscritorio
{
    nodoEscritorio * primero;
    nodoEscritorio * ultimo;
    void InsertarEscritorio(listaEscritorio *colaEsc, string letraEscritorio, string libre, string ocupado, string turnosFaltan,string NumDocumentos);
    void InsertarEscritorioPasayDoc(listaEscritorio *colaEsc, string nombre ,string Id, string Maletas, string Documentos, string turnos);
    string InsertarDocumentos(listaEscritorio * colaEsc, string nombre, int id);

    string MostrarEscritorios(listaEscritorio * colaEsc);
    bool BuscarEscritorio(listaEscritorio * colaEsc, string letraEscritorio);
    void EliminarEscritorioPasajero(listaEscritorio *colaEsc);
    void EliminarEscritorioDocumento(listaEscritorio* colaEsc);

    string prueba(listaEscritorio * colaEsc);

    int lleno();
    int NumeroMaletas();
    string cambio(listaEscritorio * colaEsc);

    //string verificar(listaEscritorio * colaA, int tiempo);
    //void modificarAvion(string nombreviejo, string nombre, string contrasena, string tipo);
};

#endif // ESCRITORIOS_H
