using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabWork16
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
            Task1Window fm = new Task1Window();
            fm.Show();
        }

        private void Task2Button_Click(object sender, RoutedEventArgs e)
        {
            Task2Window fm = new Task2Window();
            fm.Show();
        }

        private void Task3Button_Click(object sender, RoutedEventArgs e)
        {
            Task3Window fm = new Task3Window();
            fm.Show();
        }

        private void Task4Button_Click(object sender, RoutedEventArgs e)
        {
            Task4Window fm = new Task4Window();
            fm.Show();
        }

        private void Task5Button_Click(object sender, RoutedEventArgs e)
        {
            Task5Window fm = new Task5Window();
            fm.Show();
        }

        private void Task6Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
