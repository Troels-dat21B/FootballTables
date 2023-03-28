using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using CsvHelper;
namespace Game;

class FileReader {
    static void Main() {

        List<Game> gameRounds = new List<Game>();
        var i = 0;
        foreach (string file in Directory.EnumerateFiles("./csv filer/Rounds", "*.csv")) {

            using (StreamReader reader = new StreamReader(file)) {
                while (!reader.EndOfStream) {
                    i += 1;
                    
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                    Console.WriteLine(i);
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