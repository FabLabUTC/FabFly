#include "Motor.h"
#include "Accelerometre.h"

Vector3 Helper_Diff(Vector3 Actual, Vector3 Desired)
{
	//Raprocher Actual de Desired le plus vite possible
	//Pour l'instant on fait des division par 2
	return (Desired - Actual) / 2;
}


Motor::Motor(void)
{
}


Motor::~Motor(void)
{
}

void Motor::SetByte(unsigned char Value)
{
	//Envoi d'instruction de puissance
	//Pourquoi pas signal ? 
}