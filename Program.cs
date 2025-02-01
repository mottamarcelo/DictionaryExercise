using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> ballot = new Dictionary<string, int>();

            Console.WriteLine("Enter file full path: ");
            string path = Console.ReadLine();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int votes = int.Parse(line[1]);

                        if (ballot.ContainsKey(name))
                        {
                            ballot[name] += votes;
                        }
                        else
                        {
                            ballot[name] = votes;
                        }

                    }

                    foreach (var item in ballot)
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
