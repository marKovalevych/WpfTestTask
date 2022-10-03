using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTask
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public async void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = await MainWindowView.SetWindow();
            mainWindow.Show();
        }

        private void Application_Startup_1(object sender, StartupEventArgs e)
        {

        }
    }
}
