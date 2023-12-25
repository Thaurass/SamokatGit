namespace BusinessLogic
{
    public class Whoosh
    {
        public static Scooter CurrentSamokat = new();

        public static List<Scooter> Transport = new();

        public static int GetTime()
        {
            return Convert.ToInt32(
                    (CurrentSamokat.Charge / (CurrentSamokat.Speed - 5) / 1000) * 60
                );
        }

        public static bool ReadScooter(string s)
        {
            string Number = s.ToUpper();
            Scooter TempScooter = Transport.Find(Scooter => Scooter.Number == Number);
            CurrentSamokat = TempScooter;
            return Transport.Contains(TempScooter);
        }
        
    }
}
