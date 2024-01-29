using System;

internal static class Methods
{
    public static T Max<T>(T a, T b)
    {
        return Convert.ToDouble(a) > Convert.ToDouble(b) ? a : b;
    }
}