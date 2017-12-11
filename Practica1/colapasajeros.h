#ifndef COLAPASAJEROS_H
#define COLAPASAJEROS_H
#include <stdlib.h>
#include <stdio.h>
#include <iostream>

using namespace std;
typedef struct nodoPasajero nodoPasajero;
typedef struct colaPasajero colaPasajero;

struct nodoPasajero{
    string Id;
    string Maletas;
    string Documentos;
    string posEntra;

    nodoPasajero* siguiente;
    nodoPasajero* atras;
    nodoPasajero(string Id, string Maletas, string Documentos, string posEntra);
};

struct colaPasajero
{
    nodoPasajero * primero;
    nodoPasajero * ultimo;
    void InsertarPasajero(colaPasajero *colaP, string Id, string Maletas, string Documentos, string posEntra);
    string MostrarPasajero(colaPasajero * colaP);
    bool BuscarPasajero(colaPasajero * colaP, string num);
    void EliminarPasajero(colaPasajero * colaP);
    string verificarPasajero(colaPasajero * colaP, int tiempo);
    //void modificarAvion(string nombreviejo, string nombre, string contrasena, string tipo);
};

#endif // COLAPASAJEROS_H
