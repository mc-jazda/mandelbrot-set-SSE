using System.Runtime.InteropServices;

namespace MandelbrotGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        private const string cppDllPath = @"C:\Users\kgazd\source\repos\MandelbrotSet\x64\Debug\MandelbrotCpp.dll";
        private const string masmDllPath = @"C:\Users\kgazd\source\repos\MandelbrotSet\x64\Debug\MandelbrotMASM.dll";

        [DllImport(cppDllPath)]
        private static extern int HelloCpp();
        [DllImport(masmDllPath)]
        private static extern int HelloMASM();

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            int num = HelloMASM();
            MessageBox.Show(num.ToString());

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}