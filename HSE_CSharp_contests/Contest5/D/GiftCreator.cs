using System;

internal static class GiftCreator
{
    public static int PhoneId = 0;
    public static int PSId = 0;
    public static Gift CreateGift(string giftName)
    {
        if (giftName == "Phone")
        {
            return new Phone(PhoneId++);
        }
        else if (giftName == "PlayStation")
        {
            return new PlayStation(PSId++);
        }
        throw new ArgumentException("Incorrect input");
    }
}

internal sealed class Phone : Gift
{
    public Phone(int id) : base(id) { }
}

internal sealed class PlayStation : Gift
{
    public PlayStation(int id) : base(id) { }
}