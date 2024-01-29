using System;

public partial class Program
{
    // Проверка входной даты на корректность.
    private static bool ValidateData(int day, int month, int year)
    {
        if (day > 0 && month > 0 && year > 1700 && month < 13 && year < 1801)
        {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day <= 31)
                {
                    return true;
                }
                return false;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day <= 30)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (year % 4 == 0 && year % 100 != 0 ? true : year % 400 == 0 ? true : false)
                {
                    if (day <= 29)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    if (day <= 28)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
        return false;
        throw new NotImplementedException();
    }

    // Получение дня недели по дате.
    private static int GetDayOfWeek(int day, int month, int year)
    {
        int monthcode = month == 1 || month == 10 ? 1 : month == 5 ? 2 : month == 8 ? 3 : month == 2 || month == 3 || month == 11 ? 4 : month == 6 ? 5 : month == 09 || month == 12 ? 6 : 0,
            helper = (int)(year % 100 / 4),
            yearcode = (2 + year % 100 + helper) % 7;
        if (year == 1800)
        {
            yearcode = 0;
        }
        else if (year % 4 == 0 && year % 100 != 0 ? true : year % 400 == 0 ? true : false)
        {
            if (month == 1 || month == 2)
            {
                monthcode--;
            }
        }
        return (day + monthcode + yearcode) % 7;
    }

    // Получение даты пятницы.
    private static string GetDateOfFriday(int dateOfWeek, int day, int month, int year)
    {
        int n = 4 - dateOfWeek;
        if (dateOfWeek > 4)
        {
            n = 11 - dateOfWeek;
        }
        if (n + day > 28)
        {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day + n > 31)
                {
                    day = day + n - 31;
                    month++;
                }
                else
                {
                    day += n;
                }
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day <= 30)
                {
                    if (day + n > 30)
                    {
                        day = day + n - 30;
                        month++;
                    }
                    else
                    {
                        day += n;
                    }
                }
            }
            else
            {
                if (year % 4 == 0 && year % 100 != 0 ? true : year % 400 == 0 ? true : false)
                {
                    if (day <= 29)
                    {
                        if (day + n > 29)
                        {
                            day = day + n - 29;
                            month++;
                        }
                        else
                        {
                            day += n;
                        }
                    }
                }
                else
                {
                    if (day <= 28)
                    {
                        if (day + n > 28)
                        {
                            day = day + n - 28;
                            month++;
                        }
                        else
                        {
                            day += n;
                        }
                    }
                }
            }
            if (month > 12)
            {
                month = 1;
                year++;
            }
        }
        else
        {
            day += n;
        }
        if (day > 9)
        {
            if (month > 9)
            {
                return $"{day}.{month}.{year}";
            }
            else
                return $"{day}.0{month}.{year}";
        }
        else
        {
            if (month > 9)
            {
                return $"0{day}.{month}.{year}";
            }
            else
                return $"0{day}.0{month}.{year}";
        }
        throw new NotImplementedException();
    }
}