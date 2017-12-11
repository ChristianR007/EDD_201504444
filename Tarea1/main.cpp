#include <QCoreApplication>
#include <string>
#include <fstream>
#include <QTextStream>
#include <Qdebug>
#include <iostream>
#include <stdio.h>
#include <stdlib.h>

using namespace std;

struct nodoDoble{
    int dato;
    nodoDoble* siguiente;
    nodoDoble* atras;
} *primeroD, *ultimoD;

void InsertarDoble(int entrada){
    nodoDoble* nuevo = (nodoDoble*) malloc(sizeof(nodoDoble));
    nuevo->dato = entrada;
    if(primeroD==NULL){
        primeroD = nuevo;
        ultimoD = nuevo;
        primeroD->siguiente = NULL;
        primeroD->atras = NULL;
    }else{
        ultimoD->siguiente= nuevo;
        nuevo->atras = ultimoD;
        nuevo->siguiente = NULL;
        ultimoD=nuevo;
    }
}

void MostrarDoble(){
    nodoDoble* aux = primeroD;
    if(primeroD==NULL){
        printf("-------------------->> Se encuentra vacia la lista doblemente enlazada <<--------------------");
    } else {
        printf(" ->> ");
        while (aux!=NULL) {
            printf("[ %d ]",aux->dato);
            aux=aux->siguiente;
            if(aux!=NULL){
                printf(" <-> ");
            }
        }
    }
    free(aux);
}

bool BuscarDoble(int dato){
    nodoDoble* aux = primeroD;
    bool bandera = false;
    while(aux!=NULL){
        if(aux->dato==dato){
            bandera = true;
            break;
        }
        aux = aux->siguiente;
    }
    free(aux);
    return bandera;
}

void EliminarDoble(int valor){
    nodoDoble* aux = NULL;
    if(BuscarDoble(valor)==true){
        if(primeroD == ultimoD){
            primeroD = NULL;
            ultimoD = NULL;
        }else if(primeroD->dato==valor){
            aux=primeroD->siguiente;
            aux->atras=NULL;
            primeroD->siguiente=NULL;
            primeroD=aux;
        } else if(ultimoD->dato==valor){
            aux=ultimoD->atras;
            aux->siguiente=NULL;
            ultimoD->atras=NULL;
            ultimoD=aux;
        }else {
            aux=primeroD;
            while(aux!=NULL){
                if(aux->dato==valor){
                    nodoDoble* auxA = aux->atras;
                    nodoDoble* auxS = aux->siguiente;
                    aux->siguiente=NULL;
                    aux->atras=NULL;
                    auxA->siguiente=auxS;
                    auxS->atras=auxA;
                    free(auxA);
                    free(auxS);
                    break;
                } else{
                    aux=aux->siguiente;
                }
            }
        }
    } else{
        printf("No se encuentra ningun elemento con ese nombre/n");
    }
    free(aux);
}
string entrada;
int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    int n, opcion;
    //char string[256];

        do
        {
            printf( "-------------- Menu Principal [201504444]----------------- \n", 162 );
            printf( "\n   1. Insertar en Lista Doble Enlazada", 163 );
            printf( "\n   2. Mostrar Lista Doble Enlazada", 163 );
            printf( "\n   3. Eliminar en Lista Doble Enlazada", 163 );
            printf( "\n   4. Salir" );
            printf( "\n\n   Elegir opcion: ", 162 );

            scanf( "%d", &opcion );

            switch ( opcion )
            {
                case 1: printf( "\n   Introduzca un dato: ", 163 );
                        scanf( "%d" , &n );
                        InsertarDoble(n);
                        printf("\n\n");
                        break;

                case 2: printf( "\n   Estructura: ", 163 );
                        MostrarDoble();
                        printf( "\n\n");
                        break;

                case 3: printf( "\n   Introduzca un n%cmero entero: ", 163 );
                        scanf( "%d", &n );
                        EliminarDoble(n);
             }

        } while ( opcion != 4 );

    return 0;
}
