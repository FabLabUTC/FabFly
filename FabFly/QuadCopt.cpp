#include "QuadCopt.h"


QuadCopt::QuadCopt(int Port1, int Port2, int Port3, int Port4, int AccPort)
{
	this->Moteurs[0] = new Motor();
	this->Moteurs[0]->GPIONumber = Port1;
	this->Moteurs[1] = new Motor();
	this->Moteurs[1]->GPIONumber = Port2;
	this->Moteurs[2] = new Motor();
	this->Moteurs[2]->GPIONumber = Port3;
	this->Moteurs[3] = new Motor();
	this->Moteurs[3]->GPIONumber = Port4;
	this->Acc = new Accelerometre();
	Acc->GPIONumber = AccPort;
}


QuadCopt::~QuadCopt(void)
{
	delete this->Moteurs;
	delete this->Acc;
}

void QuadCopt::Start(void)
{
	Vector3 A1;
	//Devra être capable d'imprimer une accélération
	//dans toute direction, pour l'instant on décolle
	for (int i = 0; i < 4; ++i) Moteurs[i]->SetByte(0xFF);
	unsigned char Pow = 0xFF;
	do 
	{
		A1 = this->Acc->GetValue();
		for (int i = 0; i < 4; ++i) Moteurs[i]->SetByte(--Pow);
	}
	while (A1.Z > -9.81);
}