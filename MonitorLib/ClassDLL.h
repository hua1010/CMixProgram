#pragma once
#ifndef CLASSDLL_H
#define CLASSDLL_H

#include "GeneralDDC/List.h"
#include "GeneralDDC/Device.h"

#define DLL_API extern "C" __declspec(dllexport)
namespace GeneralDDC {

	//初始化
	DLL_API  List* __stdcall InitList();

	//自动获取设备
	DLL_API void __stdcall listProbe(List* mList);


	//获取设备总数
	DLL_API int __stdcall getCount(List* mList);

	//获取设备名字
	DLL_API void __stdcall getDeviceName(List* mList, int index, char* name);

	//获取设备功能字符串
	DLL_API void __stdcall getRawCapabilities(List* mList, int index, char* raw);

	//获取VCP的值
	DLL_API unsigned long __stdcall getVCPValue(List* mList, int index, unsigned char code);

	//设置VCP的值
	DLL_API void __stdcall setVCPValue(List* mList, int index, unsigned char code, unsigned long value);
}


#endif // CLASSDLL_H


