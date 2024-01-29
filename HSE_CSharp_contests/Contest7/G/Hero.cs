using System;

public class Hero : Mob
{
    public Hero(int hp, int attack) : base(hp, attack) { }

    public override string ToString()
    {
        return $"Mario with HP = {HP} and attack = {Attack}";
    }
}