#ifndef MAINWINDOW_H
#define MAINWINDOW_H
#include "colapasajeros.h"

#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void on_pushButton_clicked();

    void on_pushButton_3_clicked();

    void on_pushButton_2_clicked();

    void crearGraficaAviones();

    void crearGraficaPasajeros();

    void crearGraficaEscritorios();

    void crearGraficaMaletas();

    void crearPasajeros(colaPasajero *colaP, int numPasajeros);

    void on_pushButton_4_clicked();

    void on_pushButton_5_clicked();

    void on_pushButton_6_clicked();

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
