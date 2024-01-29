using System;

internal class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            var operation = Console.ReadLine();
            Vector a, b;
            switch (operation)
            {
                case "+":
                    Vector.ReadVectors(out a, out b);
                    Console.WriteLine(a + b);
                    break;
                case "-":
                    Vector.ReadVectors(out a, out b);
                    Console.WriteLine(a - b);
                    break;
                case "*":
                    Vector.ReadVectors(out a, out b);
                    Console.WriteLine($"{a * b:0.###}");
                    break;
                case "*n":
                    Vector.ReadVectorAndNumber(out a, out var number);
                    Console.WriteLine(number * a);
                    break;
                case "x":
                    Vector.ReadVectors(out a, out b);
                    Console.WriteLine($"{a.GetVectorMultiplication(b):0.###}");
                    break;
                case "||":
                    a = Vector.ReadVector();
                    Console.WriteLine($"{a.GetLength():0.###}");
                    break;
                case "<":
                    Vector.ReadVectors(out a, out b);
                    Console.WriteLine($"{a.GetAngleCos(b):0.###}");
                    break;
                default:
                    return;
            }
        }
    }
}