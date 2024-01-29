using System;
using System.Collections.Generic;

internal class Company
{
    public Company(int teamLeadsAmount, int[] programmersAmount)
    {
        TeamLeads = new List<TeamLead>();
        List<Programmer> programmers;
        for (int i = 1; i <= teamLeadsAmount; i++)
        {
            programmers = new List<Programmer>();
            for (int j = 1; j <= programmersAmount[i - 1]; j++)
            {
                programmers.Add(new Programmer(int.Parse($"{i}{j}")));
            }
            TeamLeads.Add(new TeamLead(i, programmers));
        }
    }
    public List<TeamLead> TeamLeads;

    public void PrintTeams()
    {
        foreach (var teamLead in TeamLeads)
        {
            Console.WriteLine(teamLead);
            Console.WriteLine("Written lines of code: {0}", teamLead.GetWrittenLinesOfCode());
        }

        Console.WriteLine();
    }
}