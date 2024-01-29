using System;

internal class Programmer
{
    public readonly int id;
    public readonly int linesOfCode;

    private int GetAlmostRandomNumber() => (int) Math.Abs(Math.Sin(GetIdDigitsSum() % 11 + 1) * 12345);

    public Programmer(int id)
    {
        this.id = id;
        linesOfCode = GetAlmostRandomNumber();
    }

    private int GetIdDigitsSum()
    {
        var sum = 0;
        var idCopy = id;
        while (idCopy != 0)
        {
            sum += idCopy % 10;
            idCopy /= 10;
        }
        return sum;
    }
    
    public override string ToString()
    {
        return $"Id: {id}\nLines of code: {linesOfCode}";
    }
}