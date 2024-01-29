using System;
using System.Collections.Generic;

public delegate int GetMoneyDelegate();

class Kikstarter
{
    List<GetMoneyDelegate> dl = new List<GetMoneyDelegate>();
    int m;

    public Kikstarter(int m, Hipster[] hipsters)
    {
        if (hipsters.Length < 1)
            throw new ArgumentException("Not enough hipsters");
        foreach (Hipster hipster in hipsters)
            dl.Add(hipster.GetMoneyDelegate);
        this.m = m;
    }

    public int Run()
    {
        int a = 0;
        int q = 0;
        while(m > 0)
        {
            a = m;
            q++;
            foreach(var l in dl)
            {
                m -= l();
            }
            if(a == m && m > 0)
            {
                throw new InvalidOperationException("Not enough money");
            }
        }
        return q;
    }
}