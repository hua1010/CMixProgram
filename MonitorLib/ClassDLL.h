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
}


#endif // CLASSDLL_H


