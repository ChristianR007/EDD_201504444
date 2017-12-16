#include "mainwindow.h"
#include <QApplication>
//#include "timer.h"
#include <iostream>
#include <ctype.h>
#include <QMessageBox>

using namespace std;

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);

        MainWindow w;
        w.show();


    return a.exec();
}
