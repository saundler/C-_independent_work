using System;
using System.Collections.Generic;

internal class TeamLead : Programmer
{
    private List<Programmer> programmers;

    public TeamLead(int id, List<Programmer> programmers) : base(id)
    {
        this.programmers = programmers;
    }
    
    public void HuntProgrammers(List<TeamLead> teamLeads)
    {
        for (int i = 0; i < teamLeads.Count; i++)
        {
            if(id == i + 1)
            {
                continue;
            }
            for(int j = 0; j < teamLeads[i].programmers.Count; j++)
            {
                if (teamLeads[i].programmers[j].linesOfCode % (id + 1) == 0)
                {
                    programmers.Add(teamLeads[i].programmers[j]);
                    teamLeads[i].programmers.RemoveAt(j);
                    j--;
                }
            }
        }
    }

    public override string ToString()
    {
        return $"Team lead #{id}\nAmount of programmers in team: {programmers.Count}";
    }
    public int GetWrittenLinesOfCode()
    {
        int alllines = linesOfCode;
        for(int i = 0; i < programmers.Count; i++)
        {
            alllines += programmers[i].linesOfCode;
        }
        return alllines;
    }
}