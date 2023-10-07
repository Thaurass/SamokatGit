using static samokat.Program;

namespace samokat
{
    public class Whoosh
    {
        public struct Transport
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

            public string Number { get; }
            public double Charge { get; set; }
            private int Type { get; }
            public int Costs { get; }
            public double Speed { get; }
            public int Index { get; }


        }

        public static Transport cur = new();

        public static List<Transport> Scooters = new();

        internal static void GenerateTransport()
        {
            Random rnd = new();
            
            for (int i = 0; i < 10; i++)
            {
                Scooters.Add(new Transport(i, rnd.Next(1, 3),i,20000));
                Console.WriteLine(Scooters[i].Number);
            }
        }

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
            Console.WriteLine("Для вас есть следующие типы самокатов");
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
                    Console.WriteLine(" Номер " + Scooters[i].Number + " Заряд в км {0:F2}", (double)(Scooters[i].Charge / 1000));
                }
            }
        }
    }
}
