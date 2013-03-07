#ifndef _MSC_VER
#include <iostream>
#endif

#include "GPIO.h"

using namespace std;

int main(int argc, char *argv[])
{
	GPIO* test = new GPIO(1, INPUT);
	test->SetByte(true);

	char sz[] = "Hello, World!\n";	//Hover mouse over "sz" while debugging to see its contents
	cout << sz << endl;	//<================= Put a breakpoint here
	return 0;
}