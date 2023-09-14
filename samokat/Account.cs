using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using static samokat.Program;

namespace samokat;

public class Account
{
    struct User
    {
        public User(string name, string password, int age)
        {
            Name = name;
            Password = password;
            Age = age;
            Balance = 0;
        }

        public string Name { get; }
        public string Password { get; }
        public int Age { get; }
        public double Balance { get; }

        
        // private override string Register()
        // {
        //     return $"({_name}, {_password}, {_age}, {_balance})";
        // }

    }
    
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

    private static void Login()
    {
        bool log = false;
        while (!log)
        {
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();

            if (
                Users.Contains(Users.Find(user => user.Name == login)) && 
                Users.Contains(Users.Find(user => user.Password == password))
                )
            {
                Console.WriteLine("Вы успешно вошли в аккаунт");
                log = true;
                Menu();
            }
            else
            {
                Console.WriteLine("Неверный логин или пороль");
            }
        }


        //Users.Find(user => user.Name.Contains(login)).Name;

    }

    private static void Register()
    {
        
        Console.WriteLine("Придумайте логин:");
        string login = Console.ReadLine();
        Console.WriteLine("Придумайте пароль:");
        string password = Console.ReadLine();
        Console.WriteLine("Введите свой возраст");
        string age = Console.ReadLine();
        
        Users.Add(new User(login, password, Convert.ToInt32(age)));
        
        Console.WriteLine($"Регистрация прошла успешно");
        Console.WriteLine("Нажжмите чтобы продолжить");
        Console.ReadKey();
        StartScreen();


    }
}