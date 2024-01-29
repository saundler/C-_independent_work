using System;

public partial class Program
{
    // Проверка входного числа на корректность.
    private static bool Validate(int n)
    {
        return n > 0 ? true : false;
        throw new NotImplementedException();
    }

    // Сумма делителей числа N (делители строго меньше N).
    private static int DivisorsSum(int n)
    {
        int sum = 0;
        for (int i = 1; i < n; i++)
        {
            if (n % i == 0)
            {
                sum += i;
            }
        }
        return sum;
        throw new NotImplementedException();
    }
}
