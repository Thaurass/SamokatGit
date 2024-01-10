using static BusinessLogic.AccountFunctions;
using static FileWorker.FileProcessing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GraphicInterface
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }


        private void FromMenuToProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile());

        }

        private void FromMenuToMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Main());
        }

        private void FromMenuToPromo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Promo());

        }

        private void FromMenuToBalance_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Balance());

        }

        private void FromMenuToRent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Rent());

        }
    }
}
