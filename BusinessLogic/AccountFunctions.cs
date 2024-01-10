namespace BusinessLogic
{
    public class AccountFunctions
    {
        public static User CurrentUser = new();

        private static string promo = "FREE";

        public static readonly List<User> Users = new();

        public static bool CheckLoginData(string _login, string _password)
        {
            bool areDataCorrect = false;

            User TempUser = Users.Find(user => user.Name == _login && user.Password == _password);

            if (Users.Contains(TempUser))
            {
                CurrentUser = TempUser;
                areDataCorrect = true;
            }

            return areDataCorrect;
        }

        public static bool AddNewUser(string _login, string _password, string _age) 
        { 
            bool userIsAded = false;

            if (Int32.TryParse(_age, out int age))
            {
                Users.Add(new User(_login, _password, age));
                userIsAded = true;
            }

            return userIsAded;
        }

        public static bool SetUserBalance(string _balance)
        {
            bool balanceWasSet = false;

            if (Double.TryParse(_balance, out double sum))
            {
                CurrentUser.SetBalance(CurrentUser.Balance + sum);
                balanceWasSet = true;
            }

            return balanceWasSet;
        }

        public static bool SetUserPromotionalCode(string _promo)
        {
            bool promoWasSet = false;

            if (_promo.Contains(promo) || _promo.ToUpper().Contains(promo))
            {
                CurrentUser.SetPromotionalCode(_promo);
                promoWasSet = true;
            }

            return promoWasSet;
        }

        public static void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}
