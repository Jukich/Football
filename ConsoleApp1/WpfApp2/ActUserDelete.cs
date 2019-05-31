using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class ActUserDelete
    {
        
        public static void Actuserdel(string usern) {
            try
            {
                WPFContext context = new WPFContext();
                var act = context.ActUser.Where(x => x.ActUsername == usern).FirstOrDefault();
                context.ActUser.Remove(act);
                context.SaveChanges();
            }
            catch { }
        }
        
    }
    
}
