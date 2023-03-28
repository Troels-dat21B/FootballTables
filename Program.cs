using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
namespace Game;

class FileReader {
    static void Main() {

        List<Game> gameRounds = new List<Game>();

        foreach (string file in Directory.EnumerateFiles("./csv filer/Rounds", "*.csv")) {

            using (StreamReader reader = new StreamReader(file)) {
                while (!reader.EndOfStream) {
                    
                    var line = reader.ReadLine();
                    string[] values = line.Split(',');

                    Game tuple = new Game(values[0], values[1], int.Parse(values[2]), int.Parse(values[3]));
                    gameRounds.Add(tuple);
                    
                }
            }
        }

        foreach (Game g in gameRounds) {

            Console.WriteLine(g.roundInfo(g));
        }
    }
}