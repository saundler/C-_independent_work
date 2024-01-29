using System;

public partial class Program
{

    // Вычисление максимума трех чисел.
    private static double MaxOfThree(double a, double b, double c)
    {
        return a >= b ? a >= c ? a : c : b >= c ? b : c;
        throw new NotImplementedException();
    }
}