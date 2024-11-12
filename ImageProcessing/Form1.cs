using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq.Expressions;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;
        BasicDIP dip;

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

        public Form1()
        {
            InitializeComponent();

            InitializeDefaultImage();
            InitializeVideoCameras();
            InitializePart2();

            dip = new BasicDIP();
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
            pictureBox2.Image = processed = dip.PixelCopy(loaded);
        }

        private void grayscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.GrayScale(loaded);
        }

        private void luminenceGrayscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.LuminenceGrayScale(loaded);
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.Invert(loaded);
        }

        private void mirrorHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.MirrorHorizontal(loaded);
        }

        private void mirrorVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.MirrorVertical(loaded);
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.Histogram(loaded);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.Sepia(loaded);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.Brightness(loaded, trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.Contrast(loaded, trackBar1.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.Rotate(loaded, trackBar3.Value);
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
            pictureBox5.Image = subtractRes = dip.Subtract(imageA, imageB, colorDialog1.Color);
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
                    vfxRes = dip.Subtract(imageA, imageB, colorDialog1.Color);
                    break;
                case 1:
                    vfxRes = dip.PixelCopy(imageA);
                    break;
                case 2:
                    vfxRes = dip.GrayScale(imageA);
                    break;
                case 3:
                    vfxRes = dip.LuminenceGrayScale(imageA);
                    break;
                case 4:
                    vfxRes = dip.Invert(imageA);
                    break;
                case 5:
                    vfxRes = dip.MirrorHorizontal(imageA);
                    break;
                case 6:
                    vfxRes = dip.MirrorVertical(imageA);
                    break;
                case 7:
                    vfxRes = dip.Sepia(imageA);
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
            pictureBox2.Image = processed = dip.Shrink(loaded);
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.Sharpen(loaded);
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.Blur(loaded);
        }

        private void strongerBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.StrongerBlur(loaded);
        }

        private void edgeEnchanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.EdgeEnhance(loaded);
        }

        private void edgeDetectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.EdgeDetect(loaded);
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.GaussianBlur(loaded);
        }

        private void embossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.EmbossLaplascian(loaded);
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.MeanRemoval(loaded);
        }

        private void embossLaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = processed = dip.EmbossLaplascian(loaded);
        }
    }
}
