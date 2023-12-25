using static UserInterface.ProgramStartScreen;
using static UserInterface.MenuFunctions;
using static FileWorker.FileProcessing;

namespace samokat
{
    public abstract class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Print_message("Аргумент не передан");
            }
            else
            {
                arg0 = args[0];
                StartScreen();
            }
        }
    }
}