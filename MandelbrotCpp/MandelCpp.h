#pragma once

#ifdef MANDELCPP_EXPORTS
#define MANDELCPP_API __declspec(dllexport)
#else
#define MANDELCPP_API __declspec(dllimport)
#endif

extern "C" MANDELCPP_API void generateMandelCpp(BYTE * bmp, int rowCount, int rowNum, int resX, int resY, int iterCount);