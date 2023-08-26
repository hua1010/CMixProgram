#pragma once
#ifndef CLASSDLL_H
#define CLASSDLL_H

#include "GeneralDDC/List.h"
#include "GeneralDDC/Device.h"

#define DLL_API extern "C" __declspec(dllexport)
namespace GeneralDDC {

	//��ʼ��
	DLL_API  List* __stdcall InitList();

	//�Զ���ȡ�豸
	DLL_API void __stdcall listProbe(List* mList);


	//��ȡ�豸����
	DLL_API int __stdcall getCount(List* mList);

	//��ȡ�豸����
	DLL_API void __stdcall getDeviceName(List* mList, int index, char* name);

	//��ȡ�豸�����ַ���
	DLL_API void __stdcall getRawCapabilities(List* mList, int index, char* raw);

	//��ȡVCP��ֵ
	DLL_API unsigned long __stdcall getVCPValue(List* mList, int index, unsigned char code);

	//����VCP��ֵ
	DLL_API void __stdcall setVCPValue(List* mList, int index, unsigned char code, unsigned long value);
}


#endif // CLASSDLL_H


