#include "piladocumentos.h"
#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include "QString"

using namespace std;

nodoDocumento::nodoDocumento( string nombre, int id )
{
    this->nombre = nombre;
    this->id = id;
    this->siguiente = NULL;
}

void pilaDocumento::InsertarDocumento( pilaDocumento *pilaD, string nombre, int id ){
    nodoDocumento* nuevo = new nodoDocumento( nombre, id );
    if(pilaD->primero == NULL){
        pilaD->primero = nuevo;
        pilaD->ultimo = pilaD->primero;
    }else{
        pilaD->ultimo->siguiente = nuevo;
        pilaD->ultimo = nuevo;
    }
}

string pilaDocumento::MostrarDocumentos(pilaDocumento *pilaD){
    string cuerpo;
    nodoDocumento * aux = pilaD->primero;
    while(aux != NULL ){
        cuerpo += "\"" + aux->nombre + "\n"+ QString::number( aux->id ).toStdString() +  "\";\n";
        if(aux->siguiente != NULL){
            cuerpo += "\"" + aux->nombre + "\n"+ QString::number( aux->id ).toStdString() +"\" -> \"" + aux->siguiente->nombre + "\n"+ QString::number( aux->siguiente->id ).toStdString() + "\";\n";
        }
        aux = aux->siguiente;
    }
    return cuerpo;
}

string pilaDocumento::MostrarDocumentosOTRO(pilaDocumento *pilaD){
    string cuerpo;
    nodoDocumento * aux = pilaD->primero;
    if(colaP->primero != NULL){
        if(colaP->primero->nombre != "xx"){
            while(aux != NULL){
                cuerpo += "\" Nombre: " + aux->nombre + "\n ID: " + aux->Id + "\n Numero de Maletas: " + aux->Maletas + "\n Numero de Documentos: " + aux->Documentos + "\n Turnos: " + aux->turnos + "\" ";
                aux = aux->siguiente;
            }
            return cuerpo;
        }
    }
    return cuerpo;
    string cuerpo;
    nodoPasajero* aux = colaP->primero;
    if(colaP->primero != NULL){
        if(colaP->primero->nombre != "xx"){
            while(aux != NULL){
                cuerpo += "\" Nombre: " + aux->nombre + "\n ID: " + aux->Id + "\n Numero de Maletas: " + aux->Maletas + "\n Numero de Documentos: " + aux->Documentos + "\n Turnos: " + aux->turnos + "\" ";
                aux = aux->siguiente;
            }
            return cuerpo;
        }
    }
}

void pilaDocumento::vaciarPilaDocumentos(pilaDocumento * pilaD){

    nodoDocumento *aux = pilaD->primero;

    if(aux != NULL){
        if(aux->siguiente != NULL){

            while(aux != pilaD->ultimo){
                if(aux->siguiente == pilaD->ultimo){
                    break;
                }
                aux = aux->siguiente;
            }
            nodoDocumento * aux2 = aux->siguiente;
            aux->siguiente = NULL;
            pilaD->ultimo = aux;
            aux2 = NULL;
            //free(aux);
        } else{
            if(pilaD->primero != NULL){
                    pilaD->primero = NULL;
                    pilaD->ultimo = NULL;
            }
        }
    }


}
