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
    /// Interaction logic for PlayerInfo2.xaml
    /// </summary>
    public partial class PlayerInfo2 : Page
    {
        int flag=0;
        public PlayerInfo2()
        {
            InitializeComponent();

        }
        public PlayerInfo2(player data,bool isadm,string username) : this()
        {
            WPFContext context = new WPFContext();
            lblName.Content = data.name.ToString();
            lblSure.Content = data.surename.ToString();
            Image imag = new Image();
            imag.Source = new BitmapImage(new Uri(data.img.ToString()));
            gri.Children.Add(imag);
            imag.SetValue(Grid.ColumnProperty, 0);
            imag.Height = 200;
            imag.Width = 200;
            //  < Image Grid.Column = "0" Height = "200" Width = "200" Margin = "100,60,100,190" />
            imag.Margin = new Thickness(40, 50, 40, 100);
            imag.HorizontalAlignment = HorizontalAlignment.Left;
            imag.VerticalAlignment = VerticalAlignment.Top;
            foreach (Control c in this.gri2.Children.OfType<Control>())
            {
                c.FontWeight = FontWeights.Bold;


            }
            txtapp.Text = data.appearances.ToString();
            txtass.Text = data.assists.ToString();
            txtyc.Text = data.YC.ToString();
            txtrc.Text = data.Rc.ToString();
            txtcarg.Text = data.careergoals.ToString();
            txtval.Text = "€"+ data.value.ToString()+ " million";

            var player = context.Players.First(a => a.teamNumber == data.teamNumber);
            txtcarg.Text = (player.careergoals + player.goalsScored).ToString();

            txtapp.TextChanged += new TextChangedEventHandler(txtappchanged);
            txtass.TextChanged += new TextChangedEventHandler(txtasschanged);
            txtyc.TextChanged += new TextChangedEventHandler(txtycchanged);
            txtrc.TextChanged += new TextChangedEventHandler(txtrchanged);
            backhl.Click += new RoutedEventHandler((sender, e) => backHL_Click(sender, e,data, isadm, username));
            pgPlInfo.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, username, flag));

            if (isadm == true)
            {
                foreach (TextBox t in this.gri2.Children.OfType<TextBox>())
                {
                    t.IsReadOnly = false;
                }
            }
            else foreach (TextBox t in this.gri2.Children.OfType<TextBox>())
                {
                    t.IsReadOnly = true;              
                }
            void txtappchanged(object sender, RoutedEventArgs e)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtapp.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    txtapp.Text = txtapp.Text.Remove(txtapp.Text.Length - 1);
                }
                try
                {
                    int newst = Int32.Parse(txtapp.Text);                  
                    player.appearances = newst;
                    context.SaveChanges();
                }
                catch { }
            }

            void txtasschanged(object sender, RoutedEventArgs e)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtass.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    txtass.Text = txtass.Text.Remove(txtass.Text.Length - 1);
                }
                try
                {
                    int newst = Int32.Parse(txtass.Text);
                    player.assists = newst;
                    context.SaveChanges();
                }
                catch { }
            }
            void txtycchanged(object sender, RoutedEventArgs e)
            {

                if (System.Text.RegularExpressions.Regex.IsMatch(txtyc.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    txtyc.Text = txtyc.Text.Remove(txtapp.Text.Length - 1);
                }

                try
                {
                    int newst = Int32.Parse(txtyc.Text);
                    player.YC = newst;
                    context.SaveChanges();

                }
                catch { }


            }
            void txtrchanged(object sender, RoutedEventArgs e)
            {

                if (System.Text.RegularExpressions.Regex.IsMatch(txtrc.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    txtrc.Text = txtrc.Text.Remove(txtrc.Text.Length - 1);
                }

                try
                {
                    int newst = Int32.Parse(txtrc.Text);
                    player.Rc = newst;
                    context.SaveChanges();

                }
                catch { }


            }

        }
        public void backHL_Click(object sender1, RoutedEventArgs e1, player data, bool isadm, string username)
        {
            flag = 1;
            PlayerInfo pli2 = new PlayerInfo(data, isadm, username);
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
    }
}
