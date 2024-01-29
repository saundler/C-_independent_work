using System;
using System.Collections.Generic;

class Hipster
{
    public int departureDay { get; set; }
    public int arrivalDay { get; set; }
    public int PostsRead { get; private set; }

    public Hipster(int departureDay, int arrivalDay)
    {
        this.departureDay = departureDay;
        this.arrivalDay = arrivalDay;
        PostsRead = 0;
    }
    
    public void Subscribe(Blogger blogger)
    {
        blogger.Notification += ReadPost;
    }

    public void ReadPost(DateTime time)
    {
        if(!(time.Day >= departureDay && time.Day <= arrivalDay))
            PostsRead++;
    }
}