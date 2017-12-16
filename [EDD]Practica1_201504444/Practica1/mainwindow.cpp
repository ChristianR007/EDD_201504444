#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <time.h>
#include <QMessageBox>
#include "QString"
#include <QTimer>
#include <fstream>      // Grafica
#include <QBoxLayout>   // Grafica
#include <QLabel>       // Grafica
#include <QPixmap>      // Grafica
#include "timer.h"
#include <QChar>

#include "colaaviones.h"
#include "colapasajeros.h"
#include "escritorios.h"
#include "piladocumentos.h"
#include "listacircular.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    ui->lineEdit->setVisible(false);
    ui->lineEdit_2->setVisible(false);
    ui->pushButton->setVisible(false);
    ui->pushButton_3->setVisible(false);
    ui->pushButton_4->setVisible(false);
    ui->pushButton_5->setVisible(false);
    ui->pushButton_6->setVisible(false);
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
string randomCantidadMaletas(){   // Random de cantidad de Maletas
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 10; c++)
    {
        num = 1 + rand() % (4);
        return QString::number(num).toStdString();
    }
}
string randomCantidadDocumentacion(){   // Random de cantidad de documentos
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 10; c++)
    {
        num = 1 + rand() % (10);
        return QString::number(num).toStdString();
    }
}
string randomCantidadTurnosRegistro(){   // Random de cantidad de turnos para registrarse
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 10; c++)
    {
        num = 1 + rand() % (3);
        return QString::number(num).toStdString();
    }
}
// ------------------------------------------------------------------------------------------------------------------------

std::string cadena;
QString qcadena;// = QString::fromStdString(cadena);

colaPasajero * nuevoPasajero = new colaPasajero();                              // Apuntadores
colaAvion * nuevoAvion = new colaAvion();
listaEscritorio * nuevoEscritorio = new listaEscritorio();
pilaDocumento * nuevaPilaDocumentos = new pilaDocumento();
listaMaletas * nuevaMaleta = new listaMaletas();

    QString str;
void MainWindow::on_pushButton_clicked()
{
    /*try {
        ui->lineEdit->setText(nuevoPasajero->primero->nombre.c_str());
        ui->lineEdit->setText("entra");
    }
    catch (...) {
        ui->lineEdit->setText("Hay un error");
    }
*/
    int num, c;
    srand(time(NULL));

    for(c = 1; c <= 25; c++)
    {
        //num += rand()%5;
        str += QString::fromStdString(QString::number( 1+rand()%3 ).toStdString()) + "-";
    }

    //str = QString::fromStdString(QString::number( num ).toStdString());
        //return str;
    ui->lineEdit_2->setText(str);
}

QVBoxLayout *contenedor = new QVBoxLayout();
QLabel *apuntador;
QVBoxLayout *contenedorPasajeros = new QVBoxLayout();
QLabel *apuntadorPasajeros;
QVBoxLayout *contenedorEscritorios = new QVBoxLayout();
QLabel *apuntadorEscritorios;
QVBoxLayout *contenedorMaletas = new QVBoxLayout();
QLabel *apuntadorMaletas;

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
void MainWindow::crearGraficaPasajeros(){
    string cuerpo="digraph G {\nrankdir=LR;\nnode [shape=box, color=blue];\n";
    if(nuevoPasajero->MostrarPasajero(nuevoPasajero) != "vacio"){
        cuerpo+= nuevoPasajero->MostrarPasajero(nuevoPasajero);
    }
    cuerpo += "}";
    ofstream salida;
    salida.open("C:\\Musica\\archivoPasajeros.dot");
    salida<<cuerpo;
    salida.close();
    system("dot.exe -Tpng C:\\Musica\\archivoPasajeros.dot -o C:\\Musica\\archivoPasajeros.png");
    contenedorPasajeros->removeWidget(apuntadorPasajeros);
    delete apuntadorPasajeros;
    QPixmap img("C:\\Musica\\archivoPasajeros.png");
    QLabel* l = new QLabel();
    apuntadorPasajeros = l;
    l->setPixmap(img);
    l->setFixedSize(img.size());
    l->repaint();
    contenedorPasajeros->addWidget(l);
    ui->scrollAreaWidgetContents_2->setLayout(contenedorPasajeros);
}

