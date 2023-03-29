using System;
using System.IO;
using System.Linq;
using System.Globalization;

class FileReader {
    static void Main() {

        //csvAllRoundsReader();
        csvTeamReader();
    }

    public static List<Game> csvAllRoundsReader() {

        List<Game> allGameRounds = new List<Game>();
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

    foreach(Game g in allGameRounds){
        Console.WriteLine(g.roundInfo(g));
    }

    return allGameRounds;

    }

    public static List<Team> csvTeamReader() {

        List<Team> teams = new List<Team>();
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

    foreach(Team t in teams){
        Console.WriteLine(t.teamInfo(t));
        
    }
    
    return teams;
    }

    public static void Table() {
        List<Team> teams = csvTeamReader();

        Console.WriteLine("Position  Club                       M  W  D  L  GF  GA  GD  Points  Streak");
        Console.WriteLine("---------------------------------------------------------------------------");

        foreach(Team t in teams){

        //Console.WriteLine("{position} {club} {match} {wins} {draws} {losses} {gf} {ga} {gd} {points} {streak}");
        }
    }
}