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

namespace LabWork17
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
            var fm = new Task1Window();
            fm.Show();
        }

        private void Task2Button_Click(object sender, RoutedEventArgs e)
        {
            var fm = new Task2Window();
            fm.Show();
        }

        private void Task3Button_Click(object sender, RoutedEventArgs e)
        {
            var fm = new Task3Window();
            fm.Show();
        }

        private void Task4Button_Click(object sender, RoutedEventArgs e)
        {
            var fm = new Task4Window();
            fm.Show();
        }

        private void Task5Button_Click(object sender, RoutedEventArgs e)
        {
            var fm = new Task5Window();
            fm.Show();
        }
    }
}
