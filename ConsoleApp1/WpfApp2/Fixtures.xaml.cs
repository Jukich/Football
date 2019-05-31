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
using System.ComponentModel;
using System.Data.SqlClient;
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Fixtures.xaml
    /// </summary>
    public partial class Fixtures : Page
    {
        int flag = 0;
        public Fixtures(bool isadm,string username)
        {
 
            InitializeComponent();
            OrderFix();
            fillpage(isadm,username);
        }
        public void OrderFix()
        {


            WPFContext context = new WPFContext();
            List<fixtures> orderFix = new List<fixtures>();
           foreach (fixtures m in context.Results)
            {
                orderFix.Add(m);
         
            }
            delete();
            create();
            AddFix(orderFix);
        }

        private void delete()
        {
            using (SqlConnection connection = new
           SqlConnection(Properties.Settings.Default.DbConnect))
            {
                SqlCommand command = new SqlCommand("IF OBJECT_ID('dbo.fixtures') " +
                    "IS NOT NULL DROP TABLE dbo.fixtures", connection);
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
                SqlCommand command = new SqlCommand("IF OBJECT_ID('dbo.fixtures') " +
                    "IS NULL CREATE TABLE dbo.fixtures( ID int IDENTITY (1,1) " +
                    " PRIMARY KEY,    date nvarchar(MAX)  NULL, hometeam nvarchar(MAX)" +
                    " NULL  , result nvarchar(MAX) NULL, awayteam nvarchar(MAX) NULL);", connection);

                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }
        public void AddFix(List<fixtures> orderFix)
        {

            WPFContext context = new WPFContext();
            foreach (fixtures m in orderFix)
            {
                context.Results.Add(m);
            }
            context.SaveChanges();


        }
        public void fillpage(bool isadm,string username)
        {
            WPFContext context = new WPFContext();

            List<fixtures> FixList;
            FixList = context.Results.ToList();

            if (isadm == true)
            {
                datagr.ItemsSource = FixList;
              
            }

            if (isadm == false)
            {
                    datagr.ItemsSource = FixList.Select(i => new { i.date,i.hometeam,i.result,i.awayteam});
                    datagr.IsReadOnly = true;

            }
            hplback.Click += new RoutedEventHandler((sender, e) => hplback_Click_1(sender, e, isadm, username));
            datagr.CurrentCellChanged += new EventHandler<EventArgs>((sender,e)=>Datagr_CurrentCellChanged(sender,e,isadm,username));
            datagr.PreviewKeyDown += new KeyEventHandler((sender,e)=>PreviewKeyDownHandler(sender,e,isadm,username));
            pgFix.Unloaded += new RoutedEventHandler((sender, e) => Page_Unloaded(sender, e, username, flag));
        }
           private void Datagr_CurrentCellChanged(object sender, EventArgs e,bool isadm,string username)
            {
              WPFContext context = new WPFContext();
            try
            {

                var LastID = context.Results.OrderByDescending(a => a.ID).FirstOrDefault().ID;
                if ((datagr.SelectedIndex + 1) > LastID)
                {
                    fixtures t = new fixtures();
                    t.ID = LastID + 1;
                    context.Results.Add(t);
                }
                DataGridRow r = (DataGridRow)datagr.ItemContainerGenerator.ContainerFromIndex(datagr.SelectedIndex);
                DataGridCell RowColumn = datagr.Columns[datagr.CurrentColumn.DisplayIndex].GetCellContent(r).Parent as DataGridCell;
                string CellValue = ((TextBlock)RowColumn.Content).Text;



                if ((datagr.SelectedIndex + 1) > LastID)
                {
                    fixtures t = new fixtures();
                    t.ID = LastID + 1;
                    context.Results.Add(t);
                    context.SaveChanges();
                }
                var res = context.Results.First(a => a.ID == datagr.SelectedIndex + 1);

                if (datagr.CurrentColumn.DisplayIndex == 0)

                {
                   

                            res.date = CellValue;
                            context.SaveChanges();
                            OrderFix();
                            fillpage(isadm,username);
                        
                    
                }
                if (datagr.CurrentColumn.DisplayIndex == 1)

                {                   
                            res.hometeam = CellValue;
                            context.SaveChanges();
                            OrderFix();
                            fillpage(isadm, username);                
                }
                if (datagr.CurrentColumn.DisplayIndex == 2)

                {
                    try
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(CellValue.Substring(0, 1), "[^0-9]") ||
                            (CellValue.Substring(1, 1)!="-")||
                            System.Text.RegularExpressions.Regex.IsMatch(CellValue.Substring(2, 1), "[^0-9]"))
                        {
                            MessageBox.Show("Incorrect input. Example input: '0-0'");
                            OrderFix();
                            fillpage(isadm, username);

                        }
                        else
                        {
                            res.result = CellValue;
                            context.SaveChanges();
                            OrderFix();
                            fillpage(isadm, username);
                        }
                    }
                    catch { }
                                      
                }
                if (datagr.CurrentColumn.DisplayIndex == 3)

                {
                    res.awayteam = CellValue;
                    context.SaveChanges();
                    OrderFix();
                    fillpage(isadm, username);
                }
            

                
            }
            catch { }
            
            
        }
        
        private void PreviewKeyDownHandler(object sender, KeyEventArgs e,bool isadm,string username)
        {
            WPFContext context = new WPFContext();

            if (Key.Delete == e.Key)
            {
                if (datagr.SelectedIndex != -1)
                {
                    try
                    {
                        if (MessageBox.Show("Are you sure you want to delete this fixture?", "Are you sure?", 
                            MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            flag = 1;
                            datagr.UnselectAll();
                            Fixtures pg = new Fixtures(isadm, username);
                            this.NavigationService.Navigate(pg);
                        }
                        else
                        {


                            var res = context.Results.FirstOrDefault(a => a.ID == datagr.SelectedIndex + 1);
                            context.Results.Remove(res);
                            context.SaveChanges();
                            Fixtures pg = new Fixtures(isadm, username);
                            flag = 1;
                            datagr.UnselectAll();
                            this.NavigationService.Navigate(pg);
                        }
                    }
                    catch { }
                }
                 
                        
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

    }
}
