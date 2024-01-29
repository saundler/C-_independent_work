using System;

internal sealed class Task
{
    public int taskId;
    public string title;
    public string description;
    private Task(string taskId, string title, string description)
    {
        this.taskId = int.Parse(taskId);
        this.title = title;
        this.description = description;
    }
    
    public static Task Parse(string line)
    {
        string[] str = line.Split(';');
        return new Task(str[1], str[2], str[3]);
    }
    
}