using System;

public class CircleIntersection
{
    // Find the intersection points of two circles
    public static Tuple<double, double>[] FindCircleIntersection(double x1, double y1, double r1, double x2, double y2, double r2)
    {
        // Calculate the distance between the centers of the circles
        double d = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

        // Check if the circles do not intersect
        if (d > r1 + r2)
        {
            Console.WriteLine("The circles do not intersect.");
            return null;
        }

        // Check if one circle is contained within the other
        if (d < Math.Abs(r1 - r2))
        {
            Console.WriteLine("One circle is contained within the other.");
            return null;
        }

        // Calculate the intersection points
        double a = (Math.Pow(r1, 2) - Math.Pow(r2, 2) + Math.Pow(d, 2)) / (2 * d);
        double h = Math.Sqrt(Math.Pow(r1, 2) - Math.Pow(a, 2));
        double x3 = x1 + a * (x2 - x1) / d;
        double y3 = y1 + a * (y2 - y1) / d;
        double x4 = x3 + h * (y2 - y1) / d;
        double y4 = y3 - h * (x2 - x1) / d;
        double x5 = x3 - h * (y2 - y1) / d;
        double y5 = y3 + h * (x2 - x1) / d;

        Tuple<double, double>[] intersectionPoints = new Tuple<double, double>[2];
        intersectionPoints[0] = new Tuple<double, double>(x4, y4);
        intersectionPoints[1] = new Tuple<double, double>(x5, y5);

        return intersectionPoints;
    }

    static void Main(string[] args)
    {
        // Find the intersection points of two circles
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());
        double r1 = double.Parse(Console.ReadLine());
        double r2 = double.Parse(Console.ReadLine());

        Tuple<double, double>[] intersectionPoints = FindCircleIntersection(x1, y1, r1, x2, y2, r2);

        if (intersectionPoints != null)
        {
            Console.WriteLine("The circles intersect at (" + intersectionPoints[0].Item1 + ", " + intersectionPoints[0].Item2 + ") and (" + intersectionPoints[1].Item1 + ", " + intersectionPoints[1].Item2 + ")");
        }
    }
}