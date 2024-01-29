using System;
using System.Collections.Generic;

internal static class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        var firstPlanner = new Planner(ReadTasks(n));
        var secondPlanner = new Planner(ReadTasks(m));

        int k = int.Parse(Console.ReadLine());

        for (int i = 1; i <= k; i++)
        {
            var task = Task.Parse(Console.ReadLine());

            try
            {
                if (i % 4 == 0)
                {
                    firstPlanner += task;
                }
                else if (i % 4 == 1)
                {
                    firstPlanner -= task;
                }
                else if (i % 4 == 2)
                {
                    secondPlanner += task;
                }
                else
                {
                    secondPlanner -= task;
                }
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }
        if (k % 2 == 0)
        {
            Console.WriteLine(firstPlanner + secondPlanner);
        }
        else
        {
            Console.WriteLine(firstPlanner - secondPlanner);
        }

    }

    private static List<Task> ReadTasks(int count)
    {
        var tasks = new List<Task>(count);

        for (int i = 0; i < count; i++)
        {
            tasks.Add(Task.Parse(Console.ReadLine()));
        }

        return tasks;
    }
}