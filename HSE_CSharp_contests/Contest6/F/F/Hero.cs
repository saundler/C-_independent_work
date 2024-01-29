public class Hero : IHero
{
    void IHero.KillMonster(ref int numberOfMonsters)
    {
        --numberOfMonsters;
    }
}