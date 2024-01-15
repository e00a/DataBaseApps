using PractWork4.Data;
using PractWork4.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;


namespace PractWork4.Windows
{
    /// <summary>
    /// Логика взаимодействия для Task4Window.xaml
    /// </summary>
    public partial class Task4Window : Window
    {
        public List<Game> Games { get; set; }

        public Task4Window()
        {
            DataContext = this;

            try
            {
                using (var context = new MarketContext())
                {
                    Games = context.Games.Include(x => x.Category).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            InitializeComponent();
        }
    }
}
