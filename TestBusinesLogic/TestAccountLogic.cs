using static BusinessLogic.AccountFunctions;

namespace TestBusinesLogic
{
    internal class TestAccountLogic
    {
        [Test]
        public void TestAddUser()
        {
            var userIsAdd = AddNewUser("1", "1", "1");
            Assert.That(userIsAdd);
        }
        [Test]
        public void TestLoginUser()
        {
            Users.Add(new BusinessLogic.User("1", "1", 1));
            var checkUser = CheckLoginData("1", "1");
            Assert.That(checkUser);
        }
        [Test]
        public void TestSetBalance() 
        {
            AddNewUser("1", "1", "1");
            CurrentUser = Users[0];
            CurrentUser.SetBalance(1000);
            bool balanceIsSet = SetUserBalance("1000");
            Assert.That(balanceIsSet && CurrentUser.Balance == 2000);
        }
        [Test]
        public void TestSetPromo()
        {
            AddNewUser("1", "1", "1");
            CurrentUser = Users[0];
            bool promoIsActivated = SetUserPromotionalCode("free");
            Assert.That(promoIsActivated);
        }
    }
}
