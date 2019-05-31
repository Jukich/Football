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

using System.Data.SqlClient;
using Players;
using System.Data;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        int flag = 0;
        public   LoginPage()
        {
          
          //  delete();
           // create();
           

            InitializeComponent();
            HplNewAcc.Click += new RoutedEventHandler(HplNewAcc_Click);
            pgLgn.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, flag));


        }
        private void delete()
        {
            using (SqlConnection connection = new
           SqlConnection(Properties.Settings.Default.DbConnect))
            {
                SqlCommand command = new SqlCommand("IF OBJECT_ID('dbo.ActiveUsers') IS NOT NULL DROP TABLE dbo.ActiveUsers", connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }

        }
    
        private void create()
        {
            



            using (SqlConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                SqlCommand command = new SqlCommand("IF OBJECT_ID('dbo.ActiveUsers') IS NULL CREATE TABLE dbo.ActiveUsers( Id int IDENTITY (1,1) PRIMARY KEY,    ActUsername nvarchar(MAX)  NULL , ActPassword nvarchar(MAX) NULL  , ActIsAdmin bit, LoggedIn  datetime );", connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }

            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            WPFContext context = new WPFContext();
            WPFContext context1 = new WPFContext();


            foreach (user u in context.Users)
            {
                
                if (txtname.Text == u.Username && txtpass.Text == u.Password)
                {
                        lblerr.Content = "";
                         ActiveUser act = new ActiveUser();
                        
                        act.ActUsername = u.Username;
                        act.ActPassword = u.Password;
                        act.LoggedIn = DateTime.Now;
                        act.ActIsAdmin = u.IsAdmin;
                        context1.ActUser.Add(act);
                        context1.SaveChanges();
                        
                        
                        MessageBox.Show("Logged In");
                        logger.Log(act);
                        StartPage startp = new StartPage(act.ActIsAdmin,u.Username);
                        flag = 1;
                        this.NavigationService.Navigate(startp);                                   
                }
                
                else                                 
                    lblerr.Content = "Wrong username or password"; 
                
            }
            
            
        }

        private void Button_ADd(object sender, RoutedEventArgs e)
        {
            /*
              user p = new user();

              for (int i = 2; i < 8; i++)
              {
                  var del = context.Users.Where(a => a.UserID == i).SingleOrDefault();
                  context.Users.Remove(del);
                  context.SaveChanges();
              }
              */
         //   delete();
           // create();
            /*
           WPFContext context = new WPFContext();
            IEnumerable<player> queryPlayers = context.Players;
            IEnumerable<user> queryUsers = context.Users;
            IEnumerable<team> queryTeam = context.Teams;

            foreach (user u in UserData.TestUsers)
            {
                context.Users.Add(u);
            }
            foreach (player st in PlayerData.TestPLayer)
            {
                context.Players.Add(st);
            }

           
            foreach (team t in TeamsData.TestTeams)
            {
                context.Teams.Add(t);
                
            }
            foreach(fixtures fx in MatchesDate.TestFixtures)
            {
                context.Results.Add(fx);
            }
            
            context.SaveChanges(); */
        }



        private void Page_Unloaded(object sender, RoutedEventArgs e, int flag)
        {


            if (flag == 0)
            {
               
                Application.Current.Shutdown();
            }

        }
        private void HplNewAcc_Click(object sender, RoutedEventArgs e)
        {

            flag = 1;
            NewAcc newacc = new NewAcc();
            this.NavigationService.Navigate(newacc);
                      
            

        }

    }
}
