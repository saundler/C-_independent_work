using System;
using System.Linq;

public partial class Program
{
    private static bool TryParseInput(string inputA, string inputB, out int a, out int b)
    {
        if (int.TryParse(inputA, out a) & int.TryParse(inputB, out b) && a >= 0 && b >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        throw new NotImplementedException();
    }
    private static void SwapMaxDigit(ref int a, ref int b)
    {
        int[] ArrA = new int[a.ToString().Length];
        int[] ArrB = new int[b.ToString().Length];
        int raz = 10;
        for (int i = 0; i < ArrA.Length; i++)
        {
            ArrA[i] = a % raz / (raz / 10);
            raz *= 10;
        }
        raz = 10;
        for (int i = 0; i < ArrB.Length; i++)
        {
            ArrB[i] = b % raz / (raz / 10);
            raz *= 10;
        }
        int maxA = ArrA.Max(), maxB = ArrB.Max();    
        for (int i = 0; i < ArrA.Length; i++)
        {
            if (ArrA[i] == maxA)
            {
                ArrA[i] = maxB;
            }
        }
        for (int i = 0; i < ArrB.Length; i++)
        {
            if (ArrB[i] == maxB) 
            {
                ArrB[i] = maxA;
            }
        }
        raz = 1;
        a = 0;
        b = 0; 
        foreach (int element in ArrA)
        {
            a += element * raz;
            raz *= 10;
        }
        raz = 1;
        foreach (int element in ArrB)
        {
            b += element * raz;
            raz *= 10;
        }
    }
    public static void Main(string[] args)
    {
        if (!TryParseInput(Console.ReadLine(), Console.ReadLine(), out var a, out var b))
        {
            Console.WriteLine("Incorrect input");
        }
        else
        {
            SwapMaxDigit(ref a, ref b);

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}