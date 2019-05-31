using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Players;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Player2.xaml
    /// </summary>
    public partial class Player2 : Page
    {
        int flag = 0;
        public Player2(bool isadm, string username)
        {
            InitializeComponent();
            hp1.Click += new RoutedEventHandler((sender, e) => Hyperlink_Click_1(sender, e, isadm, username));
            hp2.Click += new RoutedEventHandler((sender, e) => Hyperlink_Click_2(sender, e, isadm, username)); ;
            hp3.Click += new RoutedEventHandler((sender, e) => Hyperlink_Click_3(sender, e, isadm, username));
            hp4.Click += new RoutedEventHandler((sender, e) => Hyperlink_Click_4(sender, e, isadm, username)); ;
            hp5.Click += new RoutedEventHandler((sender, e) => Hyperlink_Click_5(sender, e, isadm, username));
            ViewPlayerHL.Click += new RoutedEventHandler((sender, e) => ViewPlayerHL_Click(sender, e, isadm, username)); ;
            pgPlayers.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, username, flag));
        }
        private void viewStat(string str,bool isadm, string username)
        {
            WPFContext context = new WPFContext();


            List<stat> ls = new List<stat>();
            foreach (player p in context.Players)
            {
                stat s = new stat();
                if (str == "Goals")
                    s.statistic = p.goalsScored;
                else if (str == "Assists")
                    s.statistic = p.assists;
                else if (str == "Appearances")
                    s.statistic = p.appearances;
                else if (str == "Yellow cards")
                    s.statistic = p.YC;
                else if (str == "Red cards")
                    s.statistic = p.Rc;
                
                s.Name = p.name + " " + p.surename;
                s.stattype = str;
                ls.Add(s);
            }
            flag = 1;
            StatPage st = new StatPage(ls,isadm,username);
            this.NavigationService.Navigate(st);
        }
        private void Hyperlink_Click_1(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            string str = "Goals";
            viewStat(str,isadm,username);
        }

        private void Hyperlink_Click_2(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            string str = "Assists";
            viewStat(str, isadm, username);

        }
        private void Hyperlink_Click_3(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            string str = "Appearances";
            viewStat(str, isadm, username);

        }
        private void Hyperlink_Click_4(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            string str = "Yellow cards";
            viewStat(str, isadm, username);

        }
        private void Hyperlink_Click_5(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            string str = "Red cards";
            viewStat(str, isadm, username);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string stattype = "Goals";
            export.Exp(stattype);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string stattype = "Assists";
            export.Exp(stattype);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string stattype = "Appearances";
            export.Exp(stattype);

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string stattype = "Yellow cards";
            export.Exp(stattype);

        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string stattype = "Red cards";
            export.Exp(stattype);


        }
        private void ViewPlayerHL_Click(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            flag = 1;
            Players pl = new Players(isadm, username);
            this.NavigationService.Navigate(pl);
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e, string username, int flag)
        {
           

            if (flag == 0)
            {
                ActUserDelete.Actuserdel(username);
                Application.Current.Shutdown();
            }

        }



    }
}
