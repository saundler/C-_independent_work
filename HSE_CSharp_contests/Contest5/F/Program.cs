using System;

internal static class Program
{
    private static void Main(string[] args)
    {
        if (!Polynomial.TryParsePolynomial(Console.ReadLine(), out var firstPolynomial) ||
            !Polynomial.TryParsePolynomial(Console.ReadLine(), out var secondPolynomial) ||
            !int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Incorrect input");
            return;
        }

        Console.WriteLine((firstPolynomial + secondPolynomial).ToString());
        Console.WriteLine((firstPolynomial - secondPolynomial).ToString());
        Console.WriteLine((firstPolynomial * n).ToString());
        Console.WriteLine((firstPolynomial * secondPolynomial).ToString());
    }
}