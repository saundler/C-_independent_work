using System;
internal static class DateTimeExtensions
{
    public static bool IsWeekend(this DateTime a)
    {
        return a.DayOfWeek == DayOfWeek.Sunday || a.DayOfWeek == DayOfWeek.Saturday;
    }
    public static bool IsWorkingDay(this DateTime a)
    {
        return !IsWeekend(a);
    }
    public static string NextDayOfWeek(this DateTime a)
    {
        a = a.AddDays(1);
        return a.DayOfWeek.ToString();
    }
    public static string DaysBetween(this DateTime a, DateTime b)
    {
        int n = (b - a).Days;
        if (n > 0)
            return $"{n} days in future";
        return $"{-1 * n} days ago";
    }
    public static string DayOfWeekSomeDaysFromCurrent(this DateTime a, int n)
    {
        a = a.AddDays(n);
        return a.DayOfWeek.ToString();
    }
}