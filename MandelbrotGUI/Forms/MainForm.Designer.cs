using System.Windows.Forms;

namespace MandelbrotGUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTitle = new Label();
            radioBtnMASM = new RadioButton();
            radioBtnCpp = new RadioButton();
            groupDll = new GroupBox();
            settingResX = new NumericUpDown();
            groupSettings = new GroupBox();
            labelThreadNum = new Label();
            settingThreadCount = new NumericUpDown();
            settingIterationCount = new NumericUpDown();
            labelIterNum = new Label();
            settingResY = new NumericUpDown();
            labelResX = new Label();
            labelResY = new Label();
            buttonGenerate = new Button();
            pictureBoxBmp = new PictureBox();
            groupDll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)settingResX).BeginInit();
            groupSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)settingThreadCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingIterationCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingResY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBmp).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.Location = new Point(146, 32);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(706, 54);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Generowanie fraktala Mandelbrota";
            labelTitle.Click += label1_Click;
            // 
            // radioBtnMASM
            // 
            radioBtnMASM.AutoSize = true;
            radioBtnMASM.Location = new Point(30, 26);
            radioBtnMASM.Name = "radioBtnMASM";
            radioBtnMASM.Size = new Size(74, 24);
            radioBtnMASM.TabIndex = 1;
            radioBtnMASM.TabStop = true;
            radioBtnMASM.Text = "MASM";
            radioBtnMASM.UseVisualStyleBackColor = true;
            // 
            // radioBtnCpp
            // 
            radioBtnCpp.AutoSize = true;
            radioBtnCpp.Location = new Point(30, 56);
            radioBtnCpp.Name = "radioBtnCpp";
            radioBtnCpp.Size = new Size(59, 24);
            radioBtnCpp.TabIndex = 2;
            radioBtnCpp.TabStop = true;
            radioBtnCpp.Text = "C++";
            radioBtnCpp.UseVisualStyleBackColor = true;
            // 
            // groupDll
            // 
            groupDll.Controls.Add(radioBtnMASM);
            groupDll.Controls.Add(radioBtnCpp);
            groupDll.Location = new Point(32, 89);
            groupDll.Name = "groupDll";
            groupDll.Size = new Size(147, 95);
            groupDll.TabIndex = 3;
            groupDll.TabStop = false;
            groupDll.Text = "Wybierz funkcję:";
            // 
            // settingResX
            // 
            settingResX.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            settingResX.Location = new Point(189, 33);
            settingResX.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            settingResX.Minimum = new decimal(new int[] { 300, 0, 0, 0 });
            settingResX.Name = "settingResX";
            settingResX.Size = new Size(90, 27);
            settingResX.TabIndex = 4;
            settingResX.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // groupSettings
            // 
            groupSettings.Controls.Add(labelThreadNum);
            groupSettings.Controls.Add(settingThreadCount);
            groupSettings.Controls.Add(settingIterationCount);
            groupSettings.Controls.Add(labelIterNum);
            groupSettings.Controls.Add(settingResY);
            groupSettings.Controls.Add(settingResX);
            groupSettings.Controls.Add(labelResX);
            groupSettings.Controls.Add(labelResY);
            groupSettings.Location = new Point(32, 227);
            groupSettings.Name = "groupSettings";
            groupSettings.Size = new Size(306, 182);
            groupSettings.TabIndex = 5;
            groupSettings.TabStop = false;
            groupSettings.Text = "Dostosuj ustawienia:";
            groupSettings.Enter += groupSettings_Enter;
            // 
            // labelThreadNum
            // 
            labelThreadNum.AutoSize = true;
            labelThreadNum.Location = new Point(29, 134);
            labelThreadNum.Name = "labelThreadNum";
            labelThreadNum.Size = new Size(106, 20);
            labelThreadNum.TabIndex = 11;
            labelThreadNum.Text = "Liczba wątków";
            // 
            // settingThreadCount
            // 
            settingThreadCount.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            settingThreadCount.Location = new Point(189, 132);
            settingThreadCount.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            settingThreadCount.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            settingThreadCount.Name = "settingThreadCount";
            settingThreadCount.Size = new Size(90, 27);
            settingThreadCount.TabIndex = 9;
            settingThreadCount.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // settingIterationCount
            // 
            settingIterationCount.Location = new Point(189, 99);
            settingIterationCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            settingIterationCount.Name = "settingIterationCount";
            settingIterationCount.Size = new Size(90, 27);
            settingIterationCount.TabIndex = 8;
            settingIterationCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelIterNum
            // 
            labelIterNum.AutoSize = true;
            labelIterNum.Location = new Point(29, 101);
            labelIterNum.Name = "labelIterNum";
            labelIterNum.Size = new Size(100, 20);
            labelIterNum.TabIndex = 10;
            labelIterNum.Text = "Liczba iteracji";
            // 
            // settingResY
            // 
            settingResY.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            settingResY.Location = new Point(189, 66);
            settingResY.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            settingResY.Minimum = new decimal(new int[] { 300, 0, 0, 0 });
            settingResY.Name = "settingResY";
            settingResY.Size = new Size(90, 27);
            settingResY.TabIndex = 6;
            settingResY.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // labelResX
            // 
            labelResX.AutoSize = true;
            labelResX.Location = new Point(29, 35);
            labelResX.Name = "labelResX";
            labelResX.Size = new Size(134, 20);
            labelResX.TabIndex = 5;
            labelResX.Text = "Szerokość bitmapy";
            labelResX.Click += label2_Click;
            // 
            // labelResY
            // 
            labelResY.AutoSize = true;
            labelResY.Location = new Point(29, 68);
            labelResY.Name = "labelResY";
            labelResY.Size = new Size(133, 20);
            labelResY.TabIndex = 7;
            labelResY.Text = "Wysokość bitmapy";
            // 
            // buttonGenerate
            // 
            buttonGenerate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonGenerate.Location = new Point(32, 488);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(136, 53);
            buttonGenerate.TabIndex = 6;
            buttonGenerate.Text = "Generuj";
            buttonGenerate.UseVisualStyleBackColor = true;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // pictureBoxBmp
            // 
            pictureBoxBmp.Location = new Point(418, 115);
            pictureBoxBmp.Name = "pictureBoxBmp";
            pictureBoxBmp.Size = new Size(574, 451);
            pictureBoxBmp.TabIndex = 7;
            pictureBoxBmp.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 603);
            Controls.Add(pictureBoxBmp);
            Controls.Add(buttonGenerate);
            Controls.Add(groupSettings);
            Controls.Add(groupDll);
            Controls.Add(labelTitle);
            Name = "MainForm";
            Text = "Form1";
            groupDll.ResumeLayout(false);
            groupDll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)settingResX).EndInit();
            groupSettings.ResumeLayout(false);
            groupSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)settingThreadCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingIterationCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingResY).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBmp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private RadioButton radioBtnMASM;
        private RadioButton radioBtnCpp;
        private GroupBox groupDll;
        private NumericUpDown settingResX;
        private GroupBox groupSettings;
        private Label labelResX;
        private Label labelResY;
        private NumericUpDown settingResY;
        private Label labelThreadNum;
        private Label labelIterNum;
        private NumericUpDown settingThreadCount;
        private NumericUpDown settingIterationCount;
        private Button buttonGenerate;
        private PictureBox pictureBoxBmp;
    }
}