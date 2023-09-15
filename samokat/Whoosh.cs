namespace samokat
{
    internal class Whoosh
    {
        struct Transport
        {
            public Transport(int number, int type)
            {
                Type = type;
                switch (Type)
                {
                    case 1:
                        Number = $"{number}A";
                        Costs = 5;
                        Charge = 30;
                        Speed = 15;
                        break;
                    case 2:
                        Number = $"{number}B";
                        Costs = 7;
                        Charge = 20;
                        Speed = 25;
                        break;
                }
            }

            public string Number { get; }
            public int Charge { get; set; }
            private int Type { get; }
            public int Costs { get; }
            public int Speed { get; }
            
        }
        
        private static readonly List<Transport> Scooters = new();

        internal static void GenerateTransport()
        {
            Random rnd = new();
            
            for (int i = 0; i < 10; i++)
            {
                Scooters.Add(new Transport(i, rnd.Next(1, 3)));
                Console.WriteLine(Scooters[i].Number);
            }
        }
    }
}
