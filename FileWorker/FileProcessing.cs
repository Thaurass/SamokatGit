using BusinessLogic;


namespace FileWorker
{
    using static BusinessLogic.Whoosh;
    public class FileProcessing
    {
        public static string arg0 = "";
        public static void Save()
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

        public static string[] Load()
        {
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

            string[] Messages = new string[10];
            for (int i = 0; i < 10; i++)
            {
                if ((double)(Transport[i].Charge / 1000) > 0)
                {
                    Messages[i] = " Номер " + Transport[i].Number + " Заряд в км " + (double)(Transport[i].Charge / 1000);
                }
            }
            return Messages;
        }
    }
}
