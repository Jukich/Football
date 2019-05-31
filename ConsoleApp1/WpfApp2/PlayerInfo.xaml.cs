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
using System.Data;

using Players;
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for PlayerInfo.xaml
    /// </summary>
    public partial class PlayerInfo : Page
    {
        int flag = 0;
        public List<string> Nationalities { get; set; }
        public List<string> Positions { get; set; }
        public PlayerInfo()
        {

            this.DataContext = this;
            FillNationalities();
            FillPositions();
            
            InitializeComponent();
            FillDates();       


        }
        public PlayerInfo(player data,bool isadm,string username) : this()
        {
            WPFContext context = new WPFContext();
            lblName.Content = data.name.ToString();
            lblSure.Content = data.surename.ToString();
            txtdate.Text = data.dateOfBirth.ToString("  dd MMMM yyyy");
            SetAge();
            txtage.Text = data.age.ToString();
            txtnat.Text = data.Nationality.ToString();
            txtpos.Text = data.position.ToString();
            cmbday.Text = data.dateOfBirth.Day.ToString();
            cmbmonth.Text = data.dateOfBirth.Month.ToString();
            cmbyear.Text = data.dateOfBirth.Year.ToString(); 
            cmbnat.Text = data.Nationality.ToString();
            cmbpos.Text = data.position.ToString();
            txtnumb.Text = data.teamNumber.ToString();
            txtgoal.Text = data.goalsScored.ToString();
            

            Image imag = new Image();
            imag.Source = new BitmapImage(new Uri(data.img.ToString()));
            gri.Children.Add(imag);
            imag.SetValue(Grid.ColumnProperty, 0);
            imag.Height = 200;
            imag.Width = 200;
            imag.Margin = new Thickness(40, 50, 40, 100);
            imag.HorizontalAlignment = HorizontalAlignment.Left;
            imag.VerticalAlignment = VerticalAlignment.Top;
            foreach (Control c in this.gri2.Children.OfType<Control>())
            {
                c.FontWeight = FontWeights.Bold;
                
                                      
            }

          
            if (isadm == true)
            {
                foreach (TextBox t in this.gri2.Children.OfType<TextBox>())
                {
                    t.IsReadOnly = false;
                    txtdate.Visibility = Visibility.Hidden;
                    txtnat.Visibility = Visibility.Hidden;
                    txtpos.Visibility = Visibility.Hidden;
                    btndel.Visibility = Visibility.Visible;
                }
                
            }
            else foreach (TextBox t in this.gri2.Children.OfType<TextBox>())
                {
                    t.IsReadOnly = true;
                    cmbnat.IsEnabled = false;
                    cmbpos.IsEnabled = false;
                    cmbday.Visibility = Visibility.Hidden;
                    cmbmonth.Visibility = Visibility.Hidden;
                    cmbyear.Visibility = Visibility.Hidden;
                    aplch.Visibility = Visibility.Hidden;
                    cmbnat.Visibility = Visibility.Hidden;
                    cmbpos.Visibility = Visibility.Hidden;
                }

           void cmbnatchanged(object sender, RoutedEventArgs e)
            {
                var player = context.Players.First(a => a.teamNumber == data.teamNumber);

                         

                try
                {
                    string nat = cmbnat.SelectedItem.ToString() ;
                    player.Nationality = nat;
                    context.SaveChanges();
                    SetAge();
                }
                catch { }
                SetAge();

            }
            
            void cmbposchanged(object sender, RoutedEventArgs e)
            {
                var player = context.Players.First(a => a.teamNumber == data.teamNumber);
                                            
                try
                {
                    string pos = cmbpos.SelectedItem.ToString() ;
                    player.position = pos;
                    context.SaveChanges();
                }
                catch { }

            }
            void cmbdatechanged(object sender, RoutedEventArgs e)
            {
                var player = context.Players.First(a => a.teamNumber == data.teamNumber);

                try
                {
                    int year = Int32.Parse(cmbyear.SelectedItem.ToString());
                    int month = Int32.Parse(cmbmonth.SelectedItem.ToString());
                    int day = Int32.Parse(cmbday.SelectedItem.ToString());
                    DateTime dt = new DateTime(year, month, day);
                    DateTime now = DateTime.Now;
                    if (DateTime.Compare(dt, now) > 0)
                    {
                        MessageBox.Show("Incorrect input");
                    }
                    player.dateOfBirth = dt;
                    context.SaveChanges();
                }
                catch { }

            }




            void txtgoalchanged(object sender, RoutedEventArgs e)
                {
                    var player = context.Players.First(a => a.teamNumber == data.teamNumber);
                  
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtgoal.Text, "[^0-9]"))
                        {
                            MessageBox.Show("Please enter only numbers.");
                            txtgoal.Text = txtgoal.Text.Remove(txtgoal.Text.Length - 1);
                        }

                try
                {
                    int newg = Int32.Parse(txtgoal.Text);
                    player.goalsScored = newg;
                    context.SaveChanges();
                }
                catch { }

            }

            void myButton_Click(object sender, RoutedEventArgs e)
            {            
                try
                {                    
                    var player = context.Players.First(a => a.teamNumber == data.teamNumber);
                    if (txtnumb.Text == string.Empty)
                    {
                        MessageBox.Show("Feild Empty");
                    }
                    if (System.Text.RegularExpressions.Regex.IsMatch(txtnumb.Text, "[^0-9]"))
                    {
                        MessageBox.Show("Please enter only numbers.");
                        txtnumb.Text = txtnumb.Text.Remove(txtnumb.Text.Length - 1);
                    }
                    else
                    {
                        int newg = Int32.Parse(txtnumb.Text);
                        if (context.Players.All(o => o.teamNumber != newg))
                        { 
                            player.teamNumber = newg;
                            context.SaveChanges();
                            MessageBox.Show("Player number changed"); 
                        }
                        else
                        {
                            MessageBox.Show("Player with this team number already exists");
                            txtnumb.Text = string.Empty;

                        }

                    }
                 


                }



                catch { }
               


            }
            void btndel_Click(object sender, RoutedEventArgs e)
            {
                var player = context.Players.First(a => a.teamNumber == data.teamNumber);
                if (MessageBox.Show("Are you sure you want to delete this player?", "Are you sure?",
                    MessageBoxButton.YesNo,  MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    context.Players.Remove(player);
                    context.SaveChanges();
                    flag = 1;
                    Players pl = new Players(isadm,username);
                    this.NavigationService.Navigate(pl);
                }
            }
            cmbday.SelectionChanged += new SelectionChangedEventHandler(cmbdatechanged);
            cmbmonth.SelectionChanged += new SelectionChangedEventHandler(cmbdatechanged);
            cmbyear.SelectionChanged += new SelectionChangedEventHandler(cmbdatechanged);
            cmbnat.SelectionChanged += new SelectionChangedEventHandler(cmbnatchanged);
            txtgoal.TextChanged += new TextChangedEventHandler(txtgoalchanged);
            cmbpos.SelectionChanged += new SelectionChangedEventHandler(cmbposchanged);
            MoreInfoHL.Click += new RoutedEventHandler((sender,e)=>MoreInfoHL_Click(sender,e,data,isadm,username));
            backhl.Click += new RoutedEventHandler((sender, e) => backHL_Click(sender, e,  isadm, username));
            aplch.Click += myButton_Click;
            btndel.Click += btndel_Click;
            pgPlInfo.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, username, flag));

        }
        void SetAge()
        {
            WPFContext context1 = new WPFContext();
            foreach (player p in context1.Players)
            {

                p.age = DateTime.Now.Year - p.dateOfBirth.Year;
                if (p.dateOfBirth.Month > DateTime.Now.Month)
                    p.age--;
                else if (p.dateOfBirth.Month == DateTime.Now.Month)
                {
                    if (p.dateOfBirth.Day > DateTime.Now.Day)
                        p.age--;
                }

            }
            context1.SaveChanges();
       

        }

        private void Txtage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void MoreInfoHL_Click(object sender1, RoutedEventArgs e1, player data, bool isadm,string username)
        {
            flag = 1;
            PlayerInfo2 pli2 = new PlayerInfo2(data,isadm,username);
            this.NavigationService.Navigate(pli2);

        }
        public void backHL_Click(object sender1, RoutedEventArgs e1,  bool isadm, string username)
        {
            flag = 1;
            Players pli2 = new Players(isadm,username);
            this.NavigationService.Navigate(pli2);

        }
        private void Page_Unloaded(object sender, RoutedEventArgs e, string username, int flag)
        {
          

            if (flag == 0)
            {
                ActUserDelete.Actuserdel(username);
                Application.Current.Shutdown();
            }

        }
        private void FillDates()
        {
           for (int i = 1900; i <= 2019; i++)
            {
                cmbyear.Items.Add(i);
            }
            for (int i=1; i <= 31; i++)
            {
                cmbday.Items.Add(i);

            }
            for (int i = 1; i <= 12; i++)
            {
                cmbmonth.Items.Add(i);
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

