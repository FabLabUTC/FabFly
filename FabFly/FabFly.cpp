#include "GPIO.h"
#include "wiringPi.h'
using namespace std;

int main(int argc, char *argv[])
{
	wiringPiSetup();
	pinMode(1, OUTPUT);
}

