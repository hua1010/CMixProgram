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

void __stdcall GeneralDDC::getRawCapabilities(List* mList, int index, char* raw)
{
	Device* device;
	if (mList != NULL) {
		device = mList->at(index);
		if (device != NULL) {
			strcpy(raw, device->getRawCapabilities().c_str());
		}
	}
}

unsigned long __stdcall GeneralDDC::getVCPValue(List* mList, int index, unsigned char code)
{
	Device* device;
	if (mList != NULL) {
		device = mList->at(index);
		if (device != NULL) {
			return device->readValue(code);
		}
	}
	return 0;
}

void __stdcall GeneralDDC::setVCPValue(List* mList, int index, unsigned char code, unsigned long value)
{
	Device* device;
	if (mList != NULL) {
		device = mList->at(index);
		if (device != NULL) {
			device->writeValue(code, value);
		}
	}
}
