using static samokat.Program;

namespace samokat;

internal class Account
{
    internal struct User
    {
        internal User(string name, string password, int age)
        {
            Name = name;
            Password = password;
            Age = age;
            Balance = 100000;
            Distance = 0;
            Time = 0;
            NumTrips = 0;
            PromotionalCode = "";
        }

        internal string Name { get; }
        internal string Password { get; }
        internal int Age { get; }
        internal double Balance { get; set; }
        internal double Distance { get; set; }
        internal double Time { get; set; }
        internal int NumTrips { get; set; }
        internal string PromotionalCode { get; set; }




        // private override string Register()
        // {
        //     return $"({_name}, {_password}, {_age}, {_balance})";
        // }

    }

    internal static User CurrentUser = new();

    internal static string promo = "FREE";


    private static readonly List<User> Users = new();
    
    protected internal static void StartScreen()
    {
        Console.Clear();
        Console.WriteLine("Добро пожаловать в сервис самокат");
        Console.WriteLine("1. Войти");
        Console.WriteLine("2. Зарегистрироваться");
        Console.WriteLine("3. Выйти из приложения");
            
        bool stop = false;
        while (!stop)
        {
            string? answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Login();
                    stop = true;
                    break;
                case "2":
                    Register();
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

    static void Login()
    {
        bool log = false;
        while (!log)
        {
            Console.Clear();
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();


            if (Users.Contains(Users.Find(user => user.Name == login && user.Password == password)))
            {
                CurrentUser = Users.Find(user => user.Name == login && user.Password == password);
                Console.WriteLine("Вы успешно вошли в аккаунт");
                log = true;
                Menu();
            }
            else
            {
                Console.WriteLine("Неверный логин или пороль, если вы его забыли нажмите : 1 для выхода");
                Console.WriteLine("Или любую другую клавишу, чтобы продолжить");

                if ("1" == Console.ReadLine())
                {
                    StartScreen();
                }
                
            }
        }


        //Users.Find(user => user.Name.Contains(login)).Name;

    }

    static void Register()
    {
        
        Console.WriteLine("Придумайте логин:");
        string login = Console.ReadLine();
        Console.WriteLine("Придумайте пароль:");
        string password = Console.ReadLine();
        Console.WriteLine("Введите свой возраст");
        if (Int32.TryParse(Console.ReadLine(), out int age))
        {
            Users.Add(new User(login, password, age));
        
            Console.WriteLine($"Регистрация прошла успешно");
        }
        else
        {
            Console.WriteLine($"Возраст должен быть введен в формате числа");
        }
        
        Console.WriteLine("Нажжмите чтобы продолжить");
        Console.ReadKey();
        StartScreen();


    }
}