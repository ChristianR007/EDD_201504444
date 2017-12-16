#ifndef COLAPASAJEROS_H
#define COLAPASAJEROS_H
#include <stdlib.h>
#include <stdio.h>
#include <iostream>

using namespace std;
typedef struct nodoPasajero nodoPasajero;
typedef struct colaPasajero colaPasajero;

struct nodoPasajero{
    string nombre;
    string Id;
    string Maletas;
    string Documentos;
    string turnos;

    nodoPasajero* siguiente;
    nodoPasajero(string nombre ,string Id, string Maletas, string Documentos, string turnos);
};

struct colaPasajero
{
    nodoPasajero * primero;
    nodoPasajero * ultimo;
    void InsertarPasajero(colaPasajero *colaP, string nombre ,string Id, string Maletas, string Documentos, string turnos);
    string MostrarPasajero(colaPasajero * colaP);
    string MostrarPasajeroClo(colaPasajero * colaP);
    bool BuscarPasajero(colaPasajero * colaP, string Id);
    void EliminarPasajero(colaPasajero * colaP);
    //string verificarPasajero(colaPasajero * colaP, int tiempo);
    //void modificarAvion(string nombreviejo, string nombre, string contrasena, string tipo);
};

#endif // COLAPASAJEROS_H
