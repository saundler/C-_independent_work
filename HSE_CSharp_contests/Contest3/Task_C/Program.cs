using System;
using System.Linq;

public partial class Program
{
    private static int GetCountGreaterThanValue(int[] array, double average)
    {
        int count = 0;
        foreach(int item in array)
        {
            if (item > average)
            {
                count++;
            }
        }
        return count;
    }

    private static double GetAverage(int[] array)
    {
        int average = 0;
        foreach (int item in array)
        {
            average += item;
        }
        if( array.Length == 0 )
        {
            return 0;
        }
        return average / array.Length;
    }

    private static bool ValidateNumber(out int n)
    {
        return int.TryParse(Console.ReadLine(), out n) && n >= 0 ? true : false;
    }

    private static bool ReadNumbers(int n, out int[] array)
    {
        array = new int[n];
        for(int i = 0; i < n; i++)
        {
            if (!int.TryParse(Console.ReadLine(), out array[i]) || array[i] < 0)
            {
                return false;
            }
        }
        return true;
    }
    public static void Main(string[] args)
    {
        if (!ValidateNumber(out int n) || !ReadNumbers(n, out int[] array))
        {
            Console.WriteLine("Incorrect input");
            return;
        }
        double averageNumber = GetAverage(array);
        int countAboveAverage = GetCountGreaterThanValue(array, averageNumber);
        Console.WriteLine(countAboveAverage);
    }
}