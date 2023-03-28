using System;
using System.Collections.Generic;

public class PointInPolygonChecker
{
    // Check if a given point is inside a polygon
    public static bool IsPointInPolygon(List<Point> polygon, Point point)
    {
        bool isInside = false;
        int i, j = polygon.Count - 1;

        // Iterate through each edge of the polygon
        for (i = 0; i < polygon.Count; i++)
        {
            if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
                (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
            {
                isInside = !isInside;
            }

            j = i;
        }

        return isInside;
    }
public struct Point
{
    public int X { get; set;}
    public int Y { get; set;}
}
    static void Main(string[] args)
    {
        // Create the polygon
        List<Point> polygon = new List<Point>();
        Console.WriteLine("Enter the points that make up the polygon (enter 0,0 to finish):");
        Point point = new Point();
        do
        {
            string[] input = Console.ReadLine().Split(',');
            point.X = int.Parse(input[0]);
            point.Y = int.Parse(input[1]);

            if (point.X != 0 || point.Y != 0)
            {
                polygon.Add(point);
            }
        } while (point.X != 0 || point.Y != 0);

        // Get the point to check
        Console.WriteLine("Enter the point to check (in the format X,Y):");
        string[] pointInput = Console.ReadLine().Split(',');
        Point pointToCheck = new Point();
        pointToCheck.X = int.Parse(pointInput[0]);
        pointToCheck.Y = int.Parse(pointInput[1]);

        // Check if the point is inside the polygon
        bool isInside = IsPointInPolygon(polygon, pointToCheck);

        if (isInside)
        {
            Console.WriteLine("The point is inside the polygon.");
        }
        else
        {
            Console.WriteLine("The point is outside the polygon.");
        }
    }
}