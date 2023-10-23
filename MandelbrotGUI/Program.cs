using System;
using System.Runtime.InteropServices;
using MandelbrotGUI.Functions;

namespace MandelbrotGUI
{
    internal static class Program
    {
        private const string cppDllPath = @"C:\Users\kgazd\source\repos\MandelbrotSet\x64\Debug\MandelbrotCpp.dll";
        private const string masmDllPath = @"C:\Users\kgazd\source\repos\MandelbrotSet\x64\Debug\MandelbrotMASM.dll";

        [DllImport(cppDllPath)]
        private static extern int generateMandelCpp(int resX, int resY, int rowNum, int iterCount, byte[] bmp);
        [DllImport(masmDllPath)]
        private static extern int generateMandelMASM(int resX, int resY, int rowNum, int iterCount, byte[] bmp);

        [STAThread]
        static void Main()
        {
            //Utility.initMandel(4, 100);

            //byte[] bytes = new byte[2];
            //int num = generateMandelMASM(1, 2, 3, 5, bytes);
            //MessageBox.Show(num.ToString());

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}