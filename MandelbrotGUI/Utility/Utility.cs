using MandelbrotGUI.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MandelbrotGUI.Utility
{
    static public class Utility
    {
        // Need to change to /release path
        // and turn on optimization in cpp and masm dlls
        private const string cppDllPath = @"C:\Users\kgazd\source\repos\MandelbrotSet\x64\Debug\MandelbrotCpp.dll";
        private const string masmDllPath = @"C:\Users\kgazd\source\repos\MandelbrotSet\x64\Debug\MandelbrotMASM.dll";

        [DllImport(cppDllPath)]
        private static extern void generateMandelCpp(
            byte[] bmp, int rowCount, int rowNum, int resX, int resY, int alignment, int iterCount);

        [DllImport(masmDllPath)]
        private static extern void generateMandelMASM(
            byte[] bmp, int rowCount, int rowNum, int resX,
            int resY, int alignment, int iterCount);

        private delegate void GenerateMandelDelegate(
                byte[] bmp, int rowCount, int rowNum, int resX, int resY, int alignment, int iterCount);
        static public Bitmap initMandel(MandelSettings settings)
        {
            // Setting function to generate Mandelbrot set
            GenerateMandelDelegate generateMandel;
            switch(settings.function)
            {
                default: 
                case DLLFunction.MASM:
                    generateMandel = generateMandelMASM; break;
                case DLLFunction.Cpp:
                    generateMandel = generateMandelCpp; break;
            }

            // Bitmap initialization
            Bitmap bitmap = new(settings.resX, settings.resY, PixelFormat.Format24bppRgb);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, settings.resX, settings.resY),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr bitmapPtr = bitmapData.Scan0;
            int bytesPerRow = Math.Abs(bitmapData.Stride);
            int bmpBytesCount = bytesPerRow * bitmap.Height;
            byte[] bitmapBytes = new byte[bmpBytesCount];

            int alignment = bytesPerRow - settings.resX*3;

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

            byte[][] bitmapRows = new byte[settings.threadCount][];
            for(int i = 0; i < settings.threadCount; i++)
            {
                bitmapRows[i] = new byte[rowsPerThread[i] * bytesPerRow];
                Array.Copy(bitmapBytes, rowOffset[i] * bytesPerRow,
                    bitmapRows[i], 0, rowsPerThread[i] * bytesPerRow);
            }

            // Threads initialization
            Thread[] threads = new Thread[settings.threadCount];

            for (int i = 0; i < settings.threadCount; i++)
            {
                int localIter = i; // Necessary because lambda captures reference, not value

                threads[i] = new Thread(() => generateMandel(bitmapRows[localIter], rowsPerThread[localIter],
                    rowOffset[localIter], settings.resX, settings.resY, alignment, settings.iterationCount));
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (Thread thread in threads)
            {
                thread.Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds} ms");

            for (int i = 0; i < settings.threadCount; i++)
            {
                Array.Copy(bitmapRows[i], 0, bitmapBytes,
                    rowOffset[i] * bytesPerRow, rowsPerThread[i] * bytesPerRow);
            }

            Marshal.Copy(bitmapBytes, 0, bitmapPtr, bmpBytesCount);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
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
        public DLLFunction function { get; init; }

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
