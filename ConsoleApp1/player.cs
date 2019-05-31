using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;


namespace Players
{
    public class player
    {
        public System.String name { get; set; }
        public System.String surename { get; set; }
        public DateTime dateOfBirth { get; set; }
        public System.Int32 age { get; set; }
        public System.String Nationality { get; set; }
        public System.String position { get; set; }
        public System.Int32 teamNumber { get; set; }

        public System.Int32 goalsScored { get; set; }
        public System.Int32 assists { get; set; }
        public System.Int32 appearances { get; set; }
        public System.Int32 careergoals { get; set; }
        public System.Int32 value { get; set; }
        public System.Int32 YC { get; set; }
        public System.Int32 Rc { get; set; }
        public System.Int32 PlayerID { get; set; }
       
        public System.String img {get; set;}
        

    }
}
