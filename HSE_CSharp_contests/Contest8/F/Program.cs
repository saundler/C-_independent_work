using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    private static List<(TKey, TValue)> ParsePairs<TKey, TValue>(List<(string, string)> data) =>
        (from argumentPair in data
         let key = (TKey)Convert.ChangeType(argumentPair.Item1, typeof(TKey))
         let value = (TValue)Convert.ChangeType(argumentPair.Item2, typeof(TValue))
         select (key, value))
        .ToList();

    private static List<TKey> ParseKeys<TKey>(List<string> data) =>
        (from argument in data
         let key = (TKey)Convert.ChangeType(argument, typeof(TKey))
         select key)
        .ToList();

    public static void TestMap<TKey, TValue>(List<(string, string)> pairs, List<string> keys, List<string> keysToRemove)
    {
        var map = new Map<TKey, TValue>();

        var parsedPairs = ParsePairs<TKey, TValue>(pairs);
        foreach (var (key, value) in parsedPairs)
        {
            try
            {
                map.Add(key, value);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(map.Count);

        var parsedKeys = ParseKeys<TKey>(keys);
        foreach (var key in parsedKeys)
        {
            Console.WriteLine(map.ContainsKey(key));

            try
            {

                Console.WriteLine(map[key]);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        var parsedKeysToRemove = ParseKeys<TKey>(keysToRemove);
        foreach (var key in parsedKeysToRemove)
        {
            Console.WriteLine(map.Remove(key));
            Console.WriteLine(map.Count);
        }
    }

    private const string InputPath = "input.txt";

    public static void Main(string[] args)
    {
        using (var sr = new StreamReader(InputPath))
        {
            string[] mapInfo = sr.ReadLine().Split();
            var pairsToAdd = new List<(string, string)>();
            var keysToCheck = new List<string>();
            var keysToRemove = new List<string>();

            int batchSize = int.Parse(sr.ReadLine().Split()[1]);
            for (int i = 0; i < batchSize; ++i)
            {
                var argumentPair = sr.ReadLine().Split();
                pairsToAdd.Add((argumentPair[0], argumentPair[1]));
            }

            batchSize = int.Parse(sr.ReadLine().Split()[1]);
            for (int i = 0; i < batchSize; ++i)
            {
                keysToCheck.Add(sr.ReadLine());
            }

            batchSize = int.Parse(sr.ReadLine().Split()[1]);
            for (int i = 0; i < batchSize; ++i)
            {
                keysToRemove.Add(sr.ReadLine());
            }
            TestMap<string, string>(pairsToAdd, keysToCheck, keysToRemove);
        }
    }
}

