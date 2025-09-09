namespace _21_FinalWork
{
    using NAudio.Wave;
    using System.IO;
    using System.Media;
    using System.Reflection;
    using System.Security.Cryptography.X509Certificates;

    class TotalCommander
    {
        string CurrentPath { get; set; }
        List<string> paths;
        public TotalCommander()
        {
            CurrentPath = @"C:\";
            paths = new List<string>();
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

        public void ShowInfo()
        {
            Console.Clear();

            DirectoryInfo dir = new DirectoryInfo(CurrentPath);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < 83; i++)
            {
                if (i == 0)
                {
                    printC($"{"\u250c"}");
                }

                else if (i == 45)
                {
                    printC($"{"\u252c"}");
                }
                else if (i == 72)
                {
                    printC($"{"\u252c"}");
                }
                else if (i == 82)
                {
                    printC($"{"\u2510"}");

                }
                else
                {
                    printC($"{"\u2500"}");
                }
            }
            Console.WriteLine();
            printC($"{"\u2502"}");
            printDY($"{"Name",25}");
            printC($"{"\u2502",20}");
            printDY($"{"Data",15}");
            printC($"{"\u2502",12}");
            printDY($"{"Extension"}");
            printC($"{"\u2502"}");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in dir.GetDirectories())
            {
                Console.WriteLine($"{"\u2502"}{item.Name,-40}{"\u2502",5}{item.CreationTimeUtc,-22}{"\u2502",5}{"\u2502",10}");

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in dir.GetFiles())
            {
                Console.WriteLine($"{"\u2502"}{item.Name,-40}{"\u2502",5}{item.CreationTimeUtc,-22}{"\u2502",5}{item.Extension,7}{"\u2502",3}");
            }
            for (int i = 0; i < 83; i++)
            {
                if (i == 0)
                {
                    printC($"{"\u2514"}");
                }

                else if (i == 45)
                {
                    printC($"{"\u2534"}");
                }
                else if (i == 72)
                {
                    printC($"{"\u2534"}");
                }
                else if (i == 82)
                {
                    printC($"{"\u2518"}");

                }
                else
                {
                    printC($"{"\u2500"}");
                }

            }
            Console.WriteLine();
            printDY("1 - make a folder \tBackspace - step back \tEscape - exit \nDelete - delete folder \tN - create a new file \tW - write to the file\n");
            printC(CurrentPath + @"\");
        }
        public void MakingFolder()
        {
            printC("Enter the name of the new folder: ");
            string newFolderName = Console.ReadLine()!;
            Directory.CreateDirectory(Path.Combine(CurrentPath, newFolderName));
            printG($"Folder '{newFolderName}' created successfully.");
            Console.ReadKey();
        }
        public void deleteFolder()
        {
            printR("Enter the name of the folder or file you want to delete: ");
            string deleteName = Console.ReadLine()!;
            string deletePath = Path.Combine(CurrentPath, deleteName);
            if (Directory.Exists(deletePath))
            {
                Directory.Delete(deletePath, true);
                printG($"Folder '{deleteName}' deleted successfully.");
            }
            else
            {
                printR($"'{deleteName}' does not exist in the current directory.");
            }

        }
        public void MakingFile()
        {
            printG("Enter the nama of the file with extension you want to create: ");
            string fileName = Console.ReadLine()!;
            string filePath = Path.Combine(CurrentPath, fileName);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                printG($"File '{fileName}' created successfully.");
            }
            else
            {
                printR($"File '{fileName}' already exists.");
            }
        }
        public void WriteToFile()
        {
            printG("Enter the name of the file you want to write to: ");
            string fileName = Console.ReadLine()!;
            var filePath = new FileInfo(Path.Combine(CurrentPath, fileName));
            Console.WriteLine("Enter your text for writing to the file:");
            string message = Console.ReadLine()!;
            if (!filePath.Exists)
            {
                printR($"File '{fileName}' does not exist in the current directory.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("opennig the file");
                using (StreamWriter writer = filePath.AppendText())
                {
                    writer.WriteLine(message);
                    printG($"Text written to '{fileName}' successfully.");
                    Console.ReadKey();
                }
            }
        }
        public void start()
        {
            //string mp3File = @"C:\Users\espgo\Downloads\test.mp3";                        //Converter Audio files   to get it you need to install NAudio library 
            //string wavFile = @"C:\Users\espgo\Downloads\test.wav";                        //Turning a mp3 file to a wav file
            //using (var audioFile = new AudioFileReader(mp3File))                     
            //using (var writter = new WaveFileWriter(wavFile, audioFile.WaveFormat))
            //{
            //    audioFile.CopyTo(writter);
            //}
           Console.OutputEncoding = System.Text.Encoding.UTF8;
           // string music = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //Console.WriteLine(music);
           // string test = Path.Combine(music, @"test.wav");
            //SoundPlayer player = new SoundPlayer(Path.Combine(music, @"test.wav"));      //then we can play the wav file in the loop By using "System.Windows.Extensions"
           // player.PlayLooping();                                                           //to stop the sound you need to close the program
            string nextpath = "";
            paths.Add(CurrentPath);
            bool flag = true;

            do
            {

                ShowInfo();

                string next = Console.ReadLine()!;
                if (next == "")
                {
                    Console.WriteLine();
                }
                else if (Directory.Exists(Path.Combine(CurrentPath, next)))
                {
                    nextpath = Path.Combine(CurrentPath, next);
                    paths.Add(nextpath);
                    CurrentPath = nextpath;
                }
                else
                    continue;
                Console.WriteLine("choose one of the hot keys or just push any button");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        {
                            MakingFolder();
                            break;
                        }
                    case ConsoleKey.Backspace:
                        {
                            if (paths.Count > 0)
                            {
                                paths.RemoveAt(paths.Count - 1);
                                CurrentPath = paths.Last();
                            }
                            else
                            {
                                printG("You are already in the root directory.");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            flag = false;
                            break;
                        }
                    case ConsoleKey.Delete:
                        {
                            deleteFolder();
                            break;
                        }
                    case ConsoleKey.N:
                        {
                            MakingFile();
                            break;
                        }
                    case ConsoleKey.W:
                        {
                            WriteToFile();
                            break;
                        }

                }
                next = "";
                Console.WriteLine();
            } while (flag);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TotalCommander Totalcomander = new TotalCommander();
            Totalcomander.start();

        }

    }
}