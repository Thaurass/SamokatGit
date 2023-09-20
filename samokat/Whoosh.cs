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
    }
}
