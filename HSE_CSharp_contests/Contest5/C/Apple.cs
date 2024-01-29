using System;

internal sealed class Apple
{
    private double weight;
    private string color;
    public double Weight 
    { 
        get
        {
            return weight;
        }
        set
        {
            if (value <= 0 || value > 1000)
            {
                throw new ArgumentException("Incorrect input");
            }
            weight = value;
        } 
    }
    
    public string Color
    { 
        get
        {
            return color;
        }
        set
        {
            if(value.Length > 5 || value[0].ToString() == value[0].ToString().ToLower())
            {
                throw new ArgumentException("Incorrect input");
            }
            color = value;
        }
    }
    public override string ToString()
    {
        return $"{Color} Apple. Weight = {Weight:F2}g.";
    }
}