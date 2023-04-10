
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Game
{

    public string HomeTeam { get; set; }
    public string AwayTeam { get; set; }
    public int HomeTeamGoals { get; set; }
    public int AwayTeamGoals { get; set; }

    public bool isCancelled { get;}

    public Game(string homeTeam, string awayTeam, int homeTeamGoals, int awayTeamGoals)
    {
        this.HomeTeam = homeTeam;
        this.AwayTeam = awayTeam;
        this.HomeTeamGoals = homeTeamGoals;
        this.AwayTeamGoals = awayTeamGoals;
    }

    public Game(string homeTeam, string awayTeam, bool isCancelled)
    {
        this.HomeTeam = homeTeam;
        this.AwayTeam = awayTeam;
        this.isCancelled = isCancelled;
    }


    public Game()
    {
        this.HomeTeam = "";
        this.AwayTeam = "";
        this.HomeTeamGoals = 0;
        this.AwayTeamGoals = 0;
    }

    public string IsCancelled{
        get { return isCancelled.ToString(); }
    }
    
    public static Tuple<string, string, int, int> roundInfo(Game g)
    {
        return new Tuple<string, string, int, int>(g.HomeTeam, g.AwayTeam, g.HomeTeamGoals, g.AwayTeamGoals);
    }

}