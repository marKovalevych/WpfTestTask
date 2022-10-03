using ModelCryptoCurrency;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        async public static Task<MainWindowView> SetWindow()
        {
            var repo = await CCRepo.SetRepo();

            return new MainWindowView(repo);
        }
        private MainWindowView(CCRepo repo)
        {
            InitializeComponent();
            var set = new ModelDataSet(repo.GetData());
            foreach (var item in set.DataSet)
            {
                DataView.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var cell = DataView.SelectedCells.First();
            if (cell.Column.Header.Equals("Markets"))
            {
                ModelCrypto content = (ModelCrypto)cell.Item;
                System.Diagnostics.Process.Start("explorer.exe", content.Market);
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var findCurrencyWin = await FindCurrencyWindow.SetFindCurrencyWindow();
            findCurrencyWin.ShowDialog();
        }

        private async void Convert_Click(object sender, RoutedEventArgs e)
        {
            var convertWin = await ConvertWindow.SetConvertWindow();
            convertWin.ShowDialog();
            
        }
    }
}
