using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Update;

namespace RSA_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if ((DateTime.Today - Properties.Settings.Default.LastUpdateCheck).TotalDays >= Properties.Settings.Default.CheckUpdateEvery)
            {
                LookForUpdate();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            this.Close();
        }


        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void EncryptButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (Main.Content.ToString() != "RSA_WPF.EncryptPage")
                Main.Content = new EncryptPage();
        }

        private void DecryptButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (Main.Content.ToString() != "RSA_WPF.DecryptPage")
                Main.Content = new DecryptPage();
        }

        private void GenerateButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (Main.Content.ToString() != "RSA_WPF.GeneratePage")
                Main.Content = new GeneratePage();
        }

        private void SettingsButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (Main.Content.ToString() != "RSA_WPF.SettingsPage")
                Main.Content = new SettingsPage();
        }

        private async void LookForUpdate()
        {
            int comparasion = await Task.Run(() => CheckForUpdate.CheckGitHubNewerVersion());
            string latestRelease = await Task.Run(() => CheckForUpdate.GetLatestRelease());

            var dateTime = DateTime.Today;

            if (comparasion < 0)
            {
                // Need update
                Properties.Settings.Default.Update = 1;
                Properties.Settings.Default.LatestRelease = latestRelease;
                Properties.Settings.Default.LastUpdateCheck = dateTime;
                Properties.Settings.Default.Save();
            }
            else if (comparasion > 0)
            {
                // Version ahead
                Properties.Settings.Default.Update = 2;
                Properties.Settings.Default.LatestRelease = latestRelease;
                Properties.Settings.Default.LastUpdateCheck = dateTime;
                Properties.Settings.Default.Save();
            }
            else if (comparasion == 0)
            {
                // Up to date
                Properties.Settings.Default.Update = 0;
                Properties.Settings.Default.LatestRelease = latestRelease;
                Properties.Settings.Default.LastUpdateCheck = dateTime;
                Properties.Settings.Default.Save();
            }
        }
    }
}
