using System;
using System.Collections.Generic;

internal static class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var apples = new List<Apple>(n);

        for (int i = 0; i < n; i++)
        {
            var words = Console.ReadLine().Split(' ');
            try
            {
                apples.Add(new Apple()
                {
                    Weight = double.Parse(words[0]),
                    Color = words[1]
                });
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }

        var worker = new Worker(apples.ToArray());

        foreach (var sortedApple in worker.GetSortedApples())
        {
            Console.WriteLine(sortedApple);
        }
    }
}