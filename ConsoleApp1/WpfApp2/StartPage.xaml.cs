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
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        int flag = 0;
        public StartPage(bool isadm,string username)
        {
            
            WPFContext context = new WPFContext();
          
                InitializeComponent();
            if (isadm != true)
            {
                txtUsers.Visibility = Visibility.Hidden;
                txtAct.Visibility = Visibility.Hidden;
                txtadd.Visibility = Visibility.Hidden;
            }
            ViewPlayerHL.Click += new RoutedEventHandler((sender, e) => ViewPlayerHL_Click(sender, e, isadm, username)); ;
            ViewRankingHL.Click += new RoutedEventHandler((sender,e)=>ViewRankingHL_Click(sender,e,isadm, username));
            AddPlayersHL.Click += new RoutedEventHandler((sender, e) => AddPlayersHL_Click(sender, e, isadm, username));
            FixResHL.Click += new RoutedEventHandler((sender, e) => FixResHL_Click(sender, e, isadm, username));
            hpUsers.Click += new RoutedEventHandler((sender, e) => hpUsers_Click(sender, e, isadm, username));
            hpAct.Click += new RoutedEventHandler((sender, e) => hpact_Click(sender, e, isadm, username));
            btnLogout.Click += new RoutedEventHandler((sender, e) => btnLogout_Click(sender, e, username));
            pg.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, username,flag));


        }
        private void ViewPlayerHL_Click(object sender, RoutedEventArgs e,bool isadm,string username)
        {
            flag = 1;
            Players pl = new Players(isadm,username);
            this.NavigationService.Navigate(pl);
        }
        private void ViewRankingHL_Click(object sender, RoutedEventArgs e,bool isadm, string username)
        {
            flag = 1;
            Page2 rnkg = new Page2(isadm,username);
            this.NavigationService.Navigate(rnkg);
        }
        
        private void FixResHL_Click(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            flag = 1;
            Fixtures fx = new Fixtures(isadm,username);
            this.NavigationService.Navigate(fx);
        }

        private void hpUsers_Click(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            flag = 1;
            ViewUsers fx = new ViewUsers(isadm, username);
            this.NavigationService.Navigate(fx);
        }
        private void hpact_Click(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            flag = 1;
            ViewActiveUsers fx = new ViewActiveUsers(isadm, username);
            this.NavigationService.Navigate(fx);
        }
        private void AddPlayersHL_Click(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            int i = 0;
            WPFContext context = new WPFContext();
            foreach (player p in context.Players)
            {
                i++;
            }
            if (i == 25)
            {
                MessageBox.Show("Maximum number of players is 25, please delete player to continue!");
            }
            else
            {
                flag = 1;
                NewPlayer npl = new NewPlayer(isadm, username);
                this.NavigationService.Navigate(npl);

            }
        }


        private void btnLogout_Click(object sender, RoutedEventArgs e,string username)
        {

            flag = 1;
            ActUserDelete.Actuserdel(username);
            LoginPage lg = new LoginPage();
            this.NavigationService.Navigate(lg);
                  

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e,string username,int flag)
        {
           
           
            if (flag==0)
            {
                ActUserDelete.Actuserdel(username);
                Application.Current.Shutdown();
            }

        }
    }
}
