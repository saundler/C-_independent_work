using System;
using System.Collections.Generic;

class Program 
{

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        try
        {
            List<Citizen> citizens = GetCitizens(n);
            foreach (var citizen in citizens)
            {
                Console.WriteLine(GetForecasts(citizen));
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static string GetForecasts(Citizen citizen)
    {
        return string.Format("{0:f3} {1:f3} {2:f3}", ((IPessimist)citizen).GetForecast(),
            citizen.GetForecast(),
            ((IOptimist)citizen).GetForecast());
    }

    
    private static List<Citizen> GetCitizens(int n)
    {
        List<Citizen> citizens = new List<Citizen>();
        for (int i = 0; i < n; i++)
        {
            citizens.Add(Citizen.Parse(Console.ReadLine()));
        }

        return citizens;
    }
}