#include "GPIO.h"

const bool INPUT = false;
const bool OUTPUT = true;
const float MAXPOW = 3.3f;
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

void GPIO::operator=(bool Value)
{
	this->operator=(Value ? MAXPOW : 0.0f);
}

void GPIO::operator=(unsigned char Value)
{
	this->operator=((MAXPOW * Value) / __UINT8_MAX__);
}
void GPIO::operator=(float Value)
{
	this->SetValue(Value > MAXPOW ? MAXPOW : Value < 0 ? 0 : Value);
}
GPIO::operator bool()
{
	return this->GetValue() > MAXPOW / 2;
}
GPIO::operator unsigned char()
{
	return (this->GetValue / MAXPOW) * __UINT8_MAX__;
}
GPIO::operator float()
{
	return this->GetValue();
}