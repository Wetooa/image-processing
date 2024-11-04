using System.Drawing;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;

        FilterInfoCollection fic;
        VideoCaptureDevice vcd;

        public Form1()
        {
            InitializeComponent();
            String defaultImage = System.IO.Path.Combine(Application.StartupPath, "..\\..\\..\\static\\cat.jpg");
            if (System.IO.File.Exists(defaultImage))
            {
                loaded = new Bitmap(defaultImage);
                pictureBox1.Image = loaded;
            }
            else
            {
                MessageBox.Show("Image file not found. " + defaultImage);
            }
            pictureBox1.Image = loaded;


            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            vcd = new VideoCaptureDevice();
            foreach (FilterInfo dev in fic)
            {
                comboBox1.Items.Add(dev.Name);
                comboBox1.SelectedIndex = 0;
            }

            pictureBox6.BackColor = colorDialog1.Color;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }


        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
        }

        private void pixelCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    processed.SetPixel(i, j, loaded.GetPixel(i, j));
                }
            }

            pictureBox2.Image = processed;
        }

        private void grayscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    Color pixel = loaded.GetPixel(i, j);
                    int avg = (pixel.R + pixel.G + pixel.B) / 3;
                    Color grayscaled = Color.FromArgb(avg, avg, avg);
                    processed.SetPixel(i, j, grayscaled);
                }
            }

            pictureBox2.Image = processed;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void luminenceGrayscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    Color pixel = loaded.GetPixel(i, j);
                    int avg = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    Color grayscaled = Color.FromArgb(avg, avg, avg);
                    processed.SetPixel(i, j, grayscaled);
                }
            }

            pictureBox2.Image = processed;
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    Color pixel = loaded.GetPixel(i, j);
                    Color inverted = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    processed.SetPixel(i, j, inverted);
                }
            }

            pictureBox2.Image = processed;
        }

        private void mirrorHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    Color pixel = loaded.GetPixel(i, j);
                    processed.SetPixel(loaded.Width - i - 1, j, pixel);
                }
            }

            pictureBox2.Image = processed;
        }

        private void mirrorVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    Color pixel = loaded.GetPixel(i, j);
                    processed.SetPixel(i, loaded.Height - j - 1, pixel);
                }
            }

            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] hist = new int[256];

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    Color pixel = loaded.GetPixel(i, j);
                    int avg = (pixel.R + pixel.G + pixel.B) / 3;
                    hist[avg]++;
                }
            }

            processed = new Bitmap(256, 800);
            int max = hist.Max() / processed.Height;

            for (int i = 0; i < hist.Length; i++)
            {
                for (int j = 0; j < Math.Min(processed.Height, hist[i] / max); j++)
                {
                    processed.SetPixel(i, processed.Height - j - 1, Color.Black);
                }
            }

            pictureBox2.Image = processed;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            var sepiaMatrix = new float[][] {
                new float[] { 0.393f, 0.349f, 0.272f, 0, 0 },
                new float[] { 0.769f, 0.686f, 0.534f, 0, 0 },
                new float[] { 0.189f, 0.168f, 0.131f, 0, 0 },
                new float[] { 0,      0,      0,      1, 0 },
                new float[] { 0,      0,      0,      0, 1 }
            };

            var attributes = new ImageAttributes();
            attributes.SetColorMatrix(new ColorMatrix(sepiaMatrix));

            using (var g = Graphics.FromImage(processed))
            {
                g.DrawImage(loaded, new Rectangle(0, 0, loaded.Width, loaded.Height),
                            0, 0, loaded.Width, loaded.Height, GraphicsUnit.Pixel, attributes);
            }

            pictureBox2.Image = processed;
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            processed.Save(saveFileDialog1.FileName + ".jpg");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }


        Bitmap imageA, imageB, subtractRes;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private Bitmap ResizeImage(Bitmap a, Bitmap b)
        {
            Bitmap resizedImage = new Bitmap(b.Width, b.Height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(a, 0, 0, b.Width, b.Height); 
            }
            return resizedImage;
        }

        private void Subtract()
        {
            if (imageA == null || imageB == null) { return; }

            Bitmap a = (Bitmap)imageA.Clone();
            Bitmap b = (Bitmap)imageB.Clone();
            a = ResizeImage(a, b);
            Color subColor = colorDialog1.Color;
            int sub = (subColor.R + subColor.G + subColor.B) / 3;
            int threshold = 10;

            subtractRes = new Bitmap(a.Width, a.Height);

            for (int i = 0; i < a.Width; i++)
            {
                for (int j = 0; j < a.Height; j++)
                {
                    Color front = a.GetPixel(i, j);
                    Color back = b.GetPixel(i, j);
                    int curr = (front.R + front.G + front.B) / 3;
                    subtractRes.SetPixel(i, j, Math.Abs(curr - sub) <= threshold ? back : front);
                }
            }

            pictureBox5.Image = subtractRes;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Subtract();
        }

        private void openFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            imageA = new Bitmap(openFileDialog2.FileName);
            pictureBox3.Image = imageA;
        }

        private void openFileDialog3_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            imageB = new Bitmap(openFileDialog3.FileName);
            pictureBox4.Image = imageB;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.BackColor = colorDialog1.Color;
            }
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            imageA = (Bitmap)eventArgs.Frame.Clone();
            pictureBox3.Image = imageA;
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
    }
}
