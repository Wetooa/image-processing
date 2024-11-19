using System;
using System.Collections.Generic;
using System.Drawing;

public class CoinCounter
{
    public static double CalculatePerimeter(List<Point> contour)
    {
        double perimeter = 0;
        for (int i = 0; i < contour.Count; i++)
        {
            Point current = contour[i];
            Point next = contour[(i + 1) % contour.Count]; // Loop back to the first point
            double distance = Math.Sqrt(Math.Pow(next.X - current.X, 2) + Math.Pow(next.Y - current.Y, 2));
            perimeter += distance;
        }
        return perimeter;
    }

    public static double CalculateArea(List<Point> contour)
    {
        double area = 0;
        for (int i = 0; i < contour.Count; i++)
        {
            Point current = contour[i];
            Point next = contour[(i + 1) % contour.Count];
            area += current.X * next.Y - current.Y * next.X;
        }
        return Math.Abs(area) / 2.0;
    }
}
