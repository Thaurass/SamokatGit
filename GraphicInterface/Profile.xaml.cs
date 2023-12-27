using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static BusinessLogic.AccountFunctions;

namespace GraphicInterface
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();

            _userName.Content = "Здравствуйте " + CurrentUser.Name;
            _userAge.Content = "Ваш возраст " + CurrentUser.Age;
            _userBalance.Content = "Ваш баланс " + CurrentUser.Balance;
            _userPassword.Content = "Ваш пароль " + CurrentUser.Password;
            _profileDistance.Content = "Мы вместе проехали " + (int)CurrentUser.Distance;
            _profileTime.Content = "Время в пути вместе " + CurrentUser.Time;
            _profileTrip.Content = "Всего поездок " + CurrentUser.NumTrips;
        }

        private void FromProfileToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());

        }
    }
}
