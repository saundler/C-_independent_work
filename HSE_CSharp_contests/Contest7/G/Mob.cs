using System;

public class Mob
{
    public int HP { get; set; }
    public int Attack { get; set; }

    public Mob(int hp, int attack)
    {
        HP = hp;
        Attack = attack;
    }
    
    public void AttackMob(Mob other)
    {
        while(other.HP > 0 && HP > 0)
        {
            Console.WriteLine(other + " attacked " + this);
            Console.WriteLine(this + " attacked " + other);
            HP -= other.Attack;
            other.HP -= Attack;
        }
    }
}