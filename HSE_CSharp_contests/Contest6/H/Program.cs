using System;

internal class Program
{
    private static string Compare(Vector first, Vector second)
    {
        return first.CompareTo(second) switch
        {
            > 0 => "FIRST",
            < 0 => "SECOND",
            _ => "SAME"
        };
    }

    private static void Main(string[] args)
    {
        try
        {
            Vector first = Vector.Parse(Console.ReadLine());
            Vector second = Vector.Parse(Console.ReadLine());
            Console.WriteLine(Compare(first, second));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}