using System.Reflection.Metadata;
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
            Console.WriteLine("3. Профиль");
            Console.WriteLine("4. Пополнить баланс");
            Console.WriteLine("5. Выйти");

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
                        Balance();
                        stop = true;
                        break;
                    case "4":
                        deposit();
                        stop = true;
                        break;
                    case "5":
                        StartScreen();
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
            Console.WriteLine("Для вас есть следующие типы самокатов");
            //
            //
            Console.WriteLine("Введите время аренды самоката:");
            //
            //
            Console.WriteLine("Хорошей поездки!");
            Menu();
        }
        
        static void Book()
        {
            Console.Clear();
            Console.WriteLine("Введите время бронирования самоката:");
            Menu();
        }
        static void Balance()
        {
            Console.Clear();
            Console.WriteLine("Здравствуйте: " + current.Name);
            Console.WriteLine("Ваш возраст: " + current.Age);
            Console.WriteLine("Ваш баланс: " + current.Balance);
            Console.WriteLine("Ваш пароль: " + current.Password);
            Console.WriteLine("Если желаете посмотреть дополнительную статистику нажмите 1");
            Console.WriteLine("Или любую другую клавишу, чтобы продолжить");

            if (1 == Convert.ToInt32(Console.ReadLine()))
            {
                Console.WriteLine("#######################################\r\n" +
                                  "#                                     #\r\n" +
                                  "#   #####   ######     ##     ######  #\r\n" +
                                  "#  ##   ##  # ## #    ####    # ## #  #\r\n" +
                                  "#  #          ##     ##  ##     ##    #\r\n" +
                                  "#   #####     ##     ##  ##     ##    #\r\n" +
                                  "#       ##    ##     ######     ##    #\r\n" +
                                  "#  ##   ##    ##     ##  ##     ##    #\r\n" +
                                  "#   #####    ####    ##  ##    ####   #\r\n" +
                                  "#                                     #\r\n" +
                                  "#######################################");

                Console.WriteLine("Вы проехали: " + current.Password);
                Console.WriteLine("Время в пути вместе: " + current.Password);
            }
            Console.WriteLine("Нажмите чтобы выйти");
            Console.ReadKey();
            Menu();
        }
        static void deposit()
        {
            Console.Clear();
            Console.WriteLine("Ваш баланс:" + current.Balance);
            Console.WriteLine("Какую сумму хотите ввести?");
            current.Balance +=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Баланс успешно пополнен, теперь ваш баланс составляет: " + current.Balance);
            Console.WriteLine("Нажмите чтобы продолжить");

            Console.ReadKey();
            Menu();
        }
    }
}