using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Players
{
    public  class MatchesDate
    {
        public static List<fixtures> fixtures = new List<fixtures>();
        public static void addUs()
        {
            int i = 0;
            int p = 0;
            List<fixtures> ls = new List<fixtures>();
            string[] line = new string[1000];
            fixtures[] match = new fixtures[200];
            int goals=0;
            for (int t = 0; t < match.Length; t++) match[t] = new fixtures();
            while ((line = File.ReadAllLines("C:\\Users\\Jukich\\Desktop\\fixtures.txt")) != null)
            {
                try
                {
                    if(line[i] == null) ;
                }
                catch
                {
                    break;
                }
                match[p].date = line[i];
                match[p].hometeam = line[i + 1];
                match[p].result = line[i + 2];
                match[p].awayteam = line[i + 3];

                fixtures.Add(match[p]);
              // Console.WriteLine(fixtures[p].date+"\n" + fixtures[p].hometeam + fixtures[p].result + fixtures[p].awayteam);
                if (fixtures[p].hometeam == "Chelsea")
                {
                    goals += Int32.Parse(fixtures[p].result.Substring(0, 1));
                 }
                if (fixtures[p].awayteam == "Chelsea")
                {
                    Console.WriteLine(fixtures[p].result.Substring(2, 1));
                   // goals += Int32.Parse(fixtures[p].result.Substring(0, 1));
                }
                p++;
                i = i + 4;
                


            }
            //Console.WriteLine(goals);
        }
            public static List<fixtures> TestFixtures
             {
            get
            {
                addUs();
                fixtures.Reverse();
                return fixtures;

            }
            set { }
            }
    




    }
    
}
