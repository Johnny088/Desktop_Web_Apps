using System.Drawing;
using System.Text;

namespace LinqToObject
{
    internal class Program
    {
        static void FillList(List<int> items)
        {
            
            Random rand = new Random();
            for (int i = 0; i < 40; i++)
            {
                items.Add(rand.Next(-150,150));
            }
        }
        static void showItems<type>(IEnumerable<type> items)
        {
            if (items == null)
            {
                Console.WriteLine("you gave an empty variable ");
            }
            else 
            {
                printC("");
                foreach (var item in items)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
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
            printDC("Дано цілочисельну послідовність.Витягти з неї всі позитивні числа, відсортувавши їх по зростанню.");

            List<int> ints = new List<int>();
            FillList(ints);
            printY("origin");
            printC("");
            showItems(ints);
            IEnumerable<int> result = ints.Where(i => i > 0).OrderBy(i => i).Select(i => i); //method
            printY("query by method");
            showItems(result);
            
            var query = from item in ints
                        where item > 0
                        orderby item
                        select item;

            printY("just query");
            showItems(query);

            printDC("Дано колекцію цілих чисел. Знайти кількість позитивних двозначних елементів, а також їх середнє арифметичне.");

            printY("array");
            showItems(ints);
            result = ints.Where(i => i > 9 && i < 100);
            printDC("------------------------------------------------------");
            printY("query collection");
            showItems(result);
            int positiveNumbers = ints.Count(i => i > 9 && i < 100);
            double avg = ints.Where(i => i > 9 && i < 100).Average();
            printY($"Positive numbers from 10 to 99 are {positiveNumbers} and the Average of them is {avg}");
            printDC("Дано колекцію цілих чисел. Знайти максимальне парне значення.");
            showItems(ints);
            int maxOfEven = ints.Where(i => i%2 == 0).Max();
            printY($"The maximum even number is: {maxOfEven}.");
            printDC("Дано колекцію непустих рядків. Отримати колекцію рядків, додавши вкінець до кожної три знаки оклику.");
            printY("Origin");
            string[] collection = new string[] { "Дано", "колекцію", "непустих", "рядків" };
            showItems(collection);
            IEnumerable<string> addSymbol = collection.Select(i => i + "!!!");
            printY("Changed collection");
            showItems(addSymbol);
            printDC("Дано певний символ і строкова колекція. Отримати колекцію строк, які мають відповідний символ.");
            printY("origin");
            string[] newCollection = new string[] { "red", "green", "blue", "pink", "yellow", "gray", "white" };
            showItems(newCollection);
            printY("query symbol 'w' .......");
            IEnumerable<string> showBySymbol = newCollection.Where(i => i.Contains("w"));
            //showItems(showBySymbol);
            //var query2 = from item in newCollection                      // %w% doesn't work
            //             where item == "%w%"
            //            orderby item
            //            select item;
            printDC("Дано колекцію непустих рядків. Згрупувати всі елементи по кількості символів.");
            printY("origin collection");
            string[] groupCollectionOrigin = new string[] {"Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipisicing", "elit", "Quidem", "possimus", "suscipit",
                "expedita", "repellendus", "veniam", "Quibusdam" };
            IEnumerable <string> groupCollection = groupCollectionOrigin.GroupBy(i => i.Count());
            reset();
            
        }
    }
}
