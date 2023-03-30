using System;
using System.IO;
using System.Linq;
using System.Globalization;

class FileReader {
    static void Main(string[] args) {
        //csvAllRoundsReader();
        //csvTeamReader();
        //Table();
        //testPrint();

        Console.WriteLine("Write the abbreviation of the team you want to see the results of: ");
        string team = Console.ReadLine();

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
        List<Team> teams = csvTeamReader();

        Console.WriteLine("Position  Club                       M  W  D  L  GF  GA  GD  Points  Streak");
        Console.WriteLine("---------------------------------------------------------------------------");

        foreach(Team t in teams){

        Console.WriteLine($"{t.Abriviation} {t.FullName} {t.SpecialRanking}");
        }
    }

    public static void testPrint() {
        List<Game> allGameRounds = csvAllRoundsReader();
        foreach(Game g in allGameRounds){
            if(g.HomeTeam == "AAB" && g.HomeTeamGoals > g.AwayTeamGoals){
                Console.WriteLine(g.roundInfo(g));
            }
        }
    }
}