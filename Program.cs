using System;
using System.IO;
using System.Linq;
using System.Globalization;

class FileReader
{
    static void Main()
    {
        csvAllRoundsReader();
        csvTeamReader();
        //Table();
        Round();

    }

    public static List<Game> csvAllRoundsReader()
    {

        List<Game> allGameRounds = new List<Game>();
        try
        {
            foreach (string file in Directory.EnumerateFiles("./csv filer/Rounds", "*.csv"))
            {

                using (StreamReader reader = new StreamReader(file))
                {

                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();
                        string[] values = line.Split(',');

                        Game tuple = new Game(values[0], values[1], int.Parse(values[2]), int.Parse(values[3]));
                        allGameRounds.Add(tuple);

                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("CSV file not found.");
            Console.WriteLine(e.Message);
        }

        return allGameRounds;
    }

    public static List<Team> csvTeamReader()
    {

        List<Team> teams = new List<Team>();
        try
        {

            foreach (string file in Directory.EnumerateFiles("./csv filer", "Teams.csv"))
            {

                using (StreamReader reader = new StreamReader(file))
                {

                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();
                        string[] values = line.Split(',');

                        Team tuple = new Team(values[0], values[1], values[2]);
                        teams.Add(tuple);

                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("CSV file not found.");
            Console.WriteLine(e.Message);
        }


        return teams;
    }

    public static void Table()
    {
        List<Team> teams = csvTeamReader();

        Console.WriteLine("Position  Club                       M  W  D  L  GF  GA  GD  Points  Streak");
        Console.WriteLine("---------------------------------------------------------------------------");

        foreach (Team t in teams)
        {

            Console.WriteLine($"{t.Abriviation} {t.FullName} {t.SpecialRanking}");
        }

    }

    public static void Round()
    {
        List<Game> allGameRounds = csvAllRoundsReader();
        List<Team> teams = csvTeamReader();

        allGameRounds.Sort((x, y) => x.HomeTeam.CompareTo(y.HomeTeam));
        teams.Sort((x, y) => x.Abriviation.CompareTo(y.Abriviation));

        foreach (Game g in allGameRounds)
        {
            //Use addMatch from Team.cs on the teams list.
            //ignore away team name, but keep the goals
            //If statement to check who won the match

            foreach (Team t in teams)
            {
                Console.WriteLine(t.Abriviation);
                if (t.Abriviation.ToLower() == g.HomeTeam.ToLower())
                {
                    if (g.HomeTeamGoals > g.AwayTeamGoals)
                    {
                        t.addMatch(g.HomeTeamGoals, g.AwayTeamGoals, true);
                    }else if(g.HomeTeamGoals < g.AwayTeamGoals){
                        t.addMatch(g.HomeTeamGoals, g.AwayTeamGoals, false);
                    }else{
                        t.addMatch(g.HomeTeamGoals, g.AwayTeamGoals);
                    }
                }

            }
        }

        foreach (Team t in teams)
        {
            Console.WriteLine(t.getStats());
        }
    }

}
