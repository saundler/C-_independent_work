using System;
using System.Linq;
public partial class Program
{
    private static double GetMin(double[] array)
    {
        return array.Min();
    }

    private static double GetAverage(double[] array)
    {
        return array.Sum() / array.Length;
    }

    private static double GetMedian(double[] array)
    {
        Array.Sort(array);
        if (array.Length % 2 == 0)
        {
            return (array[array.Length / 2 - 1 ] + array[array.Length / 2]) / 2;
        }
        else
        {
            return array[array.Length / 2];
        }
    }

    private static double[] ReadNumbers(string line)
    {
        return line.Split(' ').Select(double.Parse).ToArray();
    }
    public static void Main(string[] args)
    {
        double[] array = ReadNumbers(Console.ReadLine());

        Console.WriteLine($"{GetMin(array):F2}{Environment.NewLine}" +
                          $"{GetAverage(array):F2}{Environment.NewLine}" +
                          $"{GetMedian(array):F2}");
    }

}

