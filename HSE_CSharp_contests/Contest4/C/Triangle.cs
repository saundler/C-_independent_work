using System;

internal sealed class Triangle
{
    private const double Delta = 0.00001;
    private readonly double a;
    private readonly double b; 
    private readonly double c;

    public Triangle(Point a, Point b, Point c)
    {
        this.a = Math.Sqrt(Math.Pow(a.GetX() - b.GetX(), 2) + Math.Pow(a.GetY() - b.GetY(), 2));
        this.b = Math.Sqrt(Math.Pow(b.GetX() - c.GetX(), 2) + Math.Pow(b.GetY() - c.GetY(), 2));
        this.c = Math.Sqrt(Math.Pow(c.GetX() - a.GetX(), 2) + Math.Pow(c.GetY() - a.GetY(), 2));
    }
    
    public double GetPerimeter()
    {
        return a + b + c;
    }
    
    public double GetSquare()
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    private double GetRadiane(double x, double y)
    {
        return 2 * Math.Asin(y / (2 * x)); 
    }

    public bool GetAngleBetweenEqualsSides(out double angle)
    {
        if(a == b)
        {
            angle = GetRadiane(a, c);
            return true;
        }
        else if(b == c)
        {
            angle = GetRadiane(b, a);
            return true;
        }
        else if(a == c)
        {
            angle = GetRadiane(a, b);
            return true;
        }
        angle = 0;
        return false;
    }

    public bool GetHypotenuse(out double hypotenuse)
    {
        if (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) == c) 
        {
            hypotenuse = c;
            return true;
        }
        else if (Math.Sqrt(Math.Pow(b, 2) + Math.Pow(c, 2)) == a)
        {
            hypotenuse = a;
            return true;
        }
        else if (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(c, 2)) == b)
        {
            hypotenuse = b;
            return true;
        }
        hypotenuse = 0;
        return false;
    }
}