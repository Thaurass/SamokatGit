using System.Text.Encodings.Web;
using static samokat.Account;
using static samokat.Whoosh;

namespace samokat
{
    internal abstract class Program
    {
        static void Main(string[] args)
        {
            GenerateTransport();
            StartScreen();
        }

        protected internal static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1. Арендовать самокат");
            Console.WriteLine("2. Забронировать самокат");
            Console.WriteLine("3. Профиль");
            Console.WriteLine("4. Пополнить баланс");
            Console.WriteLine("5. Ввести промокод");
            Console.WriteLine("6. Выйти");

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
                        Profile();
                        stop = true;
                        break;
                    case "4":
                        deposit();
                        stop = true;
                        break;
                    case "5":
                        ChangePromo();
                        stop = true;
                        break;
                    case "6":
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
            for (int i = 0; i < 10; i++)
            {
                if ((double)(Scooters[i].Charge / 1000) > 0)
                {
                    Console.WriteLine(" Номер " + Scooters[i].Number + " Заряд в км {0:F2}", (double)(Scooters[i].Charge / 1000));
                }
            }
            Console.WriteLine("Введите номер желаймого самоката:");
            string Number = Console.ReadLine().ToUpper();
            if (Scooters.Contains(Scooters.Find(Transport => Transport.Number == Number)))
            {
                cur = Scooters.Find(Transport => Transport.Number == Number);
                Console.WriteLine("Введите время аренды самоката:");
                int ChargeTm = Convert.ToInt32((cur.Charge / (cur.Speed - 5) / 1000) * 60);
                Console.WriteLine("Доступное время до " + ChargeTm + " минут");
                int tm = Convert.ToInt32(Console.ReadLine());
                double t = tm;
                if (tm * cur.Costs > current.Balance || tm >= ChargeTm)
                {
                    if (tm * cur.Costs > current.Balance)
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
                    current.Distance += (double)(t / 60) * (cur.Speed - 5) * 1000;
                    cur.Charge -= (int)((double)(t / 60) * (cur.Speed - 5) * 1000);
                    Scooters[cur.Index] = cur;

                    Console.WriteLine("Цена вашей поездки составить " + tm * cur.Costs);
                    current.Balance = current.Balance - tm * cur.Costs;
                    Console.WriteLine("Хорошей поездки!");
                    Console.WriteLine("Нажмите чтобы продолжить");
                    Console.ReadKey();
                }
            }
            else 
            {
                Console.WriteLine("Такой самокат отсутствует");
            }
            Menu();
        }
        
        static void Book()
        {
            Console.Clear();
            Console.WriteLine("Через сколько минут вам нужен самокат:");
            int TimeToStart = Convert.ToInt32(Console.ReadLine());
            
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
                Console.WriteLine("Нажмите чтобы выйти");
            }else
            {
                Console.WriteLine("Неверный промокод");
            }
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