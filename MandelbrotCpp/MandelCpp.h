#pragma once

#ifdef MANDELCPP_EXPORTS
#define MANDELCPP_API __declspec(dllexport)
#else
#define MANDELCPP_API __declspec(dllimport)
#endif

extern "C" MANDELCPP_API int generateMandelCpp(BYTE * bmp, int resX, int resY, int rowNum, int iterCount);