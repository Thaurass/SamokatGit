using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using static BusinessLogic.ProgramFunctions;
using static BusinessLogic.Whoosh;
using static FileWorker.FileProcessing;

namespace GraphicInterface
{
    /// <summary>
    /// Логика взаимодействия для Rent.xaml
    /// </summary>
    public partial class Rent : Page
    {
        string[] Messages;

        public Rent()
        {
            InitializeComponent();
            Messages = Load();
            _chooseSamokat.ItemsSource = Messages;
        }

        private void FromRentToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
            _errorMsg.Content = string.Empty;
            Save();
        }

        private void Rent_Samokat(object sender, RoutedEventArgs e)
        {
            _errorMsg.Content = string.Empty;

            if (_chooseSamokat.SelectedIndex != -1)
            {
                if (CheckCorrectTime(_rentalTime.Text))
                {
                    CurrentSamokat = Transport[_chooseSamokat.SelectedIndex];

                    if (DoYouHaveABalance())
                    {
                        if (CheckLimitTime())
                        {
                            SetData();
                            _errorMsg.Content = "Цена вашей поездки составит " + 
                                GetCurrentCost() + "\nХорошей поездки!";
                        }
                        else
                        {
                            _errorMsg.Content = "Данное время поездки не доступно, введите " +
                                                    "актуальное или возьмите другой самокат";
                        }
                    }
                    else
                    {
                        _errorMsg.Content = "У вас недостаточно средств пополните баланс!";
                    }
                }
                else
                {
                    _errorMsg.Content = "Время аренды должно быть в формате числа!";
                }
            }
            else
            {
                _errorMsg.Content = "Сначала нужно выбрать самокат!";
            }
            
            
        }

        private void Change_Rent_Time(object sender, SelectionChangedEventArgs e)
        {
            _labelTime.Content = "Введите желаемое время аренды (максимум " + 
                                    Transport[_chooseSamokat.SelectedIndex].GetTime() + " минут)";
        }
    }

}
