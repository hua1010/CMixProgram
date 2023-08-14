#define _CRT_SECURE_NO_WARNINGS
#include "ClassDLL.h"
#include "GeneralDDC/Device.h"
#include <print>
#include <iostream>
using namespace std;

DLL_API GeneralDDC::List* __stdcall GeneralDDC::InitList()
{
	List* mList = new List();
	return mList;
}


DLL_API int __stdcall GeneralDDC::getCount(List* mList)
{
	int num = 0;
	if (mList != NULL) {
		num = mList->count();
	}
	return num;
}


DLL_API void __stdcall GeneralDDC::listProbe(List* mList)
{
	if (mList != NULL) {
		mList->probe();
	}
	return ;
}


DLL_API void __stdcall GeneralDDC::getDeviceName(List* mList, int index, char* name)
{
	Device* device;
	if (mList != NULL) {
		device = mList->at(index);
		if (device != NULL) {
			strcpy(name, device->getName().c_str());
		}
	}
}
