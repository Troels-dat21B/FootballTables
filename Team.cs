using System;
using System.Runtime.InteropServices;
class Team
{

    //TODO: add AddGame method
    //TODO: add ToString method
    //TODO: add GetStats method
    //TODO: Refactor constructor/Delete constructor
private int matches { get;}
private int wins{ get;}
private int draws{ get;}
private int losses{ get;}
private int goalsFor{ get;}
private int goalsAgainst{ get;}
private int goalDifference{ get;}
private int points{ get;}

    public Team([Optional]bool wins, [Optional] bool draws, [Optional] bool losses)
    {
        this.matches++;
        this.goalsFor += goalsFor;
        this.goalsAgainst += goalsAgainst;

        if (wins)
        {
            this.wins++;
            this.points += 3;
        }
        else if (losses)
        {
            this.losses++;
        }
        else if (draws)
        {
            this.draws++;
            this.points++;
        }

        this.goalDifference = this.goalsFor - this.goalsAgainst;
    }

}