using System;

public delegate double F(double x);

class IntegralCalculator
{
    public static double Square(double x, double y, F f)
    {
        double s = 0;
        double t;
        while (x < y)
        {
            t = x + Program.EPSYLON;
            if(t > y)
                t = y;
            s += (f(x) + f(t)) / 2 * Math.Abs(t - x);
            x = t;
        }
        return s;
    }
    public static double Sin(double x, double y)
    {
        return Square(x, y, Math.Sin);
    }
    public static double Cos(double x, double y)
    {
        return Square(x, y, Math.Cos);
    }
    public static double Tan(double x, double y)
    {
        return Square(x, y, Math.Tan);
    }
    public static void InsertParameter(int param)
    {
        switch (param)
        {
            case 0:
                Program.func = Sin;
                break;
            case 1:
                Program.func = Cos;
                break;
            case 2:
                Program.func = Tan;
                break;
        }
    }
}