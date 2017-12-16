#include "timer.h"
#include <QtCore>
#include <QMessageBox>

timer::timer()
{
    time = new QTimer(this);
    connect(time, SIGNAL(timeout()), this, SLOT(MySlot()));

    time->start(1000);
}

void timer::MySlot(){
    QMessageBox msgBoxE;
    msgBoxE.setText(" timer finalizado ");
    msgBoxE.exec();
}
