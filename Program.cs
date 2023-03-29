using System;
using System.IO;
using System.Linq;
using System.Globalization;

class FileReader {
    static void Main() {
        //csvAllRoundsReader();
        //csvTeamReader();
        Table();
    }

    public static List<Game> csvAllRoundsReader() {

        List<Game> allGameRounds = new List<Game>();
        try{
        foreach (string file in Directory.EnumerateFiles("./csv filer/Rounds", "*.csv")) {

            using (StreamReader reader = new StreamReader(file)) {

                while (!reader.EndOfStream) {
                
                var line = reader.ReadLine();
                string[] values = line.Split(',');

                Game tuple = new Game(values[0], values[1], int.Parse(values[2]), int.Parse(values[3]));
                allGameRounds.Add(tuple);
                
            }
        }
    }
    } catch (Exception e) {
        Console.WriteLine("CSV file not found.");
        Console.WriteLine(e.Message);
    }

    return allGameRounds;
    }

    public static List<Team> csvTeamReader() {

        List<Team> teams = new List<Team>();
        try{
            
            foreach (string file in Directory.EnumerateFiles("./csv filer" , "Teams.csv")) {

                using (StreamReader reader = new StreamReader(file)) {

                    while (!reader.EndOfStream) {
                
                    var line = reader.ReadLine();
                    string[] values = line.Split(',');

                    Team tuple = new Team(values[0], values[1], values[2]);
                    teams.Add(tuple);
                
                }
            }
        }
        } catch (Exception e) {
            Console.WriteLine("CSV file not found.");
            Console.WriteLine(e.Message);
        }
    
    
        return teams;
    }

    public static void Table() {
        Console.ForegroundColor = ConsoleColor.Black;
        List<Team> teams = csvTeamReader();

        Console.WriteLine("Club  Name                      Rank");
        Console.WriteLine("------------------------------------");

        foreach(Team t in teams){

        switch (t.SpecialRanking) {
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
        }
        Console.ForegroundColor = ConsoleColor.Black;
    }
    
}
        