using System;

class Citizen : IPessimist, IOptimist
{
    public int predictedValue;
    public Citizen(int predictedValue)
    {
        this.predictedValue = predictedValue;
    }

    public double GetForecast()
    {
        return (double)predictedValue * 1.1;
    }

    double IPessimist.GetForecast()
    {
        return (double)predictedValue * 0.6;
    }

    double IOptimist.GetForecast()
    {
        return (double)predictedValue * 2;
    }

    internal static Citizen Parse(string input)
    {
        int n;
        if(!int.TryParse(input, out n) || n < 1)
        {
            throw new ArgumentException("Incorrect input");
        }
        return new Citizen(n);
    }
}