using static samokat.Program;
using static samokat.MenuFunctions;

namespace samokat
{
    internal class Whoosh
    {
        internal struct Transport
        {
            public Transport(int number, int type, int index, double charge)
            {
                Type = type;
                Index = index;
                Charge = charge;

                switch (Type)
                {
                    case 1:
                        Number = $"{number}A";
                        Costs = 5;
                        Speed = 15;
                        break;
                    case 2:
                        Number = $"{number}B";
                        Costs = 7;
                        Speed = 25;
                        break;
                }
            }

            internal string Number { get; }
            internal double Charge { get; set; }
            private int Type { get; }
            internal int Costs { get; }
            internal double Speed { get; }
            internal int Index { get; }


        }

        internal static Transport CurrentSamokat = new();

        internal static List<Transport> Scooters = new();

        internal static void Save()
        {
            StreamWriter f = new StreamWriter(arg0, false);
            int i = 0;
            while (i < 10)
            {
                string s0 = Scooters[i].Number.Remove(1);
                string s1 = Scooters[i].Number;
                if (s1[1] == 'A')
                    s1 = "1";
                else
                    s1 = "2";
                string s2 = ((double)(Scooters[i].Charge / 1000)).ToString();
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
                Scooters.Add(new Transport(Convert.ToInt32(s.Remove(1)),
                                           Convert.ToInt32(s.Substring(2, 2)), j,
                                           Convert.ToDouble(s.Substring(3)) * 1000));
                j++;
            }
            f.Close();
            for (int i = 0; i < 10; i++)
            {
                if ((double)(Scooters[i].Charge / 1000) > 0)
                {
                    Print_message(" Номер " + Scooters[i].Number + " Заряд в км {0:F2}", (double)(Scooters[i].Charge / 1000));
                }
            }
        }

        internal static int GetTime()
        {
            return Convert.ToInt32((CurrentSamokat.Charge / (CurrentSamokat.Speed - 5) / 1000) * 60);
        }
        internal static bool ReadScooter(string s)
        {
            string Number = s.ToUpper();
            Transport TempScooter = Scooters.Find(Transport => Transport.Number == Number);
            CurrentSamokat = TempScooter;
            return Scooters.Contains(TempScooter);
        }
        
    }
}
