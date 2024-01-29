using System;

public class Monster : Mob
{
    public int Position { get; set; }
    public Monster(int hp, int attack, int position) : base(hp, attack)
    {
        Position = position;
    }
    public void AttackHero(Mob hero, int position)
    {
        if (position == Position)
        {
            Console.WriteLine($"Mario meet monster on {Position}");
            AttackMob(hero);
        }
    }
    public override string ToString()
    {
        return $"Monster with HP = {HP} and attack = {Attack}";
    }
}