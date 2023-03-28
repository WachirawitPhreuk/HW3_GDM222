using System;
using System.Collections.Generic;
 
public static class Program {
    public static void
    lineFromPoints(List<double> P, List<double> Q,
                   ref double a, ref double b, ref double c)
    {
        a = Q[1] - P[1];
        b = P[0] - Q[0];
        c = a * (P[0]) + b * (P[1]);
    }
 
    public static void perpendicularBisectorFromLine(
        List<double> P, List<double> Q, ref double a,
        ref double b, ref double c)
    {
        List<double> mid_point = new List<double>();
        mid_point.Add((P[0] + Q[0]) / 2);
 
        mid_point.Add((P[1] + Q[1]) / 2);

        c = -b * (mid_point[0]) + a * (mid_point[1]);
 
        double temp = a;
        a = -b;
        b = temp;
    }
 
    public static List<double>
    lineLineIntersection(double a1, double b1, double c1,
                         double a2, double b2, double c2)
    {
        List<double> ans = new List<double>();
        double determinant = a1 * b2 - a2 * b1;
        if (determinant == 0) {
            ans.Add(double.MaxValue);
            ans.Add(double.MaxValue);
        }
 
        else {
            double x = (b2 * c1 - b1 * c2) / determinant;
            double y = (a1 * c2 - a2 * c1) / determinant;
            ans.Add(x);
            ans.Add(y);
        }
        return ans;
    }
 
    public static void findCircumCenter(List<double> P,
                                        List<double> Q,
                                        List<double> R)
    {

        double a = 0;
        double b = 0;
        double c = 0;
        lineFromPoints(P, Q, ref a, ref b, ref c);
 
        double e = 0;
        double f = 0;
        double g = 0;
        lineFromPoints(Q, R, ref e, ref f, ref g);
 
        perpendicularBisectorFromLine(P, Q, ref a, ref b,
                                      ref c);
        perpendicularBisectorFromLine(Q, R, ref e, ref f,
                                      ref g);
 
        List<double> circumcenter
            = lineLineIntersection(a, b, c, e, f, g);
 
        if (circumcenter[0] == float.MaxValue
            && circumcenter[1] == float.MaxValue) {
            Console.Write("The two perpendicular bisectors "
                          + "found come parallel");
            Console.Write("\n");
            Console.Write(
                "Thus, the given points do not form "
                + "a triangle and are collinear");
            Console.Write("\n");
        }
 
        else {
            Console.WriteLine(circumcenter[0]);
            Console.WriteLine(circumcenter[1]);
            double r = Math.Sqrt(Math.Pow(circumcenter[0] - P[0], 2) + Math.Pow(circumcenter[1] - P[1], 2));
            Console.WriteLine(r);
        }
    }
 
    public static void Main()
    {
 
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());
        double f = double.Parse(Console.ReadLine());

        List<double> P = new List<double>();
        P.Add(a);
        P.Add(b);
        List<double> Q = new List<double>();
        Q.Add(c);
        Q.Add(d);
        List<double> R = new List<double>();
        R.Add(e);
        R.Add(f);
 
        findCircumCenter(P, Q, R);
    }
}