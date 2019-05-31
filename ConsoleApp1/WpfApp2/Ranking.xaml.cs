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
using System.ComponentModel;
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        int flag = 0;
        public Page2(bool isadm,string username)
        {
            WPFContext context = new WPFContext();
                     
            InitializeComponent();
            OrderTeams();
            fillpage(isadm,username);

        }
        public void OrderTeams()
        {

            WPFContext context = new WPFContext();

            foreach (team tm in context.Teams)
            {

                tm.Points = (tm.Won * 3 + tm.Drawn);
                tm.GD = tm.GF - tm.GA;
                tm.Played = tm.Won + tm.Lost + tm.Drawn;

            }
            context.SaveChanges();
            int max = context.Teams.Max(a => a.Points);
            List<team> orderTeams = (from p in context.Teams select p)
                .OrderByDescending(a => a.Points).ThenByDescending(a=>a.GD).ToList();
            for (int i = 0; i < orderTeams.Count; i++)
            {
                orderTeams[i].Position = i + 1;
            }
            delete();
            create();
            AddTeams(orderTeams);
        }

        private void delete()
        {
            using (SqlConnection connection = new
           SqlConnection(Properties.Settings.Default.DbConnect))
            {
                SqlCommand command = new SqlCommand("IF OBJECT_ID('dbo.teams')" +
                    " IS NOT NULL DROP TABLE dbo.teams", connection);
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
                SqlCommand command = new SqlCommand("IF OBJECT_ID('dbo.teams') IS NULL " +
                    "CREATE TABLE dbo.teams( Id int IDENTITY (1,1)  PRIMARY KEY,   " +
                    " Position int  NULL, Club nvarchar(MAX) NULL  , Played int NULL," +
                    " Won int NULL,  Drawn int NULL, Lost int NULL, GF int NULL," +
                    " GA int NULL, GD int NULL, Points int NULL);", connection);

                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }


        }


        public void AddTeams(List<team>orderTeams) {

            
            WPFContext context = new WPFContext();

      
            
            foreach (team t in orderTeams)
             {
               context.Teams.Add(t);
            }
            context.SaveChanges();


        }

        public void fillpage(bool isadm,string username)
        {
            int won=0, lost=0, drawn=0;
            int goalsf = 0;
            int goalsa = 0;
            WPFContext context = new WPFContext();
           
    
            foreach(fixtures m in context.Results)
            {
                if (m.hometeam == "Chelsea")
                {
                    goalsf+= Int32.Parse(m.result.Substring(0, 1));
                    goalsa+= Int32.Parse(m.result.Substring(2, 1));
                    if(Int32.Parse(m.result.Substring(0, 1))> 
                        Int32.Parse(m.result.Substring(2, 1))){
                        won++;
                    }
                    else if (Int32.Parse(m.result.Substring(0, 1))== 
                        Int32.Parse(m.result.Substring(2, 1)))
                    {
                        drawn ++;
                    }
                    else
                    {
                        lost++;
                    }
                }
                if (m.awayteam == "Chelsea")
                {
                    goalsf += Int32.Parse(m.result.Substring(2, 1));
                    goalsa +=Int32.Parse(m.result.Substring(0, 1));
                    if (Int32.Parse(m.result.Substring(0, 1)) > 
                        Int32.Parse(m.result.Substring(2, 1)))
                    {
                        lost++;
                    }
                    else if (Int32.Parse(m.result.Substring(0, 1)) == 
                        Int32.Parse(m.result.Substring(2, 1)))
                    {
                        drawn++;
                    }
                    else
                    {
                        won++;
                    }
                }  

            }
            foreach (team t in context.Teams)
            {
                if (t.Club == "Chelsea")
                {
                    t.GF = goalsf;
                    t.GA = goalsa;
                    t.Won = won;
                    t.Lost = lost;
                    t.Drawn = drawn;
                }

            }
            foreach (team tm in context.Teams)
            {

                tm.Points = (tm.Won * 3 + tm.Drawn);
                tm.GD = tm.GF - tm.GA;
                tm.Played = tm.Won + tm.Lost + tm.Drawn;

            }
            context.SaveChanges();
            WPFContext context1 = new WPFContext();

            List<team> teamlist;
            teamlist = context.Teams.ToList();
            if (isadm == true)
            {
                var newList = teamlist.OrderBy(x => x.Position).ToList();             
                datagr.ItemsSource = newList ;
                colPosition.IsReadOnly = true;
                colPlayed.IsReadOnly = true;
                colGD.IsReadOnly = true;
                colPoints.IsReadOnly = true;
                colID.Visibility = Visibility.Hidden;
                datagr.CanUserSortColumns = false;
         
            }
      
            if (isadm == false)
            {
                var newList = teamlist.OrderBy(x => x.Position).ToList();
                teamlist.Sort((x, y) => string.Compare(x.Position.ToString(), y.Position.ToString()));              
                datagr.ItemsSource = newList;
                datagr.IsReadOnly =true;
                colID.Visibility = Visibility.Hidden;
                
            }
            hplback.Click += new RoutedEventHandler((sender, e) => hplback_Click_1(sender, e, isadm, username));
            pgRanking.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, username, flag));
            datagr.CurrentCellChanged += new EventHandler<EventArgs>((sender, e) => 
            Datagr_CurrentCellChanged(sender, e, isadm,username));

        }


        private void Datagr_CurrentCellChanged(object sender, EventArgs e, bool isadm,string username)
        {
            WPFContext context = new WPFContext();
            try
            {
                       
                var LastID = context.Teams.OrderByDescending(a => a.ID).FirstOrDefault().ID;
                if ((datagr.SelectedIndex + 1) > LastID)
                {
                    team t = new team();
                    t.ID = LastID + 1;
                    context.Teams.Add(t);
                }
                DataGridRow r = (DataGridRow)datagr.ItemContainerGenerator.ContainerFromIndex(datagr.SelectedIndex);
                DataGridCell RowColumn = datagr.Columns[datagr.CurrentColumn.DisplayIndex].GetCellContent(r).Parent as DataGridCell;
                string CellValue = ((TextBlock)RowColumn.Content).Text;
     
                

                if ((datagr.SelectedIndex + 1) > LastID && (datagr.SelectedIndex+1)<20)
                {
                    team t = new team();
                    t.ID = LastID + 1;
                    context.Teams.Add(t);
                    context.SaveChanges();
                }
                var team = context.Teams.First(a => a.Position == datagr.SelectedIndex + 1);

                if (datagr.CurrentColumn.DisplayIndex == 2)

                {
                    
                    team.Club = CellValue;
                    context.SaveChanges();
                    OrderTeams();
                    fillpage(isadm, username);
                }

                if (datagr.CurrentColumn.DisplayIndex == 4)

                {
                    int newg = Convert.ToInt32(CellValue);
                    team.Won = newg;
                    context.SaveChanges();
                    OrderTeams();
                    fillpage(isadm, username);
                }
                if (datagr.CurrentColumn.DisplayIndex == 5)

                {
                    int newg = Convert.ToInt32(CellValue);
                    team.Drawn = newg;
                    context.SaveChanges();
                    OrderTeams();
                    fillpage(isadm, username);
                }
                if (datagr.CurrentColumn.DisplayIndex == 6)

                {
                    int newg = Convert.ToInt32(CellValue);
                    team.Lost = newg;
                    context.SaveChanges();
                    OrderTeams();
                    fillpage(isadm, username);
                }
                if (datagr.CurrentColumn.DisplayIndex == 7)

                {
                    int newg = Convert.ToInt32(CellValue);
                    team.GF = newg;
                    context.SaveChanges();
                    OrderTeams();
                    fillpage(isadm, username);
                }
                if (datagr.CurrentColumn.DisplayIndex == 8)

                {
                    int newg = Convert.ToInt32(CellValue);
                    team.GA = newg;
                    context.SaveChanges();
                    OrderTeams();
                    fillpage(isadm, username);
                }


            }
            catch  { }

            

        }
        private void hplback_Click_1(object sender, RoutedEventArgs e, bool isadm, string username)
        {
            flag = 1;
            StartPage pl = new StartPage(isadm, username);
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
