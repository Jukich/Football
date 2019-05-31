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
using System.Data.SqlClient;
using System.Data;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ViewActiveUsers.xaml
    /// </summary>
    public partial class ViewUsers : Page
    {
        int flag = 0;
        int flag1 = 0;
        public ViewUsers(bool isadm, string username)
        {
            InitializeComponent();
            OrderFix();
            FillPage(isadm, username);

        }
        public void OrderFix()
        {


            WPFContext context = new WPFContext();
            List<user> orderFix = new List<user>();
            foreach (user m in context.Users)
            {
                orderFix.Add(m);

            }
            delete();
            create();
            AddUsers(orderFix);
        }
        private void delete()
        {
            using (SqlConnection connection = new
           SqlConnection(Properties.Settings.Default.DbConnect))
            {
                SqlCommand command = new SqlCommand("IF OBJECT_ID('dbo.users') " +
                    "IS NOT NULL DROP TABLE dbo.users", connection);
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
                SqlCommand command = new SqlCommand("IF OBJECT_ID('dbo.users')" +
                    " IS NULL CREATE TABLE dbo.users( UserID int IDENTITY (1,1)  PRIMARY KEY,   " +
                    " Username nvarchar(MAX)  NULL, Password nvarchar(MAX) NULL  , IsAdmin bit)" +
                    ";", connection);

                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }
        public void AddUsers(List<user> orderFix)
        {


            WPFContext context = new WPFContext();



            foreach (user m in orderFix)
            {
                context.Users.Add(m);
            }
            context.SaveChanges();


        }
        public void FillPage(bool isadm, string username)
        {
            WPFContext context = new WPFContext();


            List<user> UserList = new List<user>();
            UserList = context.Users.ToList();
            datagr.ItemsSource = UserList;

            if (flag1 == 0)
            {
                DataGridTemplateColumn buttonColumn = new DataGridTemplateColumn();
                DataTemplate buttonTemplate = new DataTemplate();
                FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));
                buttonTemplate.VisualTree = buttonFactory;
                buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler((sender, e)
                    => btnRemove_Click(sender, e, isadm, username)));
                buttonFactory.SetValue(ContentProperty, "Delete user");
                buttonColumn.CellTemplate = buttonTemplate;

                datagr.Columns.Add(buttonColumn);
            }

            hplback.Click += new RoutedEventHandler((sender, e) => hplback_Click_1(sender, e, isadm, username));
            pgAct.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, username, flag));

        }
        void Checked(object sender, RoutedEventArgs e)
        {
            WPFContext context = new WPFContext();
            try
            {
                var player = context.Users.First(a => a.UserID == datagr.SelectedIndex + 1);

                player.IsAdmin = true;
                MessageBox.Show("User is now admin");
                context.SaveChanges();


            }
            catch { }

        }
        void Unchecked(object sender, RoutedEventArgs e)
        {
            WPFContext context = new WPFContext();
            try
            {
                var player = context.Users.First(a => a.UserID == datagr.SelectedIndex + 1);
                if (player.Username == "admin")
                {
                    MessageBox.Show("Administrator righs for this user cannot be removed");
                    player.IsAdmin = true;
                }
                else
                {
                    player.IsAdmin = false;
                    MessageBox.Show("User is no more admin");
                    context.SaveChanges();

                }

            }
            catch { }

        }
        void btnRemove_Click(object sender, RoutedEventArgs e,bool isadm, string username)
        {
            try
            {
                WPFContext context = new WPFContext();
                if (MessageBox.Show("Are you sure you want to remove this user?", "Are you sure?",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    datagr.UnselectAll();
                }
                else
                {
                   var res = context.Users.FirstOrDefault(a => a.UserID == datagr.SelectedIndex + 1);
                   if (res.IsAdmin == true)
                   {
                        MessageBox.Show("This user is admin and cannot be deleted");
                   }
                   else
                   {
                        context.Users.Remove(res);
                        context.SaveChanges();
                        datagr.ItemsSource = null;
                        flag1 = 1;
                        OrderFix();
                        FillPage(isadm, username);
                   }
                }
            }
            catch { }
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
