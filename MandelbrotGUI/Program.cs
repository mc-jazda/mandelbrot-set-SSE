using System;
using System.Runtime.InteropServices;
using MandelbrotGUI.Functions;

namespace MandelbrotGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}