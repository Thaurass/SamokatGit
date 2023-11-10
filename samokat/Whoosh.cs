namespace samokat
{
    internal class Whoosh
    {
        internal static Scooter CurrentSamokat = new();

        internal static List<Scooter> Transport = new();

        internal static int GetTime()
        {
            return Convert.ToInt32(
                    (CurrentSamokat.Charge / (CurrentSamokat.Speed - 5) / 1000) * 60
                );
        }

        internal static bool ReadScooter(string s)
        {
            string Number = s.ToUpper();
            Scooter TempScooter = Transport.Find(Scooter => Scooter.Number == Number);
            CurrentSamokat = TempScooter;
            return Transport.Contains(TempScooter);
        }
        
    }
}
