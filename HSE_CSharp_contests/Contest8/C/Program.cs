using System;
using System.Collections.Generic;

class Program
{
    private static void Assign(string type)
    {
        try
        {
            if (type == "int")
            {
                Singleton<List<int>>.Instance = new List<int>();
            }
            else
            {
                Singleton<List<string>>.Instance = new List<string>();
            }
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void Print(string type)
    {
        if (type == "int")
        {
            Singleton<List<int>>.Instance.ForEach(x => Console.Write($"{x} "));
        }
        else
        {
            Singleton<List<string>>.Instance.ForEach(x => Console.Write($"{x} "));
        }

        Console.WriteLine();
    }

    private static void Add(string type, string val)
    {
        if (type == "int")
        {
            Singleton<List<int>>.Instance.Add(int.Parse(val));
            return;
        }

        Singleton<List<string>>.Instance.Add(val);
    }
    
    public static void Main(string[] args)
    {
        string s;
        while ((s = Console.ReadLine()) != null)
        {
            string[] command = s.Split();
            switch (command[0])
            {
                case "add":
                    Add(command[1], command[2]);
                    break;
                case "print":
                    Print(command[1]);
                    break;
                case "assign":
                    Assign(command[1]);
                    break;
            }
        }
    }
}