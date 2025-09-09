using Microsoft.Data.SqlClient;
using System.Text;

namespace _01_ADO_NET
{

    internal class Program
    {
        static void ShowCastomers( SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Clients
                              ";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// ExecuteReader - виконує команду select та повертає результат у вигляді
            //// DbDataReader
            SqlDataReader reader = command.ExecuteReader();


            //// відображається назви всіх колонок таблиці
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

        static void ShowSellers(SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Employees
                              ";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// ExecuteReader - виконує команду select та повертає результат у вигляді
            //// DbDataReader
            SqlDataReader reader = command.ExecuteReader();


            //// відображається назви всіх колонок таблиці
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
        static void ShowSallesByName(SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Salles as s join Clients as c on s.ClientId = c.Id
                              where c.FullName = 'Петрук Степан Романович'";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// ExecuteReader - виконує команду select та повертає результат у вигляді
            //// DbDataReader
            SqlDataReader reader = command.ExecuteReader();


            //// відображається назви всіх колонок таблиці
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
        static void ShowFilterPrice(SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Salles as s join Products as p on p.Id = s.ProductId
                              where s.Price <= 1800";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// ExecuteReader - виконує команду select та повертає результат у вигляді
            //// DbDataReader
            SqlDataReader reader = command.ExecuteReader();


            //// відображається назви всіх колонок таблиці
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


        static void ShowMinSalesPrice(SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Salles as s join Products as p on p.Id = s.ProductId
                              where s.Price = ( select min(price) from Salles)";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// ExecuteReader - виконує команду select та повертає результат у вигляді
            //// DbDataReader
            SqlDataReader reader = command.ExecuteReader();

           

            //// відображається назви всіх колонок таблиці
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

        static void ShowMaxSalesPrice(SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Salles as s join Products as p on p.Id = s.ProductId
                              where s.Price = ( select max(price) from Salles)";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// ExecuteReader - виконує команду select та повертає результат у вигляді
            //// DbDataReader
            SqlDataReader reader = command.ExecuteReader();



            //// відображається назви всіх колонок таблиці
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
        static void FirstClientPurchase(SqlConnection sqlConnection, string Fullname)
        {

            string cmdText = $@"select top 1 *
                            from Salles as s join Clients as c on c.Id = s.ClientId
                            where c.FullName = '{Fullname}'                                               
                            order by s.DateSalles";                                         

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// ExecuteReader - виконує команду select та повертає результат у вигляді
            //// DbDataReader
            SqlDataReader reader = command.ExecuteReader();


            //// відображається назви всіх колонок таблиці
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
        static void SQL_Menu(SqlConnection sqlConnection)
        {
            string message = "Push any button, to continue.....";
            bool flag = true;
            while (flag)
            {

                Console.Clear();

                printC("");
                Console.WriteLine("1. Show Customers");
                Console.WriteLine("2. Show Sellers");
                Console.WriteLine("3. Show Sales by Customer Name");
                Console.WriteLine("4. Show Sales with Price Filter");
                Console.WriteLine("5. Show Minimum Sale Price");
                Console.WriteLine("6. Show Maximum Sale Price");
                Console.WriteLine("7. Show First Purchase of a Customer");
                Console.WriteLine("0. Exit");
                Console.Write("Type your choice: ");
                int Key = int.Parse(Console.ReadLine());
                printY("");
                switch (Key)
                {
                    case 1:
                        ShowCastomers(sqlConnection);
                        printG(message);
                        Console.ReadKey();
                        break;
                    case 2:
                        ShowSellers(sqlConnection);
                        printG(message);
                        Console.ReadKey();
                        break;
                    case 3:
                        ShowSallesByName(sqlConnection);
                        printG(message);
                        Console.ReadKey();
                        break;
                    case 4:
                        ShowFilterPrice(sqlConnection);
                        printG(message);
                        Console.ReadKey();
                        break;
                    case 5:
                        ShowMinSalesPrice(sqlConnection);
                        printG(message);
                        Console.ReadKey();
                        break;
                    case 6:
                        ShowMaxSalesPrice(sqlConnection);
                        printG(message);
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Write("Enter full name of the customer: ");
                        string fullName = Console.ReadLine();
                        FirstClientPurchase(sqlConnection, fullName);
                        printG(message);
                        Console.ReadKey();
                        break;
                    case 0:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
        #region print

        static public void printR<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        static public void printC<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
        }
        static public void printDC<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(message);
        }
        static public void printY<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
        }
        static public void printG<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }
        static public void printDY<type>(type message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(message);
        }
        static public void reset()
        {
            Console.ResetColor();
        }
        #endregion
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //connectionString : Property = value;property2 = value;
            /* SQL Server:
              - Windows Authentication:    "Data Source=server_name;
                                            Initial Catalog=db_name;
                                            Integrated Security=True";
              - SQL Server Authentication: "Data Source=server_name;
                                            Initial Catalog=db_name;
                                            User ID=login;Password=password";
          */
            //connectionString:  Property=value;Property2=value2;
            string connectionString = @"Data Source = MIAMI\SQLEXPRESS; 
                                        Initial Catalog = SportShop;                      
                                        Integrated Security = true; TrustServerCertificate=True;
";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Connected success!");


            #region Execute Non-Query
            //string cmdText = @"INSERT INTO Products
            //                  VALUES ('Gloves', 'Equipment', 50, 500, 'Ukraine', 50)";

            //SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            //command.CommandTimeout = 5; // default - 30sec


            //////// ExecuteNonQuery - виконує команду яка не повертає результат 
            ///////(insert, update, delete...),
            ////////але метод повертає кількітсь рядків, які були задіяні
            //int rows = command.ExecuteNonQuery();

            //Console.WriteLine(rows + " rows affected!");
            #endregion
            #region Execute Scalar
            //string cmdText = @"select AVG(Price) from Products";

            //SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// Execute Scalar - виконує команду, яка повертає одне значення
            //int res = (int)command.ExecuteScalar();

            //Console.WriteLine("Result: " + res);
            #endregion
            //int id = 2;
            #region Execute Reader
            //string cmdText = $@"select * from Products
            //                  where Id = '{id}'";

            //SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            ////// ExecuteReader - виконує команду select та повертає результат у вигляді
            ////// DbDataReader
            //SqlDataReader reader = command.ExecuteReader();

            //Console.OutputEncoding = Encoding.UTF8;

            ////// відображається назви всіх колонок таблиці
            //for (int i = 0; i < reader.FieldCount; i++)
            //{
            //    Console.Write($" {reader.GetName(i),14}");
            //}
            //Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            ////////// відображаємо всі значення кожного рядка
            //while (reader.Read())
            //{

            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        Console.Write($" {reader[i],14} ");
            //    }
            //    Console.WriteLine();
            //}

            //reader.Close();

            #endregion
           
            //FirstClientPurchase(sqlConnection, "Романчук Людмила Степанівна");
            SQL_Menu(sqlConnection);

            
            sqlConnection.Close();

        }
    }
}
