#include "pch.h"
#include "MandelCpp.h"

void generateMandelCpp(BYTE* bmp, int rowCount, int rowNum, int resX, int resY, int iterCount)
{
    int alignment = (resX * 3) % 4;

    for (int y = 0; y < rowCount; y++)
    {
        for (int x = 0; x < resX; x++)
        {
            // Calculate the complex coordinates for the current pixel
            double real = 3.5 * (static_cast<double>(x) / resX) - 2.5;
            double imag = 2.0 * (static_cast<double>(rowNum + y) / resY) - 1.0;

            double zReal = real;
            double zImag = imag;

            int n = 0;
            while (n < iterCount)
            {
                double zReal2 = zReal * zReal;
                double zImag2 = zImag * zImag;

                if (zReal2 + zImag2 > 4.0)
                    break;

                zImag = 2 * zReal * zImag + imag;
                zReal = zReal2 - zImag2 + real;

                n++;
            }

            // Set the pixel color to black if inside the set; otherwise, set it to white
            BYTE color = (n == iterCount) ? 255 : 0;

            *bmp = color;
            bmp++;
            *bmp = color;
            bmp++;
            *bmp = color;
            bmp++;
        }

        // Padding to ensure 4-byte alignment
        for (int p = 0; p < alignment; p++)
        {
            *bmp = 0;
            bmp++;
        }
    }
}