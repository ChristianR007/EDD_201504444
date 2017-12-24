#include "escritorios.h"
#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include "QString"
#include <qmessagebox.h>

using namespace std;

nodoEscritorio::nodoEscritorio(colaPasajero * sigPasajero, pilaDocumento * sigDocumento, string letraEscritorio, string libre, string ocupado, string turnosFaltan,string NumDocumentos)
{
    this->letraEscritorio = letraEscritorio;
    this->libre = libre;
    this->ocupado = ocupado;
    this->turnosFaltan = turnosFaltan;
    this->NumDocumentos = NumDocumentos;
    this->sigPasajero = sigPasajero;
    this->sigDocumento = sigDocumento;

    this->siguiente = NULL;
    this->atras = NULL;
}

void listaEscritorio::InsertarEscritorio(listaEscritorio *colaEsc, string letraEscritorio, string libre, string ocupado, string turnosFaltan, string NumDocumentos){
    colaPasajero * nuevoPasajero = new colaPasajero();
    pilaDocumento * nuevoDocumento = new pilaDocumento();
    nodoEscritorio* nuevo = new nodoEscritorio(nuevoPasajero, nuevoDocumento, letraEscritorio, libre, ocupado, turnosFaltan, NumDocumentos);
    if(colaEsc->primero==NULL){
        colaEsc->primero = nuevo;
        colaEsc->ultimo = colaEsc->primero;
    }else{
        if(colaEsc->BuscarEscritorio(colaEsc, letraEscritorio)==false){
            colaEsc->ultimo->siguiente = nuevo;
            nuevo->atras = colaEsc->ultimo;
            nuevo->siguiente = NULL;
            colaEsc->ultimo = nuevo;
        }
    }
}

            /*else if(tmp->siguiente == NULL){
                colaEsc->ultimo->siguiente = nuevo;
                nuevo->atras = colaEsc->ultimo;
                nuevo->siguiente = NULL;
                colaEsc->ultimo = nuevo;
            } else{
                tmp = tmp->siguiente;
            }
        }




    }
}

/*
else{
        if(colaEsc->BuscarEscritorio(colaEsc, letraEscritorio)==false){
            colaEsc->ultimo->siguiente = nuevo;
            nuevo->atras = colaEsc->ultimo;
            nuevo->siguiente = NULL;
            colaEsc->ultimo = nuevo;
        }
    }
*/

int pt=1;
string listaEscritorio::InsertarDocumentos(listaEscritorio *colaEsc, string nombre, int id){
    string rr;
    nodoEscritorio * aux = colaEsc->primero;
    while(aux->NumDocumentos != QString::number( 0 ).toStdString()){
        for(int z=1; z<QString::fromStdString( aux->NumDocumentos ).toInt()+1; z++){
            string nombre = "Documento " + QString::number( z ).toStdString();
            aux->sigDocumento->InsertarDocumento(aux->sigDocumento, nombre, pt);
            //rr += nombre;
            pt++;
        }

        //rr+= "||" + aux->letraEscritorio + " - " + aux->sigDocumento->MostrarDocumentos(aux->sigDocumento) + "|| -";
        aux = aux->siguiente;
    }
    return rr;
}

int enEscritoriosHay = 0;
void listaEscritorio::InsertarEscritorioPasayDoc(listaEscritorio *colaEsc, string nombre ,string Id, string Maletas, string Documentos, string turnos){
    nodoEscritorio * aux = colaEsc->primero;

    while(QString::fromStdString( colaEsc->ultimo->libre ).toInt() != 10){
        if(QString::fromStdString( aux->libre ).toInt() < 10){
            aux->sigPasajero->InsertarPasajero(aux->sigPasajero, nombre, Id , Maletas , Documentos , turnos);  // Pasajero en mesa


            aux->turnosFaltan = aux->sigPasajero->primero->turnos;
            aux->NumDocumentos = aux->sigPasajero->primero->Documentos;

            int aumento = QString::fromStdString( aux->libre ).toInt() +1;
            aux->libre = QString::number( aumento ).toStdString();
            enEscritoriosHay++;
            break;
        } else if(QString::fromStdString( aux->libre ).toInt() == 10){
            aux->ocupado = "Ocupado";
            aux = aux->siguiente;
        }

    }
}

int listaEscritorio::lleno(){
    // cuatos hay en escritorios
    return enEscritoriosHay;
}

