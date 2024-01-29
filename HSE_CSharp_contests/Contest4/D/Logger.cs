using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

internal sealed class Logger
{
    static List<string> loggers = new List<string>();

    public static void HandleCommand(string command)
    {
        Regex regex = new Regex("AddLog <+[\\w\\d]+>");
        Match match = regex.Match(command);
        if (match.Success)
        {
            loggers.Add(match.Value[8..^1]);
        }
        else if (command.Contains("DeleteLastLog"))
        {
            if(loggers.Count < 1)
            {
                File.AppendAllText("logs.log", "No active logs\n");
                return;
            }
            loggers.RemoveAt(loggers.Count - 1);
        }
        else if (command.Contains("WriteAllLogs"))
        {
            if (loggers.Count < 1)
            {
                File.AppendAllText("logs.log", "No active logs\n");
                return;
            }
            File.AppendAllLines("logs.log", loggers);
            loggers = new List<string>();
        }
        else
        {
            File.AppendAllText("logs.log", "Incorrect input\n");
        }
    }
}