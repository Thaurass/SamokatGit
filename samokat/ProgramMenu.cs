using static samokat.Whoosh;
using static samokat.MenuFunctions;
using static samokat.Account;
using static samokat.ProgramStartScreen;

namespace samokat
{
	internal class ProgramMenu
    {
        internal static void Menu()
        {
            StartMenuMsg();

            bool stop = false;
            while (!stop)
            {
                switch (ReadAnswer())
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
                        ErrorMessage();
                        break;
                }
            }

        }
    }
}

