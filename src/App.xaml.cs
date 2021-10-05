using System;
using System.Windows;

namespace RSA_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var lightTheme = new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/Resources/LightTheme.xaml", UriKind.RelativeOrAbsolute)
            };

            var darkTheme = new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/Resources/DarkTheme.xaml", UriKind.RelativeOrAbsolute)
            };

            if (RSA_WPF.Properties.Settings.Default.Theme == 0)
            {
                Current.Resources.MergedDictionaries.Clear();
                Current.Resources.MergedDictionaries.Add(lightTheme);
            }

            else if (RSA_WPF.Properties.Settings.Default.Theme == 1)
            {
                Current.Resources.MergedDictionaries.Clear();
                Current.Resources.MergedDictionaries.Add(darkTheme);
            }

            MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}
