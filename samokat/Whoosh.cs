namespace samokat
{
    public class Whoosh
    {
        public struct Transport
        {
            public Transport(int number, int type, int index)
            {
                Type = type;
                Index = index;

                switch (Type)
                {
                    case 1:
                        Number = $"{number}A";
                        Costs = 5;
                        Charge = 30000;
                        Speed = 15;
                        break;
                    case 2:
                        Number = $"{number}B";
                        Costs = 7;
                        Charge = 20000;
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
                Scooters.Add(new Transport(i, rnd.Next(1, 3),i));
                Console.WriteLine(Scooters[i].Number);
            }
        }
    }
}
