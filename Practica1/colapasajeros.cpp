#include "colapasajeros.h"
#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include "QString"

using namespace std;

nodoPasajero::nodoPasajero(string Id, string Maletas, string Documentos, string posEntra)
{
    this->Id = Id;
    this->Maletas = Maletas;
    this->Documentos = Documentos;
    this->posEntra = posEntra;

    this->siguiente = NULL;
    this->atras = NULL;
}

void colaPasajero::InsertarPasajero(colaPasajero *colaP, string Id, string Maletas, string Documentos, string posEntra){
    nodoPasajero* nuevo = new nodoPasajero(Id, Maletas, Documentos, posEntra);
    if(colaP->primero==NULL){
        colaP->primero = nuevo;
        colaP->ultimo = nuevo;
    }else{
        colaP->ultimo->siguiente = nuevo;
        colaP->ultimo = nuevo;
    }
}

string colaPasajero::MostrarPasajero(colaPasajero *colaP){
    nodoPasajero * aux = colaP->primero->siguiente;
    string cuerpo = colaP->primero->Id + "->" + aux->Id + "->" + colaP->ultimo->Id;
    return cuerpo;
}
