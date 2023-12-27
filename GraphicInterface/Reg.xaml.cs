using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using static BusinessLogic.AccountFunctions;

namespace GraphicInterface
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void FromRegToMain_Click(object sender, RoutedEventArgs e)
        {
            _errorMsg.Content = string.Empty;
            NavigationService.Navigate(new Main());
        }

        private void ToRegistr_Click(object sender, RoutedEventArgs e)
        {
            _errorMsg.Content = string.Empty;
            string login = _login.Text;
            string password = _password.Text;
            string age = _age.Text;

            if (AddNewUser(login, password, age))
            {
                _errorMsg.Content = "Регистрация прошла успешно";
            }
            else { _errorMsg.Content = "Возраст должен быть введен в формате числа"; }
        }
    }
}
