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
    /// Interaction logic for NewAcc.xaml
    /// </summary>
    public partial class NewAcc : Page
    {
        int flag = 0;
        public NewAcc()
        {
            InitializeComponent();
            btnback.Click += new RoutedEventHandler(btnback_Click);
            pgnewacc.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, flag));
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WPFContext context = new WPFContext();
            if (txtname.Text.Length <= 6 || txtpass.Text.Length <= 6)
                MessageBox.Show("Username and password must contain more than 6 characters");
            else
               if (context.Users.All(o => o.Username != txtname.Text))
                {

                user newUs = new user();
                newUs.Username = txtname.Text;
                newUs.Password = txtpass.Text;
                newUs.IsAdmin = false;
                
                context.Users.Add(newUs);
                context.SaveChanges();
                MessageBox.Show("Account created successfully");
                flag = 1;
                LoginPage lg = new LoginPage();
                this.NavigationService.Navigate(lg);
                }
            else
            {
                MessageBox.Show("This username already exists");
            }

        }
        private void btnback_Click(object sender, RoutedEventArgs e)
        {


            flag = 1;
            LoginPage lg = new LoginPage();
            this.NavigationService.Navigate(lg);


        }
        private void Page_Unloaded(object sender, RoutedEventArgs e, int flag)
        {


            if (flag == 0)
            {

                Application.Current.Shutdown();
            }

        }
 
    }
}
