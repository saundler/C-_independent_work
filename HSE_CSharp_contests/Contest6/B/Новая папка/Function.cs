using System;

internal abstract class Function
{
    public static Function GetFunction(string functionName)
    {
        switch(functionName)
        {
            case "Sin":
                return new Sin();
            case "Exp":
                return new Exponent();
            case "Parabola":
                return new Parabola();
            default:
                throw new ArgumentException("Incorrect input");
        }
    }

    public static double SolveIntegral(Function func, double left, double right, double step)
    {
        if (left > right)
        {
            throw new ArgumentException("Left border greater than right");
        }
        return func.Integral(left, right, step);
    }

    public abstract double Integral(double left, double right, double step);
}