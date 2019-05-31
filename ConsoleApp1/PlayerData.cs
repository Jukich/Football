using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Players
{
  public  class PlayerData
    {
       public static List<player> players = new List<player>();
        public static void addPlayer()
        {
        
        players.Add(new player
            {
                name = "Kepa",
                surename = "Arrizabalaga",
                dateOfBirth = new DateTime(1991, 10, 3),
                teamNumber = 1,
                Nationality = "Spanish",
                goalsScored = 0,
                assists = 5,
                appearances = 36,
                careergoals =0,
                value = 55,
                YC = 2,
                Rc = 0,
                position = "Goalkeeper",
                img = "C:\\Users\\Jukich\\Desktop\\img\\kepa.png"
                
            });
            players.Add(new player
            {                          
                name = "Antonio",
                surename = "Rüdiger",
                dateOfBirth = new DateTime(1993, 3, 3),
                teamNumber = 2,
                Nationality = "German",
                goalsScored = 1,
                assists = 0,
                appearances = 26,
                careergoals = 0,
                value = 45,
                YC = 7,
                Rc = 0,
                position = "Defender",
                img = "C:\\Users\\Jukich\\Desktop\\img\\ar.png"
            });
            players.Add(new player
            {
                name = "Marcos",
                surename = "Alonso",
                dateOfBirth = new DateTime(1990, 12, 28),
                teamNumber = 3,
                Nationality = "Spanish",
                goalsScored = 4,
                assists = 4,
                appearances = 30,
                careergoals = 30,
                value = 25,
                YC = 5,
                Rc = 0,
                position = "Left back",
                img = "C:\\Users\\Jukich\\Desktop\\img\\alonso.png"
            });
            players.Add(new player
            {
                name = "Jorginho ",
                surename = "",
                dateOfBirth = new DateTime(1991, 12, 20),
                teamNumber = 5,
                Nationality = "Brazilian",
                goalsScored = 2,
                assists = 5,
                appearances = 32,
                careergoals = 35,
                value = 35,
                YC = 5,
                Rc = 1,
                position = "Midfielder",
                img = "C:\\Users\\Jukich\\Desktop\\img\\jorginho.png"
            });
            players.Add(new player
            {
                name = "Danny",
                surename = "Drinkwater",
                dateOfBirth = new DateTime(1990, 3, 5),
                teamNumber = 6,
                Nationality = "English",
                goalsScored = 0,
                assists = 1,
                appearances = 4,
                careergoals = 19,
                value = 10,
                YC = 1,
                Rc = 0,
                position = "Midfielder",
                img = "C:\\Users\\Jukich\\Desktop\\img\\danny.png"

            });
            players.Add(new player
            {
                name = "N'Golo",
                surename = "Kanté",
                dateOfBirth = new DateTime(1991, 4, 12),
                teamNumber = 7,
                Nationality = "French",
                goalsScored = 10,
                assists = 8,
                appearances = 33,
                careergoals = 40,
                value = 30,
                YC = 10,
                Rc = 2,
                position = "Midfielder",
                img = "C:\\Users\\Jukich\\Desktop\\img\\kante.jpg"
            });
            players.Add(new player
            {
                name = "Ross",
                surename = "Barkley",
                dateOfBirth = new DateTime(1993, 12, 5),
                teamNumber = 8,
                Nationality = "English",
                goalsScored = 5,
                assists = 0,
                appearances = 19,
                careergoals = 39,
                value = 20,
                YC = 3,
                Rc = 0,
                position = "Midfielder",
                img = "C:\\Users\\Jukich\\Desktop\\img\\barkley.png"
            });
            players.Add(new player
            {
                name = "Gonzalo",
                surename = "Higuain",
                dateOfBirth = new DateTime(1987, 12, 10),
                teamNumber = 9,
                Nationality = "English",
                goalsScored = 4,
                assists = 0,
                appearances = 10,
                careergoals = 194,
                value = 25,
                YC = 2,
                Rc = 0,
                position ="Striker",
                img = "C:\\Users\\Jukich\\Desktop\\img\\higuain.jpg"
            });
            players.Add(new player
            {
                name = "Eden",
                surename = "Hazard",
                dateOfBirth = new DateTime(1991, 1, 7),
                teamNumber = 10,
                Nationality = "Belgian",
                goalsScored = 19,
                assists = 17,
                appearances = 30,
                careergoals = 212,
                value = 105,
                YC = 1,
                Rc = 0,
                position = "Winger / Attacking Midfielder",
                img= "C:\\Users\\Jukich\\Desktop\\img\\hazard.png"


            });
   
            players.Add(new player
            {
                name = "Pedro",
                surename = "",
                dateOfBirth = new DateTime(1987, 7, 28),
                teamNumber = 11,
                Nationality = "Spanish",
                goalsScored = 11,
                assists = 5,
                appearances = 21,
                careergoals = 96,
                value = 23,
                YC = 3,
                Rc = 0,
                position = "Winger",
                img = "C:\\Users\\Jukich\\Desktop\\img\\pedro.png"
            });
            players.Add(new player
            {
                name = "Ruben",
                surename = "Loftus-Cheek",
                dateOfBirth = new DateTime(1996, 1, 23),
                teamNumber = 12,
                Nationality = "English",
                goalsScored = 8,
                assists = 6,
                appearances = 20,
                careergoals = 26,
                value = 40,
                YC = 6,
                Rc = 0,
                position = "Midfielder",
                img = "C:\\Users\\Jukich\\Desktop\\img\\ruben.png"
            });
            players.Add(new player
            {
                name = "Willy",
                surename = "Caballero",
                dateOfBirth = new DateTime(1981, 9, 28),
                teamNumber = 13,
                Nationality = "Argentine",
                goalsScored = 0,
                assists = 0,
                appearances = 1,
                careergoals = 1,
                value = 1,
                YC = 0,
                Rc = 0,
                position = "Goalkeeper",
                img = "C:\\Users\\Jukich\\Desktop\\img\\willy.png"
            });
            players.Add(new player
            {
                name = "Mateo",
                surename = "Kovačić",
                dateOfBirth = new DateTime(1994, 5, 6),
                teamNumber = 17,
                Nationality = "Croatian",
                goalsScored = 0,
                assists = 3,
                appearances = 15,
                careergoals = 29,
                value = 30,
                YC = 5,
                Rc = 1,
                position = "Midfielder",
                img = "C:\\Users\\Jukich\\Desktop\\img\\kovacic.png"

            });
            players.Add(new player
            {
                name = "Olivier",
                surename = "Giroud",
                dateOfBirth = new DateTime(1986, 9, 30),
                teamNumber = 18,
                Nationality = "French",
                goalsScored = 12,
                assists = 9,
                appearances = 21,
                careergoals = 114,
                value = 15,
                YC = 2,
                Rc = 0,
                position = "Striker",
                img = "C:\\Users\\Jukich\\Desktop\\img\\giroud.png"

            });
            players.Add(new player
            { 
                name = "Callum",
                surename = "Hudson-Odoi",
                dateOfBirth = new DateTime(2000, 11, 7),
                teamNumber = 20,
                Nationality = "English",
                goalsScored = 4,
                assists = 2,
                appearances = 15,
                careergoals = 37,
                value = 60,
                YC = 1,
                Rc = 0,
                position = "Forward",
                img = "C:\\Users\\Jukich\\Desktop\\img\\odoi.png"

            });
            players.Add(new player
            {
                name = "Davide",
                surename = "Zappacosta",
                dateOfBirth = new DateTime(1992, 6, 1),
                teamNumber = 21,
                Nationality = "Italian",
                goalsScored = 1,
                assists = 1,
                appearances = 12,
                careergoals = 9,
                value = 25,
                YC = 2,
                Rc = 0,
                position = "Right back",
                img = "C:\\Users\\Jukich\\Desktop\\img\\davide.png"

            });
            players.Add(new player
            {
                name = "Willian",
                surename = "Borges da Silva",
                dateOfBirth = new DateTime(1988, 8, 9),
                teamNumber = 22,
                Nationality = "Brazilian",
                goalsScored = 8,
                assists = 5,
                appearances = 26,
                careergoals = 87,
                value = 40,
                YC = 4,
                Rc = 1,
                position = "Winger",
                img = "C:\\Users\\Jukich\\Desktop\\img\\willian.png"

            });
            players.Add(new player
            {
                name = "Gary",
                surename = "Cahill",
                dateOfBirth = new DateTime(1985, 12, 19),
                teamNumber = 24,
                Nationality = "English",
                goalsScored = 0,
                assists = 0,
                appearances = 5,
                careergoals = 31,
                value = 5,
                YC = 0,
                Rc = 0,
                position = "Centre back",
                img = "C:\\Users\\Jukich\\Desktop\\img\\cahill.png"

            }); players.Add(new player
            {    
                name = "Andreas",
                surename = "Christensen",
                dateOfBirth = new DateTime(1996, 4, 10),
                teamNumber = 27,
                Nationality = "Danish",
                goalsScored = 2,
                assists = 0,
                appearances = 17,
                careergoals = 7,
                value = 35,
                YC = 8,
                Rc = 2,
                position = "Centre back",
                img = "C:\\Users\\Jukich\\Desktop\\img\\andreas.png"

            }); players.Add(new player
            {                
   
                name = "Cesar",
                surename = "Azpilicueta",
                dateOfBirth = new DateTime(1989, 8, 28),
                teamNumber = 28,
                Nationality = "Spanish",
                goalsScored = 3,
                assists = 2,
                appearances = 34,
                careergoals = 19,
                value = 20,
                YC = 10,
                Rc = 1,
                position = "Defender",
                img = "C:\\Users\\Jukich\\Desktop\\img\\cesar.png"

            });
            players.Add(new player
            {

                name = "David",
                surename = "Luiz",
                dateOfBirth = new DateTime(1987, 4, 22),
                teamNumber = 30,
                Nationality = "Brazilian",
                goalsScored = 3,
                assists = 0,
                appearances = 30,
                careergoals = 23,
                value = 20,
                YC = 14,
                Rc = 3,
                position = "Center back",
                img = "C:\\Users\\Jukich\\Desktop\\img\\luiz.png"

            });
            players.Add(new player
            {

                name = "Robert",
                surename = "Green",
                dateOfBirth = new DateTime(1980, 1, 18),
                teamNumber = 31,
                Nationality = "English",
                goalsScored = 0,
                assists = 0,
                appearances = 0,
                careergoals = 0,
                value = 1,
                YC = 0,
                Rc = 0,
                position = "Goalkeeper",
                img = "C:\\Users\\Jukich\\Desktop\\img\\green.png"

            });
            players.Add(new player
            {

                name = "Emerson",
                surename = "Palmieri",
                dateOfBirth = new DateTime(1994, 8, 3),
                teamNumber = 33,
                Nationality = "English",
                goalsScored = 2,
                assists = 0,
                appearances = 10,
                careergoals = 9,
                value = 30,
                YC = 2,
                Rc = 0,
                position = "Left back",
                img = "C:\\Users\\Jukich\\Desktop\\img\\emerson.jpg"

            });
            players.Add(new player
            {

                name = "Ethan",
                surename = "Ampadu",
                dateOfBirth = new DateTime(2000, 8, 14),
                teamNumber = 44,
                Nationality = "English",
                goalsScored = 0,
                assists = 0,
                appearances = 5,
                careergoals = 3,
                value = 20,
                YC = 0,
                Rc = 0,
                position = "Center back",
                img = "C:\\Users\\Jukich\\Desktop\\img\\ampadu.png"

            });  






            foreach (player p in players)
            {
                
                p.age = DateTime.Now.Year - p.dateOfBirth.Year;
                if (p.dateOfBirth.Month > DateTime.Now.Month)
                    p.age--;
                else if (p.dateOfBirth.Month == DateTime.Now.Month)
                {
                    if (p.dateOfBirth.Day > DateTime.Now.Day)
                        p.age--;
                }                 
                
            }
        }
        //List<player> SortedList = players.OrderBy(o => o.teamNumber).ToList();
        public static List<player> TestPLayer
        {
            get
            {

                     addPlayer();
                     return players.OrderBy(o => o.teamNumber).ToList();


            }
            set { }
        }
    }
}
