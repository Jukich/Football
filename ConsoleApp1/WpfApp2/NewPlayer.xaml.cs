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
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for NewPlayer.xaml
    /// </summary>
    public partial class NewPlayer : Page
    {
        public List<string> Nationalities { get; set; }
        public List<string> Positions { get; set; }
        int flag = 0;
        public NewPlayer(bool isadm,string username)
        {
            this.DataContext = this;
            FillNationalities();
            FillPositions();
            InitializeComponent();
            hplback.Click += new RoutedEventHandler((sender, e) => hplback_Click_1(sender, e, isadm, username));
            pgNewP.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, username, flag));
        }
       
        private void Btnadd_Click(object sender, RoutedEventArgs e)
        {
            WPFContext context = new WPFContext();
            //player newP = new player();
           
            try
            {
                 foreach (TextBox t in this.gri2.Children.OfType<TextBox>())
                {
                    if (t.Text == string.Empty)
                    {
                        t.Text = "Empty";
                        
                    }
                }
                foreach (ComboBox cb in this.gri2.Children.OfType<ComboBox>())
                {
                    if (cb.Text == string.Empty)
                    {
                        cb.Text = "Empty";

                    }
                }
                foreach (TextBox t in this.gri.Children.OfType<TextBox>())
                {
                    if (t.Text == string.Empty)
                    {
                        t.Text = "Empty";
                    }
                }
                DateTime dt = new DateTime(Convert.ToInt32(txtyear.Text), 
                    Convert.ToInt32(txtmonth.Text), Convert.ToInt32(txtday.Text));
                player newP = new player();
                newP.name = txtName.Text.ToString();
                newP.surename = txtSure.Text.ToString();
                newP.dateOfBirth = dt;
                newP.Nationality = cmbnat.SelectedItem.ToString();
                newP.position = cmbpos.SelectedItem.ToString();
                newP.teamNumber = Convert.ToInt32(txtnumb.Text);
                newP.careergoals = Convert.ToInt32(txtgoal.Text);
                newP.img = txtimg.Text.ToString();
                if (!context.Players.All(o => o.teamNumber != newP.teamNumber))
                {
                    MessageBox.Show("Player with this team number already exists");                  
                }
                else if (!File.Exists(txtimg.Text.ToString()))
                {
                    MessageBox.Show( "Invalid image source");
                }
                else
                {
                    MessageBox.Show("Player created");
                    context.Players.Add(newP);
                    context.SaveChanges();
                }         
            }
            catch
            {
                MessageBox.Show("Incorrect input");            
            }

           
        }
        private void hplback_Click_1(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            flag = 1;
            StartPage pl2 = new StartPage(isadm, username);
            this.NavigationService.Navigate(pl2);


        }
        private void Page_Unloaded(object sender, RoutedEventArgs e, string username, int flag)
        {


            if (flag == 0)
            {
                ActUserDelete.Actuserdel(username);
                Application.Current.Shutdown();
            }

        }
        private void FillNationalities()
        {
            Nationalities = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT Natiolnality
                FROM Nationalities";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    Nationalities.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
        private void FillPositions()
        {
            Positions = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT Position
                FROM Positions";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    Positions.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
    }
}
