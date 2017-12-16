#include "listacircular.h"
#include <string>
#include <cstdlib>
#include <QMessageBox>
using namespace std;

nodoCircular::nodoCircular(string nombre)
{
    this->nombre = nombre;
    this->siguiente = NULL;
    this->atras = NULL;
}

// Insertar en lista Doblemente enlazada circular
void listaMaletas::InsertarCircular(listaMaletas *listaM, string nombre){
        nodoCircular* nuevo = new nodoCircular(nombre);
        if(listaM->primero==NULL){

            listaM->primero = nuevo;
            listaM->ultimo= nuevo;
            listaM->primero->siguiente = listaM->primero;
            listaM->primero->atras = listaM->ultimo;

        }else{

            listaM->ultimo->siguiente = nuevo;
            nuevo->atras = listaM->ultimo;
            nuevo->siguiente = listaM->primero;
            listaM->ultimo = nuevo;
            listaM->primero->atras = listaM->ultimo;

        }
}

// Mostrar en lista Doblemente enlazada circular
string listaMaletas::MostrarCircular(listaMaletas * listaM){
    string cuerpo = "";
    nodoCircular* aux = listaM->primero;
    if(listaM->ultimo != NULL){
        if(listaM->ultimo != listaM->primero){
             do{
                cuerpo+= "\""+aux->nombre + "\";\n";
                //cuerpo+= aux->nombre + "->" + aux->Palbumld->primeroD->dato +";\n";
                //cuerpo+= "subgraph cluster"+to_string(indice)+ "{" + aux->Palbumld->MostrarDoble()+"color=blue;}\n";
                if(aux->siguiente != listaM->primero){
                    cuerpo += "\""+aux->nombre + "\" -> \"" +aux->siguiente->nombre + "\";\n";
                    cuerpo += "\""+aux->siguiente->nombre + "\" -> \"" + aux->nombre  + "\";\n";
                } else if(aux->siguiente = listaM->primero){

                }
                aux = aux->siguiente;
            }while (aux != listaM->primero);

            cuerpo += "\""+listaM->primero->nombre + "\" -> \"" + listaM->ultimo->nombre +"\";\n";
            cuerpo += "\""+listaM->ultimo->nombre + "\" -> \"" + listaM->primero->nombre +"\";\n";
        }else{
            cuerpo = "\""+listaM->primero->nombre + "\";\n";
        }

    }

    return cuerpo;
}

// Eliminar en lista doblemente enlazada circular
void listaMaletas::EliminarCircular( listaMaletas * listaM ){
    nodoCircular* aux = listaM->primero->siguiente;// = new nodoCircular();
    nodoCircular * tem = listaM->primero;
    if( listaM->ultimo != NULL ){

        if(listaM->primero == listaM->ultimo){

            listaM->primero = NULL;
            listaM->ultimo = NULL;

        }else if(aux != listaM->ultimo){
            listaM->primero->atras = NULL;
            listaM->primero->siguiente = NULL;
            listaM->primero = NULL;

            listaM->ultimo->siguiente = aux;
            aux->atras = listaM->ultimo;
            listaM->primero = aux;

        } else if(listaM->primero->siguiente == listaM->ultimo){
            listaM->primero = listaM->ultimo;
            tem->siguiente=NULL;

            listaM->primero->atras = NULL;
            tem = NULL;
        }
    }
}
