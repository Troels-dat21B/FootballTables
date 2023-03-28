using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("./csv filer/Rounds/Round-1.csv"))
        {
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                foreach (var value in values)
                {
                    //Console.WriteLine(value);
                }
                //Console.WriteLine();
            }
        }        

        Team testTeam = new Team("test", "test", "test");
        testTeam.addMatch(4, 2, false);
        testTeam.addMatch(2, 2, false);
        Team testTeam2 = new Team("test2", "test2");
        testTeam2.addMatch(1, 0, true);
        testTeam2.addMatch(2, 1, true);

        Console.WriteLine(testTeam.ToString());
        Console.WriteLine(testTeam2.ToString());
    }
}