using System;

internal static class Program
{
    private static void Main(string[] args)
    {
        var matrix = new Matrix("matrix.txt");
        Console.Write(matrix);
        Console.WriteLine(matrix.SumOfEvenElements);
    }
}