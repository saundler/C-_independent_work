using System;

internal static class TemperatureCalculator
{
    public static double FromCelsiusToFahrenheit(double celsiusTemperature)
    {
        return celsiusTemperature > -273.15 ? celsiusTemperature * 9 / 5 + 32 : throw new ArgumentException("Incorrect input");
    }

    public static double FromCelsiusToKelvin(double celsiusTemperature)
    {
        return celsiusTemperature > -273.15 ? celsiusTemperature + 273.15 : throw new ArgumentException("Incorrect input");
    }
    public static double FromFahrenheitToCelsius(double fahrenheitTemperature)
    {
        return fahrenheitTemperature > -459.67 ? (fahrenheitTemperature - 32) * 5 / 9 : throw new ArgumentException("Incorrect input");
    }

    public static double FromFahrenheitToKelvin(double fahrenheitTemperature)
    {
        return fahrenheitTemperature > -459.67 ? (fahrenheitTemperature - 32) * 5 / 9 + 273.15 : throw new ArgumentException("Incorrect input");
    }

    public static double FromKelvinToCelsius(double kelvinTemperature)
    {
        return kelvinTemperature > 0 ? kelvinTemperature - 273.15 : throw new ArgumentException("Incorrect input");
    }

    public static double FromKelvinToFahrenheit(double kelvinTemperature)
    {
        return kelvinTemperature > 0 ? (kelvinTemperature - 273.15) * 9 / 5 + 32 : throw new ArgumentException("Incorrect input");
    }
}