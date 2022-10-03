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
    /// Interaction logic for FindCurrencyWindow.xaml
    /// </summary>
    public partial class FindCurrencyWindow : Window
    {
        private readonly CCRepo _repo;
        async public static Task<FindCurrencyWindow> SetFindCurrencyWindow()
        {
            var repo = await CCRepo.SetRepo();

            return new FindCurrencyWindow(repo);
        }
        public FindCurrencyWindow(CCRepo repo)
        {
            InitializeComponent();
            _repo = repo;
            GoMarket.IsEnabled = false;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            NameLabel.Content = "Name  ";
            Code.Content = "Code  ";
            Price.Content = "Price  ";
            Change.Content = "Change 24h  ";
            MarketView.Content = "";
            string code = textBox.Text;
            var cryptoCurrency = await _repo.GetByCode(code);
            if (cryptoCurrency is null)
            {
                MessageBox.Show("Could not find a cryptocurrency");
                return;
            }
            NameLabel.Content += cryptoCurrency.Name;
            Code.Content += cryptoCurrency.Code;
            Price.Content += cryptoCurrency.Price.ToString();
            Change.Content += cryptoCurrency.PriceChange.ToString();
            MarketView.Content += cryptoCurrency.Market;
            GoMarket.IsEnabled = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GoMarket_Click(object sender, RoutedEventArgs e)
        {
            var link = MarketView.Content.ToString();
            System.Diagnostics.Process.Start("explorer.exe", link);
        }
    }
}
