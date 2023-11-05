#include "pch.h"
#include "MandelCpp.h"

void generateMandelCpp(BYTE* bmp, int rowCount, int rowNum, int resX, int resY, int iterCount)
{
	int alignment = (resX*3) % 4;

	for (int y = 0; y < rowCount; y++)
	{
		for (int x = 0; x < resX*3; x++)
		{
			*bmp = 120;
			bmp++;
		}
		bmp += alignment;
	}
}