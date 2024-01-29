using System;

public abstract class Gift
{
    public int Id { get; set; }
    protected Gift(int id)
    {
        Id = id;
    }
}

internal static class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var gifts = new Gift[n];
        for (int i = 0; i < n; i++)
        {
            gifts[i] = GiftCreator.CreateGift(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(gifts[i].Id);
        }
    }
}