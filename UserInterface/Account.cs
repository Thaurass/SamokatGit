using static UserInterface.ProgramStartScreen;
using static UserInterface.ProgramMenu;
using static UserInterface.MenuFunctions;
using static BusinessLogic.AccountFunctions;
namespace UserInterface;

public class Account
{

    public static void StartScreenMsg()
    {
        ClearConsole();
        Print_message("Добро пожаловать в сервис самокат");
        Print_message("1. Войти");
        Print_message("2. Зарегистрироваться");
        Print_message("3. Выйти из приложения");
    }

    public static void Login()
    {
        bool log = false;
        while (!log)
        {
            ClearConsole();
            Print_message("Введите логин:");
            string login = Read_message();
            Print_message("Введите пароль:");
            string password = Read_message();
            
            if (CheckLoginData(login, password))
            {
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

    public static void Register()
    {

        Print_message("Придумайте логин:");
        string login = Read_message();
        Print_message("Придумайте пароль:");
        string password = Read_message();
        Print_message("Введите свой возраст");
        string age = Read_message();

        if (AddNewUser(login, password, age))
        {
            Print_message($"Регистрация прошла успешно");
        }
        else { Print_message($"Возраст должен быть введен в формате числа"); }

        Wait();
        StartScreen();

    }

    public static void ErrorMessage()
    {
        Print_message("Неверный ввод");
    }

    public static string ReadAnswer()
    {
        return Read_message();
    }

    public static void ChangeBallance()
    {
        Print_message("Неверный ввод");
    }

    public static void CheckPromo()
    {
        if (CurrentUser.PromotionalCode != "")
        {
            Print_message("Ваш промокод ");
            Console.ForegroundColor = ConsoleColor.Green;
            Print_message("активирован");
            Console.ResetColor();

        }
    }

    public static void CheckReadPromo(string temp)
    {
        if (SetUserPromotionalCode(temp))
        {
            Print_Promo();
            Print_message("Нажмите чтобы выйти");
        }
        else
        {
            Print_message("Неверный промокод");
        }
    }

    public static void AddBalance()
    {
        string balance = Read_message();
        if (SetUserBalance(balance))
        {
            Print_message("Баланс успешно пополнен, теперь ваш баланс составляет: " + CurrentUser.Balance);
        }
        else
        {
            Print_message("неверно введена сумма, ваш баланс составляет: " + CurrentUser.Balance);
        }
    }
}