void MainWindow::crearGraficaEscritorios(){
    string cuerpo="digraph G {\nnode [shape=box, color=gray];\n";

    cuerpo+= nuevoEscritorio->MostrarEscritorios(nuevoEscritorio) + "}";
    ofstream salida;
    salida.open("C:\\Musica\\archivoEscritorios.dot");
    salida<<cuerpo;
    salida.close();
    system("dot.exe -Tpng C:\\Musica\\archivoEscritorios.dot -o C:\\Musica\\archivoEscritorios.png");
    contenedorEscritorios->removeWidget(apuntadorEscritorios);
    delete apuntadorEscritorios;
    QPixmap img("C:\\Musica\\archivoEscritorios.png");
    QLabel* l = new QLabel();
    apuntadorEscritorios = l;
    l->setPixmap(img);
    l->setFixedSize(img.size());
    l->repaint();
    contenedorEscritorios->addWidget(l);
    ui->scrollAreaWidgetContents_3->setLayout(contenedorEscritorios);
}

void MainWindow::crearGraficaMaletas(){
    string cuerpo="digraph G {\nrankdir=LR;\nnode [shape=box, color=gray];\n";

    cuerpo+= nuevaMaleta->MostrarCircular(nuevaMaleta) + "}";

    ofstream salida;
    salida.open("C:\\Musica\\archivoMaletas.dot");
    salida<<cuerpo;
    salida.close();
    system("dot.exe -Tpng C:\\Musica\\archivoMaletas.dot -o C:\\Musica\\archivoMaletas.png");
    contenedorMaletas->removeWidget(apuntadorMaletas);
    delete apuntadorMaletas;
    QPixmap img("C:\\Musica\\archivoMaletas.png");
    QLabel* l = new QLabel();
    apuntadorMaletas = l;
    l->setPixmap(img);
    l->setFixedSize(img.size());
    l->repaint();
    contenedorMaletas->addWidget(l);
    ui->scrollAreaWidgetContents_4->setLayout(contenedorMaletas);
}

int idPasajeros = 1;

void MainWindow::crearPasajeros(colaPasajero *colaP, int numPsajeros){
    //QTimer *timer = new QTimer(this);
    for(int i=1; i< numPsajeros; i++){
        //timer mtimer;

        string nom = "Pasajero " + QString::number(idPasajeros).toStdString();
        colaP->InsertarPasajero(colaP, nom, QString::number(idPasajeros).toStdString(), QString::number( 1+rand()%4 ).toStdString(), QString::number( 1+rand()%10 ).toStdString(), QString::number( 1+rand()%3 ).toStdString());
        idPasajeros++;
    }

    //ui->lineEdit_2->setText(nuevoPasajero->MostrarPasajero(nuevoPasajero).c_str());
    crearGraficaPasajeros();
}
int asciiLetra = 41;
void MainWindow::on_pushButton_3_clicked()
{
    //crearPasajeros(nuevoPasajero, 5);

    //ui->lineEdit_2->setText(nuevoPasajero->primero->nombre.c_str());


    ui->lineEdit_2->setText( nuevoEscritorio->primero->turnosFaltan.c_str() );


/*    nuevoEscritorio->InsertarEscritorioPasayDoc(nuevoEscritorio, "dos", "1", "3","5", "2");
    nuevoEscritorio->InsertarEscritorioPasayDoc(nuevoEscritorio, "tres", "1", "3","5", "2");
    nuevoEscritorio->InsertarEscritorioPasayDoc(nuevoEscritorio, "cuatro", "1", "3","5", "2");


    if(nuevoEscritorio->BuscarEscritorio(nuevoEscritorio,"B")==true){
        //ui->lineEdit_2->setText("Encontrado");
    }else{
        //ui->lineEdit_2->setText("No esta");
    }
*/
}

