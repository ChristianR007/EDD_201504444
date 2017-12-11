#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <time.h>
#include "QString"
#include <fstream>      // Grafica
#include <QBoxLayout>   // Grafica
#include <QLabel>       // Grafica
#include <QPixmap>      // Grafica
#include "colaaviones.h"
#include "colapasajeros.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

// -----------------------------------  Funciones de Random ---------------------------------------------------------
int random(){       // Funcion que retorna un numero random entre 1 y 10
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 10; c++)
    {
        num = 5 + rand() % (6);
        return num;
    }
}
string randomProbabilidad(){       // Random de probabilidad
    int num, c;
    srand(time(NULL));
    for(c = 1; c <= 10; c++)
    {
        num = 1 + rand() % (3);
        return QString::number(num).toStdString();
    }
}
string randomPasajerosPequeno(){   // Random de pasajeros pequenos
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 10; c++)
    {
        num = 5 + rand() % (6);
        return QString::number(num).toStdString();
    }
}
string randomPasajerosMediano(){   // Random de pasajeros Mediano
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 10; c++)
    {
        num = 15 + rand() % (11);
        return QString::number(num).toStdString();
    }
}
string randomPasajerosGrande(){   // Random de pasajeros Grande
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 10; c++)
    {
        num = 30 + rand() % (11);
        return QString::number(num).toStdString();
    }
}
string randomMantenimientoPequeno(){   // Random de pasajeros pequenos
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 10; c++)
    {
        num = 1 + rand() % (3);
        return QString::number(num).toStdString();
    }
}
string randomMantenimientoMediano(){   // Random de pasajeros mediano
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 10; c++)
    {
        num = 2 + rand() % (3);
        return QString::number(num).toStdString();
    }
}
string randomMantenimientoGrande(){   // Random de pasajeros Grande
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 10; c++)
    {
        num = 3 + rand() % (4);
        return QString::number(num).toStdString();
    }
}
// ------------------------------------------------------------------------------------------------------------------------

std::string cadena;
QString qcadena;// = QString::fromStdString(cadena);
void MainWindow::on_pushButton_clicked()
{
    ui->lineEdit->setText(QString::number(random()));
    qcadena = qcadena +  QString::number(random());
    ui->lineEdit_2->setText(qcadena);
}

colaPasajero * nuevoPasajero = new colaPasajero();
colaAvion * nuevoAvion = new colaAvion();
QVBoxLayout *contenedor = new QVBoxLayout();
QLabel *apuntador;

void MainWindow::crearGraficaAviones(){
    string cuerpo="digraph G {\nrankdir=LR;\nnode [shape=box, color=gray];\n";
    //string cuerpo="digraph G {\ndistortion=\"" + QString::number(0.624013).toStdString() + "\", orientation=56, skew=\""+QString::number(0.101396).toStdString()+"\", color=dodgerblue1];\n";

    cuerpo+= nuevoAvion->MostrarAvion(nuevoAvion) + "}";
    ofstream salida;
    salida.open("C:\\Musica\\archivo.dot");
    salida<<cuerpo;
    salida.close();
    system("dot.exe -Tpng C:\\Musica\\archivo.dot -o C:\\Musica\\archivo.png");
    contenedor->removeWidget(apuntador);
    delete apuntador;
    QPixmap img("C:\\Musica\\archivo.png");
    QLabel* l = new QLabel();
    apuntador = l;
    l->setPixmap(img);
    l->setFixedSize(img.size());
    l->repaint();
    contenedor->addWidget(l);
    ui->scrollAreaWidgetContents->setLayout(contenedor);
}

void MainWindow::crearPasajeros(colaPasajero *colaP, string Id, string Maletas, string Documentos, string posEntra){
    colaP->InsertarPasajero(colaP, "Primero", "2", "5", "1");
    colaP->InsertarPasajero(colaP, "segundo", "2", "5", "1");
    colaP->InsertarPasajero(colaP, "tercero", "2", "5", "1");

    ui->lineEdit_2->setText(nuevoPasajero->MostrarPasajero(nuevoPasajero).c_str());
}

void MainWindow::on_pushButton_3_clicked()
{
    crearPasajeros(nuevoPasajero,"h","asd","aasd","asd");
}

int numeroAvion=1;
int tiempoCabeza;
void MainWindow::on_pushButton_2_clicked()
{
    // ---------------------------------------------------------------------------------------------------------------------------------
    // ---------------------------------------------------- Aviones --------------------------------------------------------------------
    // ---------------------------------------------------------------------------------------------------------------------------------
    string nombre;
    int turnos = ui->cajaTurnos->text().toInt();

    if(turnos+1 != numeroAvion){
        if(ui->cajaAviones->text() >= QString::number(numeroAvion)){
        nombre = "Siguiente \nTurno:" + QString::number(numeroAvion+1).toStdString();
        ui->pushButton_2->setText(nombre.c_str());}

        //ui->lineEdit_3->text()        //cantidad de aviones permitidos
        if(ui->cajaAviones->text() >= QString::number(numeroAvion)){
            string nombreAvion = "Avion " + QString::number(numeroAvion).toStdString();
            string probabilidad=randomProbabilidad();
            string tipo;
            string pasajeros;
            string desabordaje;
            string mantenimiento;
            if(probabilidad=="1"){
                tipo="Pequeño";
                pasajeros = randomPasajerosPequeno();
                desabordaje = probabilidad;
                mantenimiento = randomMantenimientoPequeno();
            } else if(probabilidad=="2"){
                tipo="Mediano";
                pasajeros = randomPasajerosMediano();
                desabordaje = probabilidad;
                mantenimiento = randomMantenimientoMediano();
            } else if(probabilidad=="3"){
                tipo="Grande";
                pasajeros = randomPasajerosGrande();
                desabordaje = probabilidad;
                mantenimiento = randomMantenimientoGrande();
            }

            nuevoAvion->InsertarAvion(nuevoAvion, nombreAvion, tipo, probabilidad, pasajeros, desabordaje, mantenimiento);
            //nuevoAvion->InsertarAvion(nuevoAvion,"Avion2","Grande","3","7","1","2");

            if(tiempoCabeza == 1){
                string numPasajeros = nuevoAvion->verificar(nuevoAvion, tiempoCabeza);
                if(numPasajeros != "f"){
                    tiempoCabeza=1;
                    ui->lineEdit_2->setText(numPasajeros.c_str());
                    nuevoAvion->EliminarAvion(nuevoAvion);
                    crearGraficaAviones();
                }
            } else{
                tiempoCabeza++;
            }
            //ui->lineEdit_2->setText(nuevoAvion->MostrarAvion(nuevoAvion).c_str());
            numeroAvion++;

        // --------------------------------------------------------------------------------------- Grafica de avion
            crearGraficaAviones();

        //-------------------------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------------------------------------------------------
            // ---------------------------------------------------- Desabordaje --------------------------------------------------------------------
            // ---------------------------------------------------------------------------------------------------------------------------------
        }
    }
}
