#pragma once
#include "Motor.h"
#include "Accelerometre.h"
class QuadCopt
{
private:
	Motor* Moteurs[4];
	Accelerometre* Acc;
public:
	QuadCopt(int Port1, int Port2, int Port3, int Port4, int AccPort);
	~QuadCopt(void);
	void Start(void);
};

