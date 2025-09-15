using _03_data_access.models;
using Microsoft.IdentityModel.Protocols;
using System.Text;
using System.Configuration;

namespace _02_ADO_NET_Desktop
{




    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionString = @"Data Source = MIAMI\SQLEXPRESS;   
                                        Initial Catalog = SportShop; 
                                        Integrated Security = True;
                                        TrustServerCertificate = True;";
            //string connectionString = ConfigurationManager.ConnectionStrings["SportShopDBConnection"].ConnectionString;
            using (SalesDB items = new SalesDB(connectionString))
            {
                items.ReadAll();
                items.ShowItems();
                //items.LastPurchaseClient("Романчук Людмила Степанівна';create table Hacked(id int);--");  // doesn't work even without protection, it must be because of Order by
                items.LastPurchaseClient("Романчук Людмила Степанівна");
                //items.Test("Романчук Людмила Степанівна';create table Hacked(Id int);--");
                //items.Test("Романчук Людмила Степанівна");
                items.TopSeller();
                items.reset();
            }

            using (SalesDB item2 = new SalesDB(connectionString))
            {
                SallesItems itemTest = new SallesItems()
                {
                    ProductID = 4,
                    Price = 4500,
                    Quantity = 1,
                    EmployeeID = 1,
                    ClientID = 2,
                    Date = DateTime.Now
                };
                item2.CreateAsInsert(itemTest);
                Console.WriteLine("------------------------------------------------");
                item2.ReadAll();
                item2.ShowItems();
                item2.reset();
            }
        }
    }
}
