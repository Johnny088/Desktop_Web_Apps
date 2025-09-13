using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Xml;
namespace _02_Ado_NET_Sales
{
    class SalesDB : IDisposable
    {
        private List<Items> items;
        private SqlConnection sqlConnection;

        public SalesDB(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);   // Creating the sql connection
            items = new List<Items>();
        }

        //-------------------------------CRUD Operations---------------------------------

        private void CreateAsInsert(Items item)
        {
            string CmdText = $@"insert into Salles values ({item.ProductID}, {item.Price}, {item.Quantity}, {item.EmployeeID},
                             {item.ClientID}, '{item.Date}')";
            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            command.CommandTimeout = 5; // seconds - default is 30 seconds
            int rows = command.ExecuteNonQuery();
            if (rows == 0)
            {
                printR("No rows affected");
            }
            else
            {
                printG($"Rows was affected {rows}");
            }


        }
        private void ReadAll()
        {
            string CmdText = @"select * from Salles";
            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())                           //reading the data
            {
                items.Add(new Items
                {
                    Id = (int)reader[0],
                    ProductID = (int)reader[1],
                    Price = (decimal)reader[2],
                    Quantity = (int)reader[3],
                    EmployeeID = (int)reader[4],
                    ClientID = (int)reader[5],
                    Date = (DateTime)reader[6]
                });
            }
            printG("Data was read successfully");
            reader.Close();

        }
        private void ShowItems()
        {
            foreach (var item in items)
            {
                printY(item);
            }
        }
        private void ShowItemsFilter()
        {
            DateTime dataBegin, dataEnd;
            printC("Type the begin date: (yyyy-mm-dd) ");
            dataBegin = DateTime.Parse(Console.ReadLine()!);
            printC("Type the end date: (yyyy-mm-dd) ");
            dataEnd = DateTime.Parse(Console.ReadLine()!);
            string CmdText = $@"select * from Salles as s where s.DateSalles between '{dataBegin}' and '{dataEnd}'";
            items.Clear();
            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())                           //reading the data
            {
                items.Add(new Items
                {
                    Id = (int)reader[0],
                    ProductID = (int)reader[1],
                    Price = (decimal)reader[2],
                    Quantity = (int)reader[3],
                    EmployeeID = (int)reader[4],
                    ClientID = (int)reader[5],
                    Date = (DateTime)reader[6]
                });
            }
            printG("Data was read successfully");
            reader.Close();
        }
        private void LastPurchaseClient()
        {
            printC("Enter the full name on the client ");
            string fullName = Console.ReadLine()!;
            string CmdText = $@"select top 1 p.Name as Product, s.Price, c.FullName, s.DateSalles
                                from Salles as s join Clients as c on c.id = s.ClientId
				                                 join Products as p on p.id = s.ProductId
                                                 where c.FullName = '{fullName}'
                                                 order by s.DateSalles";
            items.Clear();
            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n--------------------------");

            //////// відображаємо всі значення кожного рядка
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],14} ");
                }
                Console.WriteLine();
            }

        }

        private void TopSeller()
        {
            string CmdText = $@"select top 1 e.FullName, sum(s.Price)
                             from Salles as s join Employees as e on s.EmployeeId = e.Id
                             group by e.FullName
                             order by sum(s.Price) desc";
            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            printY("");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            //////// відображаємо всі значення кожного рядка
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],14} ");
                }
                Console.WriteLine();
            }

            reader.Close();
        }
        private void Update(int id)
        {
            
        }
        private void DeleteID(int idDel)
        {
            string CmdText = $@"delete Salles where Id = {idDel}";
            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            int rows = command.ExecuteNonQuery();
            if (rows == 0)
            {
                printR("No rows affected");
            }
            else
            {
                printG($"Rows was affected {rows}");
            }

        }

        //-------------------------------Menu---------------------------------

        public void Menu()
        {
            sqlConnection.Open();  // Opening the sql connection
            Console.WriteLine("Connected successfully");
            int option;
            do
            {
                printDC("\t\tShop Data \n1 - Insert to Sql Database \n2 - Read all Data from the Sql to the list \n3 - show all date from the items" +
                    " \n4 - Delete Salles by Id (not the client) \n5 - Show all products by given period of time \n6 - last purchase by client \n7 - Top Seller \n0 - Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        bool valid = true;
                        while (valid)
                        {
                            Items item = new Items();
                            printC("ProductID: (int) "); item.ProductID = int.Parse(Console.ReadLine());
                            printC("Price: (decimal) "); item.Price = decimal.Parse(Console.ReadLine());
                            printC("Quantity: (int) "); item.Quantity = int.Parse(Console.ReadLine());
                            printC("EmployeeID: (int) "); item.EmployeeID = int.Parse(Console.ReadLine());
                            printC("ClientID: (int) "); item.ClientID = int.Parse(Console.ReadLine());
                            printC("Date: (yyyy-mm-dd) "); item.Date = DateTime.Parse(Console.ReadLine());
                            CreateAsInsert(item);
                            bool flag = true;
                            do
                            {

                                printC("Do you want to add another item? (y/n): ");
                                string key = Console.ReadLine();
                                if (key == "y")
                                {
                                    valid = true;
                                    flag = false;
                                }
                                else if (key == "n")
                                {
                                    valid = false;
                                    flag = false;
                                }
                                else
                                {
                                    printR("You typed the wrong button, please push the right one...");
                                }
                            } while (flag);

                        }

                        break;

                    case 2:
                        items.Clear();
                        ReadAll();
                        break;
                    case 3:
                        ShowItems();
                        break;
                    case 4:
                        printC("Type the ID you want to delete: (int) ");
                        int idDel = int.Parse(Console.ReadLine());
                        DeleteID(idDel);
                        break;
                    case 5:
                        ShowItemsFilter();
                        ShowItems();
                        break;
                    case 6:
                        LastPurchaseClient();
                        ShowItems();
                        break;
                    case 7:
                        TopSeller();
                        break;
                    case 0:
                        sqlConnection.Close();    // Closing the sql connection
                        printC("Disconnected successfully");
                        reset();
                        break;
                    default:
                        break;
                }
            }while (option != 0);
        }
        //-------------------------------Print---------------------------------
        #region print

        public void printR<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void printC<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
        }
        public void printDC<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(message);
        }
        public void printY<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
        }
        public void printG<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }
        public void printDY<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(message);
        }
        public void reset()
        {
            Console.ResetColor();
        }
        #endregion

        public void Dispose()
        {
            sqlConnection.Close();  // Closing the sql connection
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            #region Connection
            string connectionString = @"Data Source = MIAMI\SQLEXPRESS;   
                                        Initial Catalog = SportShop; 
                                        Integrated Security = True;
                                        TrustServerCertificate = True;";
            //Data Source = MIAMI\SQLEXPRESS; - path to the server
            //Initial Catalog = SalesDB;      - the name of the database
            //Integrated Security = True;     - the type of the authentication
            //TrustServerCertificate = True;  - to avoid ssl warning messages
            #endregion
            using

            SalesDB salesDB = new SalesDB(connectionString);
            salesDB.Menu();

        }
    }
}
