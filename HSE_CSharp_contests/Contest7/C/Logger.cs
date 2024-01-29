using System;
using System.IO;

public delegate void Print(string line);

class Logger
{
    public void OutputLogs()
    {
    }
    public void MakeLog(Print method, string line)
    {
        method(line);
    }
}