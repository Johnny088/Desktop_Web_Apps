using _02_ADO_NET_Desktop;
using _03_data_access.models;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _03_SportShopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SalesDB db;
        SallesItems itemTest;
        public MainWindow()
        {
            InitializeComponent();
            //to add the class from other project we need to make the  <console> "Class Library"
            //then we need to move our classes to separate classes from Program.cs, than holding classes by mouse left button move to the  "Class Library project"
            // then right click on the "Dependencies" of the current project and choose "add project reference" and choose the "Class Library" project
            //then we need to add "using _02_ADO_NET_Desktop;" to the current project   ?? I have no idea why, but the Data_access impossible to be used like a namespace
            string connectionString = ConfigurationManager.ConnectionStrings["SportShopDBConnection"].ConnectionString;
            // Connection string must be in Application configuration file --> right click on the SportShopUI --> add new Item

            db = new SalesDB(connectionString);
            //items.LastPurchaseClient("Романчук Людмила Степанівна");
            itemTest = new SallesItems()
            {
                ProductID = 5,
                Price = 5500,
                Quantity = 10,
                EmployeeID = 2,
                ClientID = 2,
                Date = DateTime.Now
            };

        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            
            dataGrid.ItemsSource = db.ReadAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.LastPurchaseClient("Романчук Людмила Степанівна");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.CreateAsInsert(itemTest);
        }
    }
}