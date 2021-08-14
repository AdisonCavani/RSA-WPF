using System;
using System.Windows;

namespace Theme
{
    public class GetTheme
    {
        public static void SwitchTheme()
        {
            var resourceDictionary = new ResourceDictionary();

            var lightThemeUri = new Uri("pack://application:,,,/Resources/LightTheme.xaml", UriKind.RelativeOrAbsolute);
            var lightTheme = new ResourceDictionary()
            {
                Source = lightThemeUri
            };

            var darkThemeUri = new Uri("pack://application:,,,/Resources/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
            var darkTheme = new ResourceDictionary()
            {
                Source = darkThemeUri
            };

            if (RSA_WPF.Properties.Settings.Default.Theme == 0)
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(lightTheme);
            }

            else if (RSA_WPF.Properties.Settings.Default.Theme == 1)
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(darkTheme);
            }
        }
    }
}
