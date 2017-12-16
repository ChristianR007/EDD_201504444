#include "lescritorios.h"
#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include "QString"

using namespace std;

nodoEscritorio::nodoEscritorio(string letraEscritorio, string libre, string ocupado, string turnosFaltan,string NumDocumentos)
{
    this->letraEscritorio = letraEscritorio;
    this->libre = libre;
    this->ocupado = ocupado;
    this->turnosFaltan = turnosFaltan;
    this->NumDocumentos = NumDocumentos;

    this->siguiente = NULL;
    this->atras = NULL;
}

void listaEscritorio::InsertarEscritorio(listaEscritorio *colaEsc, string letraEscritorio, string libre, string ocupado, string turnosFaltan, string NumDocumentos){
    nodoEscritorio* nuevo = new nodoEscritorio(letraEscritorio, libre, ocupado, turnosFaltan, NumDocumentos);
    if(colaEsc->primero==NULL){
        colaEsc->primero = nuevo;
        colaEsc->ultimo = colaEsc->primero;
    }else{
        colaEsc->ultimo->siguiente = nuevo;
        nuevo->atras = colaEsc->ultimo;
        nuevo->siguiente = NULL;
        colaEsc->ultimo = nuevo;
    }
}

string listaEscritorio::MostrarEscritorios(listaEscritorio *colaEsc){
    string cuerpo;// = "digraph {\nrankdir=LR;\nnode [shape=box, color=gray];\n";
    nodoEscritorio * aux = colaEsc->primero;
    while(aux !=NULL ){
        cuerpo += "\"" + aux->letraEscritorio + "\";\n"; // + "\nTipo: "+ aux->Tipo + "\nProbabilidad: "+ aux->Probabilidad + "\nPasajeros: "+ aux->Pasajeros + "\nDesabordaje: "+ aux->Desabordaje + "\nMantenimiento: "+ aux->Mantenimiento + "\";\n";
        if(aux->siguiente != NULL){
            cuerpo += "\"" + aux->letraEscritorio + "->" + aux->siguiente->letraEscritorio+ ";\n";
            cuerpo += "\"" + aux->letraEscritorio + "->" + aux->letraEscritorio+ ";\n";

            //cuerpo += "\"" + aux->letraEscritorio + "\nTipo: "+ aux->Tipo + "\nProbabilidad: "+ aux->Probabilidad + "\nPasajeros: "+ aux->Pasajeros + "\nDesabordaje: "+ aux->Desabordaje + "\nMantenimiento: "+ aux->Mantenimiento +"\" -> \"" + aux->siguiente->numAvion + "\nTipo: "+ aux->siguiente->Tipo + "\nProbabilidad: "+ aux->siguiente->Probabilidad + "\nPasajeros: "+ aux->siguiente->Pasajeros + "\nDesabordaje: "+ aux->siguiente->Desabordaje + "\nMantenimiento: "+ aux->siguiente->Mantenimiento + "\"";
            //cuerpo += "\"" + aux->siguiente->numAvion + "\nTipo: "+ aux->siguiente->Tipo + "\nProbabilidad: "+ aux->siguiente->Probabilidad + "\nPasajeros: "+ aux->siguiente->Pasajeros + "\nDesabordaje: "+ aux->siguiente->Desabordaje + "\nMantenimiento: "+ aux->siguiente->Mantenimiento + "\" -> \"" + aux->numAvion + "\nTipo: "+ aux->Tipo + "\nProbabilidad: "+ aux->Probabilidad + "\nPasajeros: "+ aux->Pasajeros + "\nDesabordaje: "+ aux->Desabordaje + "\nMantenimiento: "+ aux->Mantenimiento + "\"";
        }
        aux = aux->siguiente;
    }
    return cuerpo;
}
/*
bool colaAvion::BuscarAvion(colaAvion * colaA, string nombre){
    nodoAvion* aux = colaA->ultimo;
    bool bandera = false;
    if(colaA->primero->numAvion == nombre){
        bandera = true;
    } else{
        while(aux!= colaA->primero){
            if(aux->numAvion == nombre){
                bandera = true;
                break;
            }else {
                aux = aux->siguiente;
            }
        }
    }
    return bandera;
}
void colaAvion::EliminarAvion(colaAvion * colaA){
    if(colaA->ultimo->siguiente != NULL){
        nodoAvion *aux = colaA->primero;
        colaA->primero = aux->atras;
        colaA->primero->siguiente = NULL;
        aux->atras = NULL;
        free(aux);
    } else{
        if(colaA->primero != NULL){
                colaA->primero = NULL;
                colaA->ultimo = NULL;
            }
    }
}*/
