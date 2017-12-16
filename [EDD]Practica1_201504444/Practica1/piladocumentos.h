#ifndef PILADOCUMENTOS_H
#define PILADOCUMENTOS_H
#include <stdlib.h>
#include <stdio.h>
#include <iostream>

using namespace std;
typedef struct nodoDocumento nodoDocumento;
typedef struct pilaDocumento pilaDocumento;

struct nodoDocumento{
    string nombre;
    int id;

    nodoDocumento* siguiente;
    nodoDocumento(string nombre, int id);
};

struct pilaDocumento
{
    nodoDocumento * primero;
    nodoDocumento * ultimo;

    void InsertarDocumento( pilaDocumento* pilaD , string nombre , int id );
    string MostrarDocumentos( pilaDocumento * pilaD );
    string MostrarDocumentosOTRO( pilaDocumento * pilaD );
    //bool BuscarAvion(colaAvion * colaA, string numAvion);
    void vaciarPilaDocumentos(pilaDocumento * pilaD);
    //string verificar(colaAvion * colaA, int tiempo);
    //void modificarAvion(string nombreviejo, string nombre, string contrasena, string tipo);
};

#endif // PILADOCUMENTOS_H
