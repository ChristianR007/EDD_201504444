#ifndef COLAAVIONES_H
#define COLAAVIONES_H
#include <stdlib.h>
#include <stdio.h>
#include <iostream>

using namespace std;
typedef struct nodoAvion nodoAvion;
typedef struct colaAvion colaAvion;

struct nodoAvion{
    string numAvion;
    string Tipo;
    string Probabilidad;
    string Pasajeros;
    string Desabordaje;
    string Mantenimiento;
    nodoAvion* siguiente;
    nodoAvion* atras;
    nodoAvion(string numAvion, string Tipo, string Probabilidad, string Pasajeros,string Desabordaje, string Mantenimiento);
};

struct colaAvion
{
    nodoAvion * primero;
    nodoAvion * ultimo;
    void InsertarAvion(colaAvion *colaA ,string numAvion, string Tipo, string Probabilidad, string Pasajeros,string Desabordaje, string Mantenimiento);
    string MostrarAvion(colaAvion * colaA);
    bool BuscarAvion(colaAvion * colaA, string numAvion);
    void EliminarAvion(colaAvion * colaA);
    string verificar(colaAvion * colaA, int tiempo);
    //void modificarAvion(string nombreviejo, string nombre, string contrasena, string tipo);
};

#endif // COLAAVIONES_H
