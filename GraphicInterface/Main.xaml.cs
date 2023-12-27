using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using static FileWorker.FileProcessing;

namespace GraphicInterface
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            arg0 = "SAMOKAT.txt";
        }

        private void ToSign_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Sign());
        }

        private void ToReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Reg());
        }
    }
}
