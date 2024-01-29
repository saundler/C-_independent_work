using System;

internal static class Program
{
    private static void Main(string[] args)
    {
        var firstDateTime = DateTime.Parse(Console.ReadLine());
        var secondDateTime = DateTime.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());

        Console.WriteLine(firstDateTime.IsWeekend());
        Console.WriteLine(secondDateTime.IsWeekend());

        Console.WriteLine(firstDateTime.IsWorkingDay());
        Console.WriteLine(secondDateTime.IsWorkingDay());

        Console.WriteLine(firstDateTime.NextDayOfWeek());
        Console.WriteLine(secondDateTime.NextDayOfWeek());

        Console.WriteLine(firstDateTime.DaysBetween(secondDateTime));

        Console.WriteLine(firstDateTime.DayOfWeekSomeDaysFromCurrent(days));
        Console.WriteLine(secondDateTime.DayOfWeekSomeDaysFromCurrent(days));
    }
}
