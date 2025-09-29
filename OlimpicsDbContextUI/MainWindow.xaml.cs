using System.Configuration;
using _05_OlympicsDataAccess.Entities;
using System.Text;
using _05_Final_work;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OlimpicsDbContextUI
{
    public partial class MainWindow : Window
    {
        public OlympicsGamesDbContext context { get; set; }
        public MainWindow() 
        {
            InitializeComponent();
            context = new OlympicsGamesDbContext();
            string connectionString = ConfigurationManager.ConnectionStrings["OlympicsDbConnection"].ConnectionString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = context.Players.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}