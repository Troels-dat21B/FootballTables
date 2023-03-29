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
private string abriviation{ get;}
private string fullName{ get;}
private string? specialRanking{ get;}

  

    public Team(string abriviation, string fullName, [Optional] string specialRanking){
        this.abriviation = abriviation;
        this.fullName = fullName;
        this.specialRanking = specialRanking;
    }

    public Team addMatch (int goalsFor, int GoalsAgainst, [Optional] bool? wonMatch){
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

    public Tuple<string, string, string?> teamInfo(Team t) {
        return new Tuple<string, string, string?>(t.abriviation, t.fullName, t.specialRanking);
    }

    public Tuple<int, int, int, int, int, int, int, Tuple<int>> getStats(){
        return new Tuple<int, int, int, int, int, int, int, Tuple<int>>(this.matches, this.wins, this.draws, this.losses, this.goalsFor, this.goalsAgainst, this.goalDifference, new Tuple<int>(this.points));
    }

}