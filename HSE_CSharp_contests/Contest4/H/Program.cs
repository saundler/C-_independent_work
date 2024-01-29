using System;
using System.Collections.Generic;

internal static partial class Program
{
    private static void Main(string[] args)
    {
        string favouriteName = Console.ReadLine();

        int n = int.Parse(Console.ReadLine());
        var sheep = new List<Sheep>(n);

        for (int i = 0; i < n; i++)
        {
            try
            {
                sheep.Add(ParseSheep(Console.ReadLine()));
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }

        var grassland = new Grassland(sheep);

        PrintSheep(grassland.GetEvenSheep());
        PrintSheep(grassland.GetOddSheep());
        PrintSheep(grassland.GetSheepByName(favouriteName));
    }

    private static void PrintSheep(List<Sheep> sheep)
    {
        foreach (var animal in sheep)
        {
            Console.WriteLine(animal);
        }
    }
}