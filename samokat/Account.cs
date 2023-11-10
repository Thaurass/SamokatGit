using static samokat.ProgramStartScreen;
using static samokat.ProgramMenu;
using static samokat.MenuFunctions;

namespace samokat;

internal class Account
{

    internal static User CurrentUser = new();

    internal static string promo = "FREE";

    internal static readonly List<User> Users = new();

    internal static void StartScreenMsg()
    {
        ClearConsole();
        Print_message("Добро пожаловать в сервис самокат");
        Print_message("1. Войти");
        Print_message("2. Зарегистрироваться");
        Print_message("3. Выйти из приложения");
    }

    internal static void Login()
    {
        bool log = false;
        while (!log)
        {
            ClearConsole();
            Print_message("Введите логин:");
            string login = Read_message();
            Print_message("Введите пароль:");
            string password = Read_message();

            User TempUser = Users.Find(user => user.Name == login && user.Password == password);

            if (Users.Contains(TempUser))
            {
                CurrentUser = TempUser;
                Print_message("Вы успешно вошли в аккаунт");
                log = true;
                Menu();
            }
            else
            {
                Print_message("Неверный логин или пороль, если вы его забыли нажмите : 1 для выхода");
                Print_message("Или любую другую клавишу, чтобы продолжить");
                if ("1" == Read_message()) { StartScreen(); }

            }
        }
    }

    internal static void Register()
    {

        Print_message("Придумайте логин:");
        string login = Read_message();
        Print_message("Придумайте пароль:");
        string password = Read_message();
        Print_message("Введите свой возраст");
        if (Int32.TryParse(Read_message(), out int age))
        {
            Users.Add(new User(login, password, age));
            Print_message($"Регистрация прошла успешно");
        }
        else { Print_message($"Возраст должен быть введен в формате числа"); }

        Wait();
        StartScreen();


    }

    internal static void ExitProgram()
    {
        Environment.Exit(0);
    }

    internal static void ErrorMessage()
    {
        Print_message("Неверный ввод");
    }

    internal static string ReadAnswer()
    {
        return Read_message();
    }

    internal static void ChangeBallance()
    {
        Print_message("Неверный ввод");
    }

    internal static void CheckPromo()
    {
        if (CurrentUser.PromotionalCode != "")
        {
            Print_message("Ваш промокод ");
            Console.ForegroundColor = ConsoleColor.Green;
            Print_message("активирован");
            Console.ResetColor();

        }
    }

    internal static void CheckReadPromo(string temp)
    {
        if (temp.Contains(promo) || temp.ToUpper().Contains(promo))
        {
            CurrentUser.SetPromotionalCode(temp);
            Print_Promo();
            Print_message("Нажмите чтобы выйти");
        }
        else
        {
            Print_message("Неверный промокод");
        }
    }

    internal static void AddBalance()
    {
        if (Double.TryParse(Read_message(), out double sum))
        {
            CurrentUser.SetBalance(CurrentUser.Balance + sum);
            Print_message("Баланс успешно пополнен, теперь ваш баланс составляет: " + CurrentUser.Balance);
        }
        else
        {
            Print_message("неверно введена сумма, ваш баланс составляет: " + CurrentUser.Balance);
        }
    }
}