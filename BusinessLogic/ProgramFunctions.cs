using static BusinessLogic.AccountFunctions;
using static BusinessLogic.Whoosh;

namespace BusinessLogic
{
    public class ProgramFunctions
    {
        static double rentalTime;

        public static bool CheckCorrectTime(string s)
        {
            bool timeIsCorrect = false;

            if (Double.TryParse(s, out rentalTime))
            {
                timeIsCorrect = true;
            }

            return timeIsCorrect;
        }

        public static bool DoYouHaveABalance()
        {
            bool balanceIsCorrect = false;

            if (rentalTime * CurrentSamokat.Costs <= CurrentUser.Balance)
            {
                balanceIsCorrect = true;
            }

            return balanceIsCorrect;
        }

        public static bool CheckLimitTime()
        {
            bool isTimeInLimit = false;

            if (rentalTime < GetTime())
            {
                isTimeInLimit = true;
            }

            return isTimeInLimit;
        }
        public static void SetData()
        {
            CurrentUser.SetTime(CurrentUser.Time + rentalTime);
            CurrentUser.SetDistance(CurrentUser.Distance + (double)(rentalTime / 60) * (CurrentSamokat.Speed - 5) * 1000);
            CurrentSamokat.SetCharge((int)(CurrentSamokat.Charge - (int)((double)(rentalTime / 60) * (CurrentSamokat.Speed - 5) * 1000)));
            Transport[CurrentSamokat.Index] = CurrentSamokat;
            CurrentUser.SetBalance(CurrentUser.Balance - rentalTime * CurrentSamokat.Costs);
        }

        public static double GetCurrentCost()
        {
            return rentalTime * CurrentSamokat.Costs;
        }
    }
}
