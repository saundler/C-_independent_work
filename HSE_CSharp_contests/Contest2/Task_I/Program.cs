using System;

public partial class Program
{
    // Проверка входных чисел на корректность.
    private static bool Validate(int a)
    {
        return a > 0 ? true : false;
        throw new NotImplementedException();
    }

    // Первое совершенное число в диапазоне от a до b, если такого числа нет – вернуть -1.
    private static int GetPerfectNumber(int a)
    {
        int sum, s = a;
        do
        {
            sum = 0;
            for (int i = 1; i < s; i++)
            {
                if (a % i == 0)
                {
                    sum += i;
                }
            }
            if (sum != s)
            {
                s++;
            }
        } while (sum != s) ;
        return s;
        throw new NotImplementedException();
    }
}