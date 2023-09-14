using static samokat.Account;
using static samokat.Whoosh;

namespace samokat
{
    internal abstract class Program
    {
        static void Main(string[] args)
        {
            StartScreen();
            GenerateTransport();
        }

        

        protected internal static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1. Арендовать самокат");
            Console.WriteLine("2. Забронировать самокат");
            Console.WriteLine("3. Выйти");

            bool stop = false;
            while (!stop)
            {
                string? answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Rent();
                        stop = true;
                        break;
                    case "2":
                        Book();
                        stop = true;
                        break;
                    case "3":
                        Environment.Exit(0);
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }

        }

        static void Rent()
        {
            Console.Clear();
            Console.WriteLine("Введите время аренды самоката:");
        }
        
        static void Book()
        {
            Console.Clear();
            Console.WriteLine("Введите время бронирования самоката:");
        }
    }
}