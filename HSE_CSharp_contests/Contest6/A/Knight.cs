using System;

internal sealed class Knight : LegendaryHuman
{
    public string[] Equpment;
    public Knight(string name, int healthPoints, int power, string[] equipment) : base(name, healthPoints, power)
    {
        if(equipment.Length < 1)
        {
            throw new ArgumentException("Not enough equipment.");
        }
        Equpment = equipment;
    }

    public override void Attack(LegendaryHuman enemy)
    {
        if (enemy.HealthPoints > 0 && HealthPoints > 0)
        {
            Console.WriteLine(ToString() + " attacked " + enemy.ToString() + ".");
            enemy.HealthPoints -= Power + 10 * Equpment.Length;
            if (enemy.HealthPoints < 1)
            {
                Console.WriteLine(enemy.ToString() + " is dead.");
            }
        }
        return;

    }

    public override string ToString()
    {
        return $"Knight {Name} with HP {HealthPoints}";
    }
}