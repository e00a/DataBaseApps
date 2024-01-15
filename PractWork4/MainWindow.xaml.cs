using PractWork4.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PractWork4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Task1Button_Click(object sender, RoutedEventArgs e)
        {
            new Task1Window().ShowDialog();
        }

        private void Task2Button_Click(object sender, RoutedEventArgs e)
        {
            new Task2Window().ShowDialog();
        }

        private void Task3Button_Click(object sender, RoutedEventArgs e)
        {
            new Task3Window().ShowDialog();
        }

        private void Task4Button_Click(object sender, RoutedEventArgs e)
        {
            new Task4Window().ShowDialog();
        }

        private void Task7Button_Click(object sender, RoutedEventArgs e)
        {
           new Task7Window().ShowDialog();
        }
    }
}