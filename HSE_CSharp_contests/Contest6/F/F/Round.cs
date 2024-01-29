using System;
using System.Collections;
using System.Collections.Generic;

public class Round 
{
    public int amountOfMonsters;
    public int amountOfCrashes;
    public Round(int amountOfMonsters, int amountOfCrashes)
    {
        this.amountOfMonsters = amountOfMonsters;
        this.amountOfCrashes = amountOfCrashes;
    }

    public void Play()
    {
        
        for (int i = 0; i < Game.helpers.Count; i++)
        {
            if (Game.helpers[i] is Mario)
            {
                (Game.helpers[i] as IPlumber).FixPipe(ref amountOfCrashes);
                (Game.helpers[i] as IHero).KillMonster(ref amountOfMonsters);

            }
            else if (Game.helpers[i] is Hero)
            {
                (Game.helpers[i] as IHero).KillMonster(ref amountOfMonsters);
            }
            else if (Game.helpers[i] is Plumber)
            {
                (Game.helpers[i] as IPlumber).FixPipe(ref amountOfCrashes);
            }
        }
        if (amountOfMonsters > 0 || amountOfCrashes > 0)
        {
            if (amountOfMonsters > 0 && amountOfCrashes > 0)
            {
                Game.helpers.Add(new Mario());
            }
            else if (amountOfMonsters > 0)
            {
                Game.helpers.Add(new Hero());
            }
            else if( amountOfCrashes > 0)
            {
                Game.helpers.Add(new Plumber());
            }
            Console.WriteLine("Helpers lost this round!");
        }
        else
        {
            Console.WriteLine("Helpers won this round!");
        }
    }
}