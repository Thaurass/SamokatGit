using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using static BusinessLogic.AccountFunctions;

namespace GraphicInterface
{
    /// <summary>
    /// Логика взаимодействия для Balance.xaml
    /// </summary>
    public partial class Balance : Page
    {
        public Balance()
        {
            InitializeComponent();
        }

        private void FromBalanceToMenu_Click(object sender, RoutedEventArgs e)
        {
            _errorMsg.Content = string.Empty;
            NavigationService.Navigate(new Menu());
        }

        private void _addBalance_Click(object sender, RoutedEventArgs e)
        {
            _errorMsg.Content = string.Empty;

            if (SetUserBalance(_balance.Text))
            {
                _errorMsg.Content = "Баланс успешно пополнен, теперь ваш баланс составляет: " + CurrentUser.Balance;
            }
            else
            {
                _errorMsg.Content = "неверно введена сумма, ваш баланс составляет: " + CurrentUser.Balance;
            }

        }
    }
}
