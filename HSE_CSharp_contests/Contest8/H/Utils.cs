using System;
using System.Collections.Generic;
using System.Linq;

public static class Utils
{
    private static T Parse<T>(string value)
    {
        return (T) Convert.ChangeType(value, typeof(T));
    }

    private static List<T> ParseArguments<T>(string line, int expected)
    {
        var stringArguments = line.Split(' ');
        if (stringArguments.Length != expected)
        {
            throw new ArgumentException("number of arguments doesn't match expected number");
        }

        return stringArguments.Select(Parse<T>).ToList();
    }
    
    public static void ProcessRequest<TI, TO>(Func<TI, TO> randomFunc, string request, int expected)
    {
        try
        {
            var arguments = ParseArguments<TI>(request, expected);
            Console.WriteLine(randomFunc(arguments[0]));
        }    
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("incorrect format of argument");
        }
        catch (OverflowException)
        {
            Console.WriteLine("incorrect format of arguments");
        }
    }
    
    public static void ProcessRequest<T>(Func<T, T, T> randomFunc, string request, int expected)
    {
        try
        {
            var arguments = ParseArguments<T>(request, expected);
            var result = randomFunc(arguments[0], arguments[1]);
            Console.WriteLine(
                result is double ? $"{result:#.###}" :
                result is DateTime ? $"{result:d}" :
                result?.ToString()
            );
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("incorrect format of arguments");
        }
    }
}