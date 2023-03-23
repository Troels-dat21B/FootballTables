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
    }
}