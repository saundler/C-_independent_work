using System;

public class Sheep
{
    public int id;
    public string name;
    public string sound;
    public Sheep(int id, string name, string sound)
    {
        this.id = id;
        this.name = name;
        this.sound = sound;
    }

    public override string ToString()
    {
        return $"[{id}-{name}]: {sound}...{sound}";
    }
}