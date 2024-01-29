using System;

enum Rank
{
    Neophyte = 1,
    Adept,
    Charmer,
    Sorcerer,
    Master,
    Archmage,
}

internal sealed class Wizard : LegendaryHuman
{
    public Rank rank;
    public Wizard(string name, int healthPoints, int power, string rank) : base(name, healthPoints, power)
    {
        switch(rank)
        {
            case "Neophyte":
                this.rank = Rank.Neophyte;
                break;
            case "Adept":
                this.rank = Rank.Adept;
                break;
            case "Charmer":
                this.rank = Rank.Charmer;
                break;
            case "Sorcerer":
                this.rank = Rank.Sorcerer;
                break;
            case "Master":
                this.rank = Rank.Master;
                break;
            case "Archmage":
                this.rank = Rank.Archmage;
                break;
                default: throw new ArgumentException("Invalid wizard rank.");
        }
    }

    public override void Attack(LegendaryHuman enemy)
    {
        if(enemy.HealthPoints > 0 && HealthPoints > 0)
        {
            Console.WriteLine(ToString() + " attacked " + enemy.ToString() + ".");
            enemy.HealthPoints -= Power * (int)Math.Pow((int)rank, 1.5) + HealthPoints / 10;
            if (enemy.HealthPoints < 1)
            {
                Console.WriteLine(enemy.ToString() + " is dead.");
            }
        }
        return;
    }

    public override string ToString()
    {
        return $"{rank} Wizard {Name} with HP {HealthPoints}";
    }
}
