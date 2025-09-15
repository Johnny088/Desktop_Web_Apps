 using _03_data_access.models;
using Microsoft.Data.SqlClient;

namespace _03_data_access.models
{
    public class SalesDB : IDisposable
    {
        public List<SallesItems> items;
        private SqlConnection sqlConnection;

        public SalesDB(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);   // Creating the sql connection
            items = new List<SallesItems>();
            sqlConnection.Open();
        }

        //-------------------------------CRUD Operations---------------------------------
        private List<SallesItems> GetByQuery(SqlDataReader reader) // getting data from the database
        {
            while (reader.Read())                           //reading the data
            {
                items.Add(new SallesItems
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
            return items;

        }
        public List<SallesItems> CreateAsInsert(SallesItems item)
        {
            //string CmdText = $@"insert into Salles values ({item.ProductID}, 
            //                                                {item.Price}, 
            //                                                {item.Quantity}, 
            //                                                {item.EmployeeID},
            //                                                {item.ClientID}, 
            //                                                '{item.Date}')";
            string CmdText = $@"insert into Salles values (@ProductID, 
                                                            @Price, 
                                                            @Quantity, 
                                                            @EmployeeID,
                                                            @ClientID, 
                                                            @DateSalles)";

            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            command.Parameters.AddWithValue("ProductID", item.ProductID);
            command.Parameters.AddWithValue("Price", item.Price);
            command.Parameters.AddWithValue("Quantity", item.Quantity);
            command.Parameters.AddWithValue("EmployeeID", item.EmployeeID);
            command.Parameters.AddWithValue("ClientID", item.ClientID);
            command.Parameters.AddWithValue("DateSalles", item.Date);
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
            return new List<SallesItems> { item };

        }

        private List<SallesItems> ReadFromDatabase(SqlDataReader reader)  //reading data from the different tables
        {
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
            reader.Close();
            return new List<SallesItems>();
        }

        public List<SallesItems> ReadAll()
        {
            items.Clear();
            string CmdText = @"select * from Salles";
            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            return GetByQuery(reader);



        }
        public void ShowItems()
        {
            foreach (var item in items)
            {
                printY(item);
            }
        }
        public void ReadItemsFilter()
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
            GetByQuery(reader);
        }
        public void Test(string fullName)
        {
            //items.Clear();
            string CmdText = $@"select top 1 p.Name as Product, s.Price, c.FullName, s.DateSalles
                                from Salles as s join Clients as c on c.id = s.ClientId
				                                 join Products as p on p.id = s.ProductId
                                                 where c.FullName = '{fullName}'
                                                 order by s.DateSalles";

            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            command.Parameters.Add("fullName", System.Data.SqlDbType.NVarChar).Value = fullName;  //protecting from SQL injection, need to check the variable and convert it to
            //NvarChar to avoid dangerous scripts

            SqlDataReader reader = command.ExecuteReader();

            ReadFromDatabase(reader);
            

        }
        public List<SallesItems> LastPurchaseClient(string GottenName)
        {
            //items.Clear();
            string CmdText = $@"select top 1 p.Name as Product, s.Price, c.FullName, s.DateSalles
                                from Salles as s join Clients as c on c.id = s.ClientId
				                                 join Products as p on p.id = s.ProductId
                                                 where c.FullName = @fullName order by s.DateSalles";

            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            command.Parameters.Add("fullName", System.Data.SqlDbType.NVarChar).Value = GottenName;  //protecting from SQL injection, need to check the variable and convert it to
            //NvarChar to avid dangerous scripts

            //the second version

            //SqlParameter parameter = new SqlParameter()                               //why does not work???
            //{
            //    ParameterName = "fullName",
            //    SqlDbType = System.Data.SqlDbType.NVarChar,
            //    Value = GottenName
            //};

            SqlDataReader reader = command.ExecuteReader();
            return ReadFromDatabase(reader);
        }

        public void TopSeller()
        {
            string CmdText = $@"select top 1 e.FullName, sum(s.Price)
                             from Salles as s join Employees as e on s.EmployeeId = e.Id
                             group by e.FullName
                             order by sum(s.Price) desc";
            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            ReadFromDatabase(reader);
        }
        public void Update(SallesItems item)
        {
            string CmdText = $@"update Salles set ProductID = @ProductID, 
                                                      Price = @Price, 
                                                   Quantity = @Quantity, 
                                                 EmployeeID = @EmployeeID,
                                                   ClientID = @ClientID, 
                                                 DateSalles = @DateSalles'
                                                   where Id = @Id";

            SqlCommand command = new SqlCommand(CmdText, sqlConnection);
            command.Parameters.AddWithValue("ProductID", item.ProductID);
            command.Parameters.AddWithValue("Price", item.Price);
            command.Parameters.AddWithValue("Quantity", item.Quantity);
            command.Parameters.AddWithValue("EmployeeID", item.EmployeeID);
            command.Parameters.AddWithValue("ClientID", item.ClientID);
            command.Parameters.AddWithValue("DateSalles", item.Date);
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
        public void DeleteID(int idDel)
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
}
