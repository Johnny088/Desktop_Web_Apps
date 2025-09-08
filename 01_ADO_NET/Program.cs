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

            Console.OutputEncoding = Encoding.UTF8;

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

            Console.OutputEncoding = Encoding.UTF8;

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

            Console.OutputEncoding = Encoding.UTF8;

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

            Console.OutputEncoding = Encoding.UTF8;

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

            Console.OutputEncoding = Encoding.UTF8;

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

            Console.OutputEncoding = Encoding.UTF8;

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
        static void Main(string[] args)
        {
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
            ShowCastomers(sqlConnection);
            Console.WriteLine("----------------------------------------------");
            ShowSellers(sqlConnection);
            Console.WriteLine("----------------------------------------------");

            ShowSallesByName(sqlConnection);
            Console.WriteLine("----------------------------------------------");
            ShowFilterPrice(sqlConnection);
            Console.WriteLine("--------------------min--------------------------");
            ShowMinSalesPrice(sqlConnection);
            Console.WriteLine("--------------------max--------------------------");
            ShowMaxSalesPrice(sqlConnection);
            Console.WriteLine("--------------------max--------------------------");

            sqlConnection.Close();

        }
    }
}
