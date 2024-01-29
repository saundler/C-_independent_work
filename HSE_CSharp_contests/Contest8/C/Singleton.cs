using System;
using System.Collections.Generic;

static class Singleton<T> where T :  class, new()
{
    private static T exem;
    static Singleton()
    {
        exem = new T();
    }
    public static T Instance
    {
        get { return exem; }
        set 
        {
            throw new NotSupportedException("This operation is not supported");
        }
    }
}