using System;
internal class Program
{
    private static void Main(string[] args)
    {
        object z = new ManInBlack();
        string[] info = Console.ReadLine().Split();
        switch (info[0])
        {
            case "Soldier":
                var soldier = info[1] switch
                {
                    "Soldier" => new Soldier(),
                    "CoolerSoldier" => new CoolerSoldier(),
                    "ManInBlack" => new ManInBlack(),
                    "ManInBlackBoss" => new ManInBlackBoss(),
                    _ => throw new NotImplementedException()
                };
                Console.WriteLine(soldier.Attack());
                break;
            case "ManInBlack":
                var manInBlack = info[1] switch
                {
                    "ManInBlack" => new ManInBlack(),
                    "ManInBlackBoss" => new ManInBlackBoss(),
                    _ => throw new NotImplementedException()
                };
                Console.WriteLine(manInBlack.Attack());
                break;
        }
    }
}