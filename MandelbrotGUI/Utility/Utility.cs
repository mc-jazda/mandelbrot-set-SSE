using MandelbrotGUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MandelbrotGUI.Utility
{
    static public class Utility
    {
        private const string cppDllPath = @"C:\Users\kgazd\source\repos\MandelbrotSet\x64\Debug\MandelbrotCpp.dll";
        private const string masmDllPath = @"C:\Users\kgazd\source\repos\MandelbrotSet\x64\Debug\MandelbrotMASM.dll";

        [DllImport(cppDllPath)]
        private static extern int generateMandelCpp(
            byte[] bmp, int rowCount, int rowNum, int resX, int resY, int iterCount);

        [DllImport(masmDllPath)]
        private static extern int generateMandelMASM(
            byte[] bmp, int rowCount, int rowNum, int resX, int resY, int iterCount);

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

            // Determinig number of lines for every thread
            int baseLinesPerThread = (int)(settings.resY / settings.threadCount);
            int remainingLines = settings.resY % settings.threadCount;
            int[] rowsPerThread = new int[settings.threadCount];
            Array.Fill(rowsPerThread, baseLinesPerThread);
            for (int i = 0; i < remainingLines; i++)
            {
                rowsPerThread[i]++;
            }

            // Calculating row offset for every thread
            int[] rowOffset = new int[settings.threadCount];
            rowOffset[0] = 0;
            for(int i  = 1; i < settings.threadCount; i++)
            {
                rowOffset[i] = rowOffset[i-1] + rowsPerThread[i-1];
            }

            // Threads initialization
            Thread[] threads = new Thread[settings.threadCount];

            for (int i = 0; i < settings.threadCount; i++)
            {
                int localThreadNum = i; // Necessary so that lambda captures by value, not by reference

                byte[] bitmapRows = new byte[rowsPerThread[i] * bytesPerRow];
                Array.Copy(bitmapBytes, rowOffset[i] * bytesPerRow, 
                    bitmapRows, 0, rowsPerThread[i] * bytesPerRow);

                threads[i] = new Thread(() => generateMandelMASM(bitmapRows, rowsPerThread[localThreadNum],
                    rowOffset[localThreadNum], settings.resX, settings.resY, settings.iterationCount));

                Array.Copy(bitmapRows, 0, bitmapBytes,
                    rowOffset[i] * bytesPerRow, rowsPerThread[i] * bytesPerRow);
            }
            foreach (Thread thread in threads)
            {
                thread.Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Marshal.Copy(bitmapBytes, 0, bitmapPtr, bmpBytesCount);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        //static private void initThread(byte[] bitmapBytes, int rowsPerThread, 
        //    int rowOffset, int bytesPerRow, MandelSettings settings)
        //{
        //    byte[] bitmapRows = new byte[rowsPerThread*bytesPerRow];
        //    Array.Copy(bitmapBytes, rowOffset*bytesPerRow, bitmapRows, 0, rowsPerThread*bytesPerRow);

        //    generateMandelMASM(bitmapRows, rowsPerThread, rowOffset, 
        //        settings.resX, settings.resY, settings.iterationCount);

        //    Array.Copy(bitmapRows, 0, bitmapBytes, rowOffset*bytesPerRow, rowsPerThread*bytesPerRow);

        //    //for (int j = 0; j < linesPerThread; j++)
        //    //{
        //    //    int rowOffset = (threadNum * linesPerThread + j) * bytesPerRow;
        //    //    byte[] bitmapRow = new byte[bytesPerRow];

        //    //    Array.Copy(bitmapBytes, rowOffset, bitmapRow, 0, bytesPerRow);

        //    //    generateMandelMASM(bitmapRow, resX, resY,
        //    //        threadNum * linesPerThread + j, iterationCount);

        //    //    Array.Copy(bitmapRow, 0, bitmapBytes, rowOffset, bytesPerRow);
        //    //}
        //}

        // Method solely for testing, will delete later
        static private void testThreads(int id, int count)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{id}_{count}: {i}");
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
