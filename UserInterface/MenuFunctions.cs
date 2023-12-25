using static UserInterface.Account;
using static BusinessLogic.Whoosh;
using static UserInterface.ProgramMenu;
using static UserInterface.Rent;
using static FileWorker.FileProcessing;

namespace UserInterface
{
	public class MenuFunctions
	{
        public static void StartMenuMsg()
        {
            ClearConsole();
            Print_message("Главное меню:");
            Print_message("1. Арендовать самокат");
            Print_message("2. Профиль");
            Print_message("3. Пополнить баланс");
            Print_message("4. Ввести промокод");
            Print_message("5. Выйти");
        }

        public static void RentScooter()
        {
            ClearConsole();
            Print_message("Для вас есть следующие типы самокатов");
            string[] Messages = Load();
            for (int i = 0; i < 10; i++)
            {
                if ((double)(Transport[i].Charge / 1000) > 0)
                {
                    Print_message(Messages[i]);
                }
            }
            Print_message("Введите номер желаймого самоката:");
 
            if (ReadScooter(Read_message()))
            {

                Print_message("Введите время аренды самоката:");
                Print_message("Доступное время до " + GetTime() + " минут");
                Check(Read_message());
                Print_message("Цена вашей поездки составить " + GetCurrentCost());
                Print_message("Хорошей поездки!");
            }
            else
            {
                Print_message("Такой самокат отсутствует");
            }

            Wait();
            Menu();
        }


        public static void Profile()
        {
            ClearConsole();
            Print_message("Здравствуйте: " + CurrentUser.Name);
            Print_message("Ваш возраст: " + CurrentUser.Age);
            Print_message("Ваш баланс: " + CurrentUser.Balance);
            Print_message("Ваш пароль: " + CurrentUser.Password);

            CheckPromo();
            Print_Stat();
            Print_message("Вы проехали: {0:F2} км", CurrentUser.Distance / 1000);
            Print_message("Время в пути вместе: {0:#} минут", CurrentUser.Time);
            Wait();
            Menu();
        }

  

        public static void ChangePromo()
        {
            Print_message("Введите промокод:");
            CheckReadPromo(Read_message());
            Wait();
            Menu();
        }

        public static void Deposit()
        {
            ClearConsole();
            Print_message("Ваш баланс:" + CurrentUser.Balance);
            Print_message("Какую сумму хотите ввести?");
            AddBalance();
            Wait();
            Menu();
        }

        public static void Print_message(string _yourMessage)
        {
            Console.WriteLine(_yourMessage);
        }

        public static void Print_message(string _yourMessage, double data) 
        {
            Console.WriteLine(_yourMessage, data);
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static void Print_Stat()
        {
                Print_message("#######################################\r\n" +
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
        }

        public static void Print_Promo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Print_message(
              "##################################################################################################################\r\n" +
              "#                                                                                                                #\r\n" +
              "#  ######   ######    #####   ##   ##   #####              ##       ####   ######    ####    ##   ##   #######   #\r\n" +
              "#  ##  ##   ##  ##  ##   ##   ### ###  ##   ##            ####     ##  ##  # ## #     ##     ##   ##   ##   #    #\r\n" +
              "#  ##  ##   ##  ##  ##   ##   #######  ##   ##           ##  ##   ##         ##       ##      ## ##    ## #      #\r\n" +
              "#  #####    #####   ##   ##   #######  ##   ##           ##  ##   ##         ##       ##      ## ##    ####      #\r\n" +
              "#  ##       ## ##   ##   ##   ## # ##  ##   ##           ######   ##         ##       ##       ###     ## #      #\r\n" +
              "#  ##       ##  ##  ##   ##   ##   ##  ##   ##           ##  ##    ##  ##    ##       ##       ###     ##   #    #\r\n" +
              "#  ####    ####  ##  #####    ##   ##   #####            ##   ##    ####    ####     ####       #      #######   #\r\n" +
              "#                                                                                                                #\r\n" +
              "##################################################################################################################");
            Console.ResetColor();
        }

        public static void Wait()
        {
            Print_message("Нажмите чтобы продолжить");
            Console.ReadKey();
        }

        public static string Read_message()
        {
            return Console.ReadLine();
        }

    }
}

