using System;
using System.Collections.Generic;

internal sealed class Server
{
    public static bool isconnected;
    public static string Name;
    public static List<string> commands;
    public Server()
    {
        if (!isconnected)        
        {
            commands = new List<string>();
            isconnected = false;
        }
    }

    public Server(string name)
    {
        Name = name;
    }

    public static Server Connect(string name)
    {
        if (!isconnected)
        {
            isconnected = true;
            return new Server(name);
        }
        return new Server(Name);
    }

    public void Send(string message)
    {
        if (!isconnected)
        {
            throw new ArgumentException("No connected server");
        }
        commands.Add($"Sending data {message} to server {Name}");
    }

    public void Receive(string message)
    {
        if (!isconnected)
        {
            throw new ArgumentException("No connected server");
        }
        commands.Add($"Receiving data {message} from server {Name}");
    }

    public void Output()
    {
        if (!isconnected)
        {
            throw new ArgumentException("No connected server");
        }
        foreach (string command in commands)
        {
            Console.WriteLine(command);
        }
        commands = new List<string>();
    }
}


