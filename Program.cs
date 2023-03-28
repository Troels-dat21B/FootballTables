﻿using System;
using System.IO;
using System.Linq;
using System.Globalization;
namespace Game;

class FileReader {
    static void Main() {

        csvAllRoundsReader();
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

    return allGameRounds;

    }

    public static List<Team> csvTeamReader() {

        List<Team> teams = new List<Team>();
        foreach (string file in Directory.EnumerateFiles("./csv filer/Teams.csv")) {

            using (StreamReader reader = new StreamReader(file)) {

                while (!reader.EndOfStream) {
                
                var line = reader.ReadLine();
                string[] values = line.Split(',');

                Team tuple = new Team(values[0], values[1], values[2]);
                teams.Add(tuple);
                
                
            }
        }
    }

    return teams;

    }
}