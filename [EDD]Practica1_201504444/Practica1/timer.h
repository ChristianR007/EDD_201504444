#ifndef TIMER_H
#define TIMER_H

#include <QtCore>

class timer : public QObject
{
    Q_OBJECT

public:
    timer();
    QTimer * time;

public slots:
    void MySlot();
};

#endif // TIMER_H
