using System;
using System.Text.RegularExpressions;

internal sealed class ReplacedString
{
    private string newS;
    public ReplacedString(string s, string initialSubstring, string finalSubstring)
    {
        string compare = s;
        do
        {
            s = compare;
            compare = s.Replace(initialSubstring, finalSubstring);
        } while (compare != s);
        newS = s;
    }

    public override string ToString()
    {
        return newS;
    }

}