using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
 
        public class TeamsData
        {
            public static List<team> teams = new List<team>();
            public static void addTeam()
            {
           

            teams.Add(new team
            {
              
                Position=1,
                Club = "Manchester City",
                Played = 36,
                Won=30,
                Drawn =2,
                Lost=4,
                GF=90,
                GA=22,
                

                });
            teams.Add(new team
            {
                Position=4,
                Club = "Chelsea",
                Played = 20,
                Won =20,
                Drawn = 8,
                Lost = 8,
                GF = 60,
                GA = 39,


            }); teams.Add(new team
            {
                Position=2,
                Club = "Liverpool",
                Played = 36,
                Won = 28,
                Drawn = 7,
                Lost = 1,
                GF = 84,
                GA = 20,
            }); teams.Add(new team
            {
                Position = 3,
                Club = "Tottenham",
                Played = 37,
                Won = 23,
                Drawn = 1,
                Lost = 13,
                GF = 65,
                GA = 37,
            });

            foreach (team t in teams)
            {
                t.Points = (t.Won * 3 + t.Drawn);
                t.GD = t.GF - t.GA;
            }

        }
       

        public static List<team> TestTeams
            {
                get
                {
                    addTeam();
                    return teams;

                }
                set { }
            }
        }
    
}
