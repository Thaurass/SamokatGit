using static UserInterface.Account;

namespace UserInterface
{
	public class ProgramStartScreen
	{

        public static void StartScreen()
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

