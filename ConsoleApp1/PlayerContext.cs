using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace Players
{
    class PlayerContext : DbContext
    {
        public PlayerContext() : base((Properties.Settings.Default.DbConnect))
        { }
        public DbSet<player> Players { get; set; }
        public DbSet<user> Users { get; set; }
        public DbSet<ActiveUser> ActUser { get; set; }
        public DbSet<team> Teams { get; set; }
        public DbSet<fixtures> Results {get;set;}
    }
}
