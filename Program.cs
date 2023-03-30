using System;
using System.IO;
using System.Linq;
using System.Globalization;

class FileReader
{
    static void Main(string[] args)
    {
        csvAllRoundsReader();
        csvTeamReader();
        Round();
        //Table();
        //testPrint();

        Console.WriteLine("Write the abbreviation of the team you want to see the results of: ");
        string? team = Console.ReadLine();

        foreach(Team t in csvTeamReader()){
            
            if(string.Equals(t.Abriviation, team, StringComparison.OrdinalIgnoreCase)){
                Console.WriteLine(t.Abriviation + " | " + t.FullName + " | " + t.SpecialRanking);
            }
            else if(string.Equals("all", team, StringComparison.OrdinalIgnoreCase)){
                Console.WriteLine(t.Abriviation + " | " + t.FullName + " | " + t.SpecialRanking);
            }
            else{
                Console.WriteLine("Team not found.");
            }
        }
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
        Console.ForegroundColor = ConsoleColor.Black;
        List<Team> teams = csvTeamReader();

        Console.WriteLine("Club  Name                      Rank");
        Console.WriteLine("------------------------------------");

        foreach (Team t in teams)
        {

            switch (t.SpecialRanking)
            {
                case "N":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "C":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "P":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "W":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine($"{t.Abriviation,-3} | {t.FullName,-25} | {t.SpecialRanking}");
            Console.WriteLine($"{t.Abriviation} {t.FullName} {t.SpecialRanking}");
        }
        Console.ForegroundColor = ConsoleColor.Black;

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

            //TODO - Dette stykke kode tjekker ikke om for udebane kampe. Så 16 kampe bliver ikke redegjort for.

            foreach (Team t in teams)
            {

                if (t.Abriviation.ToLower() == g.HomeTeam.ToLower())
                {
                    if (g.HomeTeamGoals > g.AwayTeamGoals)
                    {
                        t.addMatch(g.HomeTeamGoals, g.AwayTeamGoals, true);
                    }
                    else if (g.HomeTeamGoals < g.AwayTeamGoals)
                    {
                        t.addMatch(g.HomeTeamGoals, g.AwayTeamGoals, false);
                    }
                    else
                    {
                        t.addMatch(g.HomeTeamGoals, g.AwayTeamGoals);
                    }
                }

            }
        }

        Console.WriteLine("Før point sortering");

        foreach (Team t in teams)
        {

            Console.WriteLine(t.getStats());
        }

        teams.Sort((x, y) => y.Points.CompareTo(x.Points)); //<---- Sorterer efter point flest til mindst
        Console.WriteLine("Efter point sortering");

        foreach (Team t in teams)
        {

            Console.WriteLine(t.getStats());
        }
    }


    public static void testPrint() {
        List<Game> allGameRounds = csvAllRoundsReader();
        foreach(Game g in allGameRounds){
            if(g.HomeTeam == "AAB" && g.HomeTeamGoals > g.AwayTeamGoals){
                Console.WriteLine(g.HomeTeam + " " + g.HomeTeamGoals + " - " + g.AwayTeamGoals + " " + g.AwayTeam);
            }
        }
    }
}
