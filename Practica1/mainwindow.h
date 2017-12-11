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

    void crearPasajeros(colaPasajero *colaP, string Id, string Maletas, string Documentos, string posEntra);
private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
