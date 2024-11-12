﻿namespace ImageProcessing
{
    partial class Form1
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
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            trackBar3 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar1 = new TrackBar();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            dIPToolStripMenuItem = new ToolStripMenuItem();
            pixelCopyToolStripMenuItem = new ToolStripMenuItem();
            grayscalingToolStripMenuItem = new ToolStripMenuItem();
            inversionToolStripMenuItem = new ToolStripMenuItem();
            mirrorHorizontalToolStripMenuItem = new ToolStripMenuItem();
            mirrorVerticalToolStripMenuItem = new ToolStripMenuItem();
            luminenceGrayscalingToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            convolutionalMatrixToolStripMenuItem = new ToolStripMenuItem();
            shrinkToolStripMenuItem = new ToolStripMenuItem();
            blurToolStripMenuItem = new ToolStripMenuItem();
            sharpenToolStripMenuItem = new ToolStripMenuItem();
            edgeEnchanceToolStripMenuItem = new ToolStripMenuItem();
            edgeDetectToolStripMenuItem = new ToolStripMenuItem();
            embossToolStripMenuItem = new ToolStripMenuItem();
            gaussianBlurToolStripMenuItem = new ToolStripMenuItem();
            meanRemovalToolStripMenuItem = new ToolStripMenuItem();
            embossLaToolStripMenuItem = new ToolStripMenuItem();
            strongerBlurToolStripMenuItem = new ToolStripMenuItem();
            tabPage2 = new TabPage();
            comboBox2 = new ComboBox();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            pictureBox6 = new PictureBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            openFileDialog2 = new OpenFileDialog();
            openFileDialog3 = new OpenFileDialog();
            colorDialog1 = new ColorDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileOk += saveFileDialog1_FileOk;
            // 
            // tabControl1
            // 
            tabControl1.AccessibleName = "";
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(992, 563);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(trackBar3);
            tabPage1.Controls.Add(trackBar2);
            tabPage1.Controls.Add(trackBar1);
            tabPage1.Controls.Add(pictureBox2);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Controls.Add(menuStrip1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(984, 530);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Part 1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(503, 61);
            trackBar3.Maximum = 50;
            trackBar3.Minimum = -50;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(202, 56);
            trackBar3.TabIndex = 8;
            trackBar3.TickFrequency = 5;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(276, 61);
            trackBar2.Maximum = 50;
            trackBar2.Minimum = -50;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(202, 56);
            trackBar2.TabIndex = 7;
            trackBar2.TickFrequency = 5;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(47, 61);
            trackBar1.Maximum = 50;
            trackBar1.Minimum = -50;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(202, 56);
            trackBar1.TabIndex = 6;
            trackBar1.TickFrequency = 5;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(545, 135);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(397, 378);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(47, 135);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(397, 378);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, dIPToolStripMenuItem, convolutionalMatrixToolStripMenuItem });
            menuStrip1.Location = new Point(3, 3);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(978, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(128, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(128, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // dIPToolStripMenuItem
            // 
            dIPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pixelCopyToolStripMenuItem, grayscalingToolStripMenuItem, inversionToolStripMenuItem, mirrorHorizontalToolStripMenuItem, mirrorVerticalToolStripMenuItem, luminenceGrayscalingToolStripMenuItem, histogramToolStripMenuItem, sepiaToolStripMenuItem });
            dIPToolStripMenuItem.Name = "dIPToolStripMenuItem";
            dIPToolStripMenuItem.Size = new Size(46, 24);
            dIPToolStripMenuItem.Text = "DIP";
            // 
            // pixelCopyToolStripMenuItem
            // 
            pixelCopyToolStripMenuItem.Name = "pixelCopyToolStripMenuItem";
            pixelCopyToolStripMenuItem.Size = new Size(243, 26);
            pixelCopyToolStripMenuItem.Text = "Pixel Copy";
            pixelCopyToolStripMenuItem.Click += pixelCopyToolStripMenuItem_Click;
            // 
            // grayscalingToolStripMenuItem
            // 
            grayscalingToolStripMenuItem.Name = "grayscalingToolStripMenuItem";
            grayscalingToolStripMenuItem.Size = new Size(243, 26);
            grayscalingToolStripMenuItem.Text = "Grayscaling";
            grayscalingToolStripMenuItem.Click += grayscalingToolStripMenuItem_Click;
            // 
            // inversionToolStripMenuItem
            // 
            inversionToolStripMenuItem.Name = "inversionToolStripMenuItem";
            inversionToolStripMenuItem.Size = new Size(243, 26);
            inversionToolStripMenuItem.Text = "Inversion";
            inversionToolStripMenuItem.Click += inversionToolStripMenuItem_Click;
            // 
            // mirrorHorizontalToolStripMenuItem
            // 
            mirrorHorizontalToolStripMenuItem.Name = "mirrorHorizontalToolStripMenuItem";
            mirrorHorizontalToolStripMenuItem.Size = new Size(243, 26);
            mirrorHorizontalToolStripMenuItem.Text = "Mirror Horizontal";
            mirrorHorizontalToolStripMenuItem.Click += mirrorHorizontalToolStripMenuItem_Click;
            // 
            // mirrorVerticalToolStripMenuItem
            // 
            mirrorVerticalToolStripMenuItem.Name = "mirrorVerticalToolStripMenuItem";
            mirrorVerticalToolStripMenuItem.Size = new Size(243, 26);
            mirrorVerticalToolStripMenuItem.Text = "Mirror Vertical";
            mirrorVerticalToolStripMenuItem.Click += mirrorVerticalToolStripMenuItem_Click;
            // 
            // luminenceGrayscalingToolStripMenuItem
            // 
            luminenceGrayscalingToolStripMenuItem.Name = "luminenceGrayscalingToolStripMenuItem";
            luminenceGrayscalingToolStripMenuItem.Size = new Size(243, 26);
            luminenceGrayscalingToolStripMenuItem.Text = "Luminence Grayscaling";
            luminenceGrayscalingToolStripMenuItem.Click += luminenceGrayscalingToolStripMenuItem_Click;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(243, 26);
            histogramToolStripMenuItem.Text = "Histogram";
            histogramToolStripMenuItem.Click += histogramToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(243, 26);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            // 
            // convolutionalMatrixToolStripMenuItem
            // 
            convolutionalMatrixToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { shrinkToolStripMenuItem, blurToolStripMenuItem, sharpenToolStripMenuItem, edgeEnchanceToolStripMenuItem, edgeDetectToolStripMenuItem, embossToolStripMenuItem, gaussianBlurToolStripMenuItem, meanRemovalToolStripMenuItem, embossLaToolStripMenuItem, strongerBlurToolStripMenuItem });
            convolutionalMatrixToolStripMenuItem.Name = "convolutionalMatrixToolStripMenuItem";
            convolutionalMatrixToolStripMenuItem.Size = new Size(161, 24);
            convolutionalMatrixToolStripMenuItem.Text = "Convolutional Matrix";
            // 
            // shrinkToolStripMenuItem
            // 
            shrinkToolStripMenuItem.Name = "shrinkToolStripMenuItem";
            shrinkToolStripMenuItem.Size = new Size(224, 26);
            shrinkToolStripMenuItem.Text = "Shrink";
            shrinkToolStripMenuItem.Click += shrinkToolStripMenuItem_Click;
            // 
            // blurToolStripMenuItem
            // 
            blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            blurToolStripMenuItem.Size = new Size(224, 26);
            blurToolStripMenuItem.Text = "Blur";
            blurToolStripMenuItem.Click += blurToolStripMenuItem_Click;
            // 
            // sharpenToolStripMenuItem
            // 
            sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            sharpenToolStripMenuItem.Size = new Size(224, 26);
            sharpenToolStripMenuItem.Text = "Sharpen";
            sharpenToolStripMenuItem.Click += sharpenToolStripMenuItem_Click;
            // 
            // edgeEnchanceToolStripMenuItem
            // 
            edgeEnchanceToolStripMenuItem.Name = "edgeEnchanceToolStripMenuItem";
            edgeEnchanceToolStripMenuItem.Size = new Size(224, 26);
            edgeEnchanceToolStripMenuItem.Text = "Edge Enhance";
            edgeEnchanceToolStripMenuItem.Click += edgeEnchanceToolStripMenuItem_Click;
            // 
            // edgeDetectToolStripMenuItem
            // 
            edgeDetectToolStripMenuItem.Name = "edgeDetectToolStripMenuItem";
            edgeDetectToolStripMenuItem.Size = new Size(224, 26);
            edgeDetectToolStripMenuItem.Text = "Edge Detect";
            edgeDetectToolStripMenuItem.Click += edgeDetectToolStripMenuItem_Click;
            // 
            // embossToolStripMenuItem
            // 
            embossToolStripMenuItem.Name = "embossToolStripMenuItem";
            embossToolStripMenuItem.Size = new Size(224, 26);
            embossToolStripMenuItem.Text = "Emboss";
            embossToolStripMenuItem.Click += embossToolStripMenuItem_Click;
            // 
            // gaussianBlurToolStripMenuItem
            // 
            gaussianBlurToolStripMenuItem.Name = "gaussianBlurToolStripMenuItem";
            gaussianBlurToolStripMenuItem.Size = new Size(224, 26);
            gaussianBlurToolStripMenuItem.Text = "Gaussian Blur";
            gaussianBlurToolStripMenuItem.Click += gaussianBlurToolStripMenuItem_Click;
            // 
            // meanRemovalToolStripMenuItem
            // 
            meanRemovalToolStripMenuItem.Name = "meanRemovalToolStripMenuItem";
            meanRemovalToolStripMenuItem.Size = new Size(224, 26);
            meanRemovalToolStripMenuItem.Text = "Mean Removal";
            meanRemovalToolStripMenuItem.Click += meanRemovalToolStripMenuItem_Click;
            // 
            // embossLaToolStripMenuItem
            // 
            embossLaToolStripMenuItem.Name = "embossLaToolStripMenuItem";
            embossLaToolStripMenuItem.Size = new Size(224, 26);
            embossLaToolStripMenuItem.Text = "Emboss Laplascian";
            embossLaToolStripMenuItem.Click += embossLaToolStripMenuItem_Click;
            // 
            // strongerBlurToolStripMenuItem
            // 
            strongerBlurToolStripMenuItem.Name = "strongerBlurToolStripMenuItem";
            strongerBlurToolStripMenuItem.Size = new Size(224, 26);
            strongerBlurToolStripMenuItem.Text = "Stronger Blur";
            strongerBlurToolStripMenuItem.Click += strongerBlurToolStripMenuItem_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(checkBox1);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(pictureBox6);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(pictureBox5);
            tabPage2.Controls.Add(pictureBox4);
            tabPage2.Controls.Add(pictureBox3);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(984, 530);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Part 2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(668, 409);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(226, 28);
            comboBox2.TabIndex = 11;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(26, 379);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(110, 24);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Use Camera";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(142, 375);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(217, 28);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // pictureBox6
            // 
            pictureBox6.Location = new Point(859, 372);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(35, 31);
            pictureBox6.TabIndex = 7;
            pictureBox6.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(668, 372);
            button4.Name = "button4";
            button4.Size = new Size(185, 31);
            button4.TabIndex = 6;
            button4.Text = "Select Color";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(668, 337);
            button3.Name = "button3";
            button3.Size = new Size(226, 29);
            button3.TabIndex = 5;
            button3.Text = "Subtract";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(405, 337);
            button2.Name = "button2";
            button2.Size = new Size(137, 29);
            button2.TabIndex = 4;
            button2.Text = "Load Image B";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(107, 337);
            button1.Name = "button1";
            button1.Size = new Size(130, 29);
            button1.TabIndex = 3;
            button1.Text = "Load Image A";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(636, 32);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(280, 280);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 2;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(334, 32);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(280, 280);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(37, 32);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(280, 280);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            openFileDialog2.FileOk += openFileDialog2_FileOk;
            // 
            // openFileDialog3
            // 
            openFileDialog3.FileName = "openFileDialog3";
            openFileDialog3.FileOk += openFileDialog3_FileOk;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 587);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem dIPToolStripMenuItem;
        private ToolStripMenuItem pixelCopyToolStripMenuItem;
        private ToolStripMenuItem grayscalingToolStripMenuItem;
        private ToolStripMenuItem inversionToolStripMenuItem;
        private ToolStripMenuItem mirrorHorizontalToolStripMenuItem;
        private ToolStripMenuItem mirrorVerticalToolStripMenuItem;
        private ToolStripMenuItem luminenceGrayscalingToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private TabPage tabPage2;
        private Button button1;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private Button button2;
        private Button button3;
        private OpenFileDialog openFileDialog2;
        private OpenFileDialog openFileDialog3;
        private ColorDialog colorDialog1;
        private Button button4;
        private PictureBox pictureBox6;
        private ComboBox comboBox1;
        private CheckBox checkBox1;
        private TrackBar trackBar1;
        private TrackBar trackBar3;
        private TrackBar trackBar2;
        private ComboBox comboBox2;
        private ToolStripMenuItem convolutionalMatrixToolStripMenuItem;
        private ToolStripMenuItem shrinkToolStripMenuItem;
        private ToolStripMenuItem blurToolStripMenuItem;
        private ToolStripMenuItem sharpenToolStripMenuItem;
        private ToolStripMenuItem edgeEnchanceToolStripMenuItem;
        private ToolStripMenuItem edgeDetectToolStripMenuItem;
        private ToolStripMenuItem embossToolStripMenuItem;
        private ToolStripMenuItem gaussianBlurToolStripMenuItem;
        private ToolStripMenuItem meanRemovalToolStripMenuItem;
        private ToolStripMenuItem embossLaToolStripMenuItem;
        private ToolStripMenuItem strongerBlurToolStripMenuItem;
    }
}
