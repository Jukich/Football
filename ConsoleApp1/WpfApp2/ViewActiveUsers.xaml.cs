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
    /// Interaction logic for ViewActiveUsers.xaml
    /// </summary>
    public partial class ViewActiveUsers : Page
    {
        int flag = 0;
        public ViewActiveUsers(bool isadm, string username)
        {
            InitializeComponent();
            FillPage(isadm, username);

        }
        public void FillPage(bool isadm, string username)
        {
            WPFContext context = new WPFContext();


            List<ActiveUser> UserList = new List<ActiveUser>();
            UserList = context.ActUser.ToList();
            datagr.ItemsSource = UserList;
                                 
            hplback.Click += new RoutedEventHandler((sender, e) => hplback_Click_1(sender, e, isadm, username));
            pgAct.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, username, flag));

        }

        private void hplback_Click_1(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            flag = 1;
            StartPage pl2 = new StartPage(isadm, username);
            this.NavigationService.Navigate(pl2);

        }

        public void Page_Unloaded(object sender, RoutedEventArgs e, string username, int flag)
        {
            if (flag == 0)
            {
                ActUserDelete.Actuserdel(username);
                Application.Current.Shutdown();
            }

        }
    }
}
