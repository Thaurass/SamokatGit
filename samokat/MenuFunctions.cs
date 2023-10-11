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
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1. Арендовать самокат");
            Console.WriteLine("2. Профиль");
            Console.WriteLine("3. Пополнить баланс");
            Console.WriteLine("4. Ввести промокод");
            Console.WriteLine("5. Выйти");
        }

        internal static void Rent()
        {
            Console.Clear();
            Load();
            Console.WriteLine("Введите номер желаймого самоката:");
            string Number = Console.ReadLine().ToUpper();

            if (Scooters.Contains(Scooters.Find(Transport => Transport.Number == Number)))
            {
                CurrentSamokat = Scooters.Find(Transport => Transport.Number == Number);
                Console.WriteLine("Введите время аренды самоката:");
                int ChargeTm = Convert.ToInt32((CurrentSamokat.Charge / (CurrentSamokat.Speed - 5) / 1000) * 60);
                Console.WriteLine("Доступное время до " + ChargeTm + " минут");

                if (Int32.TryParse(Console.ReadLine(), out int tm))
                {
                    double t = tm;

                    if (tm * CurrentSamokat.Costs > CurrentUser.Balance || tm >= ChargeTm)
                    {
                        if (tm * CurrentSamokat.Costs > CurrentUser.Balance)
                        {
                            Console.WriteLine("У вас недостаточно средств пополните баланс");
                        }
                        if (tm >= ChargeTm)
                        {
                            Console.WriteLine("Данное время поездки не доступно, введите актуальное " +
                                              "или возбмите другой самокат");
                        }
                        Console.WriteLine("Нажмите чтобы продолжить");
                        Console.ReadKey();
                        Menu();
                    }
                    else
                    {
                        CurrentUser.Time += t;
                        CurrentUser.Distance += (double)(t / 60) * (CurrentSamokat.Speed - 5) * 1000;
                        CurrentSamokat.Charge -= (int)((double)(t / 60) * (CurrentSamokat.Speed - 5) * 1000);
                        Scooters[CurrentSamokat.Index] = CurrentSamokat;

                        Console.WriteLine("Цена вашей поездки составить " + tm * CurrentSamokat.Costs);
                        CurrentUser.Balance = CurrentUser.Balance - tm * CurrentSamokat.Costs;
                        Console.WriteLine("Хорошей поездки!");

                    }
                }
                else
                {
                    Console.WriteLine($"Время аренды должно быть в формате числа");
                }

            }
            else
            {
                Console.WriteLine("Такой самокат отсутствует");
            }

            Console.WriteLine("Нажмите чтобы продолжить");
            Console.ReadKey();
            Menu();
        }

        internal static void Profile()
        {
            Console.Clear();
            Console.WriteLine("Здравствуйте: " + CurrentUser.Name);
            Console.WriteLine("Ваш возраст: " + CurrentUser.Age);
            Console.WriteLine("Ваш баланс: " + CurrentUser.Balance);
            Console.WriteLine("Ваш пароль: " + CurrentUser.Password);

            if (CurrentUser.PromotionalCode != "")
            {
                Console.Write("Ваш промокод ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("активирован");
                Console.ResetColor();

            }

            Print_Stat();
            Console.WriteLine("Вы проехали: {0:F2} км", CurrentUser.Distance / 1000);
            Console.WriteLine("Время в пути вместе: {0:#} минут", CurrentUser.Time);

            Console.WriteLine("Нажмите чтобы выйти");
            Console.ReadKey();
            Menu();
        }

        static string promo = "FREE";

        internal static void ChangePromo()
        {
            Console.WriteLine("Введите промокод:");
            string temp = Console.ReadLine();

            if (temp.Contains(promo) || temp.ToUpper().Contains(promo))
            {
                CurrentUser.PromotionalCode = temp;
                Print_Promo();
                Console.WriteLine("Нажмите чтобы выйти");
            }
            else
            {
                Console.WriteLine("Неверный промокод");
            }

            Console.ReadKey();
            Menu();
        }

        internal static void Deposit()
        {
            Console.Clear();
            Console.WriteLine("Ваш баланс:" + CurrentUser.Balance);
            Console.WriteLine("Какую сумму хотите ввести?");

            if (Double.TryParse(Console.ReadLine(), out double sum))
            {
                CurrentUser.Balance += sum;
                Console.WriteLine("Баланс успешно пополнен, теперь ваш баланс составляет: " + CurrentUser.Balance);
            }
            else
            {
                Console.WriteLine("неверно введена сумма, ваш баланс составляет: " + CurrentUser.Balance);
            }


            Console.WriteLine("Нажмите чтобы продолжить");

            Console.ReadKey();
            Menu();
        }

        static void Print_Stat()
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
        }

        static void Print_Promo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
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

