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
using Microsoft.EntityFrameworkCore;

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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = context.Awards.Include(m => m.Medal).Include(a => a.Player).ThenInclude(p => p.CountryTeam)
                .Include(m => m.Olympic).ThenInclude(o => o.CountryHost).Where(ch => ch.Olympic.CountryHost.Name == "Japan")
                .Select(a => new
                {
                    Country = a.Player.CountryTeam.Name,
                    Medal = a.Medal.TypeOfMedal,
                    CountryHost = a.Olympic.CountryHost.Name
                }).ToList();
            datagrid.ItemsSource = result;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var result2 = context.Awards.Include(a => a.Medal).Include(a => a.Olympic).ThenInclude(a => a.CountryHost).Include(a => a.Player).ThenInclude(p => p.NameOfGame)
                .Include(a => a.Player).ThenInclude(p => p.CountryTeam).Where(a => a.Olympic.CountryHost.Name == "Japan")
                .Select(a => new
                {
                    Player_Name = a.Player.Name,
                    Player_Surname = a.Player.Surname,
                    Country = a.Player.CountryTeam.Name,
                    Game = a.Player.NameOfGame,
                    Medal = a.Medal.TypeOfMedal,
                    CountryHost = a.Olympic.CountryHost.Name

                }).ToList();
            datagrid.ItemsSource = result2;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var result3 = context.Awards.Include(m => m.Medal).Include(a => a.Player).ThenInclude(p => p.CountryTeam)
                .Include(m => m.Olympic).ThenInclude(o => o.CountryHost).Where(ch => ch.Olympic.CountryHost.Name == "Canada").GroupBy(a => a.Player.CountryTeam.Name)
                .Select(a => new
                {
                    Country = a.Key,
                    TotalMedals = a.Count(),
                }).OrderByDescending(a => a.TotalMedals).Take(1).ToList();
            datagrid.ItemsSource = result3;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var result4 = context.Awards.Include(m => m.Medal).Include(a => a.Player).ThenInclude(p => p.CountryTeam)
                .Include(m => m.Olympic).ThenInclude(o => o.CountryHost).Where(ch => ch.Olympic.CountryHost.Name == "The USA").GroupBy(a => a.Player.CountryTeam.Name)
                .Select(a => new 
                {
                    Country = a.Key,
                    TotalMedals = a.Count(),
                    Gold = a.Count(a => a.Medal.TypeOfMedal == "Gold"),
                    Silver = a.Count(a => a.Medal.TypeOfMedal == "Silver"),
                    Bronze = a.Count(a => a.Medal.TypeOfMedal == "Bronze"),
                }).OrderByDescending(a => a.Gold).Take(1).ToList();
            datagrid.ItemsSource = result4;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var result5 = context.Awards.Include(m => m.Medal).Include(a => a.Player).ThenInclude(p => p.CountryTeam)
                .Include(m => m.Olympic).ThenInclude(o => o.CountryHost).Where(a => a.Player.NameOfGame.Name == "SkateBoarding")
                .GroupBy(a => a.Player).Select(a => new 
                {
                    Player_Name = a.Key,
                    Gold_Medals = a.Count(a => a.Medal.TypeOfMedal == "gold")
                }).OrderByDescending(a => a.Gold_Medals).Take(1).ToList();
            datagrid.ItemsSource = result5;
               

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Players = context.Players.Include(p => p.CountryTeam).Include(p => p.NameOfGame).Select(p => new 
            {
                Name = p.Name,
                Surname = p.Surname,
                Country = p.CountryTeam.Name,
                Game = p.NameOfGame
            }).ToList();
            datagrid.ItemsSource = Players;
        }
    }
}