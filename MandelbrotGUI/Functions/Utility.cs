using MandelbrotGUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MandelbrotGUI.Functions
{
    static public class Utility
    {
        private const string cppDllPath = @"C:\Users\kgazd\source\repos\MandelbrotSet\x64\Debug\MandelbrotCpp.dll";
        private const string masmDllPath = @"C:\Users\kgazd\source\repos\MandelbrotSet\x64\Debug\MandelbrotMASM.dll";

        [DllImport(cppDllPath)]
        private static extern int generateMandelCpp(byte[] bmp, int resX, int resY, int rowNum, int iterCount);
        [DllImport(masmDllPath)]
        private static extern int generateMandelMASM(byte[] bmp, int resX, int resY, int rowNum, int iterCount);

        static public Bitmap initMandel(MandelSettings settings)
        {
            // Bitmap initialization
            Bitmap bitmap = new(settings.resX, settings.resY, PixelFormat.Format24bppRgb);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, settings.resX, settings.resY),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr bitmapPtr = bitmapData.Scan0;
            int bytesPerRow = Math.Abs(bitmapData.Stride);
            int bmpBytesCount = bytesPerRow * bitmap.Height;
            byte[] bitmapBytes = new byte[bmpBytesCount];

            Marshal.Copy(bitmapPtr, bitmapBytes, 0, bmpBytesCount);

            // ...
            //testBitmapProcessing(bitmapBytes, settings.resX, settings.resY);

            
            int linesPerThread = (int)(settings.resY / settings.threadCount);
            Thread[] threads = new Thread[settings.threadCount];

            for (int  i = 0; i < settings.threadCount; i++)
            {
                int threadNum = i; // Local value of i - necessary because lambda expresions captures variable, not value

                threads[i] = new Thread(() => initThread(bitmapBytes, linesPerThread,
                    threadNum, bytesPerRow, settings.resX, settings.resY, settings.iterationCount));
            }
            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            Marshal.Copy(bitmapBytes, 0, bitmapPtr, bmpBytesCount);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        static private void initThread(byte[] bitmapBytes, int linesPerThread, int threadNum, int bytesPerRow,
            int resX, int resY, int iterationCount)
        {
            for (int j = 0; j < linesPerThread; j++)
            {
                int rowOffset = (threadNum * linesPerThread + j) * bytesPerRow;
                byte[] bitmapRow = new byte[bytesPerRow];
                //Console.WriteLine($"i: {threadNum}, j: {j}");
                Array.Copy(bitmapBytes, rowOffset, bitmapRow, 0, bytesPerRow);

                generateMandelMASM(bitmapRow, resX, resY,
                    threadNum * linesPerThread + j, iterationCount);

                Array.Copy(bitmapRow, 0, bitmapBytes, rowOffset, bytesPerRow);
            }
        }
        // Methods solely for testing, will delete later
        static private void testThreads(int id, int count)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{id}_{count}: {i}");
            }
        }
        static public void testBitmapProcessing(byte[] bitmap, int resX, int resY)
        {
            for(int i = 0; i < bitmap.Length; i++) 
            { 
                if (i % 3 == 0)
                {
                    //Blue
                    bitmap[i] = 255;
                    //Green
                    bitmap[i + 1] = 255;
                    //Red
                    bitmap[i + 2] = 0;
                }
            }
        }
    }

    

    public enum DLLFunction
    {
        MASM,
        Cpp
    }
    public readonly struct MandelSettings
    {
        public int resX { get; init; }
        public int resY { get; init; }
        public int iterationCount { get; init; }
        public int threadCount { get; init; }
        DLLFunction function { get; init; }

        public MandelSettings(int _resX, int _resY, int _iterationCount, 
            int _threadCount, DLLFunction _function)
        {
            resX = _resX;
            resY = _resY;
            iterationCount = _iterationCount;
            threadCount = _threadCount;
            function = _function;
        }
    }
}
