using System;
using System.Linq;
using System.Collections;

internal sealed class Worker
{
    public Apple[] Apples = new Apple[0];
    public Worker(Apple[] apples)
    {
        Apples = apples;
    }

    public Apple[] GetSortedApples()
    {
        return Apples.OrderBy(Apple => Apple.Weight).ToArray();
    }

}