int i=0;
string listaEscritorio::MostrarEscritorios(listaEscritorio *colaEsc){
    string cuerpo;// = "digraph {\nrankdir=LR;\nnode [shape=box, color=gray];\n";
    string otro;
    string pasajeroClo;
    string doc;
    nodoEscritorio * aux = colaEsc->primero;

    otro = "\n subgraph cluster_0 {\nrankdir=LR;\n";

    while(aux !=NULL ){
            if(aux->sigPasajero->MostrarPasajero(aux->sigPasajero) != "vacio"){
                cuerpo += "\""+aux->letraEscritorio + "\n En Mesa: "+ aux->libre + "\n Disponibilidad: "+ aux->ocupado + "\n Turnos: "+ aux->turnosFaltan + "\n Documentos: "+ aux->NumDocumentos+"\"->" + aux->sigPasajero->MostrarPasajero(aux->sigPasajero) +"\n";
                //cuerpo += "\""+aux->letraEscritorio + "\n En Mesa: "+ aux->libre + "\n Disponibilidad: "+ aux->ocupado + "\n Turnos: "+ aux->turnosFaltan + "\n Documentos: "+ aux->NumDocumentos+"\"->" + aux->sigDocumento->MostrarDocumentos(aux->sigDocumento) +"\n";
                pasajeroClo += "\n subgraph cluster_"+ QString::number(i+1).toStdString() +" {\nnode [style=filled];\nrankdir=LL;\n";
                pasajeroClo += aux->sigPasajero->MostrarPasajeroClo(aux->sigPasajero);
                pasajeroClo += ";\n label= \" Pasajeros \";\n color=blue;\n}";
                //doc += "\n subgraph clusterD_"+ QString::number(i+1).toStdString() +" {\nnode [style=filled];\nrankdir=LL;\n";
                //doc += aux->sigDocumento->MostrarDocumentosOTRO(aux->sigDocumento);
                //doc += "\n label= \" Documentos \";\n color=blue;\n}";

                i++;
            }
            otro += "\""+aux->letraEscritorio + "\n"+ aux->libre+"\" ";
            cuerpo += "\""+aux->letraEscritorio + "\n En Mesa: "+ aux->libre + "\n Disponibilidad: "+ aux->ocupado + "\n Turnos: "+ aux->turnosFaltan + "\n Documentos: "+ aux->NumDocumentos + "\";\n";
            if(aux->siguiente != NULL){
                cuerpo += "\""+aux->letraEscritorio + "\n En Mesa: "+ aux->libre + "\n Disponibilidad: "+ aux->ocupado + "\n Turnos: "+ aux->turnosFaltan + "\n Documentos: "+ aux->NumDocumentos+"\" -> \"" + aux->siguiente->letraEscritorio + "\n En Mesa: "+ aux->siguiente->libre + "\n Disponibilidad: "+ aux->siguiente->ocupado + "\n Turnos: "+ aux->siguiente->turnosFaltan + "\n Documentos: "+ aux->siguiente->NumDocumentos + "\";\n";
                cuerpo += "\"" + aux->siguiente->letraEscritorio + "\n En Mesa: "+ aux->siguiente->libre + "\n Disponibilidad: "+ aux->siguiente->ocupado + "\n Turnos: "+ aux->siguiente->turnosFaltan + "\n Documentos: "+ aux->siguiente->NumDocumentos +"\" -> \"" + aux->letraEscritorio + "\n En Mesa: "+ aux->libre + "\n Disponibilidad: "+ aux->ocupado + "\n Turnos: "+ aux->turnosFaltan + "\n Documentos: "+ aux->NumDocumentos + "\";\n";
            }
            aux = aux->siguiente;

    }
    //execute -> { make_string; printf}
    otro += ";\n label= \" Escritorios \";\n color=green;\n}";
    cuerpo = pasajeroClo + doc + cuerpo;
    return cuerpo;
}

bool listaEscritorio::BuscarEscritorio(listaEscritorio * colaEsc, string letraEscritorio){
    nodoEscritorio* aux = colaEsc->primero;
    if(colaEsc->primero == NULL){
        return false;
    }
    while(aux!= NULL){
        if(aux->letraEscritorio == letraEscritorio){
            return true;
        }
        aux = aux->siguiente;
    }
    return false;
}

void listaEscritorio::EliminarEscritorioPasajero(listaEscritorio *colaEsc){

    colaEsc->primero->sigPasajero->EliminarPasajero(colaEsc->primero->sigPasajero); // Eliminar cabeza
    int quitarUno = QString::fromStdString( colaEsc->primero->libre ).toInt() - 1;  // restar -1 a mesa
    colaEsc->primero->libre = QString::number( quitarUno ).toStdString();           // Agregar a mesa
    enEscritoriosHay--;

    colaEsc->primero->turnosFaltan = colaEsc->primero->sigPasajero->primero->turnos;
    colaEsc->primero->NumDocumentos = colaEsc->primero->sigPasajero->primero->Documentos;
    //if(QString::fromStdString( colaEsc->primero->libre ).toInt() == 10){
    //    colaEsc->primero->ocupado = "Ocupado";
    //}
    colaEsc->primero->ocupado = "Libre";                                            // Cambiar a libre por quitar 1 de mesa
}

int MaletasGlobales;
string listaEscritorio::cambio(listaEscritorio *colaEsc){
    string todosTurnos;

    nodoEscritorio * aux = colaEsc->primero;
    int varLocal=0;
    while(aux != colaEsc->ultimo->siguiente){

        if(QString::fromStdString( aux->turnosFaltan ).toInt() == 1){
            //colaEsc->EliminarEscritorioPasajero(colaEsc);
            // nuevoEscritorio->EliminarEscritorioPasajero(nuevoEscritorio);

            todosTurnos += " |" + aux->turnosFaltan + "| - ";

            //colaEsc->EliminarEscritorioPasajero(colaEsc);
            varLocal += QString::fromStdString( aux->sigPasajero->primero->Maletas ).toInt();
            aux->sigPasajero->EliminarPasajero(aux->sigPasajero);
            //int quitarUno = QString::fromStdString( aux->libre ).toInt() - 1;  // restar -1 a mesa
            //aux->libre = QString::number( quitarUno ).toStdString();           // Agregar a mesa
            enEscritoriosHay--;

            if(aux->sigPasajero->primero != NULL){
                aux->turnosFaltan = aux->sigPasajero->primero->turnos;
                aux->NumDocumentos = aux->sigPasajero->primero->Documentos;
                aux->libre = QString::number( QString::fromStdString( aux->libre ).toInt() - 1 ).toStdString();
            }

            colaEsc->primero->ocupado = "Libre";

        } else if(QString::fromStdString( aux->turnosFaltan ).toInt() > 1){

            todosTurnos += aux->turnosFaltan + " - ";

            int t = QString::fromStdString( aux->turnosFaltan ).toInt() - 1;
            aux->turnosFaltan = QString::number( t ).toStdString();

        }

            aux = aux->siguiente;

    }

    MaletasGlobales = varLocal;

    return todosTurnos;
}

int listaEscritorio::NumeroMaletas(){
    return MaletasGlobales;
}
