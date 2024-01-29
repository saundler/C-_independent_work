using System;

internal sealed class File
{
    private readonly string name;
    private readonly int size;

    public File(string name, int size)
    {
        Name = name;
        Size = size;
    }

    public File(File file) : this(file.name, file.size)
    {

    }

    public string Name
    {
        get => name;
        private init
        {
            if (value.Length is <= 0 or >= 15)
            {
                throw new ArgumentException("Incorrect file name");
            }

            name = value;
        }
    }

    private int Size
    {
        get => size;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentException("Incorrect file size");
            }

            size = value;
        }
    }

    public override string ToString()
    {
        return $"{name,-15} {size,5}";
    }
}