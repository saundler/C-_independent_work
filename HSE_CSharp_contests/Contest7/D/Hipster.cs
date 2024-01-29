using System;

internal class Hipster
{
    public int money { get; set; }
    public int donate { get; set; }
    public Hipster(int money, int donate)
    {
        this.money = money;
        this.donate = donate;
    }

    public int GetMoneyDelegate()
    {
        if(money > 0)
        {
            money -= donate;
            return money > 0 ? donate : donate + money;
        }
        else
            return 0;
    }
}