using System;

public partial class Program
{
    // Вычисление максимума.
    private static double Max(double a, double b)
    {
        return a >= b ? a : b;
        throw new NotImplementedException();
    }
    static void Main()
    {
        if (!double.TryParse(Console.ReadLine(), out double a) || !double.TryParse(Console.ReadLine(), out double b))
        {
            Console.WriteLine("Incorrect input");
            return;
        }
        Console.WriteLine(Max(a, b));
    }

}



