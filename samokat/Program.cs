using static samokat.Account;
using static samokat.Whoosh;

namespace samokat
{
    internal abstract class Program
    {
        internal static string arg0 = "";

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Аргумент не передан");
            }
            else
            {
                arg0 = args[0];
                StartScreen();
            }
            
        }

        internal static void Menu()
        {
            StartMenuMsg();

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
                        Profile();
                        stop = true;
                        break;
                    case "3":
                        Deposit();
                        stop = true;
                        break;
                    case "4":
                        ChangePromo();
                        stop = true;
                        break;
                    case "5":
                        Save();
                        StartScreen();
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }

        }


        static void StartMenuMsg()
        {
            Console.Clear();
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1. Арендовать самокат");
            Console.WriteLine("2. Профиль");
            Console.WriteLine("3. Пополнить баланс");
            Console.WriteLine("4. Ввести промокод");
            Console.WriteLine("5. Выйти");
        }

        

        static void Rent()
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

                    if (tm * CurrentSamokat.Costs > current.Balance || tm >= ChargeTm)
                    {
                        if (tm * CurrentSamokat.Costs > current.Balance)
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
                        current.Time += t;
                        current.Distance += (double)(t / 60) * (CurrentSamokat.Speed - 5) * 1000;
                        CurrentSamokat.Charge -= (int)((double)(t / 60) * (CurrentSamokat.Speed - 5) * 1000);
                        Scooters[CurrentSamokat.Index] = CurrentSamokat;

                        Console.WriteLine("Цена вашей поездки составить " + tm * CurrentSamokat.Costs);
                        current.Balance = current.Balance - tm * CurrentSamokat.Costs;
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
        
        static void Profile()
        {
            Console.Clear();
            Console.WriteLine("Здравствуйте: " + current.Name);
            Console.WriteLine("Ваш возраст: " + current.Age);
            Console.WriteLine("Ваш баланс: " + current.Balance);
            Console.WriteLine("Ваш пароль: " + current.Password);

            if (current.PromotionalCode != "")
            {
                Console.Write("Ваш промокод ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("активирован");
                Console.ResetColor();

            }

            Print_Stat();
            Console.WriteLine("Вы проехали: {0:F2} км", current.Distance/1000);
            Console.WriteLine("Время в пути вместе: {0:#} минут", current.Time);
            
            Console.WriteLine("Нажмите чтобы выйти");
            Console.ReadKey();
            Menu();
        }

        static void ChangePromo()
        {
            Console.WriteLine("Введите промокод:");
            string temp = Console.ReadLine();

            if (temp.Contains(promo) || temp.ToUpper().Contains(promo))
            {
                current.PromotionalCode = temp;
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
        
        static void Deposit()
        {
            Console.Clear();
            Console.WriteLine("Ваш баланс:" + current.Balance);
            Console.WriteLine("Какую сумму хотите ввести?");

            if (Double.TryParse(Console.ReadLine(), out double sum))
            {
                current.Balance += sum;
                Console.WriteLine("Баланс успешно пополнен, теперь ваш баланс составляет: " + current.Balance);
            }
            else
            {
                Console.WriteLine("неверно введена сумма, ваш баланс составляет: " + current.Balance);
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