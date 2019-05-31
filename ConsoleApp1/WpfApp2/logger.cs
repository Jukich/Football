using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Players;
using System.IO;

namespace WpfApp2
{
    public class logger
    {
        public static void Log(ActiveUser act)
        {
            string us;
            if (act.ActIsAdmin == false)
                us = "User";
            else
                us = "admin";

            string logged = act.ActUsername+ " " + us + " " + DateTime.Now.ToString()+System.Environment.NewLine;
            if (File.Exists("C:\\Users\\Jukich\\Desktop\\Log.txt") == true)
            {
                File.AppendAllText("C:\\Users\\Jukich\\Desktop\\Log.txt", logged);
            }
            else
            {
                File.Create("C:\\Users\\Jukich\\Desktop\\Log.txt");
                File.AppendAllText("C:\\Users\\Jukich\\Desktop\\Log.txt", logged);
            }

        }
    }
}
