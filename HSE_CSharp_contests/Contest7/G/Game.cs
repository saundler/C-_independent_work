using System;

public class Game
{
    public int CastlePosition { get; set; }
    public int CountOfMonsters { get; set; }

    private Hero hero;
    private Boss boss;

    public delegate void AttackHeroOnPosition(Mob mob, int position);

    public AttackHeroOnPosition attackHero;

    public Game(int castlePosition, int countOfMonsters, Hero hero, Boss boss)
    {
        CastlePosition = castlePosition;
        CountOfMonsters = countOfMonsters;
        this.hero = hero;
        this.boss = boss;
    }
    public void Play()
    {
        int n = hero.HP;
        for(int i = 0; i < CastlePosition; i++)
        {
            attackHero?.Invoke(hero, i);
            if(hero.HP < 1)
            {
                Console.WriteLine("You Lose! Game over!"); 
                return;
            }
        }
        boss.AttackMob(hero);
        if (hero.HP < 1)
            Console.WriteLine("You Lose! Game over!");
        else if(hero.HP >= ((n / (double)4) * 3))
            Console.WriteLine("You win! Princess released!");
        else
            Console.WriteLine("Thank you, Mario! But our princess is in another castle... You lose!");
    }
}