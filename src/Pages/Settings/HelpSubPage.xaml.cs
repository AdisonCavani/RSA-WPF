using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace RSA_WPF.Pages.Settings
{
    /// <summary>
    /// Interaction logic for HelpSubPage.xaml
    /// </summary>
    public partial class HelpSubPage : Page
    {
        public HelpSubPage()
        {
            InitializeComponent();
        }

        private void Release_Click(object sender, RoutedEventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://github.com/AdisonCavani/RSA-WPF/releases";
            myProcess.Start();
        }

        private void Repo_Click(object sender, RoutedEventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://github.com/AdisonCavani/RSA-WPF";
            myProcess.Start();
        }

        private void Bug_Click(object sender, RoutedEventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://github.com/AdisonCavani/RSA-WPF/issues";
            myProcess.Start();
        }

        private void PR_Click(object sender, RoutedEventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://github.com/AdisonCavani/RSA-WPF/pulls";
            myProcess.Start();
        }
    }
}
