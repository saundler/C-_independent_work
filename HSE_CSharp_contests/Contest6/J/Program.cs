using System;
using System.Linq;
internal class Program
{
    private static void Main()
    {
        bool finder;
        int[] Arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse), tem = new int[Arr.Length];
        for (int i = 0; i < Arr.Length; i++)
        {
            finder = true;
            for (int j = i + 1; j < Arr.Length; j++)
            {
                if(Arr[j] > Arr[i])
                {
                    tem[i] = j - i; 
                    finder = false;
                    break;
                }
            }
            if(finder) 
                tem[i] = 0;
        }
        Console.WriteLine(string.Join(' ', tem));
    }
}