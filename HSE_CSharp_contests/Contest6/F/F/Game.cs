using System;
using System.Collections.Generic;

public class Game
{
    public static IList<IHelper> helpers = new List<IHelper>();
    private readonly int numberOfRounds;

    public Game(int numberOfHeroes, int numberOfPlumbers, int numberOfMarios, int numberOfRounds)
    {
        int[] a = new int[0];

        Mario mario;
        for (int i = 0; i < numberOfHeroes; i++)
        {
            helpers.Add(new Hero());
        }
        for (int i = 0; i < numberOfPlumbers; i++)
        {
            helpers.Add(new Plumber());
        }
        for (int i = 0; i < numberOfMarios; i++)
        {
            mario = new Mario();
            helpers.Add(mario);
        }
        this.numberOfRounds = numberOfRounds;
        
    }

    public void Play()
    {
        int[] a = new int[0];
        bool flag;
        for (int i = 0; i < numberOfRounds; i++)
        {
            flag = true;
            while (flag)
            {
                try
                {
                    a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    flag = a.Length != 2 ? throw new ArgumentException() : false;
                    if (a[0] < 0 || a[1] < 0)
                    {
                        throw new ArgumentException();
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect data!");
                    flag = true;
                }
            }
            new Round(a[0], a[1]).Play();
        }
    }
}