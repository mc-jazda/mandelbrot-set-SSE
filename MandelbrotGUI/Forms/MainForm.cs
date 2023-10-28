using MandelbrotGUI.Utility;
using System.Drawing;

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

        private void buttonConfirm_Click(object sender, EventArgs e)
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

            Bitmap bitmap = Utility.Utility.initMandel(settings);
            pictureBoxBmp.Image = bitmap;
        }
    }
}