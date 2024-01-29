using System;
using System.Collections.Generic;

internal sealed class Support
{
    private List<Task> fileMatrix;
    private static int count;
    public IEnumerable<Task> Tasks
    {
        get { return fileMatrix; }
    }



    public Support()
    {
        fileMatrix = new List<Task>();
        count = 1;
    }

    public int OpenTask(string text)
    {
        fileMatrix.Add(new Task(count, text));
        count++;
        return count - 1;
    }

    public void CloseTask(int id, string answer)
    {
        fileMatrix[id - 1].Answer = answer;
        fileMatrix[id - 1].IsResolved = true;
    }

    public List<Task> GetAllUnresolvedTasks()
    {
        List<Task> unresolvedTasks = new List<Task>();
        for(int i = 0; i < fileMatrix.Count; i++)
        {
            if(!fileMatrix[i].IsResolved)
            {
                unresolvedTasks.Add(fileMatrix[i]);
            }
        }
        return unresolvedTasks;
    }

    public void CloseAllUnresolvedTasksWithDefaultAnswer(string answer)
    {
        for(int i = 0; i < fileMatrix.Count; i++)
        {
            if(!fileMatrix[i].IsResolved)
            {
                fileMatrix[i].Answer = answer;
                fileMatrix[i].IsResolved = true;
            }
        }
    }

    public string GetTaskInfo(int id)
    {
        return fileMatrix[id - 1].ToString();
    }
}