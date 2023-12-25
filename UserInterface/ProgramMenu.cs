using static FileWorker.FileProcessing;
using static UserInterface.MenuFunctions;
using static UserInterface.Account;
using static UserInterface.ProgramStartScreen;

namespace UserInterface
{
	public class ProgramMenu
    {
        public static void Menu()
        {
            StartMenuMsg();

            bool stop = false;
            while (!stop)
            {
                switch (ReadAnswer())
                {
                    case "1":
                        RentScooter();
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
                        ErrorMessage();
                        break;
                }
            }

        }
    }
}

