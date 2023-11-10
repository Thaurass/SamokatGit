using static samokat.Whoosh;
using static samokat.Program;
using static samokat.MenuFunctions;

namespace samokat
{
    internal class FileProcessing
    {
        internal static void Save()
        {
            StreamWriter f = new StreamWriter(arg0, false);
            int i = 0;
            while (i < 10)
            {
                string s0 = Transport[i].Number.Remove(1);
                string s1 = Transport[i].Number;
                if (s1[1] == 'A')
                    s1 = "1";
                else
                    s1 = "2";
                string s2 = ((double)(Transport[i].Charge / 1000)).ToString();
                f.WriteLine(s0 + " " + s1 + " " + s2);
                i++;
            }
            f.Close();
        }

        internal static void Load()
        {
            Print_message("Для вас есть следующие типы самокатов");
            StreamReader f = new StreamReader(arg0);
            int j = 0;
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                Transport.Add(new Scooter(Convert.ToInt32(s.Remove(1)),
                                           Convert.ToInt32(s.Substring(2, 2)), j,
                                           Convert.ToDouble(s.Substring(3)) * 1000));
                j++;
            }
            f.Close();
            for (int i = 0; i < 10; i++)
            {
                if ((double)(Transport[i].Charge / 1000) > 0)
                {
                    Print_message(" Номер " + Transport[i].Number + " Заряд в км {0:F2}", (double)(Transport[i].Charge / 1000));
                }
            }
        }
    }
}
