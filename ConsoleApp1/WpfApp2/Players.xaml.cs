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
using System.Data;
using System.Data.SqlClient;
using Players;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Players.xaml
    /// </summary>
    public partial class Players : Page
    {
        int flag = 0;
        public Players(bool isadm,string username)
        {

            InitializeComponent();
            ShowPlayers(isadm,username);
            this.DataContext = this;
            Application.Current.MainWindow.Height = 500;
            Application.Current.MainWindow.Width = 700;
            hplBack.Click += new RoutedEventHandler((sender, e) => hplBack_Click(sender, e, isadm, username));
            hplNextPage.Click += new RoutedEventHandler((sender, e) => hplNext_Click(sender, e, isadm, username)); ;
            pgPlayers.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, username, flag));
        }
     
           
        private void ShowPlayers(bool isadm,string username)
        {
            WPFContext context = new WPFContext();
            List<Label> lblNumber = new List<Label>(2);
            List<Hyperlink> hplPlayer = new List<Hyperlink>();
            List<TextBlock> txtPlayer = new List<TextBlock>();

            int h = -350;
            int id = 1;
            int col = 0;
            foreach (player p in context.Players)
            {

                    lblNumber.Add(new Label());
                    txtPlayer.Add(new TextBlock());
                    hplPlayer.Add(new Hyperlink());
                    lblNumber.Add(new Label());
                    
                    try
                    {

                        var getrecord = context.Players.Where(a => a.teamNumber == p.teamNumber).SingleOrDefault();
                        Gr.Children.Add(txtPlayer[id - 1]);
                        Gr.Children.Add(lblNumber[id - 1]);

                        hplPlayer[id - 1].Inlines.Add(getrecord.name + " " + getrecord.surename);
                        hplPlayer[id - 1].Foreground = Brushes.Black;
                        hplPlayer[id - 1].FontWeight = FontWeights.Bold;
                        hplPlayer[id - 1].TextDecorations = null;

                        txtPlayer[id - 1].Inlines.Add(hplPlayer[id - 1]);
                        txtPlayer[id - 1].SetValue(Grid.RowProperty, 1);
                        txtPlayer[id - 1].SetValue(Grid.ColumnProperty, col + 1);
                        txtPlayer[id - 1].Height = 40;
                        txtPlayer[id - 1].Margin = new Thickness(0, h, 0, 0);
                        txtPlayer[id - 1].FontSize = 20;

                        lblNumber[id - 1].Content = getrecord.teamNumber.ToString();
                        lblNumber[id - 1].SetValue(Grid.RowProperty, 1);
                        lblNumber[id - 1].SetValue(Grid.ColumnProperty, col);
                        lblNumber[id - 1].Height = 40;
                        lblNumber[id - 1].Margin = new Thickness(0, h - 10, 0, 0);
                        lblNumber[id - 1].Foreground = new SolidColorBrush(Colors.Transparent);
                        lblNumber[id - 1].FontSize = 20;
                        lblNumber[id - 1].Foreground = Brushes.Black;
                        lblNumber[id - 1].HorizontalAlignment = HorizontalAlignment.Center;

                        PlayerInfo playerInfo = new PlayerInfo(p, isadm, username);
                        hplPlayer[id - 1].Click += new RoutedEventHandler((sender,e)=>hlclick(sender,e, playerInfo));

                        h += 60;
                        id++;                      
                        if (id == 14)
                        {
                            col += 2;
                            h = -350;
                        }
                    


                    }
                    catch(NullReferenceException e)
                    {
                        continue;
                    }


                
            }
           

        }
        void hlclick(object sender, RoutedEventArgs e,PlayerInfo playerInfo)
        {
            flag = 1;
            this.NavigationService.Navigate(playerInfo);
        }
        private void hplBack_Click(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            flag = 1;
            StartPage pl = new StartPage(isadm, username);
            this.NavigationService.Navigate(pl);
        }
        private void hplNext_Click(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            flag = 1;
            Player2 pl = new Player2(isadm, username);
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
