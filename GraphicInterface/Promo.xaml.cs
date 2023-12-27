using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using static BusinessLogic.AccountFunctions;

namespace GraphicInterface
{
    /// <summary>
    /// Логика взаимодействия для Promo.xaml
    /// </summary>
    public partial class Promo : Page
    {
        public Promo()
        {
            InitializeComponent();
        }

        private void FromPromoToMenu_Click(object sender, RoutedEventArgs e)
        {
            _errorMsg.Content = string.Empty;
            NavigationService.Navigate(new Menu());
        }

        private void Set_Promo_Click(object sender, RoutedEventArgs e)
        {
            _errorMsg.Content = string.Empty;

            if (SetUserPromotionalCode(_promo.Text))
            {
                _errorMsg.Content = "Промокод успешно активирован";
            }
            else
            {
                _errorMsg.Content = "Неверный промокод";
            }

        }
    }
}
