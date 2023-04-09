using System;
using System.IO;
using System.Linq;
using System.Globalization;

class FileReader
{
    static void Main(string[] args)
    {
        csvTeamReader();
        csvAllRoundsReader();
        Round();
        Table();
        searchTeam();


    }

    public static void searchTeam()
    {
        Console.WriteLine("Write the abbreviation of the team you want to see the results of: ");
        string? team = Console.ReadLine();
        bool found = false;
        foreach (Team t in csvTeamReader())
        {
            if (string.Equals(t.Abriviation, team, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(t.Abriviation + " | " + t.FullName + " | " + t.SpecialRanking);
                found = true; //For ikke den skal blive ved med at skrive "Team not found"
                break;
            }
            if (string.Equals("all", team, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(t.Abriviation + " | " + t.FullName + " | " + t.SpecialRanking);
            }
        }
        if (!found)
        {
            Console.WriteLine("Team not found");
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
        int maxLenght = teams.Max(x => x.FullName.Length);

        Console.WriteLine("Club\t\tName\t\t\tRank");
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
            string paddedName = t.FullName.PadRight(maxLenght + 1);
            Console.WriteLine($"{t.Abriviation}\t" + paddedName + $"\t{t.SpecialRanking}");
        }
        Console.ResetColor();
    }

    public static void Round()
    {
        List<Game> allGameRounds = csvAllRoundsReader();
        List<Team> teams = csvTeamReader();

        allGameRounds.Sort((x, y) => x.HomeTeam.CompareTo(y.HomeTeam));
        teams.Sort((x, y) => x.Abriviation.CompareTo(y.Abriviation));

        foreach (Game g in allGameRounds)
        {
            foreach (Team t in teams)
            {
                if (t.Abriviation.ToLower() == g.AwayTeam.ToLower())
                {
                    if (g.HomeTeamGoals > g.AwayTeamGoals)
                    {
                        t.addMatch(g.HomeTeamGoals, g.AwayTeamGoals, false);
                    }
                    else if (g.HomeTeamGoals < g.AwayTeamGoals)
                    {
                        t.addMatch(g.HomeTeamGoals, g.AwayTeamGoals, true);
                    }
                    else
                    {
                        t.addMatch(g.HomeTeamGoals, g.AwayTeamGoals);
                    }
                }
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
        //--------------------------------------Sortering----------------------------------------------|


        var finalList = teams.OrderByDescending(x => x.Points)
        .ThenByDescending(x => x.GoalDifference)
        .ThenByDescending(x => x.GoalsFor)
        .ThenByDescending(x => x.GoalsAgainst)
        .ThenByDescending(x => x.Abriviation).ToList();

        printing(finalList);

    }


    public static void printing(List<Team> teams)
    {
        Console.WriteLine("Position\tTeam\tMatches\tWins\tLosses\tDraws\tGF\tGA\tGD\tPoints");
        for (int i = 0; i < teams.Count; i++)// loop through the teams
        {
            Console.ResetColor(); // reset the color to white
            ConsoleColor color = ConsoleColor.Yellow;
            Team team = teams[i];

            if (i == 0)
            {
                color = ConsoleColor.Blue; // print the first team in blue
            }
            else if (i < 5)
            {
                color = ConsoleColor.Green; // print the next 5 teams in green
            }
            else if (i >= teams.Count - 2)
            {
                color = ConsoleColor.Red; // print the last 2 teams in red
            }

            Console.ForegroundColor = color; // set the color
            if (i == 0 || team.Points != teams[i - 1].Points ||
                team.GoalDifference != teams[i - 1].GoalDifference || team.GoalsFor != teams[i - 1].GoalsFor)
            {
                Console.Write(i + 1); // print the position number
            }
            else
            {
                Console.Write("-"); // print a dash instead of the position number
            }
            Console.Write("\t"); // print a tab
            Console.Write("\t" + team.Abriviation); // print the team name
            Console.Write("\t" + team.Matches);
            Console.Write("\t" + team.Wins); // print the team's wins (or any other stats you want to display)
            Console.Write("\t" + team.Losses);
            Console.Write("\t" + team.Draws);
            Console.Write("\t" + team.GoalsFor);
            Console.Write("\t" + team.GoalsAgainst);
            Console.Write("\t" + team.GoalDifference);
            Console.Write("\t" + team.Points);

            Console.ResetColor(); // reset the color to white
            Console.WriteLine(); // move to the next line

        }
    }




}