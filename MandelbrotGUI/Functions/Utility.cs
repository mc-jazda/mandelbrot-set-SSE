using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MandelbrotGUI.Functions
{
    static public class Utility
    {
        static public void initMandel(MandelSettings settings)
        {
            int linesPerThread = (int)(settings.resY / settings.threadCount);
            for (int  i = 0; i < settings.threadCount; i++)
            {
                Thread thread = new Thread(() =>
                {
                    for (int j = 0; j < linesPerThread; j++)
                    {
                        testThreads(System.Environment.CurrentManagedThreadId, j);
                    }
                });

                thread.Start();
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
                    bitmap[i + 1] = 0;
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
