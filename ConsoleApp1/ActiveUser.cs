using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
   public class ActiveUser
    {
        public System.String ActUsername { get; set; }
        public System.String ActPassword { get; set; }
        public System.Boolean ActIsAdmin { get; set; }
        public System.DateTime LoggedIn  { get; set; }
        
        public System.Int32 Id { get; set; }
    }
}
