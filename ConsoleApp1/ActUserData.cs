using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class ActUserData
    {
        public static List<ActiveUser> actusers = new List<ActiveUser>();
        public static void addPlayer()
        {


            actusers.Add(new ActiveUser
            {
                ActUsername = "admin",
               ActPassword = "admin",
                ActIsAdmin = true
            });
        }
        public static List<ActiveUser> TestUsers
        {
            get
            {
                addPlayer();
                return actusers;

            }
            set { }
        }
    }
}
