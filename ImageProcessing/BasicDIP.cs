public class BasicDIP
{
    public BasicDIP()
    {
    }

    public static int average(Color pixel)
    {
        return (int)(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);
    }

    public static int clamping(int a)
    {
        return Math.Max(Math.Min(a, 255), 0);
    }

    public static Bitmap Run(Bitmap bitmap, Func<Bitmap, int, int, Color> func)
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

    private static Bitmap ResizeImage(Bitmap a, Bitmap b)
    {
        Bitmap resizedImage = new Bitmap(b.Width, b.Height);
        using (Graphics g = Graphics.FromImage(resizedImage))
        {
            g.DrawImage(a, 0, 0, b.Width, b.Height);
        }
        return resizedImage;
    }

    public static Bitmap PixelCopy(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) => bitmap.GetPixel(i, j));
    }

    public static Bitmap GrayScale(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color pixel = bitmap.GetPixel(i, j);
            int avg = average(pixel);
            return Color.FromArgb(avg, avg, avg);
        });
    }

    public static Bitmap LuminenceGrayScale(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color pixel = bitmap.GetPixel(i, j);
            int avg = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
            return Color.FromArgb(avg, avg, avg);
        });
    }

    public static Bitmap Invert(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color pixel = bitmap.GetPixel(i, j);
            return Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
        });
    }

    public static Bitmap MirrorHorizontal(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            return bitmap.GetPixel(bitmap.Width - i - 1, j);
        });
    }

    public static Bitmap MirrorVertical(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            return bitmap.GetPixel(i, bitmap.Height - j - 1);
        });
    }

    public static Bitmap Sepia(Bitmap bitmap)
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

    public static Bitmap Rotate(Bitmap bitmap, int degrees)
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

    public static Bitmap Brightness(Bitmap bitmap, int value)
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

    public static Bitmap Contrast(Bitmap bitmap, int value)
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

    public static Bitmap Subtract(Bitmap imageA, Bitmap imageB, Color subColor)
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

    public static Bitmap MedianFilter(Bitmap bitmap, int windowSize)
    {
        Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
        int halfSize = windowSize / 2;

        for (int i = halfSize; i < bitmap.Width - halfSize; i++)
        {
            for (int j = halfSize; j < bitmap.Height - halfSize; j++)
            {
                List<int> reds = new List<int>();
                List<int> greens = new List<int>();
                List<int> blues = new List<int>();

                // Collect pixel values in the window
                for (int x = -halfSize; x <= halfSize; x++)
                {
                    for (int y = -halfSize; y <= halfSize; y++)
                    {
                        Color pixel = bitmap.GetPixel(i + x, j + y);
                        reds.Add(pixel.R);
                        greens.Add(pixel.G);
                        blues.Add(pixel.B);
                    }
                }

                // Get the median of each channel
                reds.Sort();
                greens.Sort();
                blues.Sort();

                int medianR = reds[reds.Count / 2];
                int medianG = greens[greens.Count / 2];
                int medianB = blues[blues.Count / 2];

                result.SetPixel(i, j, Color.FromArgb(medianR, medianG, medianB));
            }
        }

        return result;
    }


    public static Bitmap Thresholding(Bitmap bitmap, int threshold)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            Color p = bitmap.GetPixel(i, j);
            int avg = average(p);
            return avg < threshold ? Color.Black : Color.White;
        });
    }

    public static Bitmap Complement(Bitmap bitmap)
    {
        return Run(bitmap, (bitmap, i, j) =>
        {
            return average(bitmap.GetPixel(i, j)) != 0 ? Color.Black : Color.White;
        });
    }

    public static Bitmap ZhangSuenThinning(Bitmap binaryImage)
    {
        int width = binaryImage.Width;
        int height = binaryImage.Height;
        bool[,] pixels = ConvertToBinaryArray(binaryImage);

        bool pixelsChanged;
        do
        {
            pixelsChanged = false;

            // First sub-iteration
            pixelsChanged |= ThinningSubIteration(pixels, width, height, true);

            // Second sub-iteration
            pixelsChanged |= ThinningSubIteration(pixels, width, height, false);

        } while (pixelsChanged);

        return ConvertToBitmap(pixels, width, height);
    }

    private static bool ThinningSubIteration(bool[,] pixels, int width, int height, bool firstSubIteration)
    {
        bool pixelsChanged = false;
        bool[,] marker = new bool[width, height];

        for (int x = 1; x < width - 1; x++)
        {
            for (int y = 1; y < height - 1; y++)
            {
                if (!pixels[x, y]) continue;

                int neighbors = CountWhiteNeighbors(pixels, x, y);
                int transitions = CountTransitions(pixels, x, y);

                if (neighbors >= 2 && neighbors <= 6 &&
                    transitions == 1 &&
                    AtLeastOneBlackNeighbor(pixels, x, y, firstSubIteration))
                {
                    marker[x, y] = true;
                }
            }
        }

        for (int x = 1; x < width - 1; x++)
        {
            for (int y = 1; y < height - 1; y++)
            {
                if (marker[x, y])
                {
                    pixels[x, y] = false;
                    pixelsChanged = true;
                }
            }
        }

        return pixelsChanged;
    }

    private static int CountWhiteNeighbors(bool[,] pixels, int x, int y)
    {
        int count = 0;
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0) continue;
                if (pixels[x + dx, y + dy]) count++;
            }
        }
        return count;
    }

    private static int CountTransitions(bool[,] pixels, int x, int y)
    {
        int count = 0;

        bool[] neighbors = GetNeighbors(pixels, x, y);
        for (int i = 0; i < neighbors.Length; i++)
        {
            if (!neighbors[i] && neighbors[(i + 1) % neighbors.Length])
            {
                count++;
            }
        }

        return count;
    }

    private static bool AtLeastOneBlackNeighbor(bool[,] pixels, int x, int y, bool firstSubIteration)
    {
        if (firstSubIteration)
        {
            return !(pixels[x, y - 1] && pixels[x + 1, y] && pixels[x, y + 1]);
        }
        else
        {
            return !(pixels[x + 1, y] && pixels[x, y + 1] && pixels[x - 1, y]);
        }
    }

    private static bool[] GetNeighbors(bool[,] pixels, int x, int y)
    {
        return new bool[]
        {
            pixels[x, y - 1],     // N
            pixels[x + 1, y - 1], // NE
            pixels[x + 1, y],     // E
            pixels[x + 1, y + 1], // SE
            pixels[x, y + 1],     // S
            pixels[x - 1, y + 1], // SW
            pixels[x - 1, y],     // W
            pixels[x - 1, y - 1]  // NW
        };
    }

    private static bool[,] ConvertToBinaryArray(Bitmap binaryImage)
    {
        int width = binaryImage.Width;
        int height = binaryImage.Height;
        bool[,] pixels = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = binaryImage.GetPixel(x, y);
                pixels[x, y] = color.R == 255; // Assume binary image is already thresholded
            }
        }

        return pixels;
    }

    private static Bitmap ConvertToBitmap(bool[,] pixels, int width, int height)
    {
        Bitmap bitmap = new Bitmap(width, height);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                bitmap.SetPixel(x, y, pixels[x, y] ? Color.White : Color.Black);
            }
        }
        return bitmap;
    }

}
