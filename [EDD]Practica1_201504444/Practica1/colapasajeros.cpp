#include "colapasajeros.h"
#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include "QString"

using namespace std;

nodoPasajero::nodoPasajero(string nombre ,string Id, string Maletas, string Documentos, string turnos)
{
    this->nombre = nombre;
    this->Id = Id;
    this->Maletas = Maletas;
    this->Documentos = Documentos;
    this->turnos = turnos;

    this->siguiente = NULL;
}

void colaPasajero::InsertarPasajero(colaPasajero *colaP, string nombre ,string Id, string Maletas, string Documentos, string turnos){
    nodoPasajero* nuevo = new nodoPasajero(nombre, Id, Maletas, Documentos, turnos);
    if(colaP->primero==NULL){
        colaP->primero = nuevo;
        colaP->ultimo = nuevo;
    }else{
        colaP->ultimo->siguiente = nuevo;
        colaP->ultimo = nuevo;
    }
}

string colaPasajero::MostrarPasajero(colaPasajero *colaP){
    string cuerpo;
    nodoPasajero* aux = colaP->primero;
    if(colaP->primero != NULL){
        while(aux != NULL){
            cuerpo += "\" Nombre: " + aux->nombre + "\n ID: " + aux->Id + "\n Numero de Maletas: " + aux->Maletas + "\n Numero de Documentos: " + aux->Documentos + "\n Turnos: " + aux->turnos + "\";\n";
            if(aux->siguiente != NULL){
                cuerpo += "\" Nombre: " + aux->nombre + "\n ID: " + aux->Id + "\n Numero de Maletas: " + aux->Maletas + "\n Numero de Documentos: " + aux->Documentos + "\n Turnos: " + aux->turnos + "\" -> \" Nombre: " + aux->siguiente->nombre + "\n ID: " + aux->siguiente->Id + "\n Numero de Maletas: " + aux->siguiente->Maletas + "\n Numero de Documentos: " + aux->siguiente->Documentos + "\n Turnos: " + aux->siguiente->turnos +"\";";
            }
            aux = aux->siguiente;
        }
        return cuerpo;
    }
    return "vacio";
}

string colaPasajero::MostrarPasajeroClo(colaPasajero *colaP){
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
    return "vacio";
}

void colaPasajero::EliminarPasajero(colaPasajero *colaP){
    if(colaP->primero->siguiente != NULL){
        nodoPasajero *aux = colaP->primero;
        colaP->primero = aux->siguiente;
        aux->siguiente = NULL;
        free(aux);
    } else{
        if(colaP->primero != NULL){
                colaP->primero = NULL;
                colaP->ultimo = NULL;
            }
    }
}
