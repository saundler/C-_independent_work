using System;

public partial class Program
{
    // Вычисление факториала.
    private static int Factorial(int value)
    {
        int factorial = 1;
        if (value != 0)
        {
            for (int i = 1; i <= value; i++)
            {
                factorial *= i;
            }
        }
        return factorial;
        throw new NotImplementedException();
    }
    // Проверка входного числа на корректность.
    private static bool IsInputNumberCorrect(int number)
    {
        return number < 0 || number > 12 ? false : true;  
        throw new NotImplementedException();
    }
}