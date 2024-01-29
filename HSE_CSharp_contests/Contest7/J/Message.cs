using System;

internal class Message
{
    public string Text { get; set; }
    public string CreationTime { get; set; }
    public Message(string text, string creationTime)
    {
        Text = text;
        CreationTime = creationTime;
    }
    public override string ToString()
    {
        return $"[{CreationTime}] {Text}";
    }
}