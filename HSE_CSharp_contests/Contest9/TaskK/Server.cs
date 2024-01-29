using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

internal class Server
{
    static Server() 
    {
        CultureInfo.CurrentCulture = new CultureInfo("ru");
    }

    public static void ProcessAuthorization(string requestsPath, string requestsResultsPath)
    {
        var Users = new Dictionary<string, (DateTime, DateTime, DateTime, bool)>(); // узах увых нзах бан
        foreach (var user in UserDb.Users)
            Users.Add(user.Key, (default(DateTime), default(DateTime), default(DateTime), false));
        string[] str;
        using (StreamReader sr = new StreamReader(requestsPath))
        using (StreamWriter sw = new StreamWriter(requestsResultsPath))
        {
            while (!sr.EndOfStream)
            {
                str = sr.ReadLine().Split(' ');
                switch (str[0])
                {
                    case "SI":
                        if (!UserDb.Users.ContainsKey(str[1]))
                        {
                            sw.WriteLine($"{str[1]}> no user with such login");
                            break;
                        }
                        if (Users[str[1]].Item4)
                        {
                            sw.WriteLine($"{str[1]}> account blocked due suspicious login attempt");
                            break;
                        }
                        if (Users[str[1]].Item1 != default(DateTime) &&
                            (Users[str[1]].Item2 == default(DateTime) || Users[str[1]].Item2 < Users[str[1]].Item1) &&
                            (DateTime.Parse($"{str[3]} {str[4]}") - Users[str[1]].Item1) < new TimeSpan(24, 0, 0))
                        {
                            sw.WriteLine($"{str[1]}> account blocked due suspicious login attempt");
                            Users[str[1]] = (Users[str[1]].Item1, Users[str[1]].Item2, Users[str[1]].Item3, true);
                            break;
                        }
                        if (UserDb.Users[str[1]] != str[2])
                        {
                            if (Users[str[1]].Item3 != default(DateTime) && (DateTime.Parse($"{str[3]} {str[4]}") - Users[str[1]].Item3) < new TimeSpan(1, 0, 0))
                            {
                                sw.WriteLine($"{str[1]}> account blocked due suspicious login attempt");
                                Users[str[1]] = (Users[str[1]].Item1, Users[str[1]].Item2, Users[str[1]].Item3, true);
                            }
                            else
                            {
                                sw.WriteLine($"{str[1]}> incorrect password");
                                Users[str[1]] = (Users[str[1]].Item1, Users[str[1]].Item2, DateTime.Parse($"{str[3]} {str[4]}"), Users[str[1]].Item4);
                            }
                        }
                        else
                        {
                            sw.WriteLine($"{str[1]}> sign in successful");
                            Users[str[1]] = (DateTime.Parse($"{str[3]} {str[4]}"), Users[str[1]].Item2, Users[str[1]].Item3, Users[str[1]].Item4);
                        }
                        break;
                    case "SO":
                        if (!UserDb.Users.ContainsKey(str[1]))
                        {
                            sw.WriteLine($"{str[1]}> no user with such login");
                            break;
                        }
                        if (Users[str[1]].Item4)
                        {
                            sw.WriteLine($"{str[1]}> account blocked due suspicious login attempt");
                        }
                        else
                        {
                            sw.WriteLine($"{str[1]}> sign out successful");
                            Users[str[1]] = (Users[str[1]].Item1, DateTime.Parse($"{str[2]} {str[3]}"), Users[str[1]].Item3, Users[str[1]].Item4);
                        }
                        break;
                }
            }
        }
    }
}