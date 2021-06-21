using System;
using System.IO;

namespace HideoutMover
{
    class Program
    {

        static void Main(string[] args)
        {
            int translateX = -10;
            int translateY = -35;

            using (Stream stream = File.Open("2B.hideout", FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            using (Stream stream2 = File.Create("2Bprime.hideout"))
            using (StreamWriter writer = new StreamWriter(stream2))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.Contains("\"x\":"))
                    {
                        string[] parts = line.Split(':');

                        parts[1] = parts[1].TrimStart();
                        parts[1] = parts[1].TrimEnd(',');

                        int numToParse = int.Parse(parts[1]);
                        numToParse += translateX;

                        line = parts[0] + ": " + numToParse + ',';
                    }

                    if (line.Contains("\"y\":"))
                    {
                        string[] parts = line.Split(':');

                        parts[1] = parts[1].TrimStart();
                        parts[1] = parts[1].TrimEnd(',');

                        int numToParse = int.Parse(parts[1]);
                        numToParse += translateY;

                        line = parts[0] + ": " + numToParse + ',';
                    }

                    writer.WriteLine(line);
                }
            }
        }
    }
}