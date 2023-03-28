using System;
using System.Runtime.InteropServices;
class Team
{

    //TODO: add AddGame method
    //TODO: add ToString method
    //TODO: add GetStats method
    //TODO: Refactor constructor/Delete constructor
private int matches { get; set;}
private int wins{ get; set;}
private int draws{ get; set;}
private int losses{ get; set;}
private int goalsFor{ get; set;}
private int goalsAgainst{ get; set;}
private int goalDifference{ get; set;}
private int points{ get; set;}
private string Abriviation{ get;}
private string FullName{ get;}
private string? SpecialRanking{ get;}


    public Team(string abriviation, string fullName, [Optional] string specialRanking){
        this.Abriviation = abriviation;
        this.FullName = fullName;
        this.SpecialRanking = specialRanking;
    }

    public Team addMatch (int goalsFor, int GoalsAgainst, [Optional] bool wonMatch){
        this.matches++;
        this.goalsFor += goalsFor;
        this.goalsAgainst += GoalsAgainst;
        this.goalDifference = this.goalsFor - this.goalsAgainst;


        switch(wonMatch){
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

    public Tuple<string, string, string> teamInfo(Team t) {
        return new Tuple<string, string, string>(t.Abriviation, t.FullName, t.SpecialRanking);
    }

}