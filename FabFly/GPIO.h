#pragma once
#define INPUT false
#define OUTPUT true
#define MAXPOW 3.3f
class GPIO
{
public:
	//Constructeurs
	GPIO();
	GPIO(int Number);
	GPIO(int Number, bool Mode);
	~GPIO(void);
	//Lien vers les fonction de base de l'api temps-r�elis�
	//Il faudra v�rifier qu'on acc�de bien au voltage par l'api
	//Sinon il suffira d'adapter les types de retour
	float GetValue(void);
	void Reset(char Mode);
	void SetValue(float Value);
	//Demendera du temps r�el pour fonctionner au top du top : envoi d'un signal via GPIO
	void Signal(char* Buffer, int Start, int Length, int BitPerSecond);
	void RecvSignal(char* Buffer, int Start, int Length, int BitPerSecond);
	//Fonction virtuel qui devrons �tre surcharg� en fonction du type de mat�riel
	//par exemple pour un Servo, SetByte permetrai d'avancer d'un certain nombre de pas
	virtual void SetBoolean      (bool Value);
	virtual void SetByte         (unsigned char Value);
	virtual void SetPower        (float Value);
	virtual bool GetBoolean      ();
	virtual float GetPower       ();
	virtual unsigned char GetByte();
private:
	bool IOType;
	int GPIONumber;
};

