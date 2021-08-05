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
            SettingFrame.Content = new GeneralSubPage();
        }

        private void AboutButton_Click(object sender, MouseButtonEventArgs e)
        {
            SettingFrame.Content = new AboutSubPage();
        }

        private void HelpButton_Click(object sender, MouseButtonEventArgs e)
        {
            SettingFrame.Content = new HelpSubPage();
        }
    }
}
