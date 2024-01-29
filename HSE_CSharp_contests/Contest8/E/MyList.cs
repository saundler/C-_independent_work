using System;
using System.Linq;

internal class MyList<T>
{
    private T[] values;
    private int count = 0;
    public MyList()
    {
        values = new T[0];
    }

    public MyList(int capacity)
    {
        values = new T[capacity];
    }

    public int Count
    {
        get { return count; }
    }

    public int Capacity
    {
        get { return values.Length; }
    }

    public void Add(T element)
    {
        if (count == values.Length)
        {
            if (count == 0)
                Array.Resize(ref values, 4);
            else
                Array.Resize(ref values, count * 2);
        }
        values[count] = element;
        count++;
    }

    public T this[int x]
    {
        set
        {
            if (count - 1 < x)
                throw new IndexOutOfRangeException();
            values[x] = value;
        }
        get
        {
            if (count - 1 < x)
                throw new IndexOutOfRangeException();
            return values[x];
        }
    }

    public void Clear()
    {
        for (int i = 0; i < count; i++)
            values[i] = default(T);
        count = 0;
    }
    public void RemoveLast()
    {
        if (count == 0)
            throw new IndexOutOfRangeException();
        --count;
        values[count] = default(T);
    }

    public void RemoveAt(int index)
    {
        if (count - 1 < index)
            throw new IndexOutOfRangeException();
        for (int i = index; i < count; i++)
        {
            if (i + 1 < count)
                values[i] = values[i + 1];
        }
        --count;
        values[count] = default(T);
    }

    public T Max() 
    {
        if (count == 0)
            throw new IndexOutOfRangeException();
        if (values[0] is IComparable)
        {
            T max = default(T);
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                    max = values[i];
                if ((max as IComparable).CompareTo(values[i]) == -1)
                    max = values[i];
            }
            return max;
        }
        else
            throw new NotSupportedException("This operation is not supported for this type");
    }
    public override string ToString()
    {
        string str = "";
        for (int i = 0; i < count; i++)
            str += values[i] + " ";
        return str;
    }
}