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
        static void showItems(List<int> items)
        { 
            foreach(int item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
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
            printC("");
            FillList(ints);
            showItems(ints);

        }
    }
}
