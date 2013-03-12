#include "GPIO.h"

GPIO::GPIO()
{

}
GPIO::GPIO(int Number)
{
	this->GPIONumber = Number;
}
GPIO::GPIO(int Number, bool Mode)
{
	this->GPIONumber = Number;
	this->IOType = Mode;
}


GPIO::~GPIO(void)
{
}


float GPIO::GetValue(void)
{
	return 0.0f;
}


void GPIO::Reset(char Mode)
{
	this->IOType = (Mode == 'w' || Mode == 'W');
}


void GPIO::SetValue(float Value)
{
}


void GPIO::Signal(char* Buffer, int Start, int Length, int BitPerSecond)
{

}


void GPIO::RecvSignal(char* Buffer, int Start, int Length, int BitPerSecond)
{
}


//Implémentation de base déstiné à un usage des GPIO pour les objets simples (LED et autres loupiottes par exemple)
void GPIO::SetBoolean(bool Value)
{
	this->SetValue(Value ? MAXPOW : 0.0f);
}

void GPIO::SetByte(unsigned char Value)
{
	this->SetValue((MAXPOW * Value) / __UINT8_MAX__);
}
void GPIO::SetPower(float Value)
{
	this->SetValue(Value > MAXPOW ? MAXPOW : Value < 0 ? 0 : Value);
}
bool GPIO::GetBoolean()
{
	return this->GetValue() > MAXPOW / 2;
}
unsigned char GPIO::GetByte()
{
	return (this->GetValue() / MAXPOW) * __UINT8_MAX__;
}
float GPIO::GetPower()
{
	return this->GetValue();
}