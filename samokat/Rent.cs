using static samokat.Whoosh;
using static samokat.MenuFunctions;
using static samokat.Account;

namespace samokat
{
    internal class Rent
    {
        internal static double t;

        internal static void Check(string s)
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

        internal static void CheckBalance()
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

        internal static void CheckMaxTime()
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

        internal static void SetData()
        {
            CurrentUser.SetTime(CurrentUser.Time + t);
            CurrentUser.SetDistance(CurrentUser.Distance + (double)(t / 60) * (CurrentSamokat.Speed - 5) * 1000);
            CurrentSamokat.SetCharge((int)(CurrentSamokat.Charge - (int)((double)(t / 60) * (CurrentSamokat.Speed - 5) * 1000)));
            Transport[CurrentSamokat.Index] = CurrentSamokat;
            CurrentUser.SetBalance(CurrentUser.Balance - t * CurrentSamokat.Costs);
        }

        internal static double GetCurrentCost()
        {
            return t * CurrentSamokat.Costs;
        }
       
    }
}
