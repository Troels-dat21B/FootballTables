
public class Game{

    public String HomeTeam { get; set; }
    public String AwayTeam { get; set; }
    public int HomeTeamGoals { get; set; }
    public int AwayTeamGoals { get; set; }

    public Game(String homeTeam, String awayTeam, int homeTeamGoals, int awayTeamGoals){
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        HomeTeamGoals = homeTeamGoals;
        AwayTeamGoals = awayTeamGoals;
    }   

}