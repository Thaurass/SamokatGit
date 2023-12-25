using static BusinessLogic.Whoosh;
using static UserInterface.MenuFunctions;
using static UserInterface.Account;

namespace UserInterface
{
    public class Rent
    {
        public static double t;

        public static void Check(string s)
        {
            if (!(Double.TryParse(s, out t)))
            {
                Print_message("Время аренды должно быть в формате числа");
                Print_message("");
                RentScooter();
                CheckBalance();
            } 
            else
            {
                //t = tm;
                CheckBalance();
            }
        }

        public static void CheckBalance()
        {
            if (t* CurrentSamokat.Costs > CurrentUser.Balance )
            {
                Print_message("У вас недостаточно средств пополните баланс");
                Print_message("");
                RentScooter();
            }
            else
            {
                CheckMaxTime();
            }
        }

        public static void CheckMaxTime()
        {
            if (t > GetTime())
            {
                Print_message("Данное время поездки не доступно, введите " +
                              "актуальное или возьмите другой самокат");
                Print_message("");
                RentScooter();
            }
            else
            {
                SetData();
            }
        }

        public static void SetData()
        {
            CurrentUser.SetTime(CurrentUser.Time + t);
            CurrentUser.SetDistance(CurrentUser.Distance + (double)(t / 60) * (CurrentSamokat.Speed - 5) * 1000);
            CurrentSamokat.SetCharge((int)(CurrentSamokat.Charge - (int)((double)(t / 60) * (CurrentSamokat.Speed - 5) * 1000)));
            Transport[CurrentSamokat.Index] = CurrentSamokat;
            CurrentUser.SetBalance(CurrentUser.Balance - t * CurrentSamokat.Costs);
        }

        public static double GetCurrentCost()
        {
            return t * CurrentSamokat.Costs;
        }
       
    }
}
