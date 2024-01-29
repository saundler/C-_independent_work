using System;
using System.Collections.Generic;
using System.Linq;

internal sealed class Planner
{
    public List<Task> tasks;
    public Planner(List<Task> tasks)
    {
        this.tasks = tasks;
    }
    public static Planner operator +(Planner a, Task b)
    {
        foreach(Task t in a.tasks)
        {
            if(t.taskId == b.taskId)
            {
                throw new ArgumentException("This task is already present");
            }
        }
        a.tasks.Add(b);
        return a;
    }
    public static Planner operator -(Planner a, Task b)
    {
        for (int i = 0; i < a.tasks.Count; i++)
        {
            if (a.tasks[i].taskId == b.taskId)
            {
                a.tasks.RemoveAt(i);
                return a;
            }
        }
        throw new ArgumentException("This task does not exist in the list");
    }
    public static Planner operator +(Planner a, Planner b)
    {
        foreach (Task t in b.tasks)
        {
            if (!Planner.IsExist(a, t))
            {
                a = a + t;
            }
        }
        return a;
    }
    public static Planner operator -(Planner a, Planner b)
    {
        foreach (Task t in b.tasks)
        {
            if(Planner.IsExist(a, t))
            {
                a = a - t;
            }
        }
        return a;
    }
    public static bool IsExist(Planner a, Task b)
    {
        foreach(Task n in a.tasks)
        {
            if (n.taskId == b.taskId)
            {
                return true;
            }
        }
        return false;
    }
    public override string ToString()
    {
        string str = "Planner: ";
        foreach (Task x in tasks)
        {
            str += $"Task [id = '{x.taskId}', title = '{x.title}', description = '{x.description}'], ";
        }
        str = str.Substring(0,str.Length - 2);
        return str;
    }
}
/*This task does not exist in the list
Planner: Task[id = '1', title = 'C# note', description = 'need make peergrade'], Task[id = '2', title = 'Home tasks', description = 'linear algebra deadline']*/