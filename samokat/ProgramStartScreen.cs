using static samokat.Account;
using static samokat.MenuFunctions;

namespace samokat
{
	public class ProgramStartScreen
	{

        protected internal static void StartScreen()
        {
            StartScreenMsg();

            bool stop = false;
            while (!stop)
            {
                switch (ReadAnswer())
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
                        ExitProgram();
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

