using System;

class Calendar
{
    public event Action<DateTime> EveryDayNotification;

    public void Simulate(DateTime startTime, DateTime endTime)
    {
        for(DateTime i = startTime; i <= endTime; i = i.AddDays(1))
        {
            EveryDayNotification?.Invoke(i);
        }
    }
}