using System;

internal sealed class Sin : Function
{
    public Sin() { }

    public double numer(double x)
    {
        if(Math.Sin(x) == 0)
        {
            throw new ArgumentException("Function is not defined in point");
        }
        return 1 / Math.Sin(x);
    }

    public override double Integral(double left, double right, double step)
    {
        double y0, y1;
        double sum = 0;
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