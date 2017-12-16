#include "colaaviones.h"
#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include "QString"

using namespace std;

nodoAvion::nodoAvion(string numAvion, string Tipo, string Probabilidad, string Pasajeros,string Desabordaje, string Mantenimiento)
{
    this->numAvion = numAvion;
    this->Tipo = Tipo;
    this->Probabilidad = Probabilidad;
    this->Pasajeros = Pasajeros;
    this->Desabordaje = Desabordaje;
    this->Mantenimiento = Mantenimiento;
    this->siguiente = NULL;
    this->atras = NULL;
}

void colaAvion::InsertarAvion(colaAvion *colaA, string numAvion, string Tipo, string Probabilidad, string Pasajeros,string Desabordaje, string Mantenimiento){
    nodoAvion* nuevo = new nodoAvion(numAvion, Tipo, Probabilidad, Pasajeros, Desabordaje, Mantenimiento);
    if(colaA->primero==NULL){
        colaA->primero = nuevo;
        colaA->ultimo = colaA->primero;
    }else{
        colaA->ultimo->atras = nuevo;
        nuevo->siguiente = colaA->ultimo;
        nuevo->atras = NULL;
        colaA->ultimo = nuevo;
        //aux->atras = nuevo;
        //aux->atras = ultimo;
        //ultimo->siguiente = aux;
    }
}

string colaAvion::MostrarAvion(colaAvion *colaA){
    string cuerpo;// = "digraph {\nrankdir=LR;\nnode [shape=box, color=gray];\n";
    nodoAvion * aux = colaA->ultimo;
    while(aux !=NULL ){
        cuerpo += "\"" + aux->numAvion + "\nTipo: "+ aux->Tipo + "\nProbabilidad: "+ aux->Probabilidad + "\nPasajeros: "+ aux->Pasajeros + "\nDesabordaje: "+ aux->Desabordaje + "\nMantenimiento: "+ aux->Mantenimiento + "\";\n";
        if(aux->siguiente != NULL){
            cuerpo += "\"" + aux->numAvion + "\nTipo: "+ aux->Tipo + "\nProbabilidad: "+ aux->Probabilidad + "\nPasajeros: "+ aux->Pasajeros + "\nDesabordaje: "+ aux->Desabordaje + "\nMantenimiento: "+ aux->Mantenimiento +"\" -> \"" + aux->siguiente->numAvion + "\nTipo: "+ aux->siguiente->Tipo + "\nProbabilidad: "+ aux->siguiente->Probabilidad + "\nPasajeros: "+ aux->siguiente->Pasajeros + "\nDesabordaje: "+ aux->siguiente->Desabordaje + "\nMantenimiento: "+ aux->siguiente->Mantenimiento + "\"";
            cuerpo += "\"" + aux->siguiente->numAvion + "\nTipo: "+ aux->siguiente->Tipo + "\nProbabilidad: "+ aux->siguiente->Probabilidad + "\nPasajeros: "+ aux->siguiente->Pasajeros + "\nDesabordaje: "+ aux->siguiente->Desabordaje + "\nMantenimiento: "+ aux->siguiente->Mantenimiento + "\" -> \"" + aux->numAvion + "\nTipo: "+ aux->Tipo + "\nProbabilidad: "+ aux->Probabilidad + "\nPasajeros: "+ aux->Pasajeros + "\nDesabordaje: "+ aux->Desabordaje + "\nMantenimiento: "+ aux->Mantenimiento + "\"";
        }
        aux = aux->siguiente;
    }
    return cuerpo;
}

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
}

string colaAvion::verificar(colaAvion *colaA, int tiempo){
    if(QString::number(1).toStdString() == colaA->primero->Desabordaje){
        return colaA->primero->Pasajeros;
    } else{
        int nn = QString::fromStdString(colaA->primero->Desabordaje).toInt() - 1;
        colaA->primero->Desabordaje = QString::number(nn).toStdString();
        return "f";
    }
}

/*
void colaAvion::EliminarAvion(colaAvion * colaA, string nombre){
    nodoAvion* aux;
    if(BuscarAvion(colaA, nombre)==true){
        if(colaA->primero->numAvion == nombre){
            aux = colaA->primero->siguiente;
            aux->atras=NULL;
            colaA->primero->siguiente=NULL;
            colaA->primero=aux;
        } else if(colaA->ultimo->numAvion == nombre){
            aux=colaA->ultimo->atras;
            aux->siguiente=NULL;
            colaA->ultimo->atras=NULL;
            colaA->ultimo=aux;
        }else {
            aux = colaA->ultimo;
            while(aux!=NULL){
                if(aux->numAvion == nombre){
                    nodoAvion* auxA = aux->atras;
                    nodoAvion* auxS = aux->siguiente;
                    aux->siguiente=NULL;
                    aux->atras=NULL;
                    auxA->siguiente = auxS;
                    auxS->atras = auxA;
                    break;
                } else{
                    aux=aux->siguiente;
                }
            }
        }
    }
}

void listaD::modificarD(string nombreviejo, string nombre, string contrasena, string tipo){
    nodoD * aux = primero;
    while(aux!=NULL){
        if(aux->nombre == nombreviejo){
            aux->nombre =nombre;
            aux->contrasena = contrasena;
            aux->tipo = tipo;
        }
        aux = aux->siguiente;
    }
}
*/
