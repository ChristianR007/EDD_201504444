#ifndef LISTACIRCULAR_H
#define LISTACIRCULAR_H
#include <string>
#include <string>
using namespace std;

typedef struct nodoCircular nodoCircular;
typedef struct listaMaletas listaMaletas;

struct nodoCircular
{
    string nombre;

    nodoCircular* siguiente;
    nodoCircular* atras;
    nodoCircular(string nombre);
};

struct listaMaletas
{
    nodoCircular * primero;
    nodoCircular * ultimo;
    void InsertarCircular( listaMaletas * listaM, string nombre );
    string MostrarCircular( listaMaletas * listaM );
    void EliminarCircular( listaMaletas * listaM );

};


#endif // LISTACIRCULAR_H
