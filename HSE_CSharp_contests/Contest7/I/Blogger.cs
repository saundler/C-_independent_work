using System;

class Blogger
{
    public event Action<DateTime> Notification;

    public DayOfWeek PostingDay;
    public Blogger(DayOfWeek postDay)
    {
        PostingDay = postDay;
    }

    public void MakePost(DateTime date)
    {
        if(date.DayOfWeek == PostingDay)
            Notification?.Invoke(date);
    }
}