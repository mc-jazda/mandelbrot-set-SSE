#include "pch.h"
#include "MandelCpp.h"
#include "cmath"

void generateMandelCpp(BYTE* bmp, int rowCount, int rowNum, int resX, int resY, int alignment, int iterCount)
{
    // Defining part of complex plane to generate
    const double xStart = -2.2;
    const double xEnd = 0.8;
    const double yStart = -1.0;
    const double yEnd = 1.0;

    // Calculating scale factors
    const double xScale = abs(xEnd - xStart) / resX;
    const double yScale = abs(yEnd - yStart) / resY;

    for (int y = 0; y < rowCount; y++)
    {   
        // Z(n) = Z(n-1)^2 + C
        const double cIm = (rowNum + y) * yScale + yStart;  // Im(C) - constant per row

        for (int x = 0; x < resX; x++)
        {
            const double cRe = x * xScale + xStart;
            double zRe = cRe, zIm = cIm;    // Re(Z1) = Re(C), Im(Z1) = Im(C)

            bool isInSet = true;    // Checks if current C is part of Mandelbrot Set

            // Calculates next values of Z(n) 
            // And cheks if |Z(n)| < 2, then C is part of Mandlebrot Set
            for (int i = 0; i < iterCount; i++)
            {
                double z2Re = zRe * zRe - zIm * zIm + cRe;
                double z2Im = 2 * zRe * zIm + cIm;

                if (z2Re * z2Re + z2Im * z2Im >= 4)
                {
                    isInSet = false;
                    break;
                }

                zRe = z2Re;
                zIm = z2Im;
            }

            // Sets BGR chanels of bitmap to either black or white
            BYTE color = isInSet ? 255 : 0;

            *bmp = color; bmp++;
            *bmp = color; bmp++;
            *bmp = color; bmp++;
        }

        bmp += alignment;
    }
}