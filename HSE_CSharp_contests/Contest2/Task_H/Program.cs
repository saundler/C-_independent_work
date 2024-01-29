using System;
using System.Runtime;

public partial class Program
{
    // Метод для вычисление результата задачи в зависимости от дня недели.
    private static int MorningWorkout(string dayOfWeek, int firstNumber, int secondNumber)
    {
        int m = 0;
        if (secondNumber < 0)
            secondNumber *= -1;
        if(firstNumber < 0)
            firstNumber *= -1;  
        switch(dayOfWeek)
        {
            case "Monday":
            case "Wednesday":
            case "Friday":
                while (firstNumber != 0)
                {
                    if (firstNumber % 10 % 2 != 0)
                    {
                        m += firstNumber % 10;
                    }
                    firstNumber /= 10;
                }
                break;
            case "Tuesday":
            case "Thursday":
                while (secondNumber != 0)
                    {
                        if (secondNumber % 10 % 2 == 0)
                        {
                            m += secondNumber % 10;
                        }
                        secondNumber /= 10;
                    }
                break;
            case "Saturday":
                m = firstNumber >= secondNumber ? firstNumber : secondNumber;
                break;
            case "Sunday":
                m = firstNumber * secondNumber;
                break;
            default:
                return -1;
        }
        return m;
        throw new NotImplementedException();
    }
}
