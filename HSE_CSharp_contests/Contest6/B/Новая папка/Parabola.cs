using System;
using System.Security;

internal sealed class Parabola : Function
{
    public Parabola() { }

    public double numer(double x)
    {
        return x * x + x + 7;
    }

    public override double Integral(double left, double right, double step)
    {
        double y0, y1;
        double sum =0;
        while (left + step < right)
        {
            y0 = numer(left);
            y1 = numer(left + step);

            sum += ((y0 + y1) / 2) * step;

            left += step;
        }

        y0 = numer(left);
        y1 = numer(right);
        sum += ((y0 + y1) / 2) * (right - left);

        return sum;
    }
}