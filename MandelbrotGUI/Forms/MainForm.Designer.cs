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
            buttonConfirm = new Button();
            pictureBoxBmp = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            mainLayout = new TableLayoutPanel();
            groupDll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)settingResX).BeginInit();
            groupSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)settingThreadCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingIterationCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingResY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBmp).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            mainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Font = new Font("Copperplate Gothic Light", 30F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.Silver;
            labelTitle.ImageAlign = ContentAlignment.BottomCenter;
            labelTitle.Location = new Point(400, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(979, 67);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Generowanie zbioru Mandelbrota";
            labelTitle.Click += label1_Click;
            // 
            // radioBtnMASM
            // 
            radioBtnMASM.AutoSize = true;
            radioBtnMASM.Location = new Point(30, 26);
            radioBtnMASM.Name = "radioBtnMASM";
            radioBtnMASM.Size = new Size(82, 25);
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
            radioBtnCpp.Size = new Size(64, 25);
            radioBtnCpp.TabIndex = 2;
            radioBtnCpp.TabStop = true;
            radioBtnCpp.Text = "C++";
            radioBtnCpp.UseVisualStyleBackColor = true;
            // 
            // groupDll
            // 
            groupDll.Controls.Add(radioBtnMASM);
            groupDll.Controls.Add(radioBtnCpp);
            groupDll.Font = new Font("Franklin Gothic Book", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            groupDll.ForeColor = Color.FromArgb(0, 0, 64);
            groupDll.Location = new Point(3, 249);
            groupDll.Name = "groupDll";
            groupDll.Size = new Size(192, 99);
            groupDll.TabIndex = 3;
            groupDll.TabStop = false;
            groupDll.Text = "Wybierz funkcję:";
            // 
            // settingResX
            // 
            settingResX.Font = new Font("Franklin Gothic Book", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            settingResX.Increment = new decimal(new int[] { 8, 0, 0, 0 });
            settingResX.Location = new Point(189, 33);
            settingResX.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            settingResX.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            settingResX.Name = "settingResX";
            settingResX.Size = new Size(90, 27);
            settingResX.TabIndex = 4;
            settingResX.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            settingResX.ValueChanged += settingResX_ValueChanged;
            // 
            // groupSettings
            // 
            groupSettings.BackColor = Color.SlateGray;
            groupSettings.Controls.Add(labelThreadNum);
            groupSettings.Controls.Add(settingThreadCount);
            groupSettings.Controls.Add(settingIterationCount);
            groupSettings.Controls.Add(labelIterNum);
            groupSettings.Controls.Add(settingResY);
            groupSettings.Controls.Add(settingResX);
            groupSettings.Controls.Add(labelResX);
            groupSettings.Controls.Add(labelResY);
            groupSettings.Font = new Font("Franklin Gothic Book", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            groupSettings.ForeColor = Color.FromArgb(0, 0, 64);
            groupSettings.Location = new Point(3, 3);
            groupSettings.Name = "groupSettings";
            groupSettings.Size = new Size(305, 179);
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
            labelThreadNum.Size = new Size(126, 21);
            labelThreadNum.TabIndex = 11;
            labelThreadNum.Text = "Liczba wątków";
            // 
            // settingThreadCount
            // 
            settingThreadCount.Font = new Font("Franklin Gothic Book", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            settingThreadCount.Location = new Point(189, 132);
            settingThreadCount.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            settingThreadCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            settingThreadCount.Name = "settingThreadCount";
            settingThreadCount.Size = new Size(90, 27);
            settingThreadCount.TabIndex = 9;
            settingThreadCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // settingIterationCount
            // 
            settingIterationCount.Font = new Font("Franklin Gothic Book", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            settingIterationCount.Location = new Point(189, 99);
            settingIterationCount.Maximum = new decimal(new int[] { 30000, 0, 0, 0 });
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
            labelIterNum.Size = new Size(123, 21);
            labelIterNum.TabIndex = 10;
            labelIterNum.Text = "Liczba iteracji";
            // 
            // settingResY
            // 
            settingResY.Font = new Font("Franklin Gothic Book", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            settingResY.Location = new Point(189, 66);
            settingResY.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            settingResY.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            settingResY.Name = "settingResY";
            settingResY.Size = new Size(90, 27);
            settingResY.TabIndex = 6;
            settingResY.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // labelResX
            // 
            labelResX.AutoSize = true;
            labelResX.Location = new Point(29, 35);
            labelResX.Name = "labelResX";
            labelResX.Size = new Size(163, 21);
            labelResX.TabIndex = 5;
            labelResX.Text = "Szerokość bitmapy";
            labelResX.Click += label2_Click;
            // 
            // labelResY
            // 
            labelResY.AutoSize = true;
            labelResY.Location = new Point(29, 68);
            labelResY.Name = "labelResY";
            labelResY.Size = new Size(159, 21);
            labelResY.TabIndex = 7;
            labelResY.Text = "Wysokość bitmapy";
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = Color.FromArgb(0, 0, 64);
            buttonConfirm.Dock = DockStyle.Top;
            buttonConfirm.Font = new Font("Copperplate Gothic Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonConfirm.ForeColor = Color.Silver;
            buttonConfirm.Location = new Point(3, 477);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(385, 62);
            buttonConfirm.TabIndex = 6;
            buttonConfirm.Text = "GENERUJ";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // pictureBoxBmp
            // 
            pictureBoxBmp.BackColor = Color.Black;
            pictureBoxBmp.Dock = DockStyle.Fill;
            pictureBoxBmp.Location = new Point(400, 70);
            pictureBoxBmp.Name = "pictureBoxBmp";
            pictureBoxBmp.Size = new Size(979, 633);
            pictureBoxBmp.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBmp.TabIndex = 7;
            pictureBoxBmp.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.SlateGray;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupDll, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonConfirm, 0, 2);
            tableLayoutPanel1.Controls.Add(groupSettings, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 70);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.90381F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 48.09619F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 158F));
            tableLayoutPanel1.Size = new Size(391, 633);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // mainLayout
            // 
            mainLayout.BackColor = Color.FromArgb(0, 0, 64);
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.7716312F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.22837F));
            mainLayout.Controls.Add(tableLayoutPanel1, 0, 1);
            mainLayout.Controls.Add(pictureBoxBmp, 1, 1);
            mainLayout.Controls.Add(labelTitle, 1, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 9.490085F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 90.50992F));
            mainLayout.Size = new Size(1382, 706);
            mainLayout.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 706);
            Controls.Add(mainLayout);
            Name = "MainForm";
            Text = "Mandelbrot";
            groupDll.ResumeLayout(false);
            groupDll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)settingResX).EndInit();
            groupSettings.ResumeLayout(false);
            groupSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)settingThreadCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingIterationCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingResY).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBmp).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            ResumeLayout(false);
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
        private Button buttonConfirm;
        private PictureBox pictureBoxBmp;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel mainLayout;
    }
}