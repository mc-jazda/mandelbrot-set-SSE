using MandelbrotGUI.Functions;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MandelbrotGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupSettings_Enter(object sender, EventArgs e)
        {

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            DLLFunction function;
            int resX, resY, iterationCount, threadCount;

            // Fetching info on which function to use
            if (radioBtnMASM.Checked) { function = DLLFunction.MASM; }
            else if (radioBtnCpp.Checked) { function = DLLFunction.Cpp; }
            else { MessageBox.Show("Nie wybrano funkcji generuj¹cej!"); return; }

            // Fetching generational settings
            resX = (int)settingResX.Value;
            resY = (int)settingResY.Value;
            iterationCount = (int)settingIterationCount.Value;
            threadCount = (int)settingThreadCount.Value;
            if (resY % threadCount != 0)
            {
                MessageBox.Show("Wysokoœæ bitmapy" +
                " musi byæ podzielna przez liczbê w¹tków"); return;
            }

            MandelSettings settings = new MandelSettings(resX, resY, iterationCount, threadCount, function);


            //
            // Bitmap creation will be moved to other function, now is present only for testing
            // 

            Bitmap bitmap = new(resX, resY, PixelFormat.Format24bppRgb);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, resX, resY),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr bitmapPtr = bitmapData.Scan0;

            int bmpBytesCount = Math.Abs(bitmapData.Stride) * bitmap.Height;
            byte[] bitmapBytes = new byte[bmpBytesCount];

            Marshal.Copy(bitmapPtr, bitmapBytes, 0, bmpBytesCount);

            Utility.testBitmapProcessing(bitmapBytes, resX, resY);

            Marshal.Copy(bitmapBytes, 0, bitmapPtr, bmpBytesCount);

            bitmap.UnlockBits(bitmapData);
            pictureBoxBmp.Image = bitmap;

            Utility.initMandel(settings);
        }
    }
}