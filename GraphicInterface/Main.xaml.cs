using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media;

using static FileWorker.FileProcessing;

namespace GraphicInterface
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        private MediaPlayer _mpBgr;

        public Main()
        {
            InitializeComponent();
            arg0 = "SAMOKAT.txt";
            _mpBgr = new MediaPlayer();
            _mpBgr.Open(new Uri(@"./Source/muz.mp3", UriKind.Relative));
            _mpBgr.Play();
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
