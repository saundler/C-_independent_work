using System;

internal class Soldier
{
    public virtual string Attack()
    {
        return "Shoot from gun";
    }
}

internal sealed class CoolerSoldier : Soldier
{
    public override string Attack()
    {
        return "Shoot from gun and throw a grenade";
    }
}

internal class ManInBlack : Soldier
{
    public new virtual string Attack()
    {
        return "Shoot from blaster";
    }
}

internal sealed class ManInBlackBoss : ManInBlack
{
    public override string Attack()
    {
        return "Shoot from blaster and call an army of aliens";
    }
}