int numeroAvion=1;
int tiempoCabeza=0;
int turnos;
int turnosbaja = 1;
int cajaAvion;
int compararCantidadMaximaEscritoris;
int compararCantidadMaximaEnPasajeros;
int prueba=1;
int idmaleta=1;
void MainWindow::on_pushButton_2_clicked()
{
    // ---------------------------------------------------------------------------------------------------------------------------------
    // ---------------------------------------------------- Aviones --------------------------------------------------------------------
    // ---------------------------------------------------------------------------------------------------------------------------------
    string nombre;
    turnos = ui->cajaTurnos->text().toInt();

    if(tiempoCabeza == 0){ // Inicio
        cajaAvion = ui->cajaAviones->text().toInt();
        int numeroEscritorios = ui->cajaEscritorios->text().toInt();
        int i = asciiLetra;
        compararCantidadMaximaEscritoris = numeroEscritorios*10;
        //ui->lineEdit->setText(QString::fromStdString(QString::number( escritoriosMul ).toStdString()));
        for(int x = i; x< i+numeroEscritorios; x++){
            QByteArray oldStr = QByteArray::fromHex(QString::fromStdString(QString::number(x).toStdString()).toLocal8Bit());
            QString mandar = "Escritorio " + oldStr;

            nuevoEscritorio->InsertarEscritorio(nuevoEscritorio, mandar.toUtf8().constData() , "0", "Libre", "0", "0");
            asciiLetra++;
        }

        crearGraficaEscritorios();
    } else if(tiempoCabeza == 1){

        //while( auxCambio != NULL ){
            /*if(QString::fromStdString( nuevoEscritorio->primero->turnosFaltan ).toInt() == 1){

                nuevoEscritorio->EliminarEscritorioPasajero(nuevoEscritorio);

            } else if(QString::fromStdString( nuevoEscritorio->primero->turnosFaltan ).toInt() > 1){

                int quitarturnoEscritorio = QString::fromStdString( nuevoEscritorio->primero->turnosFaltan ).toInt() - 1;
                nuevoEscritorio->primero->turnosFaltan = QString::number( quitarturnoEscritorio ).toStdString();

            }*/
        if(nuevoEscritorio->lleno() >=1){
            ui->lineEdit->setText( nuevoEscritorio->cambio(nuevoEscritorio).c_str() );

            for(int y = 0; y < nuevoEscritorio->NumeroMaletas() ; y++){
                nuevaMaleta->EliminarCircular(nuevaMaleta);
            }

            crearGraficaMaletas();
            crearGraficaEscritorios();
        }
            //auxTurnosFaltan = auxTurnosFaltan->siguiente;
        //}
        // nuevoEscritorio->EliminarEscritorioPasajero(nuevoEscritorio);
        // ui->lineEdit_2->setText( nuevoEscritorio->primero->turnosFaltan.c_str() );


        if(nuevoPasajero->primero != NULL){                                                   //Agarra Pasajeros, 1 turno despues de ser creados
            //ui->lineEdit->setText(nuevoPasajero->primero->nombre.c_str());
            // nuevoPasajero->primero->nombre.c_str()

            for(int x = 1; x< compararCantidadMaximaEnPasajeros+1; x++){
                if(compararCantidadMaximaEscritoris != nuevoEscritorio->lleno() ){
                    //nDoc = "Documento: ";
                    nuevoEscritorio->InsertarEscritorioPasayDoc(nuevoEscritorio, nuevoPasajero->primero->nombre , nuevoPasajero->primero->Id, nuevoPasajero->primero->Maletas, nuevoPasajero->primero->Documentos , nuevoPasajero->primero->turnos);
                    for(int y = 0; y < QString::fromStdString( nuevoPasajero->primero->Maletas ).toInt(); y++){

                        string nombremaletas = "Maleta " + QString::number( idmaleta ).toStdString();
                        nuevaMaleta->InsertarCircular(nuevaMaleta, nombremaletas);

                        idmaleta++;
                        ui->cajaEstaciones->setText("1");
                    }
                    string gg;
                    gg = nuevoEscritorio->InsertarDocumentos(nuevoEscritorio,"nada", 0);
                    //ui->cajaEstaciones->setText( gg.c_str() );

                    nuevoPasajero->EliminarPasajero(nuevoPasajero);
                    prueba++;
                } else{
                    break;
                }
            }
            // Contador que va recorriendo los escritorios
            string var = QString::number( compararCantidadMaximaEscritoris ).toStdString() + " - " + QString::number( nuevoEscritorio->lleno() ).toStdString();
            ui->lineEdit->setText( var.c_str() );

            crearGraficaEscritorios();
            crearGraficaPasajeros();
            crearGraficaAviones();
            crearGraficaMaletas();
        }     
    }

    if(turnosbaja != turnos+1){
        nombre = "Siguiente \nTurno:" + QString::number( turnosbaja + 1 ).toStdString(); //a turnos le sumo uno por que es el que sigue
        ui->pushButton_2->setText(nombre.c_str());
        turnosbaja++;
        if(tiempoCabeza == 1){ //Creando Pasajeros
            string numPasajeros = nuevoAvion->verificar(nuevoAvion, tiempoCabeza); //retorna la cantidad de pasajeros o f si faltan turnos vaciado
            if(numPasajeros != "f"){
                //ui->lineEdit_2->setText(numPasajeros.c_str());
                nuevoAvion->EliminarAvion(nuevoAvion);
                crearPasajeros(nuevoPasajero, QString::fromStdString( numPasajeros ).toInt()+1);
                crearGraficaPasajeros();

                compararCantidadMaximaEnPasajeros = QString::fromStdString( nuevoPasajero->ultimo->Id ).toInt() - QString::fromStdString( nuevoPasajero->primero->Id ).toInt() +1;
                string mandar = "Hay Pasajeros: " + QString::number( compararCantidadMaximaEnPasajeros ).toStdString();
                ui->lineEdit_2->setText(mandar.c_str());

            }

            crearGraficaAviones();
        } else{
            tiempoCabeza++;
        }
    } else{
        QMessageBox msgBoxE;
        msgBoxE.setText(" Se acabaron los turnos ");
        msgBoxE.exec();
    }

        //ui->lineEdit_3->text()        //cantidad de aviones permitidos
        if(cajaAvion != 0){
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

            //ui->lineEdit_2->setText(nuevoAvion->MostrarAvion(nuevoAvion).c_str());
            numeroAvion++;

        // --------------------------------------------------------------------------------------- Grafica de avion
            crearGraficaAviones();

        //-------------------------------------------------------------------------------------------------
            cajaAvion--;
        }


}

void MainWindow::on_pushButton_4_clicked()
{
    ui->cajaAviones->setText("6");
    ui->cajaTurnos->setText("44");
    ui->cajaEscritorios->setText("6");
/*
    try
    {
        nuevaMaleta->EliminarCircular(nuevaMaleta);
    }
    catch (...){
        QMessageBox msgBoxE;
        msgBoxE.setText(" Se presento un error ");
        msgBoxE.exec();
    }


    //ui->lineEdit_2->setText( nuevaMaleta->MostrarCircular(nuevaMaleta).c_str() );

    crearGraficaMaletas();*/
}

void MainWindow::on_pushButton_5_clicked()
{
    //crearGraficaAviones();
    //crearGraficaEscritorios();
    //crearGraficaPasajeros();

    string nDoc;
    for(int m = 1; m < QString::fromStdString( ui->cajaAviones->text().toUtf8().constData() ).toInt() + 1 ; m++){
        nDoc = "Documento: " + QString::number( m ).toStdString();
        //nuevaPilaDocumentos->InsertarDocumento(nuevaPilaDocumentos,nDoc);
    }

    nuevaMaleta->InsertarCircular(nuevaMaleta, "Zacapa 1");
    nuevaMaleta->InsertarCircular(nuevaMaleta, "Petapa 2");
    nuevaMaleta->InsertarCircular(nuevaMaleta, "Guatemala 7");
    nuevaMaleta->InsertarCircular(nuevaMaleta, "cuatro");

    //nuevaPilaDocumentos->vaciarPilaDocumentos(nuevaPilaDocumentos);
    //nuevaPilaDocumentos->vaciarPilaDocumentos(nuevaPilaDocumentos);
    //nuevaPilaDocumentos->vaciarPilaDocumentos(nuevaPilaDocumentos);

    crearGraficaMaletas();

    //ui->lineEdit_2->setText( nuevaMaleta->MostrarCircular(nuevaMaleta).c_str() );

}

void MainWindow::on_pushButton_6_clicked()
{
    nuevoEscritorio->EliminarEscritorioPasajero(nuevoEscritorio);
    crearGraficaEscritorios();
}
