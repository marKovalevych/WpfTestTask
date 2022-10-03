using Repository;
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
using System.Windows.Shapes;

namespace WpfTask
{
    /// <summary>
    /// Interaction logic for ConvertWindow.xaml
    /// </summary>
    public partial class ConvertWindow : Window
    {
        private readonly CCRepo _repo;
        async public static Task<ConvertWindow> SetConvertWindow()
        {
            var repo = await CCRepo.SetRepo();

            return new ConvertWindow(repo);
        }
        private ConvertWindow(CCRepo repo)
        {
            InitializeComponent();
            _repo = repo;
        }

        private async void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            NameFrom.Clear();
            AmountFrom.Clear();
            NameTo.Clear();
            AmountTo.Clear();
            var from = FromTB.Text;
            var to = ToTB.Text;
            var result = await _repo.ConvertCurrency(from, to);
            if(result.Item1 == 0)
            {
                MessageBox.Show("Wrong cryptocurrency code");
                return;
            }
            NameFrom.Text += result.Item3.Name;
            AmountFrom.Text += "1";
            NameTo.Text += result.Item2.Name;
            AmountTo.Text += Math.Round(result.Item1, 7).ToString();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
