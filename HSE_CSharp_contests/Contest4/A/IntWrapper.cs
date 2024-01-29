using System;

internal sealed class IntWrapper
{
    public int NumberLength;
    public IntWrapper(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Number should be non-negative.");
        }
        NumberLength = number.ToString().Length;
    }
    
}