using System;
using System.Collections.Generic;

public static class Methods
{
    public static int FindBestBiathlonistValue(List<Sportsman> sportsmen)
    {
        IShooter shooter;
        ISkiRunner runner;
        int chance = 0;
        for (int i = 0; i < sportsmen.Count; i++)
        {
            if(sportsmen[i] is Biathlonist)
            {
                shooter = sportsmen[i] as IShooter;
                runner = sportsmen[i] as ISkiRunner;
                if(chance < (int)(0.4 * Math.Max(shooter.Shoot(), runner.Run()) + 0.6 * Math.Min(shooter.Shoot(), runner.Run())))
                     chance = (int)(0.4 * Math.Max(shooter.Shoot(), runner.Run()) + 0.6 * Math.Min(shooter.Shoot(), runner.Run()));
            }
        }
        return chance;
    }
    public static int FindBestShooterValue(List<Sportsman> sportsmen)
    {
        IShooter shooter;
        int chance = 0;
        for (int i = 0; i < sportsmen.Count; i++)
        {
            if (sportsmen[i] is Shooter || sportsmen[i] is Biathlonist)
            {
                shooter = sportsmen[i] as IShooter;
                if (chance < shooter.Shoot())
                    chance = shooter.Shoot();
            }
        }
        return chance;
    }

    public static int FindBestRunnerValue(List<Sportsman> sportsmen)
    {
        ISkiRunner runner;
        int chance = 0;
        for (int i = 0; i < sportsmen.Count; i++)
        {
            if (sportsmen[i] is SkiRunner || sportsmen[i] is Biathlonist)
            {
                runner = sportsmen[i] as ISkiRunner;
                if(chance < runner.Run())
                 chance = runner.Run();
            }
        }
        return chance;
    }
}