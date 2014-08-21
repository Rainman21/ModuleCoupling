// BasicCppConsole.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <string.h>

struct EmployeeStruct
{
	char FirstName[10];
	char LastName[10];
	short EmployeeID;	 
	short BirthYear;
	char  BirthMonth;
	char  BirthDay;
};

class EmployeeClass
{
public:
	EmployeeClass(char * firstName, char * lastname, int EmployeeID)
	{
		//what is the bug here?
		//what is the problem with intializing objects at construction time?
		memcpy(FirstName, firstName,  strlen(lastname)+1);
		memcpy(LastName, lastname, strlen(lastname)+1);
	}
	bool SetBirthday(int year, int month, int day)
	{
		if(year < 2014)
			return false;

	}

private:
	char FirstName[10];
	char LastName[10];
	short EmployeeID;	 
	short BirthYear;
	char  BirthMonth;
	char  BirthDay;
};

void RunTest1()
{

	EmployeeStruct Ted;
	//Ted.FirstName = "Ted"; Doesnt' work...
	memcpy(Ted.FirstName, "Ted", 4);
	memcpy(Ted.LastName, "Frankenstein", strlen("Frankenstein")+1);
	
	EmployeeClass TedClass("Ted", "Frankenstein", 23);
	//there are two things wrong below
	TedClass.SetBirthday(3,27,1999);

}



int _tmain(int argc, _TCHAR* argv[])
{
	RunTest1();
	return 0;
}

