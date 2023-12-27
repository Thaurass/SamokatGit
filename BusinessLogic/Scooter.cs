namespace BusinessLogic
{
    public class Scooter
    {
        public Scooter(int number, int type, int index, double charge)
        {
            _type = type;
            _index = index;
            _charge = charge;

            switch (Type)
            {
                case 1:
                    _number = $"{number}A";
                    _costs = 5;
                    _speed = 15;
                    break;
                case 2:
                    _number = $"{number}B";
                    _costs = 7;
                    _speed = 25;
                    break;
            }
        }

        public Scooter()
        {
        }

        private string _number;
        private double _charge;
        private int _type;
        private int _costs;
        private double _speed;
        private int _index;

        public string Number { get => _number; }
        public double Charge { get => _charge; }
        private int Type { get => _type; }
        public int Costs { get => _costs; }
        public double Speed { get => _speed; }
        public int Index { get => _index; }

        public void SetCharge(int current_charge) { _charge = current_charge; }

        public int GetTime()
        {
            return Convert.ToInt32(
                (_charge / (_speed - 5) / 1000) * 60
            );
        }
    }
}
