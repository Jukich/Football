using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    class Program
    {
        static void Main(string[] args)
        {
            MatchesDate.addUs();
            Console.ReadLine();
            return;
            Console.WriteLine("Press 1 to view all players in the team");
            
            string cho = Console.ReadLine();
            int choice = Convert.ToInt32(cho);
            Console.Clear();
            switch (choice)
            {
                case 0:
                    return;

                case 1:
                    foreach (player p in PlayerData.TestPLayer)
                    Console.WriteLine(p.teamNumber +  "." + p.name + " " + p.surename );
                    // Console.Read();
                    PlayerData.players.Clear();
                    Console.WriteLine("Choose player's number to see more info");
                    string cho2 = Console.ReadLine();
                    int choice2 = Convert.ToInt32(cho2);
                    
                   

                    foreach (player p in PlayerData.TestPLayer)
                    {

                        if (p.teamNumber == choice2)
                        {
                            Console.WriteLine(p.name);
                            Console.WriteLine("Goals scored " + p.goalsScored);
                        }
                    }

                    Console.Read();
                    break;

            }
        }
    }
}
