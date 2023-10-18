using static samokat.Account;
using static samokat.Whoosh;
using static samokat.ProgramMenu;

namespace samokat
{
	public class MenuFunctions
	{

        internal static void StartMenuMsg()
        {
            Console.Clear();
            Print_message("Главное меню:");
            Print_message("1. Арендовать самокат");
            Print_message("2. Профиль");
            Print_message("3. Пополнить баланс");
            Print_message("4. Ввести промокод");
            Print_message("5. Выйти");
        }

        internal static void Rent()
        {
            Console.Clear();
            Load();
            Print_message("Введите номер желаймого самоката:");
            string Number = Read_message().ToUpper();

            if (Scooters.Contains(Scooters.Find(Transport => Transport.Number == Number)))
            {
                CurrentSamokat = Scooters.Find(Transport => Transport.Number == Number);
                Print_message("Введите время аренды самоката:");
                int ChargeTm = Convert.ToInt32((CurrentSamokat.Charge / (CurrentSamokat.Speed - 5) / 1000) * 60);
                Print_message("Доступное время до " + ChargeTm + " минут");

                if (Int32.TryParse(Read_message(), out int tm))
                {
                    double t = tm;

                    if (tm * CurrentSamokat.Costs > CurrentUser.Balance || tm >= ChargeTm)
                    {
                        if (tm * CurrentSamokat.Costs > CurrentUser.Balance)
                        {
                            Print_message("У вас недостаточно средств пополните баланс");
                        }
                        if (tm >= ChargeTm)
                        {
                            Print_message("Данное время поездки не доступно, введите актуальное " +
                                              "или возьмите другой самокат");
                        }
                        Print_message("Нажмите чтобы продолжить");
                        Console.ReadKey();
                        Menu();
                    }
                    else
                    {
                        CurrentUser.Time += t;
                        CurrentUser.Distance += (double)(t / 60) * (CurrentSamokat.Speed - 5) * 1000;
                        CurrentSamokat.Charge -= (int)((double)(t / 60) * (CurrentSamokat.Speed - 5) * 1000);
                        Scooters[CurrentSamokat.Index] = CurrentSamokat;

                        Print_message("Цена вашей поездки составить " + tm * CurrentSamokat.Costs);
                        CurrentUser.Balance = CurrentUser.Balance - tm * CurrentSamokat.Costs;
                        Print_message("Хорошей поездки!");

                    }
                }
                else
                {
                    Print_message($"Время аренды должно быть в формате числа");
                }

            }
            else
            {
                Print_message("Такой самокат отсутствует");
            }

            Print_message("Нажмите чтобы продолжить");
            Console.ReadKey();
            Menu();
        }

        internal static void Profile()
        {
            Console.Clear();
            Print_message("Здравствуйте: " + CurrentUser.Name);
            Print_message("Ваш возраст: " + CurrentUser.Age);
            Print_message("Ваш баланс: " + CurrentUser.Balance);
            Print_message("Ваш пароль: " + CurrentUser.Password);

            if (CurrentUser.PromotionalCode != "")
            {
                Console.Write("Ваш промокод ");
                Console.ForegroundColor = ConsoleColor.Green;
                Print_message("активирован");
                Console.ResetColor();

            }

            Print_Stat();
            Print_message("Вы проехали: {0:F2} км", CurrentUser.Distance / 1000);
            Print_message("Время в пути вместе: {0:#} минут", CurrentUser.Time);

            Print_message("Нажмите чтобы выйти");
            Console.ReadKey();
            Menu();
        }

        static string promo = "FREE";

        internal static void ChangePromo()
        {
            Print_message("Введите промокод:");
            string temp = Read_message();

            if (temp.Contains(promo) || temp.ToUpper().Contains(promo))
            {
                CurrentUser.PromotionalCode = temp;
                Print_Promo();
                Print_message("Нажмите чтобы выйти");
            }
            else
            {
                Print_message("Неверный промокод");
            }

            Console.ReadKey();
            Menu();
        }

        internal static void Deposit()
        {
            Console.Clear();
            Print_message("Ваш баланс:" + CurrentUser.Balance);
            Print_message("Какую сумму хотите ввести?");

            if (Double.TryParse(Read_message(), out double sum))
            {
                CurrentUser.Balance += sum;
                Print_message("Баланс успешно пополнен, теперь ваш баланс составляет: " + CurrentUser.Balance);
            }
            else
            {
                Print_message("неверно введена сумма, ваш баланс составляет: " + CurrentUser.Balance);
            }


            Print_message("Нажмите чтобы продолжить");

            Console.ReadKey();
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

        internal static string Read_message()
        {
            return Console.ReadLine();
        }

        static void Print_Stat()
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

        static void Print_Promo()
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
    }
}

