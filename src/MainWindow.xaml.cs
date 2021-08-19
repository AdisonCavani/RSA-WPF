using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Theme;
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
            this.DataContext = this;
            GetTheme.SwitchTheme();
            LookForUpdate();
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
                this.DragMove();
            }
        }

        private void EncryptButton_Click(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new EncryptPage();
        }

        private void DecryptButton_Click(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new DecryptPage();
        }

        private void GenerateButton_Click(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new GeneratePage();
        }

        private void SettingsButton_Click(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new SettingsPage();
        }

        private async void LookForUpdate()
        {
            int comparasion = await Task.Run(() => CheckForUpdate.CheckGitHubNewerVersion());

            if (comparasion < 0 && Properties.Settings.Default.Update != 1)
            {
                // Need update
                MessageBox.Show("Need update");
                Properties.Settings.Default.Update = 1;
                Properties.Settings.Default.Save();
            }
            else if (comparasion > 0 && Properties.Settings.Default.Update != 2)
            {
                // Version ahead
                MessageBox.Show("Need downgrade");
                Properties.Settings.Default.Update = 2;
                Properties.Settings.Default.Save();
            }
            else if (comparasion == 0 && Properties.Settings.Default.Update != 0)
            {
                // Up to date
                Properties.Settings.Default.Update = 0;
                Properties.Settings.Default.Save();
            }
        }
    }
}
