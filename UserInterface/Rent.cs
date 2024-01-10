using static UserInterface.MenuFunctions;
using static BusinessLogic.ProgramFunctions;

namespace UserInterface
{
    public class Rent
    {

        public static void Check(string s)
        {
            if (!CheckCorrectTime(s))
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
            if (!DoYouHaveABalance())
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
            if (!CheckLimitTime())
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
    }
}
