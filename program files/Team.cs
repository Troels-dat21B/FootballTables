using System;
using System.Runtime.InteropServices;
class Team
{

    private int matches { get; set; }
    private int wins { get; set; }
    private int draws { get; set; }
    private int losses { get; set; }
    private int goalsFor { get; set; }
    private int goalsAgainst { get; set; }
    private int goalDifference { get; set; }
    private int points { get; set; }
    private string abriviation;
    private string fullName;
    private string? specialRanking;

    public string Abriviation
    {
        get { return abriviation; }
        set { abriviation = value; }
    }

    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }

    public string? SpecialRanking
    {
        get { return specialRanking; }
        set { specialRanking = value; }
    }

    public int Points
    {
        get { return points; }
        set { points = value; }
    }

    public Team(string abriviation, string fullName, string specialRanking)
    {
        this.abriviation = abriviation;
        this.fullName = fullName;
        this.specialRanking = specialRanking;
    }

    public int GoalDifference
    {
        get { return goalDifference; }
    }

    public int GoalsAgainst
    {
        get { return goalsAgainst; }
    }

    public int GoalsFor
    {
        get { return goalsFor; }
    }

    public int Losses
    {
        get { return losses; }
    }

    public int Draws
    {
        get { return draws; }
    }

    public int Wins
    {
        get { return wins; }
    }

    public int Matches
    {
        get { return matches; }
    }

    public Team addMatch(int goalsFor, int GoalsAgainst, [Optional] bool? wonMatch)
    {
        this.matches++;
        this.goalsFor += goalsFor;
        this.goalsAgainst += GoalsAgainst;
        this.goalDifference = this.goalsFor - this.goalsAgainst;


        switch (wonMatch)
        {
            case true:
                this.wins++;
                this.points += 3;
                break;
            case false:
                this.losses++;
                break;
            default:
                this.draws++;
                this.points++;
                break;
        }
        return this;
    }

    public Tuple<string, string, string?> teamInfo(Team t)
    {
        return new Tuple<string, string, string?>(t.abriviation, t.fullName, t.specialRanking);
    }



    public Tuple<string, Tuple<int, int, int, int, int, int, int, Tuple<int>>> getStats()
    {
        return new Tuple<string, Tuple<int, int, int, int, int, int, int, Tuple<int>>>(this.abriviation, new Tuple<int, int, int, int, int, int, int, Tuple<int>>(this.matches, this.wins, this.draws, this.losses, this.goalsFor, this.goalsAgainst, this.goalDifference, new Tuple<int>(this.points)));
    }

}