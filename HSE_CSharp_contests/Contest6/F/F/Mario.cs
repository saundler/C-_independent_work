public class Mario : IPlumber, IHero
{
    void IHero.KillMonster(ref int numberOfMonsters)
    {
        --numberOfMonsters;
    }
    void IPlumber.FixPipe(ref int numberOfCrashes)
    {
        --numberOfCrashes;
    }
}