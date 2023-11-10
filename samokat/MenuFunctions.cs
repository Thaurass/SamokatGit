using static samokat.Account;
using static samokat.Whoosh;
using static samokat.ProgramMenu;
using static samokat.Rent;
using static samokat.FileProcessing;

namespace samokat
{
	public class MenuFunctions
	{
        internal static void StartMenuMsg()
        {
            ClearConsole();
            Print_message("Главное меню:");
            Print_message("1. Арендовать самокат");
            Print_message("2. Профиль");
            Print_message("3. Пополнить баланс");
            Print_message("4. Ввести промокод");
            Print_message("5. Выйти");
        }

        internal static void RentScooter()
        {
            ClearConsole();
            Load();
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


        internal static void Profile()
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

  

        internal static void ChangePromo()
        {
            Print_message("Введите промокод:");
            CheckReadPromo(Read_message());
            Wait();
            Menu();
        }

        internal static void Deposit()
        {
            ClearConsole();
            Print_message("Ваш баланс:" + CurrentUser.Balance);
            Print_message("Какую сумму хотите ввести?");
            AddBalance();
            Wait();
            Menu();
        }

        internal static void Print_message(string _yourMessage)
        {
            Console.WriteLine(_yourMessage);
        }

        internal static void Print_message(string _yourMessage, double data) 
        {
            Console.WriteLine(_yourMessage, data);
        }

        internal static void ClearConsole()
        {
            Console.Clear();
        }

        internal static void Print_Stat()
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

        internal static void Print_Promo()
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

        internal static void Wait()
        {
            Print_message("Нажмите чтобы продолжить");
            Console.ReadKey();
        }

        internal static string Read_message()
        {
            return Console.ReadLine();
        }

    }
}

