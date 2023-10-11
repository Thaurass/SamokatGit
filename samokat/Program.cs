using static samokat.ProgramStartScreen;

namespace samokat
{
    internal abstract class Program
    {
        internal static string arg0 = "";

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Аргумент не передан");
            }
            else
            {
                arg0 = args[0];
                StartScreen();
            }
        }
    }
}