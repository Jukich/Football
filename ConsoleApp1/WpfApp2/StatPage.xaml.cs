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
    /// Interaction logic for StatPage.xaml
    /// </summary>
    public partial class StatPage : Page
    {
        int flag = 0;
        public StatPage()
        {
            InitializeComponent();
            WPFContext context = new WPFContext();

            namecol.IsReadOnly = true;
            statcol.IsReadOnly = true;


        }
        public StatPage(List<stat> p, bool isadm, string username) : this()
        {
     
            statcol.Header = p[1].stattype;
            var newList = p.OrderByDescending(x => x.statistic).ToList();
            datagr.ItemsSource = newList;
            hplback.Click += new RoutedEventHandler((sender, e) => hplback_click(sender, e, isadm, username)); ;
            pgPlayers.Unloaded += new RoutedEventHandler((sender, e) => pgPlayers_click(sender, e, username, flag));

        }
        private void hplback_click(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            flag = 1;
            Player2 pl2 = new Player2(isadm, username);
            this.NavigationService.Navigate(pl2);

        }
        private void pgPlayers_click(object sender, RoutedEventArgs e, string username, int flag)
        {
         
            if (flag == 0)
            {
                ActUserDelete.Actuserdel(username);
                Application.Current.Shutdown();
            }

        }
    }
}
