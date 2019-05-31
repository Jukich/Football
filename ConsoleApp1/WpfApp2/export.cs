using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Players;

namespace WpfApp2
{
    public class export
    {
        public static void Exp(string stattype) {
            string file_name ="C:\\Users\\Jukich\\Desktop\\"+stattype+".txt";
            WPFContext context = new WPFContext();
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(stattype + " " + "Name" + System.Environment.NewLine);
            List<stat> ls = new List<stat>();
         
            foreach (player p in context.Players)
            {
                stat s = new stat();
                if (stattype == "Goals")
                    s.statistic = p.goalsScored;
                else if (stattype == "Assists")
                    s.statistic = p.assists;
                else if (stattype == "Appearances")
                    s.statistic = p.appearances;
                else if (stattype == "Yellow cards")
                    s.statistic = p.YC;
                else if (stattype == "Red cards")
                    s.statistic = p.Rc;
                s.Name = p.name + " " + p.surename;
                
                ls.Add(s);
              //  strBuilder.Append(s.statistic + " " + s.Name + System.Environment.NewLine);
            }
            var newList = ls.OrderByDescending(x => x.statistic).ToList();
            foreach (stat st in newList)
            {
                strBuilder.Append(st.statistic + "    " + st.Name + System.Environment.NewLine);
               
            }
            File.WriteAllText(file_name, strBuilder.ToString());
        }
    }
}
