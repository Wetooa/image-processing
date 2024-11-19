using System;

public class Histogram
{
    public Histogram()
    {
    }

    private static int[] GetPixelFrequency(Bitmap bitmap)
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

    public static Bitmap GenerateHistogram(Bitmap bitmap)
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


}
