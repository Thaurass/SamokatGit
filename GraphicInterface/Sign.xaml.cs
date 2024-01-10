
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using static BusinessLogic.AccountFunctions;


namespace GraphicInterface
{
    /// <summary>
    /// Логика взаимодействия для Sign.xaml
    /// </summary>
    public partial class Sign : Page
    {
        public Sign()
        {
            InitializeComponent();
        }

     
        private void ToSign_Click(object sender, RoutedEventArgs e)
        {
            _errorMsg.Content = string.Empty;

            string login = _login.Text;
            string password = _password.Text;

            if (CheckLoginData(login, password))
            {
                NavigationService.Navigate(new Menu());
            }
            else
            {
                _errorMsg.Content = "Неверный логин или пороль";
            }
        }

        private void FromSignToMain_Click(object sender, RoutedEventArgs e)
        {
            _errorMsg.Content = string.Empty;
            NavigationService.Navigate(new Main());
        }
    }
}
