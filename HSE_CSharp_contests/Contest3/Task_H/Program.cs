using System;
using System.Linq;

public partial class Program
{
   
    private static int[][] GetBellTriangle(uint rowCount)
    {
        int [][] result = new int[rowCount][];
        for (int i = 0; i< rowCount; i++)
        {
            if (i == 0)
            {
                result[i] = new int[1];
                result[i][i] = 1;
            }
            else
            {
                result[i] = new int[i + 1];
                for (int j = 0; j < (i + 1); j++)
                {
                    if (j == 0)
                    {
                        result[i][j] = result[i - 1][^1];
                    }
                    else
                    {
                        result[i][j] = result[i][j - 1] + result[i - 1][j - 1];
                    }
                }
            }
        }
        return result;
    }

    private static void PrintJaggedArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }
            Console.WriteLine("");
        }
    }
    /*public static void Main(string[] args)
    {
        uint rowCount = uint.Parse(Console.ReadLine());
        PrintJaggedArray(GetBellTriangle(rowCount));
    }*/
}

