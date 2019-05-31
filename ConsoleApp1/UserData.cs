using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
   public class UserData
    {
        public static List<user> users = new List<user>();
        public static void addPlayer()
        {


            users.Add(new user
            {
                Username = "admin",
                Password = "admin",
                IsAdmin = true
            });
        }
        public static List<user> TestUsers
        {
            get
            {
                addPlayer();
                return users;

            }
            set { }
        }
    }
}
