namespace BusinessLogic
{
    public class User
    {
        public User(string name, string password, int age)
        {
            _name = name;
            _password = password;
            _age = age;
            _balance = 100000;
            _distance = 0;
            _time = 0;
            _numTrips = 0;
            _promotionalCode = "";
        }

        public User()
        {
        }

        private string _name;
        private string _password;
        private int _age;
        private double _balance;
        private double _distance;
        private double _time;
        private int _numTrips;
        private string _promotionalCode;

        public string Name { get => _name; }
        public string Password { get => _password; }
        public int Age { get => _age; }
        public double Balance { get => _balance; }
        public double Distance { get => _distance; }
        public double Time { get => _time; }
        public int NumTrips { get => _numTrips; }
        public string PromotionalCode { get => _promotionalCode; }

        public void SetBalance(double balance){ _balance = balance; }
        public void SetDistance(double distance) { _distance = distance; }
        public void SetTime (double time) { _time = time; }
        public void AddNumTrips (int numTrips) { _numTrips += numTrips; }
        public void SetPromotionalCode (string promotionalCode) { _promotionalCode = promotionalCode; }
    }
}
