#ifndef LESCRITORIOS_H
#define LESCRITORIOS_H
#include <stdlib.h>
#include <stdio.h>
#include <iostream>

using namespace std;
typedef struct nodoEscritorio nodoEscritorio;
typedef struct listaEscritorio listaEscritorio;

struct nodoEscritorio{
    string letraEscritorio;
    string libre;
    string ocupado;
    string turnosFaltan;
    string NumDocumentos;

    nodoEscritorio* siguiente;
    nodoEscritorio* atras;
    nodoEscritorio(string letraEscritorio, string libre, string ocupado, string turnosFaltan,string NumDocumentos);
};

struct listaEscritorio
{
    nodoEscritorio * primero;
    nodoEscritorio * ultimo;
    void InsertarEscritorio(listaEscritorio *colaEsc, string letraEscritorio, string libre, string ocupado, string turnosFaltan,string NumDocumentos);
    string MostrarEscritorios(listaEscritorio * colaEsc);
    bool BuscarEscritorio(listaEscritorio * colaEsc, string letraEscritorio);
    void EliminarEscritorioPasajero(listaEscritorio * colaEsc);
    void EliminarEscritorioDocumento(listaEscritorio* colaEsc);
    //string verificar(listaEscritorio * colaA, int tiempo);
    //void modificarAvion(string nombreviejo, string nombre, string contrasena, string tipo);
};

#endif // LESCRITORIOS_H
