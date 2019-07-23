#include <Windows.h>
extern "C" __declspec(dllexport) PVOID __stdcall S0M(IN PVOID ptr, IN SIZE_T cnt)
{
	return SecureZeroMemory(ptr, cnt);
}