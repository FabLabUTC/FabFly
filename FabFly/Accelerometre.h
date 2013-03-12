#pragma once
#include "GPIO.h"
#include "Motor.h"

class Accelerometre : 
	public GPIO
{
public:
	Accelerometre(void);
	~Accelerometre(void);
	virtual Vector3 GetValue(void);
};

