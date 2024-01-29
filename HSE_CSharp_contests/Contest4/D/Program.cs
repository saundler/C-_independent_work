using System;
using System.IO;


internal static class Program
{
    private static bool ParseCommandsCount(string input, out int count)
    {
        return int.TryParse(input, out count) && count > 0;
    }

    private static void Main(string[] args)
    {
        if (!ParseCommandsCount(Console.ReadLine(), out int count))
        {
            File.WriteAllText("logs.log", "Incorrect input");
            return;
        }
        
        for (int i = 0; i < count; i++)
        {
            Logger.HandleCommand(Console.ReadLine());
        }
    }
}