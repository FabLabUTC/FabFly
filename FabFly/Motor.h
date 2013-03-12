#pragma once
#include "gpio.h"

struct Vector3 {
	float X;
	float Y;
	float Z;
	Vector3 operator +(Vector3 a) const
	{
		Vector3 Ret;
		Ret.X = X + a.X;
		Ret.Y = Y + a.Y;
		Ret.Z = Z + a.Z;
		return Ret;
	}
	Vector3 operator -(Vector3 a) const
	{
		Vector3 Ret;
		Ret.X = X - a.X;
		Ret.Y = Y - a.Y;
		Ret.Z = Z - a.Z;
		return Ret;
	}
	Vector3 operator /(float a) const
	{
		Vector3 Ret;
		Ret.X = X / a;
		Ret.Y = Y / a;
		Ret.Z = Z / a;
		return Ret;
	}
};


class Motor :
	public GPIO
{
public:
	Motor(void);
	~Motor(void);
	void Start();
	virtual void SetByte(unsigned char Value);
};

