using AForge.Video;
using AForge.Video.DirectShow;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;

        FilterInfoCollection fic;
        VideoCaptureDevice vcd;

        Bitmap imageA, imageB, subtractRes, vfxRes;

        int videoEffectsIndex = 0;
        String[] videoEffects =
        {
            "Subtract",
            "Pixel Copy",
            "GrayScale",
            "Luminence GrayScale",
            "Invert",
            "Mirror Horizontal",
            "Mirror Vertical",
            "Sepia"
        };
        bool isProcessing = false;

        List<Bitmap> countCoinsSteps = new List<Bitmap>();
        int currentStep = 0;
        const int MAX_STEPS = 10;

        List<List<Point>> coins;
        List<int> coinValues;
        List<double> coinSizes;

        public Form1()
        {
            InitializeComponent();

            InitializeDefaultImage();
            InitializeVideoCameras();
            InitializePart2();

        }

        public void InitializeDefaultImage()
        {
            String defaultImage = System.IO.Path.Combine(Application.StartupPath, "..\\..\\..\\static\\cat.jpg");
            if (System.IO.File.Exists(defaultImage))
            {
                loaded = new Bitmap(defaultImage);
                reloadImages();
            }
            else
            {
                MessageBox.Show("Image file not found. " + defaultImage);
                return;
            }


            String countCoinsImage = System.IO.Path.Combine(Application.StartupPath, "..\\..\\..\\static\\coins.jpeg");
            if (System.IO.File.Exists(defaultImage))
            {
                countCoinsSteps.Add(new Bitmap(countCoinsImage));
                currentStep = 0;
                listBox1.Items.Add("Base");
                listBox1.SelectedIndex = currentStep;
                reloadImages();
            }
            else
            {
                MessageBox.Show("Image file not found. " + defaultImage);
                return;
            }
        }

        public void InitializeVideoCameras()
        {
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            vcd = new VideoCaptureDevice();
            foreach (FilterInfo dev in fic)
            {
                comboBox1.Items.Add(dev.Name);
                comboBox1.SelectedIndex = 0;
            }
        }

        public void InitializePart2()
        {
            foreach (String s in videoEffects)
            {
                comboBox2.Items.Add(s);
            }
            comboBox2.SelectedIndex = 0;

            pictureBox6.BackColor = colorDialog1.Color;
        }

        public void reloadImages()
        {
            pictureBox1.Image = loaded;
            pictureBox2.Image = processed;
            pictureBox3.Image = imageA;
            pictureBox4.Image = imageB;
            pictureBox5.Image = subtractRes;
            pictureBox7.Image = countCoinsSteps.Count <= currentStep ? null : countCoinsSteps[currentStep];
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            reloadImages();
        }

        private void pixelCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = BasicDIP.PixelCopy(loaded);
        }

        private void grayscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = BasicDIP.GrayScale(loaded);
        }

        private void luminenceGrayscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = BasicDIP.LuminenceGrayScale(loaded);
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = BasicDIP.Invert(loaded);
        }

        private void mirrorHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = BasicDIP.MirrorHorizontal(loaded);
        }

        private void mirrorVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = BasicDIP.MirrorVertical(loaded);
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = Histogram.GenerateHistogram(loaded);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = BasicDIP.Sepia(loaded);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = BasicDIP.Brightness(loaded, trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = BasicDIP.Contrast(loaded, trackBar1.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = BasicDIP.Rotate(loaded, trackBar3.Value);
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            processed.Save(saveFileDialog1.FileName + ".jpg");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = subtractRes = BasicDIP.Subtract(imageA, imageB, colorDialog1.Color);
        }

        private void openFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pictureBox3.Image = imageA = new Bitmap(openFileDialog2.FileName);
            reloadImages();
        }

        private void openFileDialog3_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pictureBox4.Image = imageB = new Bitmap(openFileDialog3.FileName);
            reloadImages();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.BackColor = colorDialog1.Color;
            }
        }


        private void stopCamera()
        {
            vcd.SignalToStop();
            vcd.WaitForStop();
        }

        private void useCamera()
        {
            if (checkBox1.Checked)
            {
                stopCamera();
                vcd = new VideoCaptureDevice(fic[comboBox1.SelectedIndex].MonikerString);
                vcd.NewFrame += FinalFrame_NewFrame;
                vcd.Start();
            }
            else
            {
                stopCamera();
            }
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            imageA = (Bitmap)eventArgs.Frame.Clone();

            switch (videoEffectsIndex)
            {
                case 0:
                    vfxRes = BasicDIP.Subtract(imageA, imageB, colorDialog1.Color);
                    break;
                case 1:
                    vfxRes = BasicDIP.PixelCopy(imageA);
                    break;
                case 2:
                    vfxRes = BasicDIP.GrayScale(imageA);
                    break;
                case 3:
                    vfxRes = BasicDIP.LuminenceGrayScale(imageA);
                    break;
                case 4:
                    vfxRes = BasicDIP.Invert(imageA);
                    break;
                case 5:
                    vfxRes = BasicDIP.MirrorHorizontal(imageA);
                    break;
                case 6:
                    vfxRes = BasicDIP.MirrorVertical(imageA);
                    break;
                case 7:
                    vfxRes = BasicDIP.Sepia(imageA);
                    break;
            }

            pictureBox3.Image = imageA;
            pictureBox5.Image = vfxRes;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            useCamera();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            useCamera();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            stopCamera();
            base.OnFormClosing(e);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoEffectsIndex = comboBox2.SelectedIndex;
        }

        private void shrinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = ConvolutionMatrix.Shrink(loaded);
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = ConvolutionMatrix.Sharpen(loaded);
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = ConvolutionMatrix.Blur(loaded);
        }

        private void strongerBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = ConvolutionMatrix.StrongerBlur(loaded);
        }

        private void edgeEnchanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = ConvolutionMatrix.EdgeEnhance(loaded);
        }

        private void edgeDetectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = ConvolutionMatrix.EdgeDetect(loaded);
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = ConvolutionMatrix.GaussianBlur(loaded);
        }

        private void embossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = ConvolutionMatrix.EmbossLaplascian(loaded);
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = ConvolutionMatrix.MeanRemoval(loaded);
        }

        private void embossLaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = ConvolutionMatrix.EmbossLaplascian(loaded);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog4.ShowDialog();
        }

        private void openFileDialog4_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            countCoinsSteps.Clear();
            countCoinsSteps.Add(new Bitmap(openFileDialog4.FileName));
            currentStep = 0;
            listBox1.Items.Clear();
            listBox1.Items.Add("Base");
            listBox1.SelectedIndex = currentStep;
            reloadImages();
        }

        private void solveCountCoins(int end = MAX_STEPS)
        {
            for (int i = countCoinsSteps.Count; i < end; i++)
            {
                switch (i)
                {
                    case 1:
                        countCoinsSteps.Add(BasicDIP.GrayScale(countCoinsSteps[i - 1]));
                        listBox1.Items.Add("Grayscale");
                        break;
                    case 2:
                        countCoinsSteps.Add(ConvolutionMatrix.GaussianBlur(countCoinsSteps[i - 1]));
                        listBox1.Items.Add("Gaussian Blur");
                        break;
                    case 3:
                        countCoinsSteps.Add(ConvolutionMatrix.EdgeDetect(countCoinsSteps[i - 1]));
                        listBox1.Items.Add("Edge Detect");
                        break;
                    case 4:
                        countCoinsSteps.Add(BasicDIP.MedianFilter(countCoinsSteps[i - 1], 3));
                        listBox1.Items.Add("Median Filter");
                        break;
                    case 5:
                        countCoinsSteps.Add(ConvolutionMatrix.Dilation(countCoinsSteps[i - 1]));
                        listBox1.Items.Add("Dilation");
                        break;
                    case 6:
                        countCoinsSteps.Add(ConvolutionMatrix.Erosion(countCoinsSteps[i - 1]));
                        listBox1.Items.Add("Erosion");
                        break;
                    case 7:
                        Bitmap b = BasicDIP.MedianFilter(countCoinsSteps[i - 1], 3);
                        b = BasicDIP.MedianFilter(b, 3);
                        b = BasicDIP.MedianFilter(b, 3);
                        b = BasicDIP.MedianFilter(b, 3);
                        countCoinsSteps.Add(b);
                        listBox1.Items.Add("Multiple Median Filter");
                        break;
                    case 8:
                        countCoinsSteps.Add(BasicDIP.PixelCopy(countCoinsSteps[i - 1]));
                        listBox1.Items.Add("ZhangSuen Thinning");
                        break;
                    case 9:
                        Bitmap prev = countCoinsSteps[i - 1];
                        Bitmap contourImage = (Bitmap)countCoinsSteps[0].Clone();

                        Tuple<List<List<Point>>, List<int>, List<double>> t = CoinCounter.CountCoins(ContourTracing.TraceContours(prev));
                        coins = t.Item1;
                        coinValues = t.Item2;
                        coinSizes = t.Item3;

                        listBox2.Items.Clear();

                        foreach (var q in coinSizes.Zip(coinValues))
                        {
                            listBox2.Items.Add(q.First + " - " + (q.Second / 100.0));
                        }

                        int valSum = coinValues.Sum();

                        foreach (var contour in coins)
                        {
                            foreach (var point in contour)
                            {
                                contourImage.SetPixel(point.X, point.Y, Color.Red);
                            }
                        }

                        countCoinsSteps.Add(contourImage);
                        listBox1.Items.Add("Trace Contours");

                        // 64 Coins in Total
                        label2.Text = coins.Count.ToString();
                        label3.Text = valSum / 100 + " Peso and " + valSum % 100 + " Cents";
                        break;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            solveCountCoins();
            currentStep = MAX_STEPS - 1;
            listBox1.SelectedIndex = currentStep;
            reloadImages();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (currentStep == 0) return;

            currentStep -= 1;
            reloadImages();
            listBox1.SelectedIndex = currentStep;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (currentStep + 1 == MAX_STEPS) return;

            currentStep += 1;
            solveCountCoins(Math.Min(countCoinsSteps.Count, currentStep) + 1);
            listBox1.SelectedIndex = currentStep;
            reloadImages();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentStep = listBox1.SelectedIndex;
            reloadImages();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox7.Image = ContourTracing.DrawContour((Bitmap)countCoinsSteps[MAX_STEPS - 1].Clone(), coins[listBox2.SelectedIndex]);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            saveFileDialog2.ShowDialog();
        }

        private void saveFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pictureBox7.Image.Save(saveFileDialog2.FileName + ".jpg");
        }
    }
}
