using System;
using System.Drawing.Drawing2D;



public class BasicDIP
{

	public BasicDIP()
	{
    }

	public Bitmap Run(Bitmap bitmap, Func<Bitmap, int, int, Color> func)
	{
        Bitmap processed = new Bitmap(bitmap.Width, bitmap.Height);

        for (int i = 0; i < bitmap.Width; i++)
        {
            for (int j = 0; j < bitmap.Height; j++)
            {
                processed.SetPixel(i, j, func(bitmap, i, j));
            }
        }

        return processed; 
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

    private int[] GetPixelFrequency(Bitmap bitmap)
    {
        int[] hist = new int[256];

        for (int i = 0; i < bitmap.Width; i++)
        {
            for (int j = 0; j < bitmap.Height; j++)
            {
                Color pixel = bitmap.GetPixel(i, j);
                int avg = (pixel.R + pixel.G + pixel.B) / 3;
                hist[avg]++;
            }
        }

        return hist;
    }

    public Bitmap Histogram(Bitmap bitmap)
    {
        Bitmap processed = new Bitmap(256, 800);

        int[] hist = GetPixelFrequency(bitmap);
        int max = hist.Max() / processed.Height;

        for (int i = 0; i < hist.Length; i++)
        {
            for (int j = 0; j < Math.Min(processed.Height, hist[i] / max); j++)
            {
                processed.SetPixel(i, processed.Height - j - 1, Color.Black);
            }
        }

        return processed;
    }


    public Bitmap PixelCopy(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) => bitmap.GetPixel(i, j));
    }

    public Bitmap GrayScale(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) => {
            Color pixel = bitmap.GetPixel(i, j);
            int avg = (pixel.R + pixel.G + pixel.B) / 3;
            return Color.FromArgb(avg, avg, avg);
        });
    }

    public Bitmap LuminenceGrayScale(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color pixel = bitmap.GetPixel(i, j);
            int avg = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
            return Color.FromArgb(avg, avg, avg);
        });
    }

    public Bitmap Invert(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color pixel = bitmap.GetPixel(i, j);
            return Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
        });
    }

    public Bitmap MirrorHorizontal(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) => {
            return bitmap.GetPixel(bitmap.Width - i - 1, j);
        });
    }

    public Bitmap MirrorVertical(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) => {
            return bitmap.GetPixel(i, bitmap.Height - j - 1);
        });
    }

    public Bitmap Sepia(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color pixelColor = bitmap.GetPixel(i, j);
            int newRed = (int)(0.393 * pixelColor.R + 0.769 * pixelColor.G + 0.189 * pixelColor.B);
            int newGreen = (int)(0.349 * pixelColor.R + 0.686 * pixelColor.G + 0.168 * pixelColor.B);
            int newBlue = (int)(0.272 * pixelColor.R + 0.534 * pixelColor.G + 0.131 * pixelColor.B);
            return Color.FromArgb(Math.Min(newRed, 255), Math.Min(newGreen, 255), Math.Min(newBlue, 255));
        });
    }

    public Bitmap Rotate(Bitmap bitmap, int degrees)
    {
        float radians = (float)(degrees * Math.PI / 180);
        int xCenter = bitmap.Width / 2;
        int yCenter = bitmap.Height / 2;
        float cos = (float)Math.Cos(radians);
        float sin = (float)Math.Sin(radians);

        return Run(bitmap, (bitmap, i, j) =>
        {
            Color pixel = bitmap.GetPixel(i, j);
            int a = i - xCenter;
            int b = j - yCenter;
            int x = (int)(a * cos + sin * b) + xCenter;
            int y = (int)(-a * sin + cos * b) + yCenter;
            x = Math.Max(0, Math.Min(bitmap.Width - 1, x));
            y = Math.Max(0, Math.Min(bitmap.Height - 1, y));
            return bitmap.GetPixel(x, y);
        });
    }

    public Bitmap Brightness(Bitmap bitmap, int value)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color pixel = bitmap.GetPixel(i, j);
            int r = Math.Max(0, Math.Min(pixel.R + value, 255));
            int g = Math.Max(0, Math.Min(pixel.G + value, 255));
            int b = Math.Max(0, Math.Min(pixel.B + value, 255));

            return Color.FromArgb(r, g, b);
        });
    }

    public Bitmap Contrast(Bitmap bitmap, int value)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color pixel = bitmap.GetPixel(i, j);
            int r = Math.Max(0, Math.Min(pixel.R + value, 255));
            int g = Math.Max(0, Math.Min(pixel.G + value, 255));
            int b = Math.Max(0, Math.Min(pixel.B + value, 255));

            return Color.FromArgb(r, g, b);
        });
    }

    public Bitmap Subtract(Bitmap imageA, Bitmap imageB, Color subColor)
    {
        if (imageA == null || imageB == null) { return null; }

        Bitmap a = ResizeImage(imageA, imageB);

        int sub = (subColor.R + subColor.G + subColor.B) / 3;
        int threshold = 10;

        Bitmap subtractRes = new Bitmap(a.Width, a.Height);

        for (int i = 0; i < a.Width; i++)
        {
            for (int j = 0; j < a.Height; j++)
            {
                Color front = a.GetPixel(i, j);
                Color back = imageB.GetPixel(i, j);
                int curr = (front.R + front.G + front.B) / 3;
                subtractRes.SetPixel(i, j, Math.Abs(curr - sub) <= threshold ? back : front);
            }
        }

        return subtractRes;
    }

    private Bitmap ApplyConvMatrix(Bitmap bitmap, ConvMatrix matrix)
    {
        Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);

        int halfN = matrix.n / 2;
        int halfM = matrix.m / 2;
        for (int i = 0; i < bitmap.Width - matrix.n; i++)
        {
            for (int j = 0; j < bitmap.Height - matrix.m; j++)
            {
                int r, g, b = g = r = 0;
                for (int x = 0; x < matrix.n; x++)
                {
                    for (int y = 0; y < matrix.m; y++)
                    {
                        Color pixel = bitmap.GetPixel(i + x, j + y);
                        r += pixel.R * matrix.matrix[x, y];
                        g += pixel.G * matrix.matrix[x, y];
                        b += pixel.B * matrix.matrix[x, y];
                    }
                }
                r /= matrix.factor;
                g /= matrix.factor;
                b /= matrix.factor;

                r += matrix.offset;
                g += matrix.offset;
                b += matrix.offset;

                r = Math.Max(0, Math.Min(255, r));
                g = Math.Max(0, Math.Min(255, g));
                b = Math.Max(0, Math.Min(255, b));
                result.SetPixel(i + halfN, j + halfM, Color.FromArgb(r, g, b));
            }
        }

        return result;
    }

    public Bitmap Shrink(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }, 0, 1);
        return ApplyConvMatrix(bitmap, conv);
    }

    public Bitmap Sharpen(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { 0, -2, 0 }, { -2, 11, -2 }, { 0, -2, 0 } }, 0, 3);
        return ApplyConvMatrix(bitmap, conv);
    }

    public Bitmap Blur(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } }, 0, 9);
        return ApplyConvMatrix(bitmap, conv);
    }

    public Bitmap StrongerBlur(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(5, 5, new int[5, 5] { { 1, 1, 1, 1, 1 },{ 1, 1, 1, 1, 1 },{ 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }  }, 0, 25);
        return ApplyConvMatrix(bitmap, conv);
    }

    public Bitmap EdgeEnhance(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { 0, 0, 0 }, { -1, 1, 0 }, { 0, 0, 0 } }, 0, 2);
        return ApplyConvMatrix(bitmap, conv);
    }

    public Bitmap EdgeDetect(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } }, 0, 8);
        return ApplyConvMatrix(bitmap, conv);
    }

    public Bitmap GaussianBlur(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { {1 ,2 , 1}, {2, 4, 2}, {1, 2, 1} }, 0, 16);
        return ApplyConvMatrix(bitmap, conv);
    }

    public Bitmap MeanRemoval(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { {-1, -1, -1}, {-1, 9, -1}, {-1, -1, -1} }, 0, 1);
        return ApplyConvMatrix(bitmap, conv);
    }
    public Bitmap EmbossLaplascian(Bitmap bitmap)
    {
        ConvMatrix conv = new ConvMatrix(3, 3, new int[3, 3] { {-1, 0, -1}, {0, 4, 0}, {-1, 0, -1} }, 127, 1);
        return ApplyConvMatrix(bitmap, conv);
    }



}
