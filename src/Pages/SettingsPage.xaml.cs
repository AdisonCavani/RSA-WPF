using RSA_WPF.Pages.Settings;
using System.Windows.Controls;
using System.Windows.Input;

namespace RSA_WPF
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void GeneralButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (SettingFrame.Content.ToString() != "RSA_WPF.Pages.Settings.GeneralSubPage")
                SettingFrame.Content = new GeneralSubPage();
        }

        private void AboutButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (SettingFrame.Content.ToString() != "RSA_WPF.Pages.Settings.AboutSubPage")
                SettingFrame.Content = new AboutSubPage();
        }

        private void HelpButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (SettingFrame.Content.ToString() != "RSA_WPF.Pages.Settings.HelpSubPage")
                SettingFrame.Content = new HelpSubPage();
        }
    }
}
