#pragma once
class GPIO
{
public:
	GPIO(int Number);
	GPIO(int Number, bool Mode);
	~GPIO(void);
	float GetValue(void);
	void Reset(char Mode);
	void SetValue(float Value);
	void Signal(char* Buffer, int Start, int Length, int BitPerSecond);
	void RecvSignal(char* Buffer, int Start, int Length, int BitPerSecond);
	virtual void operator=(bool Value);
	virtual void operator=(unsigned char Value);
	virtual void operator=(float Value);
	virtual operator bool();
	virtual operator float();
	virtual operator unsigned char();
private:
	bool IOType;
	int GPIONumber;
};

