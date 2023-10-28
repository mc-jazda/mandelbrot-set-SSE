using System;
using System.Runtime.InteropServices;
using MandelbrotGUI.Utility